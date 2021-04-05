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
using pingBall.Classes;
using System.Threading;

namespace pingBall
{
    public partial class Form1 : Form
    {
        String ip1;
        String ip2;
        List<Clping> lletiquetas= new List<Clping>();
        List<Thread> llThreads = new List<Thread>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btPing_Click(object sender, EventArgs e)
        {
            if(validarip(tbip1.Text,tbip2.Text))
            {
                cambiarform();
                generaretiquetas();

            }
            else
            {
                MessageBox.Show("Las direcciones introducidas no son correctas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool validarip(String xip1, String xip2)
        {
            bool ipscorrectas = false;

            IPAddress ipuno = null;
            IPAddress ipdos = null;
            String[] ip1aux;
            String[] ip2aux;
            if(IPAddress.TryParse(xip1, out ipuno))
            {
                if (IPAddress.TryParse(xip2, out ipdos))
                {
                    if(!(xip1.Equals(xip2)))
                    {
                        ip1aux=xip1.Split('.');
                        ip2aux=xip2.Split('.');
                        if(ip1aux[0].Equals(ip2aux[0]) && ip1aux[1].Equals(ip2aux[1]) && ip1aux[2].Equals(ip2aux[2]))
                        {
                            MessageBox.Show("Las direcciones introducidas son correctas", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ipscorrectas = true;
                            ip1 = xip1;
                            ip2 = xip2;
                        }
                    }

                }
            }


            return ipscorrectas;

        }

        private void cambiarform()
        {
            titulo.Visible = false;
            lbip1.Visible = false;
            lbip2.Visible = false;
            tbip1.Visible = false;
            tbip2.Visible = false;
            btPing.Visible = false;
            this.BackColor = Color.Lime;
            this.WindowState = FormWindowState.Maximized;
        }

        private void generaretiquetas()
        {
            String ipaux = ip1;
            String[] ipaux2 ;
            String[] ipfinal = ip2.Split('.');
            String ipfinal2="";
            int numfinalip;
            numfinalip = Convert.ToInt32( ipfinal[3]);
            numfinalip++;
            ipfinal[3] = numfinalip.ToString();
            ipfinal2 += ipfinal[0] + "." + ipfinal[1] + "." + ipfinal[2] + "." + ipfinal[3];
            while (!(ipaux.Equals(ipfinal2)))
            {
                lletiquetas.Add(new Clping(this, ipaux, 1000, Color.Green));
                llThreads.Add(new Thread(lletiquetas[lletiquetas.Count - 1].iniciarPing));
                llThreads[llThreads.Count - 1].Start();

                ipaux2 = ipaux.Split('.');
                numfinalip = Convert.ToInt32(ipaux2[3]);
                numfinalip++;
                ipaux2[3] = numfinalip.ToString();
                ipaux = "";
                ipaux += ipaux2[0] + "." + ipaux2[1] + "." + ipaux2[2] + "." + ipaux2[3];
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread th in llThreads)
            {
                if (th.IsAlive)
                {
                    th.Abort();
                }
            }
        }
    }
}
