using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public static String nazwa;
        public static String opis;
        public static String kolor;
        public static String wysokość;
        public static String szerokość;
        Point XY_początkowe;        Point XY_końcowe;


        public static Boolean czy_wciśnięty;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            opis = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nazwa = textBox2.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
   
            wysokość = Convert.ToString(panel1.Height);
            szerokość = Convert.ToString(panel1.Width);
            //Zmiana kolorów w zależności od klikniętego radiobuttonu
            if (kolor == "czerwony")
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
            }
            else if (kolor == "zielony")
            {
                e.Graphics.DrawRectangle(Pens.Green, GetRectangle());
            }
            else if (kolor == "niebieski")
            {
                e.Graphics.DrawRectangle(Pens.Blue, GetRectangle());
            }
            else
            {
                Console.WriteLine("Nie podano koloru!");
            }
        }

        private void odczytToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kształt k = new Kształt();
            label1.Text=k.odczytaj();

        }

        private void zapisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kształt k = new Kształt();
            k.wypisz();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            kolor = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            kolor = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            kolor = radioButton3.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            czy_wciśnięty = true; //sprawdzenie czy przycisk jest wcisniety
            XY_początkowe = e.Location; //zczytywanie poczatkowej pozycji myszki
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (czy_wciśnięty == true)
            {
                XY_końcowe = e.Location; //zczytywanie koncowej pozycji myszki

                Refresh();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (czy_wciśnięty == true) //sprawdzenie czy przycisk jest wcisniety
            {
                XY_końcowe = e.Location;

                czy_wciśnięty = false; //przycisk jest wycisniety
            }
        
        }
        private Rectangle GetRectangle() //funkcja tworząca prostokąt
        {
            Rectangle rect = new Rectangle();
            rect.X = Math.Min(XY_początkowe.X, XY_końcowe.X);
            rect.Y = Math.Min(XY_początkowe.Y, XY_końcowe.Y);
            rect.Width = Math.Abs(XY_początkowe.X - XY_końcowe.X);
            rect.Height = Math.Abs(XY_początkowe.Y - XY_końcowe.Y);
            return rect;
        }
    }
}
