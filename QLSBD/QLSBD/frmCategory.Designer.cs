namespace QLSBD
{
    partial class frmCategory
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
            this.btnAddNewCategoryFromClosing = new System.Windows.Forms.Button();
            this.btnAddNewCategory = new System.Windows.Forms.Button();
            this.tbCategoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddNewCategoryFromClosing
            // 
            this.btnAddNewCategoryFromClosing.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCategoryFromClosing.Location = new System.Drawing.Point(258, 74);
            this.btnAddNewCategoryFromClosing.Name = "btnAddNewCategoryFromClosing";
            this.btnAddNewCategoryFromClosing.Size = new System.Drawing.Size(87, 26);
            this.btnAddNewCategoryFromClosing.TabIndex = 2;
            this.btnAddNewCategoryFromClosing.Text = "ĐÓNG";
            this.btnAddNewCategoryFromClosing.UseVisualStyleBackColor = true;
            this.btnAddNewCategoryFromClosing.Click += new System.EventHandler(this.btnAddNewCategoryFromClosing_Click);
            // 
            // btnAddNewCategory
            // 
            this.btnAddNewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCategory.Location = new System.Drawing.Point(137, 74);
            this.btnAddNewCategory.Name = "btnAddNewCategory";
            this.btnAddNewCategory.Size = new System.Drawing.Size(113, 26);
            this.btnAddNewCategory.TabIndex = 1;
            this.btnAddNewCategory.Text = "THÊM MỚI";
            this.btnAddNewCategory.UseVisualStyleBackColor = true;
            // 
            // tbCategoryName
            // 
            this.tbCategoryName.Location = new System.Drawing.Point(137, 30);
            this.tbCategoryName.Multiline = true;
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(244, 21);
            this.tbCategoryName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên loại sân";
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(134, 54);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(21, 13);
            this.lbError.TabIndex = 3;
            this.lbError.Text = "Lỗi";
            this.lbError.Visible = false;
            // 
            // frmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 120);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCategoryName);
            this.Controls.Add(this.btnAddNewCategory);
            this.Controls.Add(this.btnAddNewCategoryFromClosing);
            this.Name = "frmCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCategory";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewCategoryFromClosing;
        private System.Windows.Forms.Button btnAddNewCategory;
        private System.Windows.Forms.TextBox tbCategoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbError;
    }
}