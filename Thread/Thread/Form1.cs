using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Thread1
{
    public partial class Form1 : Form
    {
        Random rdm, czas;
        Thread th1;
        Thread th2;
        Thread th3;

        static Thread[] threads = new Thread[10];
        //liczba wolnych slotów, liczba max slotów
        static Semaphore sem = new Semaphore(3, 3);

        public Form1()
        {
            InitializeComponent();
        }
        
        //przycisk czerwony
        private void red_btn_Click(object sender, EventArgs e)
        {
            th1 = new Thread(threadr);
            th1.Start();
        }

        //rysowanie czerwonych kwadratów
        public void threadr()
        {
            for (int i = 0; i < 100; i++)
            {
                panel1.CreateGraphics().DrawRectangle(new Pen(Brushes.Red, 4), new Rectangle(rdm.Next(panel1.Width / 2, panel1.Width), rdm.Next(0, panel1.Height), 20, 20));
                Thread.Sleep(100);
            }

            MessageBox.Show("Zakończono czerwony wątek");
        }

        //rysowanie czarnych kwadratów
        public void threadw()
        {
            for (int i = 0; i < 100; i++)
            {
                panel1.CreateGraphics().DrawRectangle(new Pen(Brushes.Black, 4), new Rectangle(rdm.Next(0, panel1.Width), rdm.Next(0, panel1.Height), 20, 20));
                Thread.Sleep(100);
            }

            MessageBox.Show("Zakończono czarny wątek");
        }

        //rysowanie zielonych kwadratów
        public void threadg()
        {
            for (int i = 0; i < 100; i++)
            {
                panel1.CreateGraphics().DrawRectangle(new Pen(Brushes.Green, 4), new Rectangle(rdm.Next(0, panel1.Width/2), rdm.Next(0, panel1.Height), 20, 20));
                Thread.Sleep(200);
            }

            MessageBox.Show("Zakończono zielony wątek");
        }

        //przycisk zielony
        private void green_btn_Click(object sender, EventArgs e)
        {
            th2 = new Thread(threadg);
            th2.Start();
        }

        //łądowanie formy i losowanie liczby początkowej
        private void Form1_Load(object sender, EventArgs e)
        {
            rdm = new Random();
            czas = new Random();
        }

        //niebieski przycisk i rysowanie niebieskich kwadratów bez wątków
        private void blue_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                panel1.CreateGraphics().DrawRectangle(new Pen(Brushes.Blue, 4), new Rectangle(rdm.Next(0, panel1.Width), rdm.Next(0, panel1.Height), 20, 20));
                Thread.Sleep(100);
            }

            MessageBox.Show("Zakończono niebieski");
        }

        //pomarańcz przycisk i rysowanie pomarańczowych kwadratów bez wątków
        private void orange_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                panel1.CreateGraphics().DrawRectangle(new Pen(Brushes.Orange, 4), new Rectangle(rdm.Next(0, panel1.Width), rdm.Next(0, panel1.Height), 20, 20));
                Thread.Sleep(100);
            }

            MessageBox.Show("Zakończono pomarańcz");
        }

        //rysowanie wszytskich kwadratów, różne wątki (czerw, czarny, zielony)
        private void button1_Click(object sender, EventArgs e)
        {
            //czerwony
            th1 = new Thread(threadr);
            th1.Start();
            
            //zielony
            th2 = new Thread(threadg);
            th2.Start();

            //czekanie na zakończenie wątku czerwonego
            th1.Join();

            //czarny
            th3 = new Thread(threadw);
            th3.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //th1.Abort();
            //th2.Abort();
            //th3.Abort();
        }

        //przycisk wątki
        public void button2_Click(object sender, EventArgs e)
        {
            uruchom();
        }

        //metoda startująca wątki i nadawania nazw
        public void uruchom()
        {
            for (int i = 0; i < 10; i++)
            {

                threads[i] = new Thread(watkitekstowe);
                threads[i].Name = "Wątek nr " + i;
                threads[i].Start();
            }
        }

        //metoda wypisująca wątki w labelu
        public void watkitekstowe()
        {
            
            string nazwa = Thread.CurrentThread.Name;

            label2.BeginInvoke(new Action(() =>
            {
                label2.Text += string.Format("\n{0} CZEKA", nazwa);
            }));
            sem.WaitOne();
            //losowanie ile wątek bedzie zamrożony
            int n = czas.Next(4000, 10000);

            label2.BeginInvoke(new Action(() =>
            {
                label2.Text += string.Format("\n{0} PRZETWARZANY przez {1}", nazwa, n.ToString());
            }));
            
            Thread.Sleep(n);
            
            label2.BeginInvoke(new Action(() =>
            {
                label2.Text += string.Format("\n{0} ZAMYKANY", nazwa);
            }));
            sem.Release();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Invalidate();
        }
    }
}
