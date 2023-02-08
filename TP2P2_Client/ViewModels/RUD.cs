using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2P2_Client.Models;

namespace TP2P2_Client.ViewModels
{
    public class RUD : SerieVM
    {
        private Serie qSerie;
        private bool loading = false;

        public Serie QSerie
        {
            get { return qSerie; }
            set { 
                qSerie = value;
                OnPropertyChanged();
            }
        }

        internal override async void BtnActionSerie()
        {
            var msgload = await ShowAsync("Chargement", "Les données sont en train d'être chargées", true);

            var request = await ObjWSService.GetSerieAsync(Query);

            if (request == null)
            {
                msgload.Hide();
                ShowAsync("Erreur", "Ressource introuvable", true);
            } else
            {
                QSerie = request;
            }

            msgload.Hide();
        }

        private int query;

        public RUD()
        {
            QSerie = new Serie();
        }

        public int Query
        {
            get { return query; }
            set { query = value; }
        }
    }
}
