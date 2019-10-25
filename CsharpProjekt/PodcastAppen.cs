﻿using System;
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
            FillPodcastList();

        }

        private void FillPodcastList()
        {
            // lwPodcast.Clear();

           var podcastLista = bll.ConvertPodcastListToString();

            int i = 0;
            
            foreach (var podcast in podcastLista)
            {


                //if (podcastLista[i].Count == i - 3)
                //{

                //}
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

        /* private void FillAvsnittList(Podcast podcast)
         {
             lwPodAvsnitt.Clear();
             var avsnittList = podcast.getAvsnitt();

             foreach (var avsnitt in avsnittList)
             {
                 ListViewItem item = new ListViewItem(avsnitt.Name);
                 lwPodAvsnitt.Items.Add(item);
             }
         }*/

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
            FillPodcastList();





            //ListViewItem item = new ListViewItem(nyPodcast.Name);
            //item.SubItems.Add(nyPodcast.AntalAvsnitt.ToString());
            //item.SubItems.Add(nyPodcast.Frekvens);
            //item.SubItems.Add(nyPodcast.Kategori);
            //lwPodcast.Items.Add(item);
        }

        private void lwPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lwPodcast.SelectedItems;
            if (selected.Count > 0)
            {
                foreach (ListViewItem item in selected)
                {
                    var test = item.SubItems[0].Text;
                    ListViewItem item1 = new ListViewItem(test);
                    lwPodAvsnitt.Items.Add(item1);

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
            
        }
    }
}
