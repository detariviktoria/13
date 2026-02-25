using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2026_01_26_HttpClient_Filmek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private FilmekViewModel vm;
        public MainWindow()
        {
            InitializeComponent();

            Loaded += async (s, e) =>
            {
                AdatokFrissitese();
            };
        }

        private async void AdatokFrissitese()
        {
            vm = (FilmekViewModel)DataContext;
            await vm.AdatokBetoltese();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Film film = new Film
            {
                Cim = TxtCim.Text,
                Hossz = int.Parse(TxtHossz.Text),
                Ertekeles = double.Parse(TxtErtekeles.Text)
            };

            //ApiService apis = new ApiService();
            //bool siker = await apis.AddFilmekAsync(film);
            bool siker = await vm.AdatokFeltoltese(film);
            if (siker)
            {
                MessageBox.Show("Sikeres mentés!");
                AdatokFrissitese();
                TxtCim.Clear();
                TxtErtekeles.Clear();
                TxtHossz.Clear();
            }
            else {
                MessageBox.Show("Hiba történt a mentés során!");
            }


        }
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string cim = TxtDeleteCim.Text;


            bool siker = await vm.AdatTorlese(cim);

            if (siker)
            {
                MessageBox.Show("Sikeres törlés!");
                AdatokFrissitese();
                await vm.AdatokBetoltese();
                TxtDeleteCim.Clear();
            }
            else
            {
                MessageBox.Show("Sikertelen törlés!");
            }
        }

    }
}