using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoPathFinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Nodo nodoFinal { get; set; }
        public static Nodo NodoInicial { get; set; }
        public static Nodo PosActual { get; set; }
        public List<Nodo> listaCerrada = new List<Nodo>();
        public List<Nodo> listaAbierta = new List<Nodo>();
        public int X = 7;
        public int Y = 5;
        public Nodo[,] listaNodos;

        private void Form1_Load(object sender, EventArgs e)
        {
            listaNodos = new Nodo[X, Y];

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Nodo nuevo = new Nodo((i+1)+","+(j+1), i+1, j+1);
                    listaNodos[i, j] = nuevo;
                    this.Controls.Add(listaNodos[i,j].Vista.Caja);
                }

            }
            Button comenzar = new Button() {
                Text = "Comenzar",
                Location=new Point((X*50)+50, (Y * 50))
            };
            this.Controls.Add(comenzar);
            comenzar.Click += Comenzar_Click;
            
            
        }

        public void obtenerVecinos()
        {
            
            Nodo Left=((PosActual.X)-1<1)?null:listaNodos[PosActual.X-2,PosActual.Y-1];
            Nodo Right= ((PosActual.X) + 1 >= this.X+1) ? null : listaNodos[PosActual.X, PosActual.Y-1];
            Nodo Up=((PosActual.Y) - 1 <1) ? null : listaNodos[PosActual.X-1, PosActual.Y - 2];
            Nodo Down= ((PosActual.Y) + 1 >= this.Y+1) ? null : listaNodos[PosActual.X - 1, PosActual.Y];

            Nodo LeftUp=(((PosActual.X) - 1 < 1) || ((PosActual.Y) - 1 < 1)) ? null: listaNodos[PosActual.X-2, PosActual.Y - 2];
            Nodo LeftDown=(((PosActual.X) - 1 < 1) || ((PosActual.Y) + 1 >= this.Y + 1)) ? null: listaNodos[PosActual.X-2, PosActual.Y ];
            Nodo RightUp=(((PosActual.X) + 1 >= this.X + 1) || ((PosActual.Y) - 1 < 1)) ? null : listaNodos[PosActual.X, PosActual.Y - 2];
            Nodo RightDown=(((PosActual.X) + 1 >= this.X + 1) || ((PosActual.Y) + 1 >= this.Y + 1))?null: listaNodos[PosActual.X, PosActual.Y ];

            if(Left!=null && Left.Vista.tipo != "Prohibido")
            {
                

                if (!estaEnListaAbierta(Left))
                {
                    Left.Padre = PosActual;
                    Left.Vista.Caja.BackgroundImage = AlgoritmoPathFinding.Properties.Resources.Right;
                    Left.Vista.Caja.BackgroundImageLayout = ImageLayout.Center;
                    Left.Vista.Caja.Refresh();
                }
                listaAbierta.Add(Left);
            }
            

            if(Right!=null && Right.Vista.tipo != "Prohibido")
            {

                if (!estaEnListaAbierta(Right))
                {
                    Right.Padre = PosActual;
                    Right.Vista.Caja.BackgroundImage = AlgoritmoPathFinding.Properties.Resources.Left;
                    Right.Vista.Caja.BackgroundImageLayout = ImageLayout.Center;
                    Right.Vista.Caja.Refresh();
                }

                listaAbierta.Add(Right);                
            }

            if (Up!=null && Up.Vista.tipo != "Prohibido")
            {
                if (!estaEnListaAbierta(Up))
                {
                    Up.Padre = PosActual;
                    Up.Vista.Caja.BackgroundImage = AlgoritmoPathFinding.Properties.Resources.Down;
                    Up.Vista.Caja.BackgroundImageLayout = ImageLayout.Center;
                    Up.Vista.Caja.Refresh();
                }
                listaAbierta.Add(Up);                
            }

            if (Down!=null && Down.Vista.tipo != "Prohibido")
            {
                if (!estaEnListaAbierta(Down))
                {
                    Down.Padre = PosActual;
                    Down.Vista.Caja.BackgroundImage = AlgoritmoPathFinding.Properties.Resources.Up;
                    Down.Vista.Caja.BackgroundImageLayout = ImageLayout.Center;
                    Down.Vista.Caja.Refresh();
                }
                listaAbierta.Add(Down);                
            }

            if (LeftUp!=null && LeftUp.Vista.tipo != "Prohibido")
            {
                if (!estaEnListaAbierta(LeftUp))
                {
                    LeftUp.Padre = PosActual;
                    LeftUp.Vista.Caja.BackgroundImage = AlgoritmoPathFinding.Properties.Resources.RightDown;
                    LeftUp.Vista.Caja.BackgroundImageLayout = ImageLayout.Center;
                    LeftUp.Vista.Caja.Refresh();
                }
                listaAbierta.Add(LeftUp);
            }

            if (RightUp!=null && RightUp.Vista.tipo != "Prohibido")
            {
                if (!estaEnListaAbierta(RightUp))
                {
                    RightUp.Padre = PosActual;
                    RightUp.Vista.Caja.BackgroundImage = AlgoritmoPathFinding.Properties.Resources.LeftDown;
                    RightUp.Vista.Caja.BackgroundImageLayout = ImageLayout.Center;
                    RightUp.Vista.Caja.Refresh();
                }
                listaAbierta.Add(RightUp);

            }

            if (LeftDown!=null && LeftDown.Vista.tipo != "Prohibido")
            {
                if (!estaEnListaAbierta(LeftDown))
                {
                    LeftDown.Padre = PosActual;
                    LeftDown.Vista.Caja.BackgroundImage = AlgoritmoPathFinding.Properties.Resources.RightUp;
                    LeftDown.Vista.Caja.BackgroundImageLayout = ImageLayout.Center;
                    LeftDown.Vista.Caja.Refresh();
                }
                listaAbierta.Add(LeftDown);
            }

            if (RightDown!=null && RightDown.Vista.tipo != "Prohibido")
            {
                if (!estaEnListaAbierta(RightDown))
                {
                    RightDown.Padre = PosActual;
                    RightDown.Vista.Caja.BackgroundImage = AlgoritmoPathFinding.Properties.Resources.LeftUp;
                    RightDown.Vista.Caja.BackgroundImageLayout = ImageLayout.Center;
                    RightDown.Vista.Caja.Refresh();
                }
                listaAbierta.Add(RightDown);
            }





        }

        public void calcularGElementosEnlistaAbierta()
        {
            for (int i = 0; i < listaAbierta.Count; i++)
            {
                listaAbierta.ElementAt(i).calcularG();
            }
        }

        public void calcularFElementosEnlistaAbierta()
        {
            for (int i = 0; i < listaAbierta.Count; i++)
            {
                listaAbierta.ElementAt(i).calcularF();
            }
        }

        public Boolean estaEnListaAbierta(Nodo nodo)
        {
            foreach (var elemento in listaAbierta)
            {
                if (elemento.esIgual(nodo))
                {
                    return true;
                }

            }
            return false;
        }

        public Boolean estaEnListaCerrada(Nodo nodo)
        {
            foreach (var elemento in listaAbierta)
            {
                if (elemento.esIgual(nodo))
                {
                    return true;
                }

            }
            return false;
        }

        private void Comenzar_Click(object sender, EventArgs e)
        {
            
            foreach (var nodo in listaNodos)
            {                
                if (nodo.Vista.tipo=="Inicial")
                {
                    NodoInicial = nodo;                    
                }else if (nodo.Vista.tipo == "Final")
                {
                    nodoFinal = nodo;
                }
            }


            if (nodoFinal == null || NodoInicial == null)
            {
                MessageBox.Show("debes elegir un nodo inicial y un nodo final (haciendo doble click en el nodo)");
            }else
            {
                foreach (var nodo in listaNodos)
                {
                    nodo.Vista.cargar();
                    nodo.calcularH();                                   
                }
                PosActual = NodoInicial;
                listaCerrada.Add(PosActual);
                Algoritmo();
            }  
                     
        }


        public void Algoritmo()
        {
            obtenerVecinos();
            calcularGElementosEnlistaAbierta();
            calcularFElementosEnlistaAbierta();




        }
    }
}
