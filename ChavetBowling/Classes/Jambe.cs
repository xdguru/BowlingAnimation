using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class Jambe : MonRectangleMovable
    {
        #region Données membres
        private MonRectangleMovable _mollet, _pied;
        #endregion

        #region Constructeurs
        public Jambe(PictureBox hebergeur, int xsg, int ysg, int lg, int ht, Color centercolor, double angle)
         : base(hebergeur, xsg, ysg, lg, ht, angle, centercolor)
        {
            this._mollet = new MonRectangleMovable(hebergeur, xsg, ysg + ht, lg, ht, 0, Color.Gray);
            this._pied = new MonRectangleMovable(hebergeur, xsg, ysg + ht + this._mollet.Hauteur, lg * 2, ht / 4, 0, Color.Brown);
        }
        #endregion

        #region Méthodes
        public void Bouger(int deplX, int deplY, double angleBase, double angleMollet, double anglePied)
        {
            base.Bouger(deplX, deplY, angleBase);
            this._mollet.Bouger(0, 0, angleMollet);
            this._pied.Bouger(0, 0, anglePied);

            this._mollet.X = base.CIG.X;
            this._mollet.Y = base.CIG.Y;

            CorrectionTranslation(_mollet, _mollet.SM, base.IM);
            CorrectionTranslation(_pied, _pied.SM, _mollet.IM);
        }
        public override void Afficher(Graphics g)
        {
            base.Afficher(g);
            this._mollet.X = base.CIG.X;
            this._mollet.Y = base.CIG.Y;
            this._mollet.Afficher(g);
            this._pied.X = _mollet.CIG.X;
            this._pied.Y = _mollet.CIG.Y;
            this._pied.Afficher(g);
        }
        public override void Cacher(Graphics g)
        {
            base.Cacher(g);
            this._mollet.X = base.CIG.X;
            this._mollet.Y = base.CIG.Y;
            this._mollet.Cacher(g);
            this._pied.X = _mollet.CIG.X;
            this._pied.Y = _mollet.CIG.Y;
            this._pied.Cacher(g);
        }
        #endregion
    }
}
