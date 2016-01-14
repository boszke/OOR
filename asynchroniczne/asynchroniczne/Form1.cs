using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;


namespace asynchroniczne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //dodawanie logów
        private void WriteLog(string message)
        {
            statusList.Items.Insert(0,
                String.Format("{0}[{1}] {2}",
                DateTime.Now.TimeOfDay.ToString(),
                Thread.CurrentThread.ManagedThreadId,
                message));
        }

        //przycisk wiadomość
        private void button1_Click(object sender, EventArgs e)
        {
            WriteLog("Boszke");
        }

        //przycisk Start
        private async void button2_Click(object sender, EventArgs e)
        {
            statusList.Items.Clear();
            button2.Enabled = false;
            WriteLog("Startuję");
            for (int i = 1; i <= 100; i++)
            {
                WriteLog(i.ToString());
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });
            }
            WriteLog("Stop");
            button2.Enabled = true;
        }

        //Synchroniczne
        private void button3_Click(object sender, EventArgs e)
        {
            var result = SynchMethod();
            label1.Text += result;
        }

        private string SynchMethod()
        {
            Thread.Sleep(5000);
            return "Zrobione";
        }

        //asynchroniczne
        private async void button4_Click(object sender, EventArgs e)
        {
            var result = await AsynchMethod();
            label2.Text += result;
        }

        private Task<string> AsynchMethod()
        {
            var t = new Task<string>(SynchMethod);
            t.Start();

            return t;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            statusList.Items.Clear();
            WriteLog("Startuję");
            for (int i = 1; i <= 100; i++)
            {
                WriteLog(i.ToString());
                    Thread.Sleep(100);
            }
            WriteLog("Stop");
        }

    }
}
