using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace pingBall.Classes
{
    class Clping
    {
        Color color = new Color();
        int dx = 10;
        int dy = 10;
        Label etq = new Label();
        Form fpare = null;
        IPAddress ip;
        Point pos = new Point();
        System.Timers.Timer tm = new System.Timers.Timer();
        System.Timers.Timer tmping = new System.Timers.Timer();
        private delegate void delegat();

        public Clping(Form xpare, String xip, int xvel,Color xcolor)
        {
            fpare = xpare;
            ip =IPAddress.Parse(xip);
            //Console.WriteLine(ip);
            tm.Interval=xvel;
            tmping.Interval = 100;
            color = xcolor;
            tm.Elapsed += tmTick;
            tmping.Elapsed += nouPing;

        }

        public void aturarTimer()
        {
            tm.Stop();
            tmping.Stop();
        }


        public void iniciarPing()
        {
            Console.WriteLine(ip);
            Ping p = new Ping();
            //MessageBox.Show(ip.ToString() + p.Send(ip.ToString().Trim()).Status, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (p.Send(ip).Status == IPStatus.Success)
            {

                fpare.Invoke(new delegat(iniEtiqueta));
                //MessageBox.Show(ip.ToString() + Environment.NewLine + etq.Left + Environment.NewLine + etq.Top, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fpare.Invoke(new delegat(inserirEtiqueta));
                tm.Enabled = true;
                tm.Start();
                

            }
            tmping.Start();
        }

        private void iniEtiqueta()
        {
            Random r = new Random();
            etq.BackColor = color;
            etq.Visible = true;
            etq.Text = ip.ToString();
            etq.TextAlign = ContentAlignment.MiddleCenter;
            etq.Location = new Point(r.Next(etq.Width,fpare.Width-etq.Width), r.Next(etq.Height, fpare.Height - etq.Height));
        }
        private void inserirEtiqueta()
        {
            fpare.Controls.Add(etq);
        }


        private void moureEtiqueta()
        {
            int X = etq.Location.X;
            int Y = etq.Location.Y;

            X = X + dx;
            Y = Y + dy;

            if (X <= 0)
            {
                X = 0;
                dx = -dx;
            }
            else
            {
                if (X + etq.Width >= fpare.Width)
                {
                    X = fpare.Width - etq.Width;
                    dx = -dx;
                }

            }
            if (Y <= 0)
            {
                Y = 0;
                dy = -dy;
            }
            else
            {
                if (Y + etq.Height >= fpare.Height-300)
                {
                    Y = (fpare.Height-300) - etq.Height;
                    dy = -dy;
                }
            }

            pos = new Point(X,Y);
            try
            {
                fpare.Invoke(new delegat(movimientoetiqueta));
            }
            catch (Exception)
            {

                
            }


        }
        private void movimientoetiqueta()
        {
            etq.Location = pos;
            etq.Location = pos;
        }

        private void visualizaretiqueta()
        {
            etq.Visible = true;
        }
        private void nouPing(Object source, System.Timers.ElapsedEventArgs e)
        {
            Ping p = new Ping();
            if (p.Send(ip).Status != IPStatus.Success)
            {

                //MessageBox.Show(ip.ToString() + Environment.NewLine + etq.Left + Environment.NewLine + etq.Top, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fpare.Invoke(new delegat(eliminarEtiqueta));
                tm.Enabled = false;
                tm.Stop();
            }
            else
            {
                try
                {
                    //fpare.Invoke(new delegat(iniEtiqueta));
                    //MessageBox.Show(ip.ToString() + Environment.NewLine + etq.Left + Environment.NewLine + etq.Top, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fpare.Invoke(new delegat(visualizaretiqueta));
                    tm.Enabled = true;
                    tm.Start();
                }
                catch (Exception)
                {
                    
                }
                tm.Enabled = true;
                tm.Start();
            }

        }
        private void eliminarEtiqueta()
        {
            etq.Visible = false;
        }
        private void tmTick(Object source, System.Timers.ElapsedEventArgs e)
        {
            moureEtiqueta();
        }

    }
}
