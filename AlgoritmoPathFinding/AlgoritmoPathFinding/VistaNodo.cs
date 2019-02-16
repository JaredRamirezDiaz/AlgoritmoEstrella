using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AlgoritmoPathFinding
{
   public class VistaNodo
    {
        private Color permitido = Color.AliceBlue;
        private Color prohibido = Color.Black;
        private Color Inicial = Color.Orange;
        private Color Final = Color.Red;
        public Label ID { get; set; }
        public Label H { get; set; }
        public Label F { get; set; }
        public Label G { get; set; }
        public Panel Caja { get; set; }
        public String tipo { get; set; }
        public Nodo nodo { get; set; }


        public VistaNodo(String ID, Nodo nodo)
        {
            inicializar(nodo);
            this.nodo = nodo;

        }

        public void inicializar(Nodo nodo)
        {
            this.Caja = new Panel()
            {
                Location = new Point(((50)*nodo.X)+10,((50)*nodo.Y)+10),
                BackColor = permitido,
                Size = new Size(50, 50),
                BorderStyle = BorderStyle.FixedSingle,
            };
            


            this.H = new Label()
            {
                BackColor = Color.Transparent,
                Name = "H",
                Text = nodo.H+"",
                Location = new Point(30, 35),
                Font = new Font(FontFamily.GenericSerif, 7)
            };



            this.F = new Label()
            {
                BackColor = Color.Transparent,
                Name = "F",
                Text = nodo.F+"",
                Location = new Point(30, 1),
                Font = new Font(FontFamily.GenericSerif, 7)
            };



            this.G = new Label()
            {
                BackColor = Color.Transparent,
                Name = "G",
                Text = nodo.G+"",
                Location = new Point(1, 35),
                Font = new Font(FontFamily.GenericSerif, 7)
            };



            this.ID = new Label()
            {
                BackColor = Color.Transparent,
                Name = "ID",
                Text = nodo.ID,
                Location = new Point(1, 1),
                Font = new Font(FontFamily.GenericSerif, 7)
            };

            
            Caja.Click += Caja_Click;
            Caja.DoubleClick += Caja_DoubleClick;

        }

        private void Caja_DoubleClick(object sender, EventArgs e)
        {
            if (((Panel)sender).BackColor == prohibido || ((Panel)sender).BackColor == permitido)
            {
                ((Panel)sender).BackColor = Inicial;
                this.tipo = "Inicial";               
                
            }
            else if (((Panel)sender).BackColor == Inicial)
            {
                ((Panel)sender).BackColor = Final;
                this.tipo = "Final";
            }
            else
            {
                ((Panel)sender).BackColor = permitido;
                this.tipo = "Permtido";
            }
                    
        }

        public void cargar()
        {
            Caja.Controls.Add(F);
            Caja.Controls.Add(ID);
            Caja.Controls.Add(H);
            Caja.Controls.Add(G);
            
        }

        public void actualizar()
        {
            Caja.Controls["H"].Text = nodo.H + "";
            Caja.Controls["G"].Text = nodo.G + "";
            Caja.Controls["F"].Text = nodo.F + "";

        }

        private void Caja_Click(object sender, EventArgs e)
        {
            if (((Panel)sender).BackColor == permitido && ((Panel)sender).BackColor != Inicial && ((Panel)sender).BackColor != Final)
            {
                ((Panel)sender).BackColor = prohibido;
                this.tipo = "Prohibido";
            }
            else if (((Panel)sender).BackColor == prohibido && ((Panel)sender).BackColor != Inicial && ((Panel)sender).BackColor != Final)
            {
                ((Panel)sender).BackColor = permitido;
                this.tipo = "Permitido";
            }
        }

        public void d() { }

    }
}
