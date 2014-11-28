using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FISCA.Presentation.Controls;

namespace DataMaintain
{
    public partial class UDTTables : BaseForm
    {
        private DataTable _tables = null;

        public UDTTables()
        {
            InitializeComponent();
        }

        private void UDTTables_Load(object sender, EventArgs e)
        {
            try
            {
                string cmd = "select name from _udt_table order by name";
                _tables = Program.Query(cmd);
                SetGridViewDataSource(_tables);
            }
            catch (Exception ex)
            {
                ErrorForm.Show(ex.Message, ex);
            }
        }

        private void SetGridViewDataSource(DataTable data)
        {
            if (data == null)
            {
                tables.DataSource = null;
                return;
            }

            tables.DataSource = data;
            tables.RowHeadersVisible = false;
            tables.ColumnHeadersVisible = false;
            tables.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void txtPattern_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPattern.Text))
            {
                SetGridViewDataSource(_tables);
                return;
            }

            SetGridViewDataSource(null);

            DataTable cloneTable = _tables.Copy();
            List<DataRow> removeList = new List<DataRow>();
            foreach (DataRow row in cloneTable.Rows)
            {
                string tableName = row[0] + "";

                if (tableName.IndexOf(txtPattern.Text) < 0)
                    removeList.Add(row);
            }

            foreach (DataRow row in removeList)
                row.Delete();

            SetGridViewDataSource(cloneTable);
        }

        private void tables_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tables.Rows[e.RowIndex];
                SQLEditor.Window.InsertTextAtCursor("$" + row.Cells[0].Value + "");
                Close();
            }
        }
    }
}
