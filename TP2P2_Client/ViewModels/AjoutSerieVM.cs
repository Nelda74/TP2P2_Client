using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TP2P2_Client.Models;
using TP2P2_Client.Service;

namespace TP2P2_Client.ViewModels
{
    public class AjoutSerieVM : ObservableObject
    {
        public RelayCommand BtnSetAjoutSerie { get; }
        public AjoutSerieVM() 
        {
            BtnSetAjoutSerie = new RelayCommand(AjoutSerieBtn);
            SerieToAdd = new Serie();
        }
        public ServiceProvider Services { get; }

        public IService ObjWSService
        {
            get { return ((App)Application.Current).ObjWSService; }
        }

        private Serie serieToAdd;

        public Serie SerieToAdd
        {
            get { return serieToAdd; }
            set { 
                serieToAdd = value;
                OnPropertyChanged();
            }
        }

        public void AjoutSerieBtn()
        {
            //WSService service = new WSService("https://apiservicecherad.azurewebsites.net");

            if(string.IsNullOrEmpty(SerieToAdd.Titre))
            {
                ShowAsync("Erreur", "Le titre doit être renseigné !");
                return;
            } else if (string.IsNullOrEmpty(SerieToAdd.Resume))
            {
                ShowAsync("Erreur", "Le resumé doit être renseigné !");
                return; 
            } else if (SerieToAdd.Anneecreation== 0)
            {
                ShowAsync("Erreur", "L'année doit être renseignée !");
                return;
            } else if (SerieToAdd.Nbepisodes== 0)
            {
                ShowAsync("Erreur", "Le nombre d'épisodes doit être renseigné !");
                return;
            } else if (serieToAdd.Nbsaisons== 0)
            {
                ShowAsync("Erreur", "Le nombre de saisons doit être renseigné !");
                return;
            } else if (string.IsNullOrEmpty(SerieToAdd.Network))
            {
                ShowAsync("Erreur", "La chaine doit être renseignée !");
                return;
            }

            var request = ObjWSService.PostSerieAsync(SerieToAdd);

            if(request.Result.IsSuccessStatusCode)
            {
                ShowAsync("Succès !", $"La série {SerieToAdd.Titre} a bien été ajoutée");
            } else
            {
                ShowAsync("Erreur !", "Votre requête n'a pu aboutir");
            }
        }

        private async void ShowAsync(String title, String message)
        {
            ContentDialog msgDialog = new ContentDialog()
            {
                Title = title,
                Content = message,
                CloseButtonText = "Ok"
            };

            msgDialog.XamlRoot = App.MainRoot.XamlRoot;
            await msgDialog.ShowAsync();
        }
    }
}
