using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoPathFinding
{
    public class Nodo
    {
        public String ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public double HH { get; set; }
        public int F { get; set; }
        public Nodo Padre { get; set; }
        public VistaNodo Vista { get; set; }

        public Nodo(String ID,int x,int y)
        {
            this.ID = ID;
            this.X = x;
            this.Y = y;
            this.Vista = new VistaNodo(ID,this);
        }

        public void calcularG()
        {
            if (Form1.PosActual.X==this.X || Form1.PosActual.Y==this.Y)
            {
                this.G = 10;
            }
            else
            {
                this.G = 14;
            }
            Vista.actualizar();
        }

        public void calcularH()
        {
            double h = Math.Sqrt(Math.Pow((this.X - Form1.nodoFinal.X),2) +Math.Pow((this.Y - Form1.nodoFinal.Y),2));
            this.H = (int) (h*10) ;
            this.HH = h;

            Vista.actualizar();

        }

        public void calcularF()
        {
            this.F = this.H + this.G;
            Vista.actualizar();

        }

        public Boolean esIgual( Nodo nodo)
        {
            return ((this.X == nodo.X) && (this.Y == nodo.Y));
        }


    }
}
