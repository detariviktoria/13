using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankosFeladatBeadando
{
    
    /// <summary>
    /// A BankRendszer nyilvános API-ja — a Form/GUI ezen keresztül kommunikáljon a logikával.
    /// Implementálandó metódusok: CRUD, szűrés, export, backup, async műveletek, stb.
    /// </summary>
    public interface IBankRendszer
    {
        // Alap CRUD és lekérdezések
        List<Ugyfel> GetUgyfelek();
        List<Szamla> GetSzamlak();
        List<Tranzakcio> GetTranzakciok();

        void UjUgyfel(Ugyfel ugyfel);
        void UjUgyfelFelvetel(string nev, string lakcim, string szuletesiDatumStr, string telefonszam);
        void UjSzamla(Szamla szamla);
        void UjTranzakcio(Tranzakcio t);

        // Fájl I/O és backup
        void MentesFajlba();
        void BetoltesFajlbol();
        Task MentesAsync();
        Task BetoltesAsync();

        // Szűrések / lekérdezések
        List<Szamla> NegativSzamlak();
        List<Tranzakcio> TranzakcioSzures(DateTime tol, DateTime ig);
        List<Szamla> UgyfelSzamlai(int ugyfelId);
        List<Tranzakcio> SzamlaTranzakcioi(string szamlaszam);

        // Statisztika / export
        Ugyfel LegnagyobbForgalmuUgyfel();
        decimal OsszesTranzakcioOsszeg(DateTime tol, DateTime ig);
        (decimal befizetes, decimal kivet) Statisztika(DateTime tol, DateTime ig);
        void ExportTranzakciok(string fajlnev);
        void BiztonsagiMentes(string mappa);
        void BiztonsagiVisszaallitas(string mappa);

        // OOP API / GUI wrapperok
        List<Ugyfel> AdatokLekerdezeseUgyfelek();
        List<Szamla> AdatokLekerdezeseSzamlak();
        List<Tranzakcio> AdatokLekerdezeseTranzakciok();
        void AdatTorolUgyfel(int ugyfelId);
        void AdatModositUgyfel(int ugyfelId, string ujNev, string ujLakcim, DateTime ujSzul, string ujTel);
    }
}

