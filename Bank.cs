using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace SamengesteldObject
{
    public class Bank
    {
        private ArrayList rekeningenLijst = new ArrayList();
        public Bank()
        {
            
        }

        public void leegLijst()
        {
            //Haal de rekeningen lijst leeg
            rekeningenLijst.Clear();
        }

        public void nieuweRekening(string naam, int gironummer)
        {
            //Maak een nieuwe rekening aan
            Girorekening rekening = new Girorekening(naam, gironummer);
            //Voer een rekening toe
            rekeningenLijst.Add(rekening);
        }

        public void nieuweRekening(string naam, int gironummer, double saldo)
        {
            //Maak een nieuwe rekening aan
            Girorekening rekening = new Girorekening(naam, gironummer, saldo);
            //Voer een rekening toe
            rekeningenLijst.Add(rekening);
        }

        public int geefAantalRekeningen()
        {
            //Tel alle rekeningen
            int aantal = rekeningenLijst.Count;
            //Geef het antwoord terug
            return aantal;
        }

        public Girorekening geefRekeningOpIndex(int index)
        {
            //Haal de rekening op uit de ArrayList
            Girorekening rekening = (Girorekening)rekeningenLijst[index];
            //Geef het antwoord terug
            return rekening;
        }

        public ArrayList zoekRekeningOpNaam(string zoeknaam)
        {
            //maak een lege lijst aan
            ArrayList gevondenRekening = new ArrayList();

            for (int i = 0; i < rekeningenLijst.Count; i++)
            {
                //haal de rekeningen op positie i op
                Girorekening rekening = (Girorekening)rekeningenLijst[i];
                //haal de naam uit de rekening
                string naam = rekening.geefNaam();
                //controleer of het de juiste naam is
                if(naam.Equals(zoeknaam))
                {
                    //voeg de rekening aan de lijst toe
                    gevondenRekening.Add(rekening);
                }
            }

            //geef de lijst als resultaat terug
            return gevondenRekening;
        }

        public ArrayList zoekRekeningOpNummer(string zoeknummer)
        {
            //maak een lege lijst aan
            ArrayList gevondenRekening = new ArrayList();

            for (int i = 0; i < rekeningenLijst.Count; i++)
            {
                //haal de rekeningen op positie i op
                Girorekening rekening = (Girorekening)rekeningenLijst[i];
                //haal de naam uit de rekening
                int nummer = rekening.geefNummer();
                //controleer of het de juiste naam is
                if (nummer.ToString().Equals(zoeknummer))
                {
                    //voeg de rekening aan de lijst toe
                    gevondenRekening.Add(rekening);
                }
            }

            //geef de lijst als resultaat terug
            return gevondenRekening;
        }

        public double totaalInKluis()
        {
            //Maak een variabele aan
            double TotaalSaldo = 0;
            //Loop door de lijst heen en tel alles op
            for (int i = 0; i < rekeningenLijst.Count; i++)
            {
                //haal de rekeningen op positie i op
                Girorekening rekening = (Girorekening)rekeningenLijst[i];
                //haal het saldo uit de rekening
                double saldo = rekening.geefSaldo();
                //controleer of het de juiste naam is
                TotaalSaldo += saldo;
            }
            //Geef de waardes terug
            return TotaalSaldo;
        }
    }
}