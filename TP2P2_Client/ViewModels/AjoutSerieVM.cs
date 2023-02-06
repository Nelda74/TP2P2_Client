using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2P2_Client.Models;
using TP2P2_Client.Service;

namespace TP2P2_Client.ViewModels
{
    public class AjoutSerieVM : ObservableObject
    {
        public AjoutSerieVM() 
        {

        }

        private String titre;

        public String Titre
        {
            get { return titre; }
            set { titre = value; }
        }

        private String resume;

        public String Resume
        {
            get { return resume; }
            set { resume = value; }
        }

        private int nbSaisons;

        public int NbSaisons
        {
            get { return nbSaisons; }
            set { nbSaisons = value; }
        }

        private int nbEpisodes;

        public int NbEpisodes
        {
            get { return nbEpisodes; }
            set { nbEpisodes = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private String chaine;

        public String Chaine
        {
            get { return chaine; }
            set { chaine = value; }
        }

        public void AjoutSerie()
        {
            WSService service = new WSService("https://apiservicecherad.azurewebsites.net");

            service.PostSerieAsync(new Serie(Titre, Resume, NbSaisons, NbEpisodes, Year, Chaine));
        }
    }
}
