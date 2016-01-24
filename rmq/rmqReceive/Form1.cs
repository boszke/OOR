using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmqReceive
{
    public partial class Form1 : Form
    {

        public string HOST_NAME = "localhost";
        public string QUEUE_NAME = "helloWorld";

        private Consumer consumer;

        public Form1()
        {
            InitializeComponent();

            consumer = new Consumer(HOST_NAME, QUEUE_NAME);

            //nasłuchiwanie
            consumer.onMessageReceived += handleMessage;

            //
            consumer.StartConsuming();
        }

        //delegate to post to UI thread
        private delegate void showMessageDelegate(string message);

        //Callback for message receive
        public void handleMessage(byte[] message)
        {
            showMessageDelegate s = new showMessageDelegate(richTextBox1.AppendText);

            this.Invoke(s, System.Text.Encoding.UTF8.GetString(message) + Environment.NewLine);
        }
    }
}
