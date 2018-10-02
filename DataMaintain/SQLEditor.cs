using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Campus.Configuration;

namespace DataMaintain
{
    public partial class SQLEditor : FISCA.Presentation.BlankPanel
    {
        #region Singleton Property
        private static SQLEditor _window = null;

        public static SQLEditor Window
        {
            get
            {
                if (_window == null)
                {
                    _window = new SQLEditor();
                    _window.LoadWindowSettings();
                    LoadSQLLanguageDefinition();
                }
                return _window;
            }
        }
        #endregion

        #region Settings Function
        private void SaveWindowSettings()
        {
            Properties.Settings.Default.Save();
        }

        private void LoadWindowSettings()
        {
            Window.editor.Size = (Size)Properties.Settings.Default["Size"];
            LoadAppAllSettings();
        }

        private void SaveCurrentSqlToSettings()
        {
            if (Config.User != null)
            {
                ConfigData cd = Config.User["DataMaintain"];
                cd["SQLCommand"] = EncodeUDTTableName(editor.Text);
                cd.Save();
            }
        }

        private void LoadAppAllSettings()
        {
            if (Config.User != null)
            {
                ConfigData cd = Config.User["DataMaintain"];
                editor.Text = DecodeUDTTableName(cd["SQLCommand"]);
            }
        }

        private static void LoadSQLLanguageDefinition()
        {
            Stream sqllang = Assembly.GetExecutingAssembly().GetManifestResourceStream("DataMaintain.ActiproSoftware.SQL.xml");
            _window.editor.Document.LoadLanguageFromXml(sqllang, 0);
            sqllang.Close();
        }
        #endregion

        private ColumnWidthManager ColumnWidths;

        public SQLEditor()
        {
            InitializeComponent();

            Group = "SQL";
            msgView.Dock = DockStyle.Fill;
            dataView.Dock = DockStyle.Fill;

            ColumnWidths = new ColumnWidthManager(dataView);
        }

        public void InsertTextAtCursor(string text)
        {
            editor.SelectedView.SelectedText = text;
        }

        public void ExecuteSQL()
        {
            try
            {
                ShowMessageInStatusBar(string.Empty);

                string cmd = GetEditorText();

                //if (IsUpdateCommand(cmd))
                //    ExecuteUpdate(cmd);
                //else
                //    ExecuteSelect(cmd);
                ExecuteSelect(cmd);

                SaveCurrentSqlToSettings();
            }
            catch (Exception ex)
            {
                ErrorForm.Show(ex.Message, ex);
            }
        }

        private void ExecuteSelect(string cmd)
        {
            DisplayDataView();
            Stopwatch sw = Stopwatch.StartNew();
            DataTable table = new DataTable();
            try
            {
                table = Program.Query(cmd);
            }
            catch (FISCA.DSAClient.DSAServerException ex)
            {
                var msg = ex.Message;
                try
                {
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.LoadXml(ex.Response);
                    System.Xml.XmlElement ele = doc.SelectSingleNode("Envelope/Header/DSFault/Fault/Detail") as System.Xml.XmlElement;
                    if (ele != null)
                    {
                        msg += "\n" + ele.InnerText;
                        if (msg.Length > 400)
                            msg = msg.Substring(0, 400) + "...";
                    }
                }
                catch { }
                if (msg.IndexOf("No results were returned by the query.") > 0 || msg.IndexOf("查詢沒有傳回任何結果。") > 0)
                {
                    ShowMessageInWindow("No results were returned by the query.");
                }
                else
                {
                    ErrorForm.Show(msg, ex);
                }
            }
            DisplayDataTable(table);
            ShowMessageInStatusBar(string.Format("花費毫秒：{0}", sw.ElapsedMilliseconds));
        }

        private void ExecuteUpdate(string cmd)
        {
            DisplayMessageView();
            Stopwatch sw = Stopwatch.StartNew();
            Program.Update(SplitToCommandList(cmd));
            ShowMessageInStatusBar(string.Format("花費毫秒：{0}", sw.ElapsedMilliseconds));
            ShowMessageInWindow(string.Format("花費毫秒：{0}", sw.ElapsedMilliseconds));
        }

        private static List<string> SplitToCommandList(string cmd)
        {
            List<string> cmds = new List<string>();

            using (StringReader cmdReader = new StringReader(cmd))
            {
                while (cmdReader.Peek() > 0)
                {
                    string line = cmdReader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    cmds.Add(line);
                }
            }
            return cmds;
        }

        private void DisplayDataTable(DataTable table)
        {
            ColumnWidths.SaveColumnsWidth();
            dataView.DataSource = table;
            ColumnWidths.RestoreColumnsWidth();
        }

        private bool IsUpdateCommand(string command)
        {
            return !command.StartsWith("select", StringComparison.OrdinalIgnoreCase);
        }

        private string GetEditorText()
        {
            if (HaveSelectionText())
                return editor.SelectedView.SelectedText.Trim();
            else
                return editor.Text.Trim();
        }

        private bool HaveSelectionText()
        {
            return editor.SelectedView.Selection.Length > 0;
        }

        private void ShowMessageInWindow(string msg)
        {
            DisplayMessageView();
            msgView.Text = msg;
        }

        private void ShowMessageInStatusBar(string msg)
        {
            Program.SetMessage(msg);
        }

        private void DisplayDataView()
        {
            ColumnWidths.SaveColumnsWidth();
            dataView.DataSource = null;
            dataView.Visible = true;
            msgView.Visible = false;
        }

        private void DisplayMessageView()
        {
            msgView.Text = string.Empty;
            dataView.Visible = false;
            msgView.Visible = true;
        }

        private void editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                ExecuteSQL();
        }

        private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SaveWindowSettings();
        }

        private string EncodeUDTTableName(string text)
        {
            Regex pattern = new Regex(@"\$([\w]+)");
            return pattern.Replace(text, @"$${$1}");
        }

        private string DecodeUDTTableName(string text)
        {
            Regex pattern = new Regex(@"\$\{([\w]+)\}");
            return pattern.Replace(text, @"$$$1");
        }

        class ColumnWidthManager
        {
            private Dictionary<string, int> _column_widths = new Dictionary<string, int>();

            private DataGridView Grid { get; set; }

            public ColumnWidthManager(DataGridView grid)
            {
                this.Grid = grid;
            }

            public void SaveColumnsWidth()
            {
                foreach (DataGridViewColumn column in this.Grid.Columns)
                    AddColumnWidth(column.HeaderText, column.Width);
            }

            public void RestoreColumnsWidth()
            {
                foreach (DataGridViewColumn column in this.Grid.Columns)
                    column.Width = GetColumnWidth(column.HeaderText, column.Width);
            }

            private void AddColumnWidth(string name, int width)
            {
                if (_column_widths.ContainsKey(name))
                    _column_widths[name] = width;
                else
                    _column_widths.Add(name, width);
            }

            private int GetColumnWidth(string name, int defaultValue)
            {
                if (_column_widths.ContainsKey(name))
                    return _column_widths[name];
                else
                    return defaultValue;
            }
        }

        private void ContentPanePanel_SizeChanged(object sender, EventArgs e)
        {
            if (editor.Height > ContentPanePanel.Height - 50)
            {
                editor.Height = ContentPanePanel.Height - 50;
                ContentPanePanel.Refresh();
            }
        }
    }
}
