namespace DataMaintain
{
    partial class UDTTables
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPattern = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tables = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tables)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPattern
            // 
            // 
            // 
            // 
            this.txtPattern.Border.Class = "TextBoxBorder";
            this.txtPattern.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPattern.Location = new System.Drawing.Point(3, 3);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(371, 25);
            this.txtPattern.TabIndex = 0;
            this.txtPattern.TextChanged += new System.EventHandler(this.txtPattern_TextChanged);
            // 
            // tables
            // 
            this.tables.AllowUserToAddRows = false;
            this.tables.AllowUserToDeleteRows = false;
            this.tables.AllowUserToResizeColumns = false;
            this.tables.AllowUserToResizeRows = false;
            this.tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tables.DefaultCellStyle = dataGridViewCellStyle1;
            this.tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tables.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.tables.Location = new System.Drawing.Point(3, 34);
            this.tables.Name = "tables";
            this.tables.ReadOnly = true;
            this.tables.RowTemplate.Height = 24;
            this.tables.Size = new System.Drawing.Size(371, 380);
            this.tables.TabIndex = 1;
            this.tables.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tables_CellMouseDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtPattern, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tables, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(377, 417);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // UDTTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 417);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "UDTTables";
            this.Text = "UDT 清單";
            this.Load += new System.EventHandler(this.UDTTables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tables)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtPattern;
        private DevComponents.DotNetBar.Controls.DataGridViewX tables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}