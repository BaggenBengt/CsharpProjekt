using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace CsharpProjekt
{
    public partial class PodcastAppen : Form
    {
         
        public Bll bll { get; set; }
        

        public PodcastAppen()
        {
            InitializeComponent();
            LoadForm();
            bll = new Bll();
            bll.getSparadPodcastLista();
            bll.getSparadKategorierLista();
           FillKategoriList();
            FillPodcastList();
            

        }

        private void FillPodcastList()
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
        private void FillKategoriList()
        {
            var kategoriLista = bll.ConvertKategorierListToString();

           

            foreach (var kategori in kategoriLista)
            {

                ListViewItem item = new ListViewItem(kategori);
                lwKategori.Items.Add(item);
               
     
            }

            fyllcbKategori(kategoriLista);         
        }
        private void fyllcbKategori(List<string> kategoriLista)
        {
            foreach (var kategori in kategoriLista)
            {

                cbKategori.Items.Add(kategori);
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
            var kategori = tbKategori.Text;
            bll.nyKategori(kategori);
            bll.sparaKategorierLista();
            lwKategori.Items.Clear();
            cbKategori.Items.Clear();
            FillKategoriList();
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
            int index = lwKategori.SelectedIndices[0];
            string kategorinamn = lwKategori.Items[index].SubItems[0].Text;
            bll.DeleteKategoriFromJson(kategorinamn);
            bll.getSparadKategorierLista();
            lwKategori.Items.Clear();
            cbKategori.Items.Clear();
            FillKategoriList();
            tbKategori.Clear();
            
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

        private void lwKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lwKategori.SelectedItems.Count > 0)
            {
                var index = lwKategori.SelectedIndices[0];

                string firstValue = lwKategori.Items[index].SubItems[0].Text;

                tbKategori.Clear();
                tbKategori.Text = firstValue;
            } 
        }

        private void btAndraKatagori_Click(object sender, EventArgs e)
        {
            string nykategori = tbKategori.Text;
            int index = lwKategori.SelectedIndices[0];
            string oldkategori = lwKategori.Items[index].SubItems[0].Text;
            bll.ChangeKategori(nykategori, index, oldkategori);
            bll.getSparadKategorierLista();
            lwKategori.Items.Clear();
            cbKategori.Items.Clear();
            FillKategoriList();
            bll.sparaPodcastLista();
            lwPodcast.Items.Clear();
            FillPodcastList();
        


    }
    }
}
