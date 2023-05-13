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


        private Secretaire laSecretaire;
        private string site;


        public service_visiteur (Secretaire s, string site, WebClient wb)
        {
            InitializeComponent();
            this.wb = wb;
            this.laSecretaire = s;
            this.site = site;
            /* Construction de la requete get*/
            string url = this.site + "visiteurs?ticket=" + this.laSecretaire.getHashTicketMdp();
            /* récupération des données du serveur*/
            string data = this.wb.DownloadString(url);
            /* utilisation d'un objet dynamic pour séparer le ticket des familles*/
            dynamic d = JsonConvert.DeserializeObject(data);
            string t = d.ticket;
            string visiteur = d.visiteurs.ToString();
            /* convertit le json en liste de familles */
            List<Visiteur> l = JsonConvert.DeserializeObject<List<Visiteur>>(visiteur);
            /* On bind le datagrid à la liste des familles*/
            this.DG1.ItemsSource = l;
            /*On met à jour la secrétaire avec le nouveau ticket*/
            this.laSecretaire.ticket = t;
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

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      
        

        private void Modif_menue(object sender, RoutedEventArgs e)
        {
            Modifier_visiteur form2 = new Modifier_visiteur();
            form2.Show();

        }
    }

 }
