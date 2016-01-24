using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmq
{
    public partial class Form1 : Form
    {
        public string HOST_NAME = "localhost";
        public string QUEUE_NAME = "helloWorld";


        private Producer producer;

        public Form1()
        {
            InitializeComponent();

            producer = new Producer(HOST_NAME, QUEUE_NAME);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            producer.SendMessage(System.Text.Encoding.UTF8.GetBytes(textBox1.Text));
        }
    }
}
