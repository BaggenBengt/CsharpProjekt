using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Logic;
using Logic.Validering;

namespace CsharpProjekt
{
    public partial class PodcastAppen : Form
    {

        public Bll bll { get; set; }
        

        public PodcastAppen()
        {
            try
            {
                InitializeComponent();
                bll = new Bll();
                LoadForm();
                bll.getSparadPodcastLista();
                bll.getSparadKategorierLista();
                FillKategoriList();


                bll.StartaTimer();
                FillPodcastList();
                startaUpdateAvGuiAsync();
            }
            catch (Exception ex)
            {

            }

        }
        
            
        
        public async Task startaUpdateAvGuiAsync()
        {
            Task task1 = Task.Run(() => startaUpdateAvGui());
            await task1;
        }
        public void startaUpdateAvGui()
        {
            System.Timers.Timer timer = new System.Timers.Timer(60000);
            timer.Start();
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (lwPodcast.InvokeRequired)
                {
                    lwPodcast.Invoke((MethodInvoker)delegate
                   {
                       lwPodcast.Items.Clear();
                       FillPodcastList();
                   });
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        private void FillPodcastList()
        {
            try
            {
                var podcastLista = bll.ConvertPodcastListToString("HelaListan");

                int i = 0;

                foreach (var podcast in podcastLista)
                {
                    int ind = 0;
                    while (ind < 4)
                    {
                        ListViewItem item = new ListViewItem(podcast[i]);
                        i++;
                        ind++;
                        item.SubItems.Add(podcast[i]);
                        i++;
                        ind++;
                        item.SubItems.Add(podcast[i]);
                        i++;
                        ind++;
                        item.SubItems.Add(podcast[i]);
                        lwPodcast.Items.Add(item);
                        i++;
                        ind++;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void FillKategoriList()
        {
            try
            {
                var kategoriLista = bll.ConvertKategorierListToString();

                foreach (var kategori in kategoriLista)
                {
                    ListViewItem item = new ListViewItem(kategori);
                    lwKategori.Items.Add(item);
                }

                fyllcbKategori(kategoriLista);
            }
            catch (Exception ex)
            {

            }    
        }
        private void fyllcbKategori(List<string> kategoriLista)
        {

            try
            {
                cbKategori.DataSource = kategoriLista;
            }
            catch (Exception)
            {

            }
            
        }

        private void LoadForm()
        {
            try
            {
                bll.CreateJsonFile();
            }
            catch (Exception ex)
            {

            }
            this.cbFrekvens.SelectedIndex = 0;
            btTaBortPod.Enabled = false;
            btAndraPod.Enabled = false;
            btAndraKatagori.Enabled = false;
            btTaBortKategori.Enabled = false;
            
            this.tbAvsnittBeskrivning.ReadOnly = true;
            lwPodcast.FullRowSelect = true;
            

        }

        

        private void btNyPod_Click(object sender, EventArgs e)
        {
            try
            {
                var url = tbUrlPod.Text;
                if (!Validering.isEmpty(url))
                {
                    MessageBox.Show("Får ej lämna Url:n tom!");
                }
                if(Validering.finnsPodcast(url, bll))
                {
                    MessageBox.Show("En podcast med det namnet finns redan!");
                }
               else if (!Validering.CheckInternetConnection())
                {
                    MessageBox.Show("Du måste ha internet uppkoppling!");
                }
                else if (!Validering.IsValidFeedUrl(url))
                {
                    MessageBox.Show("Ange en korrekt rss url!");
                }
                else
                {
                    var frekvens = cbFrekvens.SelectedItem.ToString();
                    var kategori = cbKategori.SelectedItem.ToString();
                    bll.nyPodcast(url, kategori, frekvens);
                    bll.sparaPodcastLista();
                    lwPodcast.Items.Clear();
                    FillPodcastList();
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        
        private void lwPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selected = lwPodcast.SelectedItems;
                if (selected.Count > 0)
                {
                    btTaBortPod.Enabled = true;
                    btAndraPod.Enabled = true;
                    lwPodAvsnitt.Items.Clear();
                    tbAvsnittBeskrivning.Clear();
                    foreach (ListViewItem item in selected)
                    {
                        var namn = item.SubItems[0].Text;
                        var allaAvsnitt = bll.getPodcastAvsnittToString(namn);
                        tbUrlPod.Text = bll.getUrlfromPodcast(namn);
                        foreach (var avsnitt in allaAvsnitt)
                        {
                            var avsnittTitle = avsnitt;
                            ListViewItem item1 = new ListViewItem(avsnittTitle);
                            lwPodAvsnitt.Items.Add(item1);
                        }
                    }

                }
                else
                {
                    btTaBortPod.Enabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
      


        

        private void PodcastAppen_Load(object sender, EventArgs e)
        {
            try
            {
                bll.sparaPodcastLista();
            }
            catch
            {

            }
        }

        private void btAndraPod_Click(object sender, EventArgs e)
        {
            try 
            {
                string kategori = cbKategori.Text;
                string frekvens = cbFrekvens.Text;
                int index = lwPodcast.SelectedIndices[0];
                string url = tbUrlPod.Text;
                if (!Validering.isEmpty(url))
                {
                    MessageBox.Show("Du kan inte ändra till en tom url!");
                }
                else
                {
                    bll.ChangeJsonData(kategori, frekvens, index, url);
                    bll.getSparadPodcastLista();
                    bll.StartaTimer(url);
                    lwPodcast.Items.Clear();
                    FillPodcastList();
                }
            } 
            catch (Exception ex)
            {
                
            }
        }

        private void btNyKategori_Click(object sender, EventArgs e)
        {
            try
            {
                var kategori = tbKategori.Text;
                if (!Validering.isEmpty(kategori))
                {
                    MessageBox.Show("Kategorin får ej lämnas tom!");
                }
                if (Validering.finnsKategorin(kategori, bll))
                {
                    MessageBox.Show("Kategorin finns redan!");
                }

                else
                {
                    bll.nyKategori(kategori);
                    bll.sparaKategorierLista();
                    lwKategori.Items.Clear();
                    cbKategori.DataSource = null;
                    FillKategoriList();
                }
               
            }
            catch (Exception ex)
            {

            }
                
        }

      

        private void btTaBortPod_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lwPodcast.SelectedIndices[0];
                string namn = lwPodcast.Items[index].SubItems[0].Text;
                bll.DeleteJsonItem(namn);
                bll.getSparadPodcastLista();
                lwPodcast.Items.Clear();
                FillPodcastList();
                lwPodAvsnitt.Items.Clear();

                if (lwPodcast.Items.Count == 0)
                {
                    btTaBortPod.Enabled = false;
                    btAndraPod.Enabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btTaBortKategori_Click(object sender, EventArgs e)
        {

            try
            {
                if (lwKategori.SelectedItems.Count > 0)
                {
                    int index = lwKategori.SelectedIndices[0];
                    string kategorinamn = lwKategori.Items[index].SubItems[0].Text;

                    if (Validering.CantRemoveIngenKategori(index))
                    {

                        MessageBox.Show("Kan inte ta bort 'Ingen Kategori'");
                        tbKategori.Clear();
                    }
                    else
                    {
                        bll.DeleteKategoriFromJson(kategorinamn);
                        bll.getSparadKategorierLista();
                        lwKategori.Items.Clear();
                        cbKategori.DataSource = null;
                        FillKategoriList();
                        tbKategori.Clear();
                        bll.getSparadPodcastLista();
                        lwPodcast.Items.Clear();
                        FillPodcastList();
                    }
                }
            }
            catch (Exception ex)
            {

                
            }
           
        }

        private void btSortera_Click(object sender, EventArgs e)
        {
            try
            {
                string kategori = cbKategori.Text;
                bll.SorteraEfterKategori(kategori);
                lwPodcast.Items.Clear();
                FillPodcastListByKategori();
                btAndraPod.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void FillPodcastListByKategori()
        {
            try
            {
                var podcastLista = bll.ConvertPodcastListToString("SorteradKategori");

                int i = 0;

                foreach (var podcast in podcastLista)
                {
                    int ind = 0;
                    while (ind < 4)
                    {
                        ListViewItem item = new ListViewItem(podcast[i]);
                        i++;
                        ind++;
                        item.SubItems.Add(podcast[i]);
                        i++;
                        ind++;
                        item.SubItems.Add(podcast[i]);
                        i++;
                        ind++;
                        item.SubItems.Add(podcast[i]);
                        lwPodcast.Items.Add(item);
                        i++;
                        ind++;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            lwPodcast.Items.Clear();
            btAndraPod.Enabled = true;

            try
            {
                FillPodcastList();
            }
            catch (Exception ex)
            {

            }
        }

     

        private void lwPodAvsnitt_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                var selected = lwPodAvsnitt.SelectedItems;
                if (selected.Count > 0)
                {
                    tbAvsnittBeskrivning.Clear();
                    foreach (ListViewItem item in selected)
                    {
                        var avsnittNamn = item.SubItems[0].Text;
                        var avsnittBeskrivning = bll.getAvsnittBeskrivningByAvsnittName(avsnittNamn);
                        tbAvsnittBeskrivning.Text = avsnittBeskrivning;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void lwKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lwKategori.SelectedItems.Count > 0)
                {
                    var index = lwKategori.SelectedIndices[0];
                    btAndraKatagori.Enabled = true;
                    btTaBortKategori.Enabled = true;

                    string firstValue = lwKategori.Items[index].SubItems[0].Text;

                    tbKategori.Clear();
                    tbKategori.Text = firstValue;
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        private void btAndraKatagori_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lwKategori.SelectedIndices[0];
                
                string nykategori = tbKategori.Text;


                if (!Validering.isEmpty(nykategori))
                {
                    MessageBox.Show("Fältet får inte vara tomt!");
                }
                if (Validering.finnsKategorin(nykategori, bll))
                {
                    MessageBox.Show("Du kan inte ändra namnet till en kategori som redan finns!");
                }
                else if (Validering.CantModifyIngenKategori(index))
                {
                    MessageBox.Show("Går inte att ändra 'Ingen Kategori'");

                }
                else
                {
                    string oldkategori = lwKategori.Items[index].SubItems[0].Text;
                    bll.ChangeKategori(nykategori, index, oldkategori);
                    bll.getSparadKategorierLista();
                    lwKategori.Items.Clear();
                    cbKategori.DataSource = null;
                    FillKategoriList();
                    bll.sparaPodcastLista();
                    lwPodcast.Items.Clear();
                    FillPodcastList();

                }
            }
            catch (Exception ex)
            {

                
            }
            }

          
   

            
        
     
        private void PodcastAppen_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bll.sparaPodcastLista();
            }
            catch (Exception ex)
            {

            }
        }
    }

}
