using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class MonCercle : MonPoint
    {
        #region Données membres
        private Color _pot = Color.Red;
        private bool _remplir = true;
        private int _rayon = 1;
        #endregion

        #region Accesseurs
        public Color Pot
        {
            get { return _pot; }
            set
            {
                try { _pot = value; }
                catch (Exception) { }
            }
        }

        public bool Remplir
        {
            get { return _remplir; }
            set { _remplir = value; }
        }

        public int Rayon
        {
            get { return _rayon; }
            set
            {
                if (value < 0) { _rayon = 1; }
                else { _rayon = value; }
            }
        }
        #endregion

        #region Construteurs
        public MonCercle(PictureBox hebergeur, int xc, int yc, int rayon) : base(hebergeur, xc, yc)
        {
            Rayon = rayon;
        }

        public MonCercle(PictureBox hebergeur, int xc, int yc, int rayon, Color pot) : base(hebergeur, xc, yc)
        {
            Rayon = rayon;
            Pot = pot;
        }

        public MonCercle(PictureBox hebergeur, int xc, int yc, int rayon, Color crayon, Color pot)
            : base(hebergeur, xc, yc, crayon)
        {
            //MessageBox.Show("Création cercle");
            Rayon = rayon;
            Pot = pot;
        }
        #endregion

        #region Methodes
        public override void Afficher(Graphics gr)
        {
            if (this.Visible)
            {
                if (this.Remplir)
                {
                    //on dessine le cercle (le point de référence de la classe MonPoint est au centre du cercle, il faut
                    //lui retirer le rayon 2*this.Rayon est la largeur et la hauteur
                    //Remplit l'intérieur d'une ellipse définie par un rectangle englobant
                    gr.FillEllipse(new SolidBrush(this.Pot), this.X - this.Rayon, this.Y - this.Rayon, 2 * this.Rayon, 2 * this.Rayon);
                }
                gr.DrawEllipse(new Pen(this.Crayon), this.X - this.Rayon, this.Y - this.Rayon, 2 * this.Rayon, 2 * this.Rayon);
            }
        }

        public override void Cacher(Graphics gr)
        {
            if (this.Remplir)
            {
                gr.FillEllipse(new SolidBrush(this.Fond), this.X - this.Rayon, this.Y - this.Rayon, 2 * this.Rayon, 2 * this.Rayon);
            }
            gr.DrawEllipse(new Pen(this.Fond), this.X - this.Rayon, this.Y - this.Rayon, 2 * this.Rayon, 2 * this.Rayon);
        }
        #endregion
    }
}
