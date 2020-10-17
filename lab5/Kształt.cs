using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace lab5
{
    public class Kupsko
    {
        public int ii;
        public Kupsko(int i)
        {
            ii = i;
        }
        public Kupsko(long i)
        {
            ii = 15 + (int)i;
        }

    }
    public class Kształt
        
    {
        private const string FILE_NAME = "tekst.txt";
        String nazwa;
        String opis;
        String kolor;
        String wysokość;
        String szerokość;

        public Kształt() { }

        public void wypisz()///funkcjia zapisujaca informacje do pliku
        {

            try
            {
                if (File.Exists(FILE_NAME))
                {
                    Console.WriteLine($"{FILE_NAME} already exists!");//wywołanie informacji o istnieniu pliku
         
                }
                else
                {
                    using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew)) ;///uwtorzenie nowego plikiu .txt
                }
                using (StreamWriter sr = new StreamWriter("tekst.txt"))
                {
                    nazwa = Form1.nazwa; //przypisywanie wartości odczytancyh w oknie
                    opis = Form1.opis;
                    kolor = Form1.kolor;
                    wysokość = Form1.wysokość;
                    szerokość = Form1.szerokość;
                    if (nazwa != null && opis != null && kolor != null && nazwa != "" && opis != "")
                    {
                        sr.WriteLine("Kształt o nazwie "+nazwa+", opisującej się "+opis+", ma wymiary:"+ wysokość+" na "+szerokość+". I jest koloru "+kolor);
                    }
                    else
                    {
                        Console.WriteLine("Podaj wszystkie artybty elementu!"); //nie wszystkie elementy zostały podane
                    }
                }
            }
            catch (Exception e) //obsługa błedu
            {
                Console.WriteLine("blad");
                Console.WriteLine(e.Message);
            }
        }
        public String odczytaj()//funkcja odczytujaca informacje z pliku
        {

            String linia=null;
            try
            {
                // Tworzenie instancji strumienia do odczytu z pliku.
                // Deklaracja w 'using' obsługuje zarówno otwarcie jak i
                // zamknięcie strumienia.
                using (StreamReader sr = new StreamReader("Tekst.txt"))
                {
                    string line;
                    // Pętla odczytująca i wyświetlająca zawartość pliku
                    // tak długo, aż osiągniemy jego koniec.
                    while ((line = sr.ReadLine()) != null)
                    {
                        linia = line;
                    }
                }
            }
            catch (Exception e)
            {
                // Wypisanie komunikatu błędu.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return linia;
        }

    }
}
