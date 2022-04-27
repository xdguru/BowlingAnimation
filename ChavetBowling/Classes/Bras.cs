using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class Bras : MonRectangleMovable
    {
        #region Données membres
        private MonRectangleMovable _avantBras, _main;
        #endregion

        #region Constructeurs
        public Bras(PictureBox hebergeur, int xsg, int ysg, int lg, int ht, Color centercolor, double angle)
         : base(hebergeur, xsg, ysg, lg, ht, angle, centercolor)
        {
            this._avantBras = new MonRectangleMovable(hebergeur, xsg, ysg + ht, lg, ht, 0, Color.LightPink);
            this._main = new MonRectangleMovable(hebergeur, xsg, ysg + ht + this._avantBras.Hauteur, lg, ht / 2, 0, Color.LightPink);
        }
        #endregion

        #region Methodes
        public void Bouger(int deplX, int deplY, double angleBase, double angleAvantB, double angleMain)
        {
            base.Bouger(deplX, deplY, angleBase);
            this._avantBras.Bouger(0, 0, 1.50 * angleAvantB);
            this._main.Bouger(0, 0, 1.75 * angleMain);

            this._avantBras.X = base.CIG.X;
            this._avantBras.Y = base.CIG.Y;

            CorrectionTranslation(_avantBras, _avantBras.SM, base.IM);
            CorrectionTranslation(_main, _main.SM, _avantBras.IM);
        }
        public override void Afficher(Graphics g)
        {
            base.Afficher(g);
            this._avantBras.X = base.CIG.X;
            this._avantBras.Y = base.CIG.Y;
            this._avantBras.Afficher(g);
            this._main.X = _avantBras.CIG.X;
            this._main.Y = _avantBras.CIG.Y;
            this._main.Afficher(g);
        }
        public override void Cacher(Graphics g)
        {
            base.Cacher(g);
            this._avantBras.X = base.CIG.X;
            this._avantBras.Y = base.CIG.Y;
            this._avantBras.Cacher(g);
            this._main.X = _avantBras.CIG.X;
            this._main.Y = _avantBras.CIG.Y;
            this._main.Cacher(g);
        }
        #endregion
    }
}
