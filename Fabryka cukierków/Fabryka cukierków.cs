using Fabryka_cukierków.Properties;
using System.Drawing.Drawing2D;
using System.Media;
using System.Timers;


namespace Fabryka_cukierków
{

    public partial class FabrykaC : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer();


        decimal cukierki = 0;
        int pracownicy = 0;
        int Sklepy = 1;
        public FabrykaC()
        {
            InitializeComponent();
            pictureBox1.Image = Resources.menu;
            pictureBox1.Controls.Add(Startbut);
            pictureBox1.Controls.Add(loadgame);
            pictureBox1.Controls.Add(wygaszacz);
            wygaszacz.Hide();
            sklep.Show();
            sklep.SendToBack();
            pictureBox1.BringToFront();
            Startbut.BringToFront();
            loadgame.BringToFront();
            wygaszacz.BackColor = Color.Transparent;
            wygaszacz.SizeMode = PictureBoxSizeMode.Zoom;
            Startbut.BackColor = Color.Transparent;
            Startbut.SizeMode = PictureBoxSizeMode.Zoom;
            loadgame.BackColor = Color.Transparent;
            loadgame.SizeMode = PictureBoxSizeMode.Zoom;
        }

        static SoundPlayer move = new SoundPlayer("move.wav");
        static SoundPlayer select = new SoundPlayer("select.wav");
        static SoundPlayer PK = new SoundPlayer("PK.wav");

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            }
        }
        private void Startbut_Paint(object sender, PaintEventArgs e)
        {
            if (Startbut.Image != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(Startbut.Image, new Rectangle(0, 0, Startbut.Width, Startbut.Height));
            }
        }

        private void Startbut_Click(object sender, EventArgs e)
        {
            select.Play();
            wygaszacz.Show();
            wygaszacz.BringToFront();
            for (int i = 0; i <= 255; i += 5)
            {
                wygaszacz.BackColor = Color.FromArgb(i, Color.Black);
                Thread.Sleep(20);
                wygaszacz.Refresh();
            }
            pictureBox1.Hide();
            Startbut.Hide();
            loadgame.Hide();
            sklep.BringToFront();
            sklep.Controls.Add(wygaszacz);
            wygaszacz.BackColor = Color.White;
            wygaszacz.SizeMode = PictureBoxSizeMode.Zoom;
            for (int i = 255; i >= 0; i -= 5)
            {
                wygaszacz.BringToFront();
                wygaszacz.BackColor = Color.FromArgb(i, Color.Black);
                wygaszacz.Refresh();
                Thread.Sleep(50);
            }
            sklep.Controls.Add(cukwyświetl);
            sklep.Controls.Add(pictureBox2);
            sklep.Controls.Add(pracownikkup);
            sklep.Controls.Add(labelpracownicy);
            sklep.Controls.Add(pracico);
            sklep.Controls.Add(Sklepkup);
            sklep.Controls.Add(sklep1);
            sklep.Controls.Add(sklep2);
            sklep.Controls.Add(sklep3);
            sklep.Controls.Add(note);
            labelpracownicy.Show();
            wygaszacz.Hide();
            wygaszacz.SendToBack();
            pracownikkup.Hide();
            pracico.Hide();
            Sklepkup.Hide();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            labelpracownicy.Hide();

        }
        private void Startbut_MouseEnter(object sender, EventArgs e)
        {
            move.Play();
        }
        private void Loadgame_MouseEnter(object sender, EventArgs e)
        {
            move.Play();
        }

        private void sklep_Click(object sender, EventArgs e)
        {
            cukierki = cukierki + pracownicy + 1;
            if (cukierki >= 10 && pracownicy < 10)
            {
                pracownikkup.Show();
            }
            else if (pracownicy == 10 && cukierki >= 100 * Sklepy)
            {
                Sklepkup.Show();
                Sklepkup.BringToFront();
            }
            else
            {
                Sklepkup.Hide();
                pracownikkup.Hide();
            }
            cukwyświetl.Text = cukierki.ToString();
            if (cukierki >= 1000000)
            {

                timer.Stop();

                timer.Enabled = false;
                cukierki = 1000000;

                wygaszacz.BringToFront();
                for (int i = 0; i <= 255; i += 5)
                {
                    wygaszacz.BackColor = Color.FromArgb(i, Color.Black);
                    Thread.Sleep(20);
                    wygaszacz.Refresh();
                    licznink.Show();
                }

                for (int j = 1000000; j > 0; j--)
                {
                    if (j < 1000)
                    {
                        Thread.Sleep(3000 - j);
                        licznink.Text = j.ToString();
                    }
                    else
                    {
                        Thread.Sleep(20);
                        licznink.Text = j.ToString();
                    }
                }
                PK.PlayLooping();
            }
        }

        private void pracownikkup_Click(object sender, EventArgs e)
        {

            pracico.Show();
            labelpracownicy.Show();
            if (cukierki >= 10 * Sklepy)
            {
                pracownicy++;
                cukierki = cukierki - 10 * Sklepy;
            }
            if (cukierki < 10 * Sklepy || pracownicy == 10)
            {
                pracownikkup.Hide();
            }
            if (pracownicy == 10 && cukierki >= 100 * Sklepy)
            {
                Sklepkup.Show();
                Sklepkup.BringToFront();
            }
            labelpracownicy.Text = pracownicy.ToString();
            if (cukierki >= 1000000)
            {
                cukierki = 1000000;

                wygaszacz.BringToFront();
                for (int i = 0; i <= 255; i += 5)
                {
                    wygaszacz.BackColor = Color.FromArgb(i, Color.Black);
                    Thread.Sleep(20);
                    wygaszacz.Refresh();
                    licznink.Show();
                }

                for (int j = 1000000; j > 0; j--)
                {
                    if (j < 1000)
                    {
                        Thread.Sleep(3000 - j);
                        licznink.Text = j.ToString();
                    }
                    else
                    {
                        Thread.Sleep(20);
                        licznink.Text = j.ToString();
                    }
                }
                PK.PlayLooping();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            cukierki = cukierki + pracownicy + (Sklepy - 1) * 10;
            if (cukierki >= 10 * Sklepy && pracownicy < 10)
            {
                pracownikkup.Invoke((MethodInvoker)delegate
                {
                    pracownikkup.Show();
                });
            }
            else
            {
                pracownikkup.Invoke((MethodInvoker)delegate
                {
                    pracownikkup.Hide();
                });
            }
            cukwyświetl.Invoke((MethodInvoker)delegate
            {
                cukwyświetl.Text = cukierki.ToString();
            });
            if (pracownicy == 10 && cukierki >= 100 * Sklepy)
            {
                Sklepkup.Invoke((MethodInvoker)delegate
                {
                    Sklepkup.Show();
                    Sklepkup.BringToFront();
                });
            }
            switch (Sklepy)
            {
                case 2:
                    sklep1.Invoke((MethodInvoker)delegate
                    {
                        sklep1.Show();
                    });
                    break;
                case 4:
                    sklep2.Invoke((MethodInvoker)delegate
                    {
                        sklep2.Show();
                    });
                    break;
                case 8:
                    sklep3.Invoke((MethodInvoker)delegate
                    {
                        sklep3.Show();
                    });
                    break;

            }
            
        }

        private void Sklepkup_Click(object sender, EventArgs e)
        {
            pracownicy = pracownicy - 10;
            cukierki = cukierki - 100 * Sklepy;
            Sklepkup.Hide();
            Sklepy++;
            labelpracownicy.Text = pracownicy.ToString();
            sklepile.Text = Sklepy.ToString();
            sklepile.Show();
            sklepile.Show(); 
            if (cukierki >= 1000000)
            {
                cukierki = 1000000;

                wygaszacz.BringToFront();
                for (int i = 0; i <= 255; i += 5)
                {
                    wygaszacz.BackColor = Color.FromArgb(i, Color.Black);
                    Thread.Sleep(20);
                    wygaszacz.Refresh();
                    licznink.Show();
                }

                for (int j = 1000000; j > 0; j--)
                {
                    if (j < 1000)
                    {
                        Thread.Sleep(3000 - j);
                        licznink.Text = j.ToString();
                    }
                    else
                    {
                        Thread.Sleep(20);
                        licznink.Text = j.ToString();
                    }
                }
                PK.PlayLooping();
            }
        }

        private void sklep3_Click(object sender, EventArgs e)
        {

            cukierki = cukierki + pracownicy + 1;
            if (cukierki >= 10 && pracownicy < 10)
            {
                pracownikkup.Show();
            }
            else if (pracownicy == 10 && cukierki >= 100 * Sklepy)
            {
                Sklepkup.Show();
                Sklepkup.BringToFront();
            }
            else
            {
                Sklepkup.Hide();
                pracownikkup.Hide();
            }
            cukwyświetl.Text = cukierki.ToString();
            if (cukierki >= 1000000)
            {
                cukierki = 1000000;

                wygaszacz.BringToFront();
                for (int i = 0; i <= 255; i += 5)
                {
                    wygaszacz.BackColor = Color.FromArgb(i, Color.Black);
                    Thread.Sleep(20);
                    wygaszacz.Refresh();
                    licznink.Show();
                }

                for (int j = 1000000; j > 0; j--)
                {
                    if (j < 1000)
                    {
                        Thread.Sleep(3000 - j);
                        licznink.Text = j.ToString();
                    }
                    else
                    {
                        Thread.Sleep(20);
                        licznink.Text = j.ToString();
                    }
                }
                PK.PlayLooping();
            }
        }
        private void sklep2_Click(object sender, EventArgs e)
        {

            cukierki = cukierki + pracownicy + 1;
            if (cukierki >= 10 && pracownicy < 10)
            {
                pracownikkup.Show();
            }
            else if (pracownicy == 10 && cukierki >= 100 * Sklepy)
            {
                Sklepkup.Show();
                Sklepkup.BringToFront();
            }
            else
            {
                Sklepkup.Hide();
                pracownikkup.Hide();
            }
            cukwyświetl.Text = cukierki.ToString();
            if (cukierki >= 1000000)
            {
                cukierki = 1000000;

                wygaszacz.BringToFront();
                for (int i = 0; i <= 255; i += 5)
                {
                    wygaszacz.BackColor = Color.FromArgb(i, Color.Black);
                    Thread.Sleep(20);
                    wygaszacz.Refresh();
                    licznink.Show();
                }

                for (int j = 1000000; j > 0; j--)
                {
                    if (j < 1000)
                    {
                        Thread.Sleep(3000 - j);
                        licznink.Text = j.ToString();
                    }
                    else
                    {
                        Thread.Sleep(20);
                        licznink.Text = j.ToString();
                    }
                }
                PK.PlayLooping();
            }
        }
        private void sklep1_Click(object sender, EventArgs e)
        {

            cukierki = cukierki + pracownicy + 1;
            if (cukierki >= 10 && pracownicy < 10)
            {
                pracownikkup.Show();
            }
            else if (pracownicy == 10 && cukierki >= 100 * Sklepy)
            {
                Sklepkup.Show();
                Sklepkup.BringToFront();
            }
            else
            {
                Sklepkup.Hide();
                pracownikkup.Hide();
            }
            cukwyświetl.Text = cukierki.ToString();
            if (cukierki >= 1000000)
            {
                cukierki = 1000000;

                wygaszacz.BringToFront();
                for (int i = 0; i <= 255; i += 5)
                {
                    wygaszacz.BackColor = Color.FromArgb(i, Color.Black);
                    Thread.Sleep(20);
                    wygaszacz.Refresh();
                    licznink.Show();
                }

                for (int j = 1000000; j > 0; j--)
                {
                    if (j < 1000)
                    {
                        Thread.Sleep(3000 - j);
                        licznink.Text = j.ToString();
                    }
                    else
                    {
                        Thread.Sleep(20);
                        licznink.Text = j.ToString();
                    }
                }
                PK.PlayLooping();
            }
        }

        private void FabrykaC_Load(object sender, EventArgs e)
        {

        }

        private void note_Click(object sender, EventArgs e)
        {

        }
    }
}