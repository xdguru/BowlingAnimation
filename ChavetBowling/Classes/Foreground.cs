using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class Foreground : MonRectangleMovable
    {
        #region Données Membres
        //Frame
        private MonRectangle _frameTop, _frameBottom, _frameLeft, _frameRight;

        //Ball Return
        private MonRectangle _base1, _base3;
        private MonRectangleMovable _base2, _rail1, _rail2, _supp1, _supp2;
        private MonCercle _ball1, _ball2;
        #endregion

        #region Constructeurs
        public Foreground(PictureBox hebergeur, int xsg, int ysg, int lg, int ht, double angle, Color crayon)
         : base(hebergeur, xsg, ysg, lg, ht, angle, crayon)
        {
            //Frame
            this._frameTop = new MonRectangle(hebergeur, 0, 0, hebergeur.Width, 30, Color.Brown);
            this._frameBottom = new MonRectangle(hebergeur, 0, hebergeur.Height - 30, hebergeur.Width, 30, Color.Brown);
            this._frameLeft = new MonRectangle(hebergeur, 0, 0, 40, hebergeur.Height + 30, Color.Brown);
            this._frameRight = new MonRectangle(hebergeur, hebergeur.Width - 40, 0, 40, hebergeur.Height + 30, Color.Brown);

            //Ball Return
            this._base1 = new MonRectangle(hebergeur, 200, hebergeur.Height - _frameBottom.Hauteur - 50, 80, 50, Color.DarkSlateGray);
            this._base2 = new MonRectangleMovable(hebergeur, 200, hebergeur.Height - _frameBottom.Hauteur - _base1.Hauteur, 57, 57, Math.PI / 4, Color.DarkSlateGray);
            this._base3 = new MonRectangle(hebergeur, 200, hebergeur.Height - _frameBottom.Hauteur - _base1.Hauteur - 42, 40, 42, Color.DarkSlateGray);
            this._rail1 = new MonRectangleMovable(hebergeur, _frameLeft.Longueur - 25, hebergeur.Height - _frameBottom.Hauteur - 50, 10, 175, Math.PI / 2, Color.Black);
            this._rail2 = new MonRectangleMovable(hebergeur, _frameLeft.Longueur - 30, hebergeur.Height - _frameBottom.Hauteur - 30, 7, 175, Math.PI / 2, Color.Black);
            this._supp1 = new MonRectangleMovable(hebergeur, _frameLeft.Longueur + 30, hebergeur.Height - _frameBottom.Hauteur - 30, 7, 30, 0, Color.Black);
            this._supp2 = new MonRectangleMovable(hebergeur, _frameLeft.Longueur + 100, hebergeur.Height - _frameBottom.Hauteur - 30, 7, 30, 0, Color.Black);
            this._ball1 = new MonCercle(hebergeur, _frameLeft.Longueur + 40, hebergeur.Height - _frameBottom.Hauteur - 50, 20, Color.LawnGreen);
            this._ball2 = new MonCercle(hebergeur, _frameLeft.Longueur + 90, hebergeur.Height - _frameBottom.Hauteur - 50, 20, Color.Red);
        }
        #endregion

        #region Méthodes
        public override void Afficher(Graphics gr)
        {
            ////Ball Return
            this._base2.Afficher(gr);
            this._base1.Afficher(gr);
            this._base3.Afficher(gr);
            this._supp1.Afficher(gr);
            this._supp2.Afficher(gr);
            this._ball1.Afficher(gr);
            this._ball2.Afficher(gr);
            this._rail1.Afficher(gr);
            this._rail2.Afficher(gr);

            //Frame
            this._frameBottom.Afficher(gr);
            this._frameTop.Afficher(gr);
            this._frameLeft.Afficher(gr);
            this._frameRight.Afficher(gr);
        }
        public override void Cacher(Graphics gr)
        {
            //Ball Return
            this._base2.Cacher(gr);
            this._base1.Cacher(gr);
            this._base3.Cacher(gr);
            this._supp1.Cacher(gr);
            this._supp2.Cacher(gr);
            this._ball1.Cacher(gr);
            this._ball2.Cacher(gr);
            this._rail1.Cacher(gr);
            this._rail2.Cacher(gr);

            //Frame
            this._frameBottom.Cacher(gr);
            this._frameTop.Cacher(gr);
            this._frameLeft.Cacher(gr);
            this._frameRight.Cacher(gr);
        }
        public override void Bouger(int x, int y)
        {
            this._base2.Bouger(x, y);
            this._base1.Bouger(x, y);
            this._base3.Bouger(x, y);
            this._supp1.Bouger(x, y);
            this._supp2.Bouger(x, y);
            this._ball1.Bouger(x, y);
            this._ball2.Bouger(x, y);
            this._rail1.Bouger(x, y);
            this._rail2.Bouger(x, y);
        }
        #endregion
    }
}
