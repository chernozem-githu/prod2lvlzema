using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp4_zema_3_zadaniya_srazy_
{
    public partial class Form1 : Form
    {
        private Button closeButton;

        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.LightBlue;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(300, 300);

            closeButton = new Button();
            closeButton.Text = "Закрыть";
            closeButton.Size = new Size(100, 40);
            closeButton.Location = new Point(
                this.ClientSize.Width / 2 - closeButton.Width / 2,
                this.ClientSize.Height / 2 - closeButton.Height / 2);
            closeButton.Click += (s, e) => this.Close();
            this.Controls.Add(closeButton);

            this.Resize += (s, e) =>
            {
                closeButton.Location = new Point(
                    this.ClientSize.Width / 2 - closeButton.Width / 2,
                    this.ClientSize.Height / 2 - closeButton.Height / 2);
                UpdateCircleRegion();
            };

            this.FormClosing += Form1_FormClosing;

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                    this.Close();
            };

            UpdateCircleRegion();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите закрыть приложение?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void UpdateCircleRegion()
        {
            int size = Math.Min(this.ClientSize.Width, this.ClientSize.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, size, size);
            this.Region = new Region(path);
        }
    }
}
