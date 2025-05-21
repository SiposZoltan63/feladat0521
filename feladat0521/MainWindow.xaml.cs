using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace feladat0521
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Termek> termekek = new List<Termek>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 1. beolvasuk a keszlet.csv-t
            var fajl = File.ReadAllLines("keszlet.csv");
            foreach (var item in fajl)
            {
                var sor = item.Split(';');
                var termek = new Termek(sor[0], sor[1], int.Parse(sor[2]), int.Parse(sor[3]));
                termekek.Add(termek);
            }
            // 2. feltöltjük a DataGrid-et
            dgkeszlet.ItemsSource = termekek;
        }

        private void dgkeszlet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txCikkszam.Text = ((Termek)dgkeszlet.SelectedItem).Cikkszam;
            txMegnevezes.Text = ((Termek)dgkeszlet.SelectedItem).Megnevezes;
            txAr.Text = ((Termek)dgkeszlet.SelectedItem).Ar.ToString();
            txMennyiseg.Text = ((Termek)dgkeszlet.SelectedItem).Mennyiseg.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // módosítjuk a kiválasztott terméket a szövegmezők aktuális értékeire
            var Cikkszam = txCikkszam.Text;
            var Megnevezes = txMegnevezes.Text;
            var Ar = int.Parse(txAr.Text);
            var Mennyiseg = int.Parse(txMennyiseg.Text);
            foreach (var item in termekek)
            {
                if (item.Cikkszam == Cikkszam)
                {
                    item.Megnevezes = Megnevezes;
                    item.Ar = Ar;
                    item.Mennyiseg = Mennyiseg;
                    break;
                }
            }
            dgkeszlet.Items.Refresh();
            // fájlba írás
            var sw = new StreamWriter("keszlet.csv");
            foreach (var item in termekek)
            {
                sw.WriteLine($"{item.Cikkszam};{item.Megnevezes};{item.Ar};{item.Mennyiseg}");
            }
            sw.Close();
        }
    }
}