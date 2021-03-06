namespace CarRentalApp
{
    partial class ManageRentalRecordcs
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnEditRecord = new System.Windows.Forms.Button();
            this.btnAddNewRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvRecordList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.btnRefresh.Location = new System.Drawing.Point(12, 284);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 65);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.btnDeleteRecord.Location = new System.Drawing.Point(487, 284);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(150, 65);
            this.btnDeleteRecord.TabIndex = 10;
            this.btnDeleteRecord.Text = "Delete Record";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.btnEditRecord.Location = new System.Drawing.Point(324, 284);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(155, 65);
            this.btnEditRecord.TabIndex = 9;
            this.btnEditRecord.Text = "Edit Record>>";
            this.btnEditRecord.UseVisualStyleBackColor = true;
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // btnAddNewRecord
            // 
            this.btnAddNewRecord.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.btnAddNewRecord.Location = new System.Drawing.Point(148, 284);
            this.btnAddNewRecord.Name = "btnAddNewRecord";
            this.btnAddNewRecord.Size = new System.Drawing.Size(170, 65);
            this.btnAddNewRecord.TabIndex = 8;
            this.btnAddNewRecord.Text = "Add New Record >>";
            this.btnAddNewRecord.UseVisualStyleBackColor = true;
            this.btnAddNewRecord.Click += new System.EventHandler(this.btnAddNewRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(85, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 53);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manage Rental Record";
            // 
            // gvRecordList
            // 
            this.gvRecordList.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.gvRecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRecordList.Location = new System.Drawing.Point(12, 72);
            this.gvRecordList.Name = "gvRecordList";
            this.gvRecordList.Size = new System.Drawing.Size(625, 206);
            this.gvRecordList.TabIndex = 6;
            // 
            // ManageRentalRecordcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 356);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteRecord);
            this.Controls.Add(this.btnEditRecord);
            this.Controls.Add(this.btnAddNewRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvRecordList);
            this.Name = "ManageRentalRecordcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Rental Recordcs";
            this.Load += new System.EventHandler(this.ManageRentalRecordcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnEditRecord;
        private System.Windows.Forms.Button btnAddNewRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvRecordList;
    }
}