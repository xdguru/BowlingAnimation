using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class Background : MonRectangleMovable
    {
        #region Données Membres
        private MonRectangle _floor, _gutter1, _gutter2, _wall;
        #endregion

        #region Constructeurs
        public Background(PictureBox hebergeur, int xsg, int ysg, int lg, int ht, double angle, Color crayon)
         : base(hebergeur, xsg, ysg, lg, ht, angle, crayon)
        {
            this._floor = new MonRectangle(hebergeur, 0, hebergeur.Height - 120, hebergeur.Width, 90, Color.DarkKhaki);
            this._gutter1 = new MonRectangle(hebergeur, 500, hebergeur.Height - 120, hebergeur.Width, 10, Color.DimGray);
            this._gutter2 = new MonRectangle(hebergeur, 500, hebergeur.Height - 40, hebergeur.Width, 10, Color.DimGray);
            this._wall = new MonRectangle(hebergeur, 0, 30, hebergeur.Width, hebergeur.Height - _floor.Hauteur - 60, Color.SaddleBrown);
        }
        #endregion

        #region Méthodes
        public override void Afficher(Graphics gr)
        {
            this._floor.Afficher(gr);
            this._gutter1.Afficher(gr);
            this._gutter2.Afficher(gr);
            this._wall.Afficher(gr);
        }
        public override void Cacher(Graphics gr)
        {
            this._floor.Cacher(gr);
            this._gutter1.Cacher(gr);
            this._gutter2.Cacher(gr);
            this._wall.Cacher(gr);
        }
        public override void Bouger(int deplX, int deplY)
        {
            this._gutter1.Bouger(deplX, deplY);
            this._gutter2.Bouger(deplX, deplY);
        }
        #endregion
    }
}
