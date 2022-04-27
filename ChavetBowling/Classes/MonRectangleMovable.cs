using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace ChavetBowling.Classes
{
    class MonRectangleMovable : MonPoint
    {
        #region Données membres
        private Color _pot = Color.Gray;
        private bool _remplir = true;
        private int _longueur = 1, _hauteur = 1;
        private double _angle;
        Point translation = new Point(0, 0);
        #endregion

        #region Accesseurs

        #region Accesseurs de base
        public double Angle { get; set; }
        public int Longueur
        {
            get { return this._longueur; }
            set
            {
                if (value <= 0) this._longueur = 1;
                else this._longueur = value;
            }
        }
        public int Hauteur
        {
            get { return this._hauteur; }
            set
            {
                if (value <= 0) this._hauteur = 1;
                else this._hauteur = value;
            }
        }
        public bool Remplir
        {
            get { return this._remplir; }
            set
            {
                this._remplir = value;
            }
        }
        public Color Pot
        {
            get { return this._pot; }
            set
            {
                try { this._pot = value; }
                catch { }
            }
        }
        #endregion

        #region Calcul des points
        //Attention, bien faire la différence entre le type de base Point et le type MonPoint
        public Point CSG
        {
            get { return new Point(X, Y); }
        }
        public Point CSD
        {
            get
            {
                return new Point((int)(X + Longueur * Cos(Angle)),
              (int)(Y - Longueur * Sin(Angle)));
            }
        }
        public Point CIG
        {
            get
            {
                return new Point((int)(X + Hauteur * Cos(3 * PI / 2 + Angle)),
              (int)(Y - Hauteur * Sin(3 * PI / 2 + Angle)));
            }
        }
        public Point CID
        {
            get
            {
                return new Point((int)(X + Longueur * Cos(Angle) + Hauteur * Cos(3 * PI / 2 + Angle)),
              (int)(Y - Longueur * Sin(Angle) - Hauteur * Sin(3 * PI / 2 + Angle)));
            }
        }
        #endregion

        #region Calcul des points milieux
        //création de deux points supplémentaires
        //le point Supérieur Milieu et Inférieur Milieu
        //Il suffira ainsi de les aligner pour obtenir la correction de la taille des membres
        //cela évite de devoir aligner le coin inférieur puis d'effectuer une translation
        public Point SM
        {
            get
            {
                return new Point((CSG.X + CSD.X) / 2, (CSG.Y + CSG.Y) / 2);
            }
        }
        public Point IM
        {
            get
            {
                return new Point((CIG.X + CID.X) / 2, (CIG.Y + CIG.Y) / 2);
            }
        }
        #endregion

        #endregion

        #region Constructeurs
        public MonRectangleMovable()
         : base()
        {
        }
        public MonRectangleMovable(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur)
         : base(hebergeur, xsg, ysg)
        {
            this.Angle = 0f;
            Longueur = longueur;
            Hauteur = hauteur;
            this.X = xsg;
            this.Y = ysg;
        }
        public MonRectangleMovable(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, double angle, Color pot)
         : base(hebergeur, xsg, ysg)
        {
            this.Angle = angle;
            Longueur = longueur;
            Hauteur = hauteur;
            Pot = pot;
            this.X = xsg;
            this.Y = ysg;

        }
        public MonRectangleMovable(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, Color crayon, Color pot)
         : base(hebergeur, xsg, ysg, crayon)
        {
            Longueur = longueur;
            Hauteur = hauteur;
            Pot = pot;
        }
        #endregion

        #region Methodes
        public virtual void Bouger(int deplX, int deplY, double diffangle)
        {
            base.Bouger(deplX, deplY);
            Angle += diffangle;
        }
        public override void Afficher(Graphics gr)
        {
            Point[] p = new Point[4];
            p[0] = CSG;
            p[1] = CSD;
            p[2] = CID;
            p[3] = CIG;
            if (this.Visible)
            {
                if (this.Remplir)
                {
                    gr.FillClosedCurve(new SolidBrush(this.Pot), p);
                }
                gr.DrawClosedCurve(new Pen(this.Crayon), p);
            }
        }
        public override void Cacher(Graphics gr)
        {
            Point[] p = new Point[4];
            p[0] = CSG;
            p[1] = CSD;
            p[2] = CID;
            p[3] = CIG;

            if (this.Remplir)
            {
                gr.FillClosedCurve(new SolidBrush(this.Fond), p);
            }
            gr.DrawClosedCurve(new Pen(this.Fond), p);
        }
        public virtual void Courir(int deplX, int deplY, double diffangle)
        {
            base.Bouger(deplX, deplY);
            this.Angle = diffangle;
        }
        public void CorrectionTranslation(MonRectangleMovable membreInf, Point membreInfPointMilieuSup, Point membreSupPointMilieuInf)
        {
            translation.X = membreInfPointMilieuSup.X - membreSupPointMilieuInf.X;
            translation.Y = membreInfPointMilieuSup.Y - membreSupPointMilieuInf.Y;
            membreInf.X -= translation.X;
            membreInf.Y -= translation.Y;
        }
        #endregion
    }
}
