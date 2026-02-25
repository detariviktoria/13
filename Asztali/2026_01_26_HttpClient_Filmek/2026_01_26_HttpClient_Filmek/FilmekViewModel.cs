using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2026_01_26_HttpClient_Filmek
{
    class FilmekViewModel : INotifyPropertyChanged
    {
        private readonly ApiService apiService = new ApiService();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Film> Filmek { get; set; } = new();

        public async Task AdatokBetoltese()
        {
            Filmek.Clear();
            var adatok = await apiService.GetFilmekAsync();
            foreach (var film in adatok)
            { 
                Filmek.Add(film);
            }
        }

        public async Task<bool> AdatokFeltoltese(Film film)
        {
            bool siker = await apiService.AddFilmekAsync(film);
            return siker;
        }

        public async Task<bool> AdatTorlese(string cim)
        {
            return await apiService.DeleteFilmAsync(cim);
        }


    }
}
