using dllRapportVisites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour service_visiteur.xaml
    /// </summary>
    public partial class service_visiteur : Window
    {
        private WebClient wb;
        private string site;
        private string ticket;
        private Secretaire laSecretaire;
        public service_visiteur()
            
        {
            
            this.laSecretaire = new Secretaire();
            this.site = ConfigurationManager.AppSettings.Get("srvLocal");
            wb =  new WebClient();
            try
            {
                string url = this.site + "http://localhost/restGSB/visiteurs?ticket=4nblbv5zttybtvd3ygx";
                string reponse; // la réponse retournée  par le serveur
                /* Création de la requête*/
             
                                         
                /*Appel à l'objet wb pour récupérer le résultat de la requête*/
                reponse = this.wb.DownloadString(url);
                /* récupération, après désérialisation et conversion*/
                this.ticket = (string)JsonConvert.DeserializeObject(reponse);
                 List<string> list = new List<string>();
                list.Add(reponse);
                }
            catch(Exception ex) 
            {
               MessageBox.Show(Convert.ToString(ex), "error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            }
            

      
        private void modifierMenue(object sender, RoutedEventArgs e)
        {
            Modifier_visiteur form2 = new Modifier_visiteur();
            form2.Show();
        }

        private void RechargerMenue(object sender, RoutedEventArgs e)
        {

        }

        private void AjouterMenue(object sender, RoutedEventArgs e)
        {

        }

        private void QuitterMenue(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
