using dllRapportVisites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Logique d'interaction pour VoirFamillesWindow.xaml
    /// </summary>
    public partial class VoirFamillesWindow : Window
    {
        private Secretaire laSecretaire;
        private string site;
        private WebClient wb;
        
        public VoirFamillesWindow(Secretaire s, string site, WebClient wb)
        {
            InitializeComponent();

            this.wb = wb;
            this.laSecretaire = laSecretaire;
            this.site = site;
            string url = this.site + "famille?ticket=" + this.laSecretaire.getHashTicketMdp();
            string data = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(data);
            string t = d.ticket;
            string familles = d.familles;
            List<Famille> l = JsonConvert.DeserializeObject<List<Famille>>(familles);
            this.dtg.ItemsSource = l;

        }
    }
}
