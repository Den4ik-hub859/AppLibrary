namespace AppLibrary
{
    partial class CardProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPublish = new Label();
            lblAvailable = new Label();
            lblPages = new Label();
            lblHeader = new Label();
            pbImage = new PictureBox();
            lblAuthor = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // lblPublish
            // 
            lblPublish.Font = new Font("Calibri", 12F);
            lblPublish.Location = new Point(150, 103);
            lblPublish.Name = "lblPublish";
            lblPublish.Size = new Size(634, 17);
            lblPublish.TabIndex = 10;
            lblPublish.Text = "label1";
            // 
            // lblAvailable
            // 
            lblAvailable.BackColor = Color.Transparent;
            lblAvailable.Font = new Font("Calibri", 12F);
            lblAvailable.Location = new Point(150, 124);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(634, 40);
            lblAvailable.TabIndex = 9;
            lblAvailable.Text = "label1";
            // 
            // lblPages
            // 
            lblPages.Font = new Font("Calibri", 12F);
            lblPages.Location = new Point(150, 168);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(634, 17);
            lblPages.TabIndex = 8;
            lblPages.Text = "label1";
            // 
            // lblHeader
            // 
            lblHeader.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblHeader.Location = new Point(159, 13);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(625, 34);
            lblHeader.TabIndex = 7;
            lblHeader.Text = "label1";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbImage
            // 
            pbImage.Location = new Point(14, 14);
            pbImage.Margin = new Padding(3, 4, 3, 4);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(120, 153);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 6;
            pbImage.TabStop = false;
            // 
            // lblAuthor
            // 
            lblAuthor.Font = new Font("Calibri", 12F);
            lblAuthor.Location = new Point(150, 60);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(634, 39);
            lblAuthor.TabIndex = 11;
            lblAuthor.Text = "label1";
            // 
            // CardProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblAuthor);
            Controls.Add(lblPublish);
            Controls.Add(lblAvailable);
            Controls.Add(lblPages);
            Controls.Add(lblHeader);
            Controls.Add(pbImage);
            Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "CardProduct";
            Size = new Size(795, 197);
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblPublish;
        private Label lblAvailable;
        private Label lblPages;
        private Label lblHeader;
        private PictureBox pbImage;
        private Label lblAuthor;
    }
}
