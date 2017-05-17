using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SamengesteldObject
{
    public partial class BankRekeningen : System.Web.UI.Page
    {
        Bank bankObject;
        OleDbConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {           
            //Als de sessie nieuw is
            if (Session.IsNewSession)
            {
                //Zet het getal in de textbox op 0
                TextBoxKluis.Text = "0";

                //aanroepen van constructor
                bankObject = new Bank();

                //zet de instanties in een sessieobject
                Session.Add("bank", bankObject);
            }
            //Anders
            else
            {
                //haal de eerder gemaakte instantie uit het sessieobject
                bankObject = (Bank)Session["bank"];
            }
        }

        private void toonAlleRekeningen()
        {
            //maak de lijst eerst leeg
            rekeningenBox.Items.Clear();
            //maak een lus voor alle bestaande rekeningen
            for (int i = 0; i < bankObject.geefAantalRekeningen(); i++)
            {
                //haal de rekeningen op positie i op
                Girorekening rekening = bankObject.geefRekeningOpIndex(i);
                //haal de naam uit de rekening
                string naam = rekening.geefNaam();
                //haal het nummer uit de rekening
                int nummer = rekening.geefNummer();
                //zet naam en nummer op 1 regel in de listbox
                rekeningenBox.Items.Add(naam + " " + nummer);
            }
        }

        protected void ButtonOpslaan_Click(object sender, EventArgs e)
        {
            //lees tekstbox met naam uit
            string naam = rekeninghouder.Text;
            //lees gironummer uit
            string nummerTekst = gironummer.Text;
            //Converteer naar een int
            int nummer = Int32.Parse(nummerTekst);
            //maak nieuwe rekening aan via het bank object
            bankObject.nieuweRekening(naam, nummer);
            //roep de methode aan die de lijst bijwerkt
            toonAlleRekeningen();
        }

        protected void Zoek_Click(object sender, EventArgs e)
        {
            
            //maak de listbox leeg
            resultatenBox.Items.Clear();
            //maak een lijst voor de gevonden resultaten
            ArrayList lijst = new ArrayList();
            //lees de naam uit de textbox
            string rekeningZoeken = naamRekeninghouder.Text;
            try
            {
                //Maak van de string een int
                int zoek = Int32.Parse(rekeningZoeken); 
                     
                lijst = bankObject.zoekRekeningOpNummer(rekeningZoeken);
                //een herhalingslus voor alle rekeningen uit de lijst gevonden rekeningen
                for (int i = 0; i < bankObject.geefAantalRekeningen(); i++)
                {
                    //haal de rekening op positie i op
                    Girorekening rekening = (Girorekening)bankObject.geefRekeningOpIndex(i);
                    //haal rekeningnummer uit de lijst
                    int rekeningnummer = rekening.geefNummer();
                    if (zoek == rekeningnummer)
                    {
                        //zet nummer in de listbox{
                        resultatenBox.Items.Add(rekening.geefNaam());
                    }
                                 
                }
                return;
            }
            catch
            {

            }
            lijst = bankObject.zoekRekeningOpNaam(rekeningZoeken);
            //een herhalingslus voor alle rekeningen uit de lijst gevonden rekeningen
            for (int i = 0; i < bankObject.geefAantalRekeningen(); i++)
            {
                //haal de rekening op positie i op
                Girorekening rekening = (Girorekening)bankObject.geefRekeningOpIndex(i);
                //haal rekeningnummer uit de lijst
                string naam = rekening.geefNaam();
                if (rekeningZoeken == naam)
                {
                    //zet nummer in de listbox{
                    resultatenBox.Items.Add(rekening.geefNummer().ToString());
                }
            }
        }

        protected void rekeningenBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //haal de rekeningen op de positie p
            Girorekening rekening = bankObject.geefRekeningOpIndex(rekeningenBox.SelectedIndex);
            //Laat de naam van de geselecteerde index zien in de tekstbox
            TextBoxNaam.Text = rekening.geefNaam();
            //Laat de girorekening van de geselecteerde index zien in de tekstbox
            TextBoxNummer.Text = rekening.geefNummer().ToString();
            //Laat het saldo van de geselecteerde index zien in de tekstbox
            TextBoxSaldo.Text = rekening.geefSaldo().ToString();
        }

        protected void Stort_Click(object sender, EventArgs e)
        {
            //Lees het bedrag uit
            String Bedrag = TextBoxBedrag.Text;
            //Lees de rekening uit
            String reknr = TextBoxNaarGironummer.Text;
            //Zoek de rekening in de lijst
            ArrayList list = (ArrayList)bankObject.zoekRekeningOpNummer(reknr.ToString());
            Girorekening rekening = (Girorekening) list[0];
            //Converteer een string naar een double
            Double EindBedrag = Double.Parse(Bedrag);
            //Stort het bedrag op de rekening
            rekening.stort(EindBedrag);

            //Sessie updaten
            Session["bank"] = bankObject;

            //Haal het saldo in de kluis op
            string saldo = bankObject.totaalInKluis().ToString();
            //Plaats het saldo in een textbox
            TextBoxKluis.Text = saldo;
        }

        protected void NeemOp_Click(object sender, EventArgs e)
        {
            //Lees het bedrag uit
            String Bedrag = TextBoxBedrag.Text;
            Double NeemOpBedrag = Double.Parse(Bedrag);
            //Lees de rekening uit
            String reknr = TextBoxVanGironummer.Text;
            //Zoek de rekening in de lijst
            ArrayList list = (ArrayList)bankObject.zoekRekeningOpNummer(reknr.ToString());
            Girorekening rekening = (Girorekening)list[0];
            //Als het saldo groter is dan het opgenomen bedrag
            if (rekening.geefSaldo() >= NeemOpBedrag)
            {
                //Converteer een string naar een double
                Double EindBedrag = Double.Parse(Bedrag);
                //Stort het bedrag op de rekening
                rekening.neemOp(EindBedrag);

                //Sessie updaten
                Session["bank"] = bankObject;

                //Haal het saldo in de kluis op
                string saldo = bankObject.totaalInKluis().ToString();
                //Plaats het saldo in een textbox
                TextBoxKluis.Text = saldo;
            }
            //Anders
            else
            {
                //Laat een foutmelding zien
                TextBoxBedrag.Text = "Onvoldoende saldo.";
            }
        }

        protected void MaakOver_Click(object sender, EventArgs e)
        {
            //Lees het bedrag uit
            String Bedrag = TextBoxBedrag.Text;
            //Lees de rekening uit
            String reknrVan = TextBoxVanGironummer.Text;
            String reknrNaar = TextBoxNaarGironummer.Text;
            //Zoek de rekening in de lijst
            ArrayList listVan = (ArrayList)bankObject.zoekRekeningOpNummer(reknrVan.ToString());
            ArrayList listNaar = (ArrayList)bankObject.zoekRekeningOpNummer(reknrNaar.ToString());
            //Zoek de girorekening op in de lijst
            Girorekening rekeningVan = (Girorekening)listVan[0];
            Girorekening rekeningNaar = (Girorekening)listNaar[0];
            //Converteer een string naar een double
            Double EindBedrag = Double.Parse(Bedrag);
            if (rekeningVan.geefSaldo() >= EindBedrag)
            {
                //Haal het bedrag van de rekening af
                rekeningVan.neemOp(EindBedrag);
                //Stort het bedrag op de rekening
                rekeningNaar.stort(EindBedrag);

                //Sessie updaten
                Session["bank"] = bankObject;

                //Haal het saldo in de kluis op
                string saldo = bankObject.totaalInKluis().ToString();
                //Plaats het saldo in een textbox
                TextBoxKluis.Text = saldo;
            }
            //Anders
            else
            {
                //Laat een foutmelding zien
                TextBoxBedrag.Text = "Onvoldoende saldo.";
            }
        }

        protected void LoadData_Click(object sender, EventArgs e)
        {
            // maak het pad naar de database file
            string path = MapPath("~/Bank.mdb");

            // maak de connectionstring
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path;

            // maak de verbinding met de database
            connection = new OleDbConnection(connectionString);

            // maak het command
            OleDbCommand command = new OleDbCommand("SELECT * FROM rekening", connection);

            // open de verbinding met de database
            connection.Open();

            // maak een reader en voer het command uit
            OleDbDataReader reader = command.ExecuteReader();

            // maak een DataTable om de resultaten in op te slaan
            DataTable dt = new DataTable();

            // sla de resultaten op in de DataTable
            dt.Load(reader);

            // de data uitlezen en in een ListBox tonen
            if (dt.Rows.Count > 0)
            {
                //Maak het bankobject leeg
                bankObject.leegLijst();

                // maak de listbox leeg
                rekeningenBox.Items.Clear();

                // loop door alle rijen data
                foreach (DataRow row in dt.Rows)
                {
                    // lees de data uit de rij
                    string naam = row.Field<string>("naam");
                    string nummer = row.Field<int>("nummer").ToString();
                    string saldo = row.Field<decimal>("saldo").ToString();
           
                    // zet de data in de listbox
                    rekeningenBox.Items.Add(naam + " | " + nummer + " | " + saldo + " | ");
                    //Maak een nieuwe rekening aan voor elke 
                    bankObject.nieuweRekening(naam, Convert.ToInt32(nummer), Convert.ToDouble(saldo));

                }
                //Sessie updaten
                Session["bank"] = bankObject;

                //Haal het saldo in de kluis op
                string Totaalsaldo = bankObject.totaalInKluis().ToString();
                //Plaats het saldo in een textbox
                TextBoxKluis.Text = Totaalsaldo;
                //Laat een bericht in de textbox zien
                TextBoxMessage.Text = "Laden gelukt.";
            }
        }

        protected void SaveData_Click(object sender, EventArgs e)
        {
            // maak het pad naar de database file
            string path = MapPath("~/Bank.mdb");

            // maak de connectionstring
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path;

            // maak de verbinding met de database
            connection = new OleDbConnection(connectionString);

            // open de verbinding met de database
            connection.Open();

            //Loop door de lus heen
            for (int i = 0; i < bankObject.geefAantalRekeningen(); i++)
            {
                //Vul de variabelen
                string naam = (string)(bankObject.geefRekeningOpIndex(i).geefNaam());
                int nummer = (int)(bankObject.geefRekeningOpIndex(i).geefNummer());
                double saldo = (double)(bankObject.geefRekeningOpIndex(i).geefSaldo());

                //Probeer
                try
                {
                    //Maak het command
                    OleDbCommand command = new OleDbCommand("INSERT INTO rekening VALUES ('" + naam + "', " + nummer + ", " + saldo + ")", connection);

                    //Voer het commando uit
                    command.ExecuteNonQuery();

                    //Laat een bericht in de textbox zien
                    TextBoxMessage.Text = "Toevoegen gelukt.";
                }

                //Anders
                catch
                {
                    //Maak het command
                    OleDbCommand command = new OleDbCommand("UPDATE rekening SET [naam] ='" + naam + "', [nummer] ='" + nummer + "', [saldo]='" + saldo + "' WHERE [nummer]=" + nummer, connection);

                    //Voer het commando uit
                    command.ExecuteNonQuery();

                    //Laat een bericht in de textbox zien
                    TextBoxMessage.Text = "Updaten gelukt.";
                }
            }
            //Sluit de verbinding met de database
            connection.Close();
        }
    }
}