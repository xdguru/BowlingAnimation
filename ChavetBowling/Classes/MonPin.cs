using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class MonPin : MonRectangleMovable
    {
        #region Données Membres
        private MonCercle _tete;
        private MonRectangleMovable _base;
        private MonRectangleMovable _red1, _red2;
        public bool hit = false;
        #endregion

        #region Constructeurs
        public MonPin(PictureBox hebergeur, int xsg, int ysg, int lg, int ht, double angle, Color crayon)
         : base(hebergeur, xsg, ysg, lg, ht, angle, crayon)
        {
            this._tete = new MonCercle(hebergeur, xsg + 4, ysg - 3, 6, Color.Black, Color.White);
            this._red1 = new MonRectangleMovable(hebergeur, xsg, ysg, 8, 3, Color.Red, Color.Red);
            this._red2 = new MonRectangleMovable(hebergeur, xsg, ysg + 11, 8, 3, Color.Red, Color.Red);
            this._base = new MonRectangleMovable(hebergeur, xsg - 3, ysg + 16, 14, 30, Color.Black, Color.White);
        }
        #endregion

        #region Méthodes
        public override void Bouger(int deplX, int deplY, double diffangle)
        {
            base.Bouger(deplX, deplY, diffangle);
            this._tete.Bouger(deplX, deplY);
            this._red1.Bouger(deplX, deplY, diffangle);
            this._red2.Bouger(deplX, deplY, diffangle);
            this._base.Bouger(deplX, deplY, diffangle);
        }
        public override void Afficher(Graphics gr)
        {
            base.Afficher(gr);
            this._tete.Afficher(gr);
            this._base.Afficher(gr);
            this._red1.Afficher(gr);
            this._red2.Afficher(gr);
        }
        public override void Cacher(Graphics gr)
        {
            base.Cacher(gr);
            this._tete.Cacher(gr);
            this._red1.Cacher(gr);
            this._red2.Cacher(gr);
            this._base.Cacher(gr);
        }
        void MoveAllParts(int x, int y)
        {
            this.Bouger(x, y);
            this._tete.Bouger(x, y);
            this._red1.Bouger(x, y);
            this._red2.Bouger(x, y);
            this._base.Bouger(x, y);
        }
        
        #region Animation
        public void Hit1(int i)
        {
            if (i == 0)
            {
                this.Bouger(0, 0, Math.PI / 12);
                this._tete.Bouger(-2, -2);
                this._red2.Bouger(3, -3);
                this._base.Bouger(4, -3);
                MoveAllParts(2, -3);
            }
            if (i == 1)
            {
                this.Bouger(0, 0, Math.PI / 12);
                this._tete.Bouger(-2, -1);
                this._red2.Bouger(2, -2);
                this._base.Bouger(3, -2);
                MoveAllParts(2, -3);
            }
            if (i == 2)
            {
                this.Bouger(0, 0, Math.PI / 12);
                this._tete.Bouger(-1, 0);
                this._red2.Bouger(1, -1);
                this._base.Bouger(3, -1);
                MoveAllParts(2, -3);
            }
            if (i == 3)
            {
                this.Bouger(0, 0, Math.PI / 12);
                this._tete.Bouger(-1, 0);
                this._red2.Bouger(1, -1);
                this._base.Bouger(3, 0);
                MoveAllParts(2, 5);
            }
            if (i == 4)
            {
                this.Bouger(0, 0, Math.PI / 12);
                this._tete.Bouger(-1, 0);
                this._red2.Bouger(2, -1);
                this._base.Bouger(3, -4);
                MoveAllParts(2, 10);
            }
            if (i == 5)
            {
                this.Bouger(0, 0, Math.PI / 12);
                this._tete.Bouger(-1, 1);
                this._red2.Bouger(2, -3);
                this._base.Bouger(3, -2);
                MoveAllParts(2, 20);
            }
        }
        public void Hit2(int i)
        {
            if (i == 0)
            {
                this.Bouger(0, 0, -Math.PI / 16);
                this._tete.Bouger(1, 0);
                this._red2.Bouger(-2, -4);
                this._base.Bouger(-3, -6);
                MoveAllParts(10, -4);
            }
            if (i == 1)
            {
                this.Bouger(0, 0, -Math.PI / 16);
                this._tete.Bouger(0, 1);
                this._red2.Bouger(0, 0);
                this._base.Bouger(-1, 0);
                MoveAllParts(10, -2);
            }
            if (i == 2)
            {
                this.Bouger(0, 0, -Math.PI / 16);
                this._tete.Bouger(0, 1);
                this._red2.Bouger(-2, 0);
                this._base.Bouger(-2, -1);
                MoveAllParts(10, 0);
            }
            if (i == 3)
            {
                this.Bouger(0, 0, -Math.PI / 16);
                this._tete.Bouger(0, 1);
                this._red2.Bouger(-1, -1);
                this._base.Bouger(-1, -2);
                MoveAllParts(10, 5);
            }
            if (i == 4)
            {
                this.Bouger(0, 0, -Math.PI / 8);
                this._tete.Bouger(-1, 2);
                this._red2.Bouger(-2, -3);
                this._base.Bouger(-3, -4);
                MoveAllParts(10, 10);
            }
            if (i == 5)
            {
                this.Bouger(0, 0, -Math.PI / 8);
                this._tete.Bouger(-1, 2);
                this._red2.Bouger(-4, -3);
                this._base.Bouger(-2, -5);
                MoveAllParts(10, 20);
            }
        }
        public void Hit3(int i)
        {
            if (i == 0)
            {
                this.Bouger(0, 0, -Math.PI / 6);
                this._tete.Bouger(1, 2);
                this._red2.Bouger(-3, -5);
                this._base.Bouger(-5, -8);
                MoveAllParts(20, -4);
            }
            if (i == 1)
            {
                this.Bouger(0, 0, -Math.PI / 6);
                this._tete.Bouger(0, 2);
                this._red2.Bouger(-3, -2);
                this._base.Bouger(-3, -5);
                MoveAllParts(20, -2);
            }
            if (i == 2)
            {
                this.Bouger(0, 0, -Math.PI / 6);
                this._tete.Bouger(-1, 3);
                this._red2.Bouger(-3, -4);
                this._base.Bouger(-2, -5);
                MoveAllParts(20, 0);
            }
            if (i == 3)
            {
                this.Bouger(0, 0, -Math.PI / 6);
                this._tete.Bouger(-4, 0);
                this._red2.Bouger(-1, -5);
                this._base.Bouger(1, -8);
                MoveAllParts(20, 5);
            }
            if (i == 4)
            {
                this.Bouger(0, 0, -Math.PI / 6);
                this.Bouger(0, 0, -Math.PI / 16);
                this._tete.Bouger(-3, 0);
                this._red2.Bouger(8, -2);
                this._base.Bouger(11, -2);
                MoveAllParts(20, 10);
            }
            if (i == 5)
            {
                this.Bouger(0, 0, -Math.PI / 6);
                this.Bouger(0, 0, -Math.PI / 16);
                this._tete.Bouger(-2, -3);
                this._red2.Bouger(6, -1);
                this._base.Bouger(8, 0);
                MoveAllParts(20, 20);
            }
            if (i == 6)
            {
                this.Bouger(0, 0, -Math.PI / 6);
                this.Bouger(0, 0, -Math.PI / 16);
                this._tete.Bouger(-1, -3);
                this._red2.Bouger(2, 5);
                this._base.Bouger(4, 9);
                MoveAllParts(20, 20);
            }
        }
        #endregion

        #endregion
    }
}