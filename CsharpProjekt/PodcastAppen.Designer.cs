﻿namespace CsharpProjekt
{
    partial class PodcastAppen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btNyPod = new System.Windows.Forms.Button();
            this.btTaBortPod = new System.Windows.Forms.Button();
            this.btAndraPod = new System.Windows.Forms.Button();
            this.btAndraKatagori = new System.Windows.Forms.Button();
            this.btTaBortKategori = new System.Windows.Forms.Button();
            this.btNyKategori = new System.Windows.Forms.Button();
            this.tbKategori = new System.Windows.Forms.TextBox();
            this.tbUrlPod = new System.Windows.Forms.TextBox();
            this.lwKategori = new System.Windows.Forms.ListView();
            this.lwPodcast = new System.Windows.Forms.ListView();
            this.Namn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Avsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Frekvens = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwPodAvsnitt = new System.Windows.Forms.ListView();
            this.PodcastAvsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbAvsnittBeskrivning = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFrekvens = new System.Windows.Forms.ComboBox();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btSortera = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btNyPod
            // 
            this.btNyPod.Location = new System.Drawing.Point(272, 334);
            this.btNyPod.Margin = new System.Windows.Forms.Padding(4);
            this.btNyPod.Name = "btNyPod";
            this.btNyPod.Size = new System.Drawing.Size(100, 28);
            this.btNyPod.TabIndex = 0;
            this.btNyPod.Text = "Ny";
            this.btNyPod.UseVisualStyleBackColor = true;
            this.btNyPod.Click += new System.EventHandler(this.btNyPod_Click);
            // 
            // btTaBortPod
            // 
            this.btTaBortPod.Location = new System.Drawing.Point(393, 334);
            this.btTaBortPod.Margin = new System.Windows.Forms.Padding(4);
            this.btTaBortPod.Name = "btTaBortPod";
            this.btTaBortPod.Size = new System.Drawing.Size(100, 28);
            this.btTaBortPod.TabIndex = 1;
            this.btTaBortPod.Text = "Ta bort";
            this.btTaBortPod.UseVisualStyleBackColor = true;
            this.btTaBortPod.Click += new System.EventHandler(this.btTaBortPod_Click);
            // 
            // btAndraPod
            // 
            this.btAndraPod.Location = new System.Drawing.Point(513, 334);
            this.btAndraPod.Margin = new System.Windows.Forms.Padding(4);
            this.btAndraPod.Name = "btAndraPod";
            this.btAndraPod.Size = new System.Drawing.Size(100, 28);
            this.btAndraPod.TabIndex = 2;
            this.btAndraPod.Text = "Ändra";
            this.btAndraPod.UseVisualStyleBackColor = true;
            this.btAndraPod.Click += new System.EventHandler(this.btAndraPod_Click);
            // 
            // btAndraKatagori
            // 
            this.btAndraKatagori.Location = new System.Drawing.Point(1033, 334);
            this.btAndraKatagori.Margin = new System.Windows.Forms.Padding(4);
            this.btAndraKatagori.Name = "btAndraKatagori";
            this.btAndraKatagori.Size = new System.Drawing.Size(100, 28);
            this.btAndraKatagori.TabIndex = 5;
            this.btAndraKatagori.Text = "Ändra";
            this.btAndraKatagori.UseVisualStyleBackColor = true;
            // 
            // btTaBortKategori
            // 
            this.btTaBortKategori.Location = new System.Drawing.Point(913, 334);
            this.btTaBortKategori.Margin = new System.Windows.Forms.Padding(4);
            this.btTaBortKategori.Name = "btTaBortKategori";
            this.btTaBortKategori.Size = new System.Drawing.Size(100, 28);
            this.btTaBortKategori.TabIndex = 4;
            this.btTaBortKategori.Text = "Ta bort";
            this.btTaBortKategori.UseVisualStyleBackColor = true;
            this.btTaBortKategori.Click += new System.EventHandler(this.btTaBortKategori_Click);
            // 
            // btNyKategori
            // 
            this.btNyKategori.Location = new System.Drawing.Point(792, 334);
            this.btNyKategori.Margin = new System.Windows.Forms.Padding(4);
            this.btNyKategori.Name = "btNyKategori";
            this.btNyKategori.Size = new System.Drawing.Size(100, 28);
            this.btNyKategori.TabIndex = 3;
            this.btNyKategori.Text = "Ny";
            this.btNyKategori.UseVisualStyleBackColor = true;
            this.btNyKategori.Click += new System.EventHandler(this.btNyKategori_Click);
            // 
            // tbKategori
            // 
            this.tbKategori.Location = new System.Drawing.Point(755, 284);
            this.tbKategori.Margin = new System.Windows.Forms.Padding(4);
            this.tbKategori.Name = "tbKategori";
            this.tbKategori.Size = new System.Drawing.Size(395, 22);
            this.tbKategori.TabIndex = 6;
            // 
            // tbUrlPod
            // 
            this.tbUrlPod.Location = new System.Drawing.Point(40, 284);
            this.tbUrlPod.Margin = new System.Windows.Forms.Padding(4);
            this.tbUrlPod.Name = "tbUrlPod";
            this.tbUrlPod.Size = new System.Drawing.Size(260, 22);
            this.tbUrlPod.TabIndex = 7;
            this.tbUrlPod.TextChanged += new System.EventHandler(this.tbUrlPod_TextChanged);
            // 
            // lwKategori
            // 
            this.lwKategori.HideSelection = false;
            this.lwKategori.Location = new System.Drawing.Point(755, 36);
            this.lwKategori.Margin = new System.Windows.Forms.Padding(4);
            this.lwKategori.Name = "lwKategori";
            this.lwKategori.Size = new System.Drawing.Size(395, 198);
            this.lwKategori.TabIndex = 8;
            this.lwKategori.UseCompatibleStateImageBehavior = false;
            this.lwKategori.View = System.Windows.Forms.View.Details;
            // 
            // lwPodcast
            // 
            this.lwPodcast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Namn,
            this.Avsnitt,
            this.Frekvens,
            this.Kategori});
            this.lwPodcast.HideSelection = false;
            this.lwPodcast.Location = new System.Drawing.Point(39, 36);
            this.lwPodcast.Margin = new System.Windows.Forms.Padding(4);
            this.lwPodcast.Name = "lwPodcast";
            this.lwPodcast.Size = new System.Drawing.Size(572, 198);
            this.lwPodcast.TabIndex = 9;
            this.lwPodcast.UseCompatibleStateImageBehavior = false;
            this.lwPodcast.View = System.Windows.Forms.View.Details;
            this.lwPodcast.SelectedIndexChanged += new System.EventHandler(this.lwPodcast_SelectedIndexChanged);
            // 
            // Namn
            // 
            this.Namn.Text = "Namn";
            this.Namn.Width = 150;
            // 
            // Avsnitt
            // 
            this.Avsnitt.Text = "Avsnitt";
            this.Avsnitt.Width = 50;
            // 
            // Frekvens
            // 
            this.Frekvens.Text = "Frekvens";
            this.Frekvens.Width = 110;
            // 
            // Kategori
            // 
            this.Kategori.Text = "Kategori";
            this.Kategori.Width = 110;
            // 
            // lwPodAvsnitt
            // 
            this.lwPodAvsnitt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PodcastAvsnitt});
            this.lwPodAvsnitt.HideSelection = false;
            this.lwPodAvsnitt.Location = new System.Drawing.Point(40, 399);
            this.lwPodAvsnitt.Margin = new System.Windows.Forms.Padding(4);
            this.lwPodAvsnitt.Name = "lwPodAvsnitt";
            this.lwPodAvsnitt.Size = new System.Drawing.Size(572, 216);
            this.lwPodAvsnitt.TabIndex = 10;
            this.lwPodAvsnitt.UseCompatibleStateImageBehavior = false;
            this.lwPodAvsnitt.View = System.Windows.Forms.View.Details;
            this.lwPodAvsnitt.SelectedIndexChanged += new System.EventHandler(this.lwPodAvsnitt_SelectedIndexChanged_1);
            this.lwPodAvsnitt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lwPodAvsnitt_MouseClick);
            // 
            // PodcastAvsnitt
            // 
            this.PodcastAvsnitt.Text = "Avsnitt";
            this.PodcastAvsnitt.Width = 425;
            // 
            // tbAvsnittBeskrivning
            // 
            this.tbAvsnittBeskrivning.Location = new System.Drawing.Point(755, 399);
            this.tbAvsnittBeskrivning.Margin = new System.Windows.Forms.Padding(4);
            this.tbAvsnittBeskrivning.Multiline = true;
            this.tbAvsnittBeskrivning.Name = "tbAvsnittBeskrivning";
            this.tbAvsnittBeskrivning.Size = new System.Drawing.Size(395, 216);
            this.tbAvsnittBeskrivning.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(755, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kategori";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 262);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(755, 262);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ange kategori:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 377);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Podcast avsnitt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(307, 262);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Uppdateringsfrekvens:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(483, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "Kategori:";
            // 
            // cbFrekvens
            // 
            this.cbFrekvens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrekvens.FormattingEnabled = true;
            this.cbFrekvens.Items.AddRange(new object[] {
            "Var 5:e minut",
            "Var 20:e minut"});
            this.cbFrekvens.Location = new System.Drawing.Point(311, 284);
            this.cbFrekvens.Margin = new System.Windows.Forms.Padding(4);
            this.cbFrekvens.Name = "cbFrekvens";
            this.cbFrekvens.Size = new System.Drawing.Size(167, 24);
            this.cbFrekvens.TabIndex = 18;
            this.cbFrekvens.SelectedIndexChanged += new System.EventHandler(this.cbFrekvens_SelectedIndexChanged);
            // 
            // cbKategori
            // 
            this.cbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Items.AddRange(new object[] {
            "Skräck",
            "Humor",
            "Historia"});
            this.cbKategori.Location = new System.Drawing.Point(487, 284);
            this.cbKategori.Margin = new System.Windows.Forms.Padding(4);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(125, 24);
            this.cbKategori.TabIndex = 19;
            this.cbKategori.SelectedIndexChanged += new System.EventHandler(this.cbKategori_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(751, 377);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Avsnitt beskrivning";
            // 
            // btSortera
            // 
            this.btSortera.Location = new System.Drawing.Point(633, 334);
            this.btSortera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSortera.Name = "btSortera";
            this.btSortera.Size = new System.Drawing.Size(87, 28);
            this.btSortera.TabIndex = 21;
            this.btSortera.Text = "Sortera";
            this.btSortera.UseVisualStyleBackColor = true;
            this.btSortera.Click += new System.EventHandler(this.btSortera_Click);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(633, 284);
            this.btReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(87, 28);
            this.btReset.TabIndex = 22;
            this.btReset.Text = "Återställ";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // PodcastAppen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 656);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btSortera);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.cbFrekvens);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAvsnittBeskrivning);
            this.Controls.Add(this.lwPodAvsnitt);
            this.Controls.Add(this.lwPodcast);
            this.Controls.Add(this.lwKategori);
            this.Controls.Add(this.tbUrlPod);
            this.Controls.Add(this.tbKategori);
            this.Controls.Add(this.btAndraKatagori);
            this.Controls.Add(this.btTaBortKategori);
            this.Controls.Add(this.btNyKategori);
            this.Controls.Add(this.btAndraPod);
            this.Controls.Add(this.btTaBortPod);
            this.Controls.Add(this.btNyPod);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PodcastAppen";
            this.Text = "Podcast";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PodcastAppen_FormClosing);
            this.Load += new System.EventHandler(this.PodcastAppen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btNyPod;
        private System.Windows.Forms.Button btTaBortPod;
        private System.Windows.Forms.Button btAndraPod;
        private System.Windows.Forms.Button btAndraKatagori;
        private System.Windows.Forms.Button btTaBortKategori;
        private System.Windows.Forms.Button btNyKategori;
        private System.Windows.Forms.TextBox tbKategori;
        private System.Windows.Forms.TextBox tbUrlPod;
        private System.Windows.Forms.ListView lwKategori;
        private System.Windows.Forms.ListView lwPodcast;
        private System.Windows.Forms.ListView lwPodAvsnitt;
        private System.Windows.Forms.TextBox tbAvsnittBeskrivning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFrekvens;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader Namn;
        private System.Windows.Forms.ColumnHeader Avsnitt;
        private System.Windows.Forms.ColumnHeader Frekvens;
        private System.Windows.Forms.ColumnHeader Kategori;
        private System.Windows.Forms.ColumnHeader PodcastAvsnitt;
        private System.Windows.Forms.Button btSortera;
        private System.Windows.Forms.Button btReset;
    }
}

