using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2026_01_26_HttpClient_Filmek
{
    internal class ApiService
    {
        private readonly HttpClient httpClient = new HttpClient { 
            BaseAddress = new Uri("http://localhost:4000")
        };

        public async Task<List<Film>> GetFilmekAsync()
        {
            try
            {
                var valasz = await httpClient.GetFromJsonAsync<List<Film>>("/filmek");
                return valasz ?? new ();

            }
            catch(Exception ex) {
                Console.WriteLine($"Hiba történt: {ex.Message}");
                //return new List<Film>();
                return new();
            }
        }

        public async Task<bool> AddFilmekAsync(Film film)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("/filmek", film);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Hiba történt a küldés során: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteFilmAsync(string cim)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"/filmek/{cim}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }


    }
}
