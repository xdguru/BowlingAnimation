using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class MonPoint
    {
        #region Données membres
        private int _x = 0, _y = 0;
        private bool _visible = true;
        private PictureBox _hebergeur;
        private Color _fond = Color.Silver, _crayon = Color.Black;
        #endregion

        #region Accesseurs
        public int X
        {
            get { return _x; }
            set
            {
                if (value < 0) { this._x = 0; }
                else if (value > this._hebergeur.Bounds.Size.Width)
                { this._x = this._hebergeur.Bounds.Size.Width; }
                else { this._x = value; }
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (value < 0) { this._y = 0; }
                else if (value > this._hebergeur.Bounds.Size.Height)
                { this._y = this._hebergeur.Bounds.Size.Height; }
                else { this._y = value; }
            }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public Color Fond
        {
            get { return _fond; }
            set
            {
                try { _fond = value; }
                catch (Exception) { }
            }
        }

        public Color Crayon
        {
            get { return _crayon; }
            set
            {
                try { _crayon = value; }
                catch (Exception) { }
            }
        }

        public PictureBox Hebergeur
        {
            get { return _hebergeur; }
            set { _hebergeur = value; }
        }
        #endregion

        #region Construteurs
        public MonPoint()
        { this._hebergeur = null; }
        public MonPoint(PictureBox hebergeur)
        {
            this._hebergeur = hebergeur;
            _fond = hebergeur.BackColor;
        }
        public MonPoint(PictureBox hebergeur, int xy)
         : this(hebergeur)
        { _x = _y = xy; }
        public MonPoint(PictureBox hebergeur, int x, int y)
         : this(hebergeur)
        {
            _x = x;
            _y = y;
        }
        public MonPoint(PictureBox hebergeur, int xy, Color crayon)
         : this(hebergeur, xy)
        { _crayon = crayon; }
        public MonPoint(PictureBox hebergeur, int x, int y, Color crayon)
         : this(hebergeur, x, y)
        { _crayon = crayon; }
        #endregion

        #region Methodes
        public virtual void Afficher(Graphics gr)
        {
            if (this._visible)
            {
                gr.FillEllipse(new SolidBrush(Color.Yellow), this._x, this._y, 10, 10);
                gr.DrawEllipse(new Pen(this._crayon, 3), this._x, this._y, 10, 10);
            }
        }
        public virtual void Bouger(int deplX, int deplY)
        {
            _x += deplX;
            _y += deplY;
        }
        public virtual void Cacher(Graphics gr)
        {
            if (this._visible)
            {
                gr.FillEllipse(new SolidBrush(this._fond), this._x, this._y, 10, 10);
                gr.DrawEllipse(new Pen(this._fond, 3), this._x, this._y, 10, 10);
            }
        }
        #endregion
    }
}
