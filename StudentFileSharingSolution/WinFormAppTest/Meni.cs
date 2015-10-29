using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormAppTest
{
    public partial class Meni : Form
    {
        public Meni()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form nova = new KorisnikForm();
            nova.ShowDialog();
        }

        private void универзитетиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new UstanovaForm();
            nova.ShowDialog();
        }

        private void институцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new InstitucijaForm();
            nova.ShowDialog();
        }

        private void областиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new OblastForm();
            nova.ShowDialog();
        }

        private void насокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new NasokaForm ();
            nova.ShowDialog();
        }

        private void делToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new DeloviForm ();
            nova.ShowDialog();
        }

        private void предметToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new PredmetForm();
            nova.ShowDialog();
        }

        private void материјалиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new Materijali();
            nova.Show();
        }

        private void изборИУОНToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new IUONIzborFoma();
            nova.ShowDialog();
        }

        private void поставиМатеријалНаПредметToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new MaterijaliPredmeti();
            nova.ShowDialog();
        }

        private void предметиПоНасокаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nova = new DelZaPredmetPoNasokaForm();
            nova.ShowDialog();
        }
    }
}
