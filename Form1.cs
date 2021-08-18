using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            int i = Int32.Parse(tb1.Text);

            for (int a = 0; a < i; a++)
            {
                TextBox tx = new TextBox();
                flowLayoutPanel1.Controls.Add(tx);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(tb2.Text);

            for (int a = 0; a < i; a++)
            {
                TextBox tx = new TextBox();
                flowLayoutPanel2.Controls.Add(tx);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {

            int[] allocation = new int[Int32.Parse(tb2.Text)]; //Tạo mảng chứa vị trí của tiến trình thuộc bộ nhớ
            int[] blockSize = new int[100]; //Tạo mảng chứa giá trị của bộ nhớ sau khi được gán tiến trình vào

            List<int> mang1 = new List<int>(); //Tạo mảng chứa giá trị của bộ nhớ
            List<int> mang2 = new List<int>(); //Tạo mảng chứa giá trị của các tiến trình

            foreach (TextBox x in flowLayoutPanel1.Controls)
            {
                mang1.Add(Int32.Parse(x.Text)); //Gán giá trị của các phân mảnh bộ nhớ vào mảng
            }

            foreach (TextBox x in flowLayoutPanel2.Controls)
            {
                mang2.Add(Int32.Parse(x.Text)); //Gán giá trị của các tiến trình vào mảng
            }

            for (int i = 0; i < allocation.Length; i++)
                allocation[i] = -1; //Gán tất cả vị trí = -1 để xét điều kiện

            for (int i = 0; i < Int32.Parse(tb2.Text); i++)
            {
                for (int j = 0; j < Int32.Parse(tb1.Text); j++)
                {
                    if (mang1[j] >= mang2[i])
                    {
                        allocation[i] = j; //Vị trí của tiến trình được gán cho bộ nhớ

                        mang1[j] -= mang2[i]; //Kích thước của block bị giảm xuống do process tiến vào

                        blockSize[i] = mang1[j];

                        break;
                    }
                }
            }


            tbkq.Multiline = true;

            tbkq.Text = "\nProcess No.\tProcess Size\tBlock no.\t\tBlock Size\r\n";

            for (int i = 0; i < Int32.Parse(tb2.Text); i++)
            {
                tbkq.Text += " " + (i + 1) + "\t\t" + mang2[i] + "\t\t";
                if (allocation[i] != -1)
                    tbkq.Text += allocation[i] + 1 + "\t\t" + blockSize[i] + "\r\n";
                else
                    tbkq.Text += "Not Allocated\r\n";
            }

            tbkq.Text += "\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}
