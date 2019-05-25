namespace PAINApp
{
    partial class BookForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.RecordingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.genreControl = new PAINApp.GenreControl();
            this.genreLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.WarningSign = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarningSign)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.01657F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.98343F));
            this.tableLayoutPanel1.Controls.Add(this.AuthorLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.AuthorTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.RecordingDatePicker, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TitleTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.CancelButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ConfirmButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.TitleLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 241);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint);
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(105, 65);
            this.AuthorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(41, 13);
            this.AuthorLabel.TabIndex = 10;
            this.AuthorLabel.Text = "Author:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Recording Date:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Genre:";
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AuthorTextBox.Location = new System.Drawing.Point(150, 62);
            this.AuthorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(212, 20);
            this.AuthorTextBox.TabIndex = 2;
            this.AuthorTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AuthorTextBox_Validating);
            this.AuthorTextBox.Validated += new System.EventHandler(this.AuthorTextBox_Validated);
            // 
            // RecordingDatePicker
            // 
            this.RecordingDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RecordingDatePicker.Location = new System.Drawing.Point(150, 110);
            this.RecordingDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.RecordingDatePicker.Name = "RecordingDatePicker";
            this.RecordingDatePicker.Size = new System.Drawing.Size(212, 20);
            this.RecordingDatePicker.TabIndex = 3;
            this.RecordingDatePicker.Validating += new System.ComponentModel.CancelEventHandler(this.RecordingDatePicker_Validating);
            this.RecordingDatePicker.Validated += new System.EventHandler(this.RecordingDatePicker_Validated);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TitleTextBox.Location = new System.Drawing.Point(150, 14);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(212, 20);
            this.TitleTextBox.TabIndex = 1;
            this.TitleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TitleTextBox_Validating);
            this.TitleTextBox.Validated += new System.EventHandler(this.TitleTextBox_Validated);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.genreControl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.genreLabel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(150, 146);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 44);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // genreControl
            // 
            this.genreControl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.genreControl.CurrentGenre = PAINApp.Genre.Poetry;
            this.genreControl.Location = new System.Drawing.Point(2, 6);
            this.genreControl.Margin = new System.Windows.Forms.Padding(2);
            this.genreControl.Name = "genreControl";
            this.genreControl.Size = new System.Drawing.Size(40, 32);
            this.genreControl.TabIndex = 0;
            // 
            // genreLabel
            // 
            this.genreLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(47, 15);
            this.genreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(59, 13);
            this.genreLabel.TabIndex = 1;
            this.genreLabel.Text = "genre label";
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CancelButton.CausesValidation = false;
            this.CancelButton.Location = new System.Drawing.Point(22, 200);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(22, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(98, 32);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfirmButton.Location = new System.Drawing.Point(223, 201);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(97, 31);
            this.ConfirmButton.TabIndex = 4;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(2, 17);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(144, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title:";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // WarningSign
            // 
            this.WarningSign.ContainerControl = this;
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(401, 241);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.Load += new System.EventHandler(this.BookForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarningSign)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.DateTimePicker RecordingDatePicker;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ErrorProvider WarningSign;
        private GenreControl genreControl;
        private System.Windows.Forms.Label genreLabel;
    }
}