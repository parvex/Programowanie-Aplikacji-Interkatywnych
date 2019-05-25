using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAINApp
{
    public partial class MainWindow : Form
    {

        BooksDocument document = new BooksDocument();
        public MainWindow()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
        private void newWindowItem_Click(object sender, EventArgs e)
        {
            BookList bookListWindow = new BookList(document);
            bookListWindow.MdiParent = this;
            bookListWindow.NumberOfElementsUpdate += StatusStripUpdate;
            bookListWindow.Show();
        }

        public void StatusStripUpdate(int count)
        {
            NumberOfElemsLabel.Text = count.ToString();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MdiChildren.ToList().Clear();
            e.Cancel = false;
        }
    }
}
