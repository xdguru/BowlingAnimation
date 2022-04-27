using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class MonPersonnage : MonRectangleMovable
    {
        #region Données Membres
        private MonCercle _tete;
        private Bras _brasG, _brasD;
        private Jambe _jambeG, _jambeD;
        #endregion

        #region Constructeurs
        public MonPersonnage(PictureBox hebergeur, int xsg, int ysg, int lg, int ht, double angle, Color crayon)
         : base(hebergeur, xsg, ysg, lg, ht, angle, crayon)
        {
            this._tete = new MonCercle(hebergeur, xsg + lg / 2, ysg - ht / 4, ht / 4, Color.Black, Color.LightPink);
            this._brasG = new Bras(hebergeur, xsg + lg / 4, ysg + lg / 4, lg / 2, (int)(ht / 2.4), Color.MediumSpringGreen, 0);
            this._brasD = new Bras(hebergeur, xsg + lg / 4, ysg + lg / 4, lg / 2, (int)(ht / 2.4), Color.MediumSpringGreen, 0);
            this._jambeG = new Jambe(hebergeur, xsg + lg / 4, ysg + ht, lg / 2, ht / 2, Color.Gray, 0);
            this._jambeD = new Jambe(hebergeur, xsg + lg / 4, ysg + ht, lg / 2, ht / 2, Color.Gray, 0);
        }
        #endregion

        #region Méthodes
        public override void Afficher(Graphics gr)
        {
            //Attention à l'ordre d'affichage !
            this._brasG.Afficher(gr);
            this._jambeG.Afficher(gr);
            base.Afficher(gr);
            this._tete.Afficher(gr);
            this._jambeD.Afficher(gr);
            this._brasD.Afficher(gr);
        }
        public override void Cacher(Graphics gr)
        {
            base.Cacher(gr);
            this._tete.Cacher(gr);
            this._brasG.Cacher(gr);
            this._brasD.Cacher(gr);
            this._jambeG.Cacher(gr);
            this._jambeD.Cacher(gr);
        }//l'ancienne méthode Bouger qui est en réalité maintenant la méthode marcher
        public override void Bouger(int deplX, int deplY, double angle)
        {

            base.Bouger(deplX, deplY);
            this._tete.Bouger(deplX, deplY);
            this._brasG.Bouger(deplX, deplY, angle);
            this._brasD.Bouger(deplX, deplY, -angle);
            this._jambeG.Bouger(deplX, deplY, -angle);
            this._jambeD.Bouger(deplX, deplY, angle);

        }
        void MoveAllParts(int x)
        {
            this.Bouger(x, 0);
            this._tete.Bouger(x, 0);
            this._brasD.Bouger(x, 0);
            this._brasG.Bouger(x, 0);
            this._jambeD.Bouger(x, 0);
            this._jambeG.Bouger(x, 0);
        }

        #region Animation
        public void Prep(int i)
        {
            this._tete.Bouger(2, 2);
            this._brasD.Bouger(2, 2, 0, Math.PI / 12, Math.PI / 12);
            this._brasG.Bouger(2, 2, 0, Math.PI / 12, Math.PI / 12);
            base.Bouger(2, 2, -Math.PI / 90);
            this._jambeD.Bouger(0, 2, Math.PI / 24, -Math.PI / 24, 0);
            this._jambeG.Bouger(0, 2, Math.PI / 24, -Math.PI / 24, 0);
        }
        public void Step1(int i)
        {
            this._tete.Bouger(3, 0);
            this._brasD.Bouger(2, 0, Math.PI / 45, -Math.PI / 45, -Math.PI / 45);
            this._brasG.Bouger(2, 0, Math.PI / 25, -Math.PI / 55, -Math.PI / 55);
            base.Bouger(2, 0, -Math.PI / 90);
            this._jambeD.Bouger(0, 0, 0, Math.PI / 20, 0);
            this._jambeG.Bouger(0, -1, -Math.PI / 40, -Math.PI / 25, -Math.PI / 15);
            MoveAllParts(10);
        }
        public void Step2(int i)
        {
            this._tete.Bouger(0, 0);
            this._brasD.Bouger(0, -1, -Math.PI / 12, -Math.PI / 12 / 1.5, -Math.PI / 12 / 1.75);
            this._brasG.Bouger(0, 0, Math.PI / 90, Math.PI / 90 / 1.5, Math.PI / 90 / 1.75);
            base.Bouger(0, 0, 0);
            if (i < 3)
            {
                this._jambeD.Bouger(0, -1, -Math.PI / 40, -Math.PI / 15, 0);
                this._jambeG.Bouger(0, -2, Math.PI / 40, Math.PI / 20, Math.PI / 30);
            }
            else
            {
                this._jambeD.Bouger(0, 0, -Math.PI / 40, -Math.PI / 15, -Math.PI / 15);
                this._jambeG.Bouger(0, 2, 0, Math.PI / 14, Math.PI / 18);
            }
            MoveAllParts(10);
        }
        public void Step3(int i)
        {
            this._tete.Bouger(2, 1);
            this._brasD.Bouger(2, 1, -Math.PI / 20, -Math.PI / 20 / 1.5, -Math.PI / 20 / 1.75);
            this._brasG.Bouger(2, 1, Math.PI / 40, Math.PI / 40 / 1.5, Math.PI / 40 / 1.75);
            base.Bouger(2, 0, -Math.PI / 90);
            if (i < 3)
            {
                this._jambeD.Bouger(0, 0, Math.PI / 30, Math.PI / 20, Math.PI / 30);
                this._jambeG.Bouger(0, -1, -Math.PI / 40, -Math.PI / 15, 0);
            }
            else
            {
                this._jambeD.Bouger(0, 0, Math.PI / 40, Math.PI / 20, Math.PI / 20);
                this._jambeG.Bouger(0, 0, -Math.PI / 40, -Math.PI / 15, -Math.PI / 15);
            }
            MoveAllParts(10);
        }
        public void Step4(int i)
        {
            this._tete.Bouger(0, 2);
            this._brasD.Bouger(0, 2, Math.PI / 20, Math.PI / 20 / 1.5, Math.PI / 20 / 1.75);
            this._brasG.Bouger(0, 2, 0, 0, 0);
            base.Bouger(0, 2, 0);
            if (i < 3)
            {
                this._jambeD.Bouger(0, 2, -Math.PI / 40, -Math.PI / 15, -Math.PI / 90);
                this._jambeG.Bouger(0, 2, Math.PI / 12, Math.PI / 20, Math.PI / 16);
            }
            else
            {
                this._jambeD.Bouger(0, 1, -Math.PI / 20, -Math.PI / 20, -Math.PI / 10);
                this._jambeG.Bouger(0, 3, Math.PI / 20, Math.PI / 20, 0);
            }
            MoveAllParts(10);
        }
        public void Throw(int i)
        {
            if (i < 6)
            {
                this._tete.Bouger(0, 2);
                this._brasD.Bouger(0, 3, Math.PI / 12, Math.PI / 12 / 1.5, Math.PI / 12 / 1.75);
                this._brasG.Bouger(0, 3, Math.PI / 12, Math.PI / 12 / 1.5, Math.PI / 12 / 1.75);
                base.Bouger(0, 2, 0);
                this._jambeD.Bouger(0, 2, -Math.PI / 50, -Math.PI / 50, -Math.PI / 90);
                this._jambeG.Bouger(0, 2, Math.PI / 50, Math.PI / 50, 0);
            }
            else
            {
                this._brasD.Bouger(0, 0, Math.PI / 12, Math.PI / 12 / 1.5, Math.PI / 12 / 1.75);
            }
            MoveAllParts(10);
        }
        public void Roll(int i)
        {
            MoveAllParts(-55);
        }
        #endregion

        #endregion
    }
}
