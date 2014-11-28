namespace DataMaintain
{
    partial class SQLEditor
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            ActiproSoftware.SyntaxEditor.Document document1 = new ActiproSoftware.SyntaxEditor.Document();
            ActiproSoftware.SyntaxEditor.Document document2 = new ActiproSoftware.SyntaxEditor.Document();
            this.dataView = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.splitter = new DevComponents.DotNetBar.ExpandableSplitter();
            this.msgView = new DataMaintain.ChineseSyntaxEditor();
            this.editor = new DataMaintain.ChineseSyntaxEditor();
            this.ContentPanePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentPanePanel
            // 
            this.ContentPanePanel.Controls.Add(this.msgView);
            this.ContentPanePanel.Controls.Add(this.dataView);
            this.ContentPanePanel.Controls.Add(this.splitter);
            this.ContentPanePanel.Controls.Add(this.editor);
            this.ContentPanePanel.Location = new System.Drawing.Point(0, 163);
            this.ContentPanePanel.Size = new System.Drawing.Size(870, 421);
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataView.Location = new System.Drawing.Point(40, 227);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowTemplate.Height = 24;
            this.dataView.Size = new System.Drawing.Size(290, 145);
            this.dataView.TabIndex = 1;
            this.dataView.Visible = false;
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splitter.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splitter.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splitter.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.splitter.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splitter.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splitter.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splitter.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splitter.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splitter.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splitter.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splitter.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.splitter.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.splitter.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.splitter.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.splitter.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.splitter.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splitter.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splitter.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splitter.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.splitter.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.splitter.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.splitter.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.splitter.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.splitter.Location = new System.Drawing.Point(0, 215);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(870, 6);
            this.splitter.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            this.splitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoved);
            // 
            // msgView
            // 
            this.msgView.Document = document1;
            this.msgView.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.msgView.Location = new System.Drawing.Point(346, 227);
            this.msgView.Name = "msgView";
            this.msgView.Size = new System.Drawing.Size(278, 145);
            this.msgView.TabIndex = 3;
            this.msgView.Visible = false;
            // 
            // editor
            // 
            this.editor.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::DataMaintain.Properties.Settings.Default, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editor.Dock = System.Windows.Forms.DockStyle.Top;
            this.editor.Document = document2;
            this.editor.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Size = global::DataMaintain.Properties.Settings.Default.Size;
            this.editor.TabIndex = 0;
            this.editor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editor_KeyDown);
            // 
            // SQLEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SQLEditor";
            this.ContentPanePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChineseSyntaxEditor editor;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataView;
        private DevComponents.DotNetBar.ExpandableSplitter splitter;
        private ChineseSyntaxEditor msgView;
    }
}
