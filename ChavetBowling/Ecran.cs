using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChavetBowling
{
    public partial class Ecran : Form
    {
        // resources:
        // Four-Step Approach
        // https://www.youtube.com/watch?v=oq54_GlzK6A Video
        // https://imgur.com/a/fgAbEW7 Drawing Animation

        #region Données Membres
        private Classes.Foreground Foreground;
        private Classes.Background Background;
        private Classes.Scene Scene;

        private BufferedGraphics bufferG = null;
        private Graphics g;
        #endregion

        public Ecran()
        {
            InitializeComponent();
            bufferG = BufferedGraphicsManager.Current.Allocate(pbTV.CreateGraphics(), pbTV.DisplayRectangle);
            g = bufferG.Graphics;
            g.Clear(pbTV.BackColor);
            bufferG.Render();
            EnabledFalse(bThrow);
        }

        private void bCreateScence_Click(object sender, EventArgs e)
        {
            InitializeScene();
        }

        private void bThrow_Click(object sender, EventArgs e)
        {
            EnabledFalse(bThrow);
            //Prep
            for (int i = 0; i < 3; i++)
            {
                g.Clear(pbTV.BackColor);
                this.Background.Afficher(g);
                this.Scene.Prep(g, i);
                this.Foreground.Afficher(g);
                bufferG.Render();
            }
            //Step 1
            for (int i = 0; i < 5; i++)
            {
                g.Clear(pbTV.BackColor);
                this.Background.Afficher(g);
                this.Scene.Step1(g, i);
                this.Foreground.Afficher(g);
                bufferG.Render();
            }
            //Step 2
            for (int i = 0; i < 7; i++)
            {
                g.Clear(pbTV.BackColor);
                this.Background.Afficher(g);
                this.Scene.Step2(g, i);
                this.Foreground.Afficher(g);
                bufferG.Render();
            }
            //Step 3
            for (int i = 0; i < 6; i++)
            {
                g.Clear(pbTV.BackColor);
                this.Background.Afficher(g);
                this.Scene.Step3(g, i);
                this.Foreground.Afficher(g);
                bufferG.Render();
            }
            //Step 4
            for (int i = 0; i < 6; i++)
            {
                g.Clear(pbTV.BackColor);
                this.Background.Afficher(g);
                this.Scene.Step4(g, i);
                this.Foreground.Afficher(g);
                bufferG.Render();
            }
            //Throw
            for (int i = 0; i < 12; i++)
            {
                g.Clear(pbTV.BackColor);
                this.Background.Afficher(g);
                this.Scene.Throw(g, i);
                this.Foreground.Afficher(g);
                bufferG.Render();
            }
            //Roll
            for (int i = 0; i < 8; i++)
            {
                g.Clear(pbTV.BackColor);
                this.Background.Bouger(-55, 0);
                this.Foreground.Bouger(-80, 0);
                this.Background.Afficher(g);
                this.Scene.Roll(g, i);
                this.Foreground.Afficher(g);
                bufferG.Render();
            }
            //Strike
            for (int i = 0; i < 20; i++)
            {
                g.Clear(pbTV.BackColor);
                this.Background.Afficher(g);
                this.Scene.Strike(g, i);
                this.Foreground.Afficher(g);
                bufferG.Render();
            }
            MessageBox.Show("STRIKE!");
            InitializeScene();
        }

        private void bClearScreen_Click(object sender, EventArgs e)
        {
            g.Clear(pbTV.BackColor);
            bufferG.Render();
            EnabledFalse(bThrow);
        }

        #region Méthodes
        void InitializeScene()
        {
            g.Clear(pbTV.BackColor);

            this.Foreground = new Classes.Foreground(this.pbTV, 0, 0, 0, 0, 0, Color.Black);
            this.Scene = new Classes.Scene(this.pbTV, 0, 0, 0, 0, 0, Color.Black);
            this.Background = new Classes.Background(this.pbTV, 0, 0, 0, 0, 0, Color.Black);

            this.Background.Afficher(g);
            this.Scene.Afficher(g);
            this.Foreground.Afficher(g);

            bufferG.Render();

            //Activation es boutons
            EnabledTrue(bThrow);
        }
        void EnabledTrue(params Button[] mesBoutons)
        {
            foreach (Button button in mesBoutons)
            {
                button.Enabled = true;
            }
        }
        void EnabledFalse(params Button[] mesBoutons)
        {
            foreach (Button button in mesBoutons)
            {
                button.Enabled = false;
            }
        }
        #endregion
    }
}
