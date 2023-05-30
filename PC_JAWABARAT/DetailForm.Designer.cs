namespace PC_JAWABARAT
{
    partial class DetailForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bookList = new System.Windows.Forms.DataGridView();
            this.titleSearchText = new System.Windows.Forms.TextBox();
            this.Location = new System.Windows.Forms.Label();
            this.locationText = new System.Windows.Forms.TextBox();
            this.codeText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bookList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // bookList
            // 
            this.bookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookList.Location = new System.Drawing.Point(57, 215);
            this.bookList.Name = "bookList";
            this.bookList.RowTemplate.Height = 24;
            this.bookList.Size = new System.Drawing.Size(792, 167);
            this.bookList.TabIndex = 2;
            // 
            // titleSearchText
            // 
            this.titleSearchText.Location = new System.Drawing.Point(106, 113);
            this.titleSearchText.Name = "titleSearchText";
            this.titleSearchText.Size = new System.Drawing.Size(726, 22);
            this.titleSearchText.TabIndex = 3;
            // 
            // Location
            // 
            this.Location.AutoSize = true;
            this.Location.Location = new System.Drawing.Point(54, 438);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(58, 16);
            this.Location.TabIndex = 4;
            this.Location.Text = "Location";
            // 
            // locationText
            // 
            this.locationText.Location = new System.Drawing.Point(146, 435);
            this.locationText.Name = "locationText";
            this.locationText.Size = new System.Drawing.Size(166, 22);
            this.locationText.TabIndex = 5;
            // 
            // codeText
            // 
            this.codeText.Enabled = false;
            this.codeText.Location = new System.Drawing.Point(146, 475);
            this.codeText.Name = "codeText";
            this.codeText.Size = new System.Drawing.Size(166, 22);
            this.codeText.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Code";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(57, 526);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(255, 23);
            this.submitBtn.TabIndex = 8;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(753, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 601);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.codeText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.locationText);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.titleSearchText);
            this.Controls.Add(this.bookList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DetailForm";
            this.Text = "Form - Book List";
            this.Load += new System.EventHandler(this.DetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView bookList;
        private System.Windows.Forms.TextBox titleSearchText;
        private System.Windows.Forms.Label Location;
        private System.Windows.Forms.TextBox locationText;
        private System.Windows.Forms.TextBox codeText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button button2;
    }
}