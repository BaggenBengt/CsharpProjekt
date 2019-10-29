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

namespace CsharpProjekt
{
    public partial class PodcastAppen : Form
    {

        public Bll bll { get; set; }

        public PodcastAppen()
        {
            InitializeComponent();
            bll = new Bll();
            LoadForm();
            bll.getSparadPodcastLista();
            bll.StartaTimer();
            FillPodcastList();
            startaUpdateAvGuiAsync();

        }
        public async Task startaUpdateAvGuiAsync()
        {
            Task task1 = Task.Run(() => startaUpdateAvGui());
            await task1;
        }
        public void startaUpdateAvGui()
        {
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Start();
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (lwPodcast.InvokeRequired)
            {
                lwPodcast.Invoke((MethodInvoker) delegate
                {
                    lwPodcast.Items.Clear();
                    FillPodcastList();
                });
            }
           
        }

        private void FillPodcastList()
        {
           var podcastLista = bll.ConvertPodcastListToString();

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

         //private void FillAvsnittList(List<string> avsnittList)
         //{
         //    lwPodAvsnitt.Items.Clear();
             
         //    foreach (var avsnitt in avsnittList)
         //    {
         //        ListViewItem item = new ListViewItem(avsnitt.Name);
         //        lwPodAvsnitt.Items.Add(item);
         //    }
         //}

        //private void FillAvsnittBeskrivning(Avsnitt avsnitt)
        //{
        //    tbAvsnittBeskrivning.Clear();
        //    tbAvsnittBeskrivning.Text = avsnitt.Beskrivning;
        //}
        private void LoadForm()
        {
            this.cbFrekvens.SelectedIndex = 0;
            this.cbKategori.SelectedIndex = 0;
            this.tbAvsnittBeskrivning.ReadOnly = true;
            lwPodcast.FullRowSelect = true;

        }

        

        private void btNyPod_Click(object sender, EventArgs e)
        {
            var url = tbUrlPod.Text;
            var frekvens = cbFrekvens.SelectedItem.ToString();
            var kategori = cbKategori.SelectedItem.ToString();

            bll.nyPodcast(url, kategori, frekvens);
            bll.sparaPodcastLista();
            lwPodcast.Items.Clear();
            FillPodcastList(); }

        
        private void lwPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var selected = lwPodcast.SelectedItems;
            if (selected.Count > 0)
            {
                lwPodAvsnitt.Items.Clear();
                tbAvsnittBeskrivning.Clear();
                foreach (ListViewItem item in selected)
                {
                    var namn = item.SubItems[0].Text;
                    var allaAvsnitt = bll.getPodcastAvsnittToString(namn);
                    foreach(var avsnitt in allaAvsnitt)
                    {
                        var avsnittTitle = avsnitt;
                        ListViewItem item1 = new ListViewItem(avsnittTitle);
                        lwPodAvsnitt.Items.Add(item1);
                    }
                }
            }

        }
      


        private void tbUrlPod_TextChanged(object sender, EventArgs e)
        {

        }

        private void PodcastAppen_Load(object sender, EventArgs e)
        {
            bll.sparaPodcastLista();
        }

        private void btAndraPod_Click(object sender, EventArgs e)
        {
            string kategori = cbKategori.Text;
            string frekvens = cbFrekvens.Text;
            int index = lwPodcast.SelectedIndices[0];
            string namn = lwPodcast.Items[index].SubItems[0].Text;

            bll.ChangeJsonData(kategori, frekvens, index);

            bll.getSparadPodcastLista();
            lwPodcast.Items.Clear();
            FillPodcastList();


        }

        private void btNyKategori_Click(object sender, EventArgs e)
        {
          
        }

        private void cbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btTaBortPod_Click(object sender, EventArgs e)
        {
            int index = lwPodcast.SelectedIndices[0];
            string namn = lwPodcast.Items[index].SubItems[0].Text;
            bll.DeleteJsonItem(namn);
            bll.getSparadPodcastLista();
            lwPodcast.Items.Clear();
            FillPodcastList();
            lwPodAvsnitt.Items.Clear();
        }

        private void btTaBortKategori_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btSortera_Click(object sender, EventArgs e)
        {
            string kategori = cbKategori.Text;
            bll.SorteraEfterKategori(kategori);
            lwPodcast.Items.Clear();
            FillPodcastListByKategori();
            btAndraPod.Enabled = false;
        }

        private void FillPodcastListByKategori()
        {
            var podcastLista = bll.ConvertPodcastListToStringByKategori();

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

        private void btReset_Click(object sender, EventArgs e)
        {
            lwPodcast.Items.Clear();
            FillPodcastList();
            btAndraPod.Enabled = true;
        }

        private void lwPodAvsnitt_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void lwPodAvsnitt_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void cbFrekvens_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PodcastAppen_FormClosing(object sender, FormClosingEventArgs e)
        {
            bll.sparaPodcastLista();
        }
    }

}
