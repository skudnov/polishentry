using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            try
            {
                Algoritms r = new Algoritms(tbox.Text);

                label3.Text = r.Algoritm();//получаем ответ
                label3.Visible = true;
                label1.Visible = true;
                //   label.Text = res;
                label4.Text = r.Polski(); // получаем польскую запись 
                label2.Visible = true;
                label4.Visible = true;
            }
            catch (Exception g)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                
                MessageBox.Show(g.Message);
              //  MessageBox.Show("", "Ошибка");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonP_Click(new object(), new EventArgs());
        }
    }
}
