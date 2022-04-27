using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class MonRectangle : MonPoint
    {
        #region Données membres
        private Color _pot = Color.Red;
        private bool _remplir = true;
        private int _hauteur = 1;
        private int _longueur = 1;
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

        public int Longueur
        {
            get { return _longueur; }
            set
            {
                if (value < 0) { _longueur = 1; }
                else { _longueur = value; }
            }
        }

        public int Hauteur
        {
            get { return _hauteur; }
            set
            {
                if (value < 0) { _hauteur = 1; }
                else { _hauteur = value; }
            }
        }
        #endregion

        #region Constructeurs
        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg)
        {
            Longueur = longueur;
            Hauteur = hauteur;
        }

        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, Color pot) : base(hebergeur, xsg, ysg)
        {
            Longueur = longueur;
            Hauteur = hauteur;
            Pot = pot;
        }

        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, Color crayon, Color pot) : base(hebergeur, xsg, ysg)
        {
            Longueur = longueur;
            Hauteur = hauteur;
            Pot = pot;
        }

        #endregion

        #region Méthodes

        public override void Afficher(Graphics gr)
        {
            if (this.Visible)
            {
                if (this.Remplir)
                {
                    gr.FillRectangle(new SolidBrush(this.Pot), this.X, this.Y, this.Longueur, this.Hauteur);
                }
                gr.DrawRectangle(new Pen(this.Crayon), this.X, this.Y, this.Longueur, this.Hauteur);
            }
        }

        public override void Cacher(Graphics gr)
        {
            if (this.Remplir)
            {
                gr.FillRectangle(new SolidBrush(this.Fond), this.X, this.Y, this.Longueur, this.Hauteur);
            }
            gr.DrawRectangle(new Pen(this.Fond), this.X, this.Y, this.Longueur, this.Hauteur);
        }
        #endregion
    }
}
