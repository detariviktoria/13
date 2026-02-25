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
using static System.Net.Mime.MediaTypeNames;

namespace NagyPontossaguAritmetika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (string a, string b) = NagyobbKisebbSzam(szam1_text.Text, szam2_text.Text);
            int n = b.Length;
            int m = a.Length;
            string eredmeny = "";
            int maradek = 0;
            for (int i = 0; i<n; i++)
            {
                //osszeg += (a[i] - 48) + (b[i] - 48);
                int osszeg = Convert.ToInt16("" + a[m-i-1]) + Convert.ToInt16("" + b[n-i-1]);
                eredmeny = osszeg + maradek + eredmeny;
                maradek = osszeg / 10;
            }

            for (int i = m - n - 1; i >= 0; i--)
            {
                eredmeny = Convert.ToInt16("" + a[i]) + maradek + eredmeny;
                maradek = 0;
            }
            eredmeny_label.Content = eredmeny;
        }

        private (string, string) NagyobbKisebbSzam(string text1, string text2)
        {
            if (text1.Length > text2.Length) return (text1,text2);
            else if(text2.Length > text1.Length) return (text2,text1);
            int i = 0;
            while (i < text1.Length && text1[i] == text2[i])
                i++;
            if(i >= text1.Length) return (text1,text2);
            else if (text1[i] > text2[i]) return (text1,text2);
            else return (text2,text1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("kattintás");
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            Color szin = new Color();
            szin.R = 255;
            szin.G = 0;
            szin.B = 0;
            szin.A = 255;
            this.Background = new SolidColorBrush(szin);
        }

        private void Button_EgerLevetel(object sender, MouseEventArgs e)
        {
            Color szin = new Color();
            szin.R = 255;
            szin.G = 255;
            szin.B = 255;
            szin.A = 255;
            this.Background = new SolidColorBrush(szin);
        }

        private void szam1_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button b = new Button();
            mainGrid.Children.Add(b);
            b.Content = "gomb";
            //b.Width = 100;
            b.Margin = new Thickness(general_btn.Margin.Left, general_btn.Margin.Top + 100, general_btn.Margin.Right, general_btn.Margin.Bottom );
            
        }
    }
}