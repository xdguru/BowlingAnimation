using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ChavetBowling.Classes
{
    class Scene : MonRectangleMovable
    {
        #region Données Membres
        private MonPersonnage _jimmy;
        private MonCercle _ball;
        private MonPin _pin1, _pin2, _pin3, _pin4, _pin5, _pin6, _pin7, _pin8, _pin9, _pin10;
        int _speed = 75;
        int[] _pinstart = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        #endregion

        #region Constructeur
        public Scene(PictureBox hebergeur, int xsg, int ysg, int lg, int ht, double angle, Color crayon)
         : base(hebergeur, xsg, ysg, lg, ht, angle, crayon)
        {
            this._jimmy = new MonPersonnage(hebergeur, 70, hebergeur.Height - 185, 20, 60, 0, Color.MediumSpringGreen);

            this._ball = new MonCercle(hebergeur, this._jimmy.X + this._jimmy.Longueur / 2, this._jimmy.Y + this._jimmy.Hauteur + 15, 15, Color.Black, Color.Purple);

            this._pin1 = new MonPin(hebergeur, 725, hebergeur.Height - 110, 8, 32, 0, Color.White);
            this._pin2 = new MonPin(hebergeur, 725, hebergeur.Height - 115, 8, 32, 0, Color.White);
            this._pin3 = new MonPin(hebergeur, 725, hebergeur.Height - 105, 8, 32, 0, Color.White);
            this._pin4 = new MonPin(hebergeur, 725, hebergeur.Height - 120, 8, 32, 0, Color.White);
            this._pin5 = new MonPin(hebergeur, 725, hebergeur.Height - 110, 8, 32, 0, Color.White);
            this._pin6 = new MonPin(hebergeur, 725, hebergeur.Height - 100, 8, 32, 0, Color.White);
            this._pin7 = new MonPin(hebergeur, 725, hebergeur.Height - 125, 8, 32, 0, Color.White);
            this._pin8 = new MonPin(hebergeur, 725, hebergeur.Height - 115, 8, 32, 0, Color.White);
            this._pin9 = new MonPin(hebergeur, 725, hebergeur.Height - 105, 8, 32, 0, Color.White);
            this._pin10 = new MonPin(hebergeur, 725, hebergeur.Height - 95, 8, 32, 0, Color.White);
        }
        #endregion

        #region Méthodes
        public override void Afficher(Graphics gr)
        {
            this._jimmy.Afficher(gr);
            //Ball going through the middle of Pins
            this._pin1.Afficher(gr);
            this._pin2.Afficher(gr);
            this._pin4.Afficher(gr);
            this._pin5.Afficher(gr);
            this._pin7.Afficher(gr);
            this._pin8.Afficher(gr);
            this._ball.Afficher(gr); //Ball
            this._pin3.Afficher(gr);
            this._pin6.Afficher(gr);
            this._pin9.Afficher(gr);
            this._pin10.Afficher(gr);
        }
        public override void Cacher(Graphics gr)
        {
            this._jimmy.Cacher(gr);
            this._ball.Cacher(gr);
            this._pin1.Cacher(gr);
            this._pin2.Cacher(gr);
            this._pin3.Cacher(gr);
            this._pin4.Cacher(gr);
            this._pin5.Cacher(gr);
            this._pin6.Cacher(gr);
            this._pin7.Cacher(gr);
            this._pin8.Cacher(gr);
            this._pin9.Cacher(gr);
            this._pin10.Cacher(gr);
        }

        #region Animation
        public void Prep(Graphics gr, int i)
        {
            #region Positioner
            this._jimmy.Prep(i);

            switch (i)
            {
                case 0:
                    this._ball.Bouger(25, -20);
                    break;
                case 1:
                    this._ball.Bouger(6, -15);
                    break;
                case 2:
                    this._ball.Bouger(6, -10);
                    break;
                default: break;
            }
            #endregion

            this.Afficher(gr);
            Thread.Sleep(_speed);
        }
        public void Step1(Graphics gr, int i)
        {
            #region Positioner
            this._jimmy.Step1(i);

            this._ball.Bouger(10, 0);
            switch (i)
            {
                case 0:
                    this._ball.Bouger(3, 2);
                    break;
                case 1:
                    this._ball.Bouger(4, 4);
                    break;
                case 2:
                    this._ball.Bouger(3, 3);
                    break;
                case 3:
                    this._ball.Bouger(3, 3);
                    break;
                case 4:
                    this._ball.Bouger(3, 2);
                    break;
                default: break;
            }
            #endregion

            this.Afficher(gr);
            Thread.Sleep(_speed);
        }
        public void Step2(Graphics gr, int i)
        {
            #region Positioner
            this._jimmy.Step2(i);

            this._ball.Bouger(10, 0);
            switch (i)
            {
                case 0:
                    this._ball.Bouger(-10, 9);
                    break;
                case 1:
                    this._ball.Bouger(-14, 9);
                    break;
                case 2:
                    this._ball.Bouger(-13, 1);
                    break;
                case 3:
                    this._ball.Bouger(-14, -1);
                    break;
                case 4:
                    this._ball.Bouger(-14, -6);
                    break;
                case 5:
                    this._ball.Bouger(-11, -7);
                    break;
                case 6:
                    this._ball.Bouger(-13, -10);
                    break;
                default:
                    break;
            }
            #endregion

            this.Afficher(gr);
            Thread.Sleep(_speed);
        }
        public void Step3(Graphics gr, int i)
        {
            #region Positioner
            this._jimmy.Step3(i);

            this._ball.Bouger(10, 0);
            switch (i)
            {
                case 0:
                    this._ball.Bouger(-5, -8);
                    break;
                case 1:
                    this._ball.Bouger(-2, -8);
                    break;
                case 2:
                    this._ball.Bouger(-2, -8);
                    break;
                case 3:
                    this._ball.Bouger(0, -8);
                    break;
                case 4:
                    this._ball.Bouger(2, -10);
                    break;
                case 5:
                    this._ball.Bouger(3, -11);
                    break;
                default:
                    break;
            }
            #endregion

            this.Afficher(gr);
            Thread.Sleep(_speed);
        }
        public void Step4(Graphics gr, int i)
        {
            #region Positioner
            this._jimmy.Step4(i);

            this._ball.Bouger(10, 0);
            switch (i)
            {
                case 0:
                    this._ball.Bouger(3, 15);
                    break;
                case 1:
                    this._ball.Bouger(3, 15);
                    break;
                case 2:
                    this._ball.Bouger(0, 9);
                    break;
                case 3:
                    this._ball.Bouger(2, 9);
                    break;
                case 4:
                    this._ball.Bouger(2, 9);
                    break;
                case 5:
                    this._ball.Bouger(6, 11);
                    break;
                default: break;
            }
            #endregion

            this.Afficher(gr);
            Thread.Sleep(_speed);
        }
        public void Throw(Graphics gr, int i)
        {
            #region Positioner
            this._jimmy.Throw(i);

            this._ball.Bouger(10, 0);
            switch (i)
            {
                case 0:
                    this._ball.Bouger(12, 14);
                    break;
                case 1:
                    this._ball.Bouger(11, 11);
                    break;
                case 2:
                    this._ball.Bouger(16, 6);
                    break;
                case 3:
                    this._ball.Bouger(12, 2);
                    break;
                case 4:
                    this._ball.Bouger(13, 0);
                    break;
                case 5:
                    this._ball.Bouger(15, 0);
                    break;
                case 6:
                    this._ball.Bouger(15, 0);
                    break;
                case 7:
                    this._ball.Bouger(15, 6);
                    break;
                case 8:
                    this._ball.Bouger(15, 6);
                    break;
                case 9:
                    this._ball.Bouger(15, 6);
                    break;
                case 10:
                    this._ball.Bouger(15, 6);
                    break;
                case 11:
                    this._ball.Bouger(15, 0);
                    break;
                default: break;
            }
            #endregion

            this.Afficher(gr);
            Thread.Sleep(_speed);
        }
        public void Roll(Graphics gr, int i)
        {
            #region Positioner
            this._jimmy.Roll(i);

            this._ball.Bouger(-40, 0);
            if (i > 1)
            {
                this._pin1.Bouger(-25, 0, 0);
            }
            if (i > 2)
            {
                this._pin2.Bouger(-25, 0, 0);
                this._pin3.Bouger(-25, 0, 0);
            }
            if (i > 3)
            {
                this._pin4.Bouger(-25, 0, 0);
                this._pin5.Bouger(-25, 0, 0);
                this._pin6.Bouger(-25, 0, 0);
            }
            if (i > 4)
            {
                this._pin7.Bouger(-25, 0, 0);
                this._pin8.Bouger(-25, 0, 0);
                this._pin9.Bouger(-25, 0, 0);
                this._pin10.Bouger(-25, 0, 0);
            }
            #endregion

            this.Afficher(gr);
            Thread.Sleep(_speed);
        }
        public void Strike(Graphics gr, int i)
        {
            this._ball.Bouger(25, 0);

            #region Pin hit
            if (this._ball.X - 15 + 25 == this._pin1.X)
            {
                this._pin1.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin2.X)
            {
                this._pin2.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin3.X)
            {
                this._pin3.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin4.X)
            {
                this._pin4.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin5.X)
            {
                this._pin5.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin6.X)
            {
                this._pin6.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin7.X)
            {
                this._pin7.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin8.X)
            {
                this._pin8.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin9.X)
            {
                this._pin9.hit = true;

            }
            if (this._ball.X - 15 + 25 == this._pin10.X)
            {
                this._pin10.hit = true;

            }
            #endregion

            #region Pin Animation
            if (this._pin1.hit == true)
            {
                this._pin1.Hit3(_pinstart[0]);
                _pinstart[0]++;
            }
            if (this._pin2.hit == true)
            {
                this._pin2.Hit1(_pinstart[1]);
                _pinstart[1]++;
            }
            if (this._pin3.hit == true)
            {
                this._pin3.Hit2(_pinstart[2]);
                _pinstart[2]++;
            }
            if (this._pin4.hit == true)
            {
                this._pin4.Hit2(_pinstart[3]);
                _pinstart[3]++;
            }
            if (this._pin5.hit == true)
            {
                this._pin5.Hit1(_pinstart[4]);
                _pinstart[4]++;
            }
            if (this._pin6.hit == true)
            {
                this._pin6.Hit2(_pinstart[5]);
                _pinstart[5]++;
            }
            if (this._pin7.hit == true)
            {
                this._pin7.Hit1(_pinstart[6]);
                _pinstart[6]++;
            }
            if (this._pin8.hit == true)
            {
                this._pin8.Hit3(_pinstart[7]);
                _pinstart[7]++;
            }
            if (this._pin9.hit == true)
            {
                this._pin9.Hit1(_pinstart[8]);
                _pinstart[8]++;
            }
            if (this._pin10.hit == true)
            {
                this._pin10.Hit3(_pinstart[9]);
                _pinstart[0]++;
            }
            #endregion

            this.Afficher(gr);
            Thread.Sleep(_speed);

            //Reset Pin Animation
            if (i == 19)
            {
                for (int j = 0; j < 10; j++)
                    _pinstart[j] = 0;
            }
        }
        #endregion

        #endregion
    }
}
