using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using Unidad1JuegoBotellasAEstrella.Models;

namespace Unidad1JuegoBotellasAEstrella.ViewModels
{
    public class GameOfBottleViewModel:INotifyPropertyChanged
        //EL JUEGO NO ESTÁ TERMINADO
    {//comandos
        public ICommand GenerarNuevoJuegoCommand { get; set; }
        public ICommand ResolverCommand { get; set; }

        //propiedades
        private Bottle bottle;
        private List<Bottle> listOfBottles;
        public List<Bottle> ListOfBottles
        {
            set { listOfBottles = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListOfBottles")); }
            get { return listOfBottles;}
        }
        public int reds = 0;
        public int greens = 0;
        public int blues = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public GameOfBottleViewModel()
        {
            GenerarNuevoJuegoCommand = new RelayCommand(FillBottles);
            ResolverCommand = new RelayCommand(ResolverJuego);
            FillBottles();
        }

        //métodos
        public void FillBottles()
        {
            //reiniciar juego
            ListOfBottles = new List<Bottle>();
            reds = 0;
            greens = 0;
            blues = 0;

            //Lista de todas las botellas
            Random random = new Random();

            for (int e = 0; e < 3; e++)
            {
                
                bottle = new Bottle() { ColorsBottle = new List<ColorBlock>()
                {
                 new ColorBlock { Color = "" },
                 new ColorBlock { Color = "" },
                 new ColorBlock { Color = "" },
                }
                };
                

                for (int i = 0; i < 3; i++)
                {
                    //Crea un numero entreo desde 0 a 2
                    var numberOfColor = random.Next(0, 3);
                    //Si es 0 es rojo
                    if (numberOfColor == 0)
                    {
                        //y todavia se puede poner el color rojo
                        if (reds < 3)
                        {
                            //Sumamos uno al rojo
                            reds++;
                            //Ponemos el color en la posicion i
                            bottle.ColorsBottle[i].Color = "Red";
                            //255 51 51 / 102 255 255
                        }
                        //Si ya hay 3
                        else
                        {
                            //Genera numero 0 o 1 
                            numberOfColor = random.Next(0, 2);
                            //Si el numero es 0
                            if (numberOfColor == 0)
                            {
                                //Y todavia no hay 3 verdes
                                if (greens < 3)
                                {
                                    //Sumamos a verdes
                                    greens++;
                                    //Asignamos el color verde en la botella
                                    bottle.ColorsBottle[i].Color = "Green";
                                }
                                else
                                {
                                    //Si no, la unica parte donde cabe es en azul
                                    blues++;
                                    //Agregamos el color azul.
                                    bottle.ColorsBottle[i].Color = "Blue";
                                }
                            }
                            //El numero fue 1
                            else
                            {
                                //Aun cabe en azules
                                if (blues < 3)
                                {
                                    //Sumamos en azules
                                    blues++;
                                    //Asignamos el color azul a la botella
                                    bottle.ColorsBottle[i].Color = "Blue";
                                }
                                else
                                {
                                    greens++;
                                    bottle.ColorsBottle[i].Color = "Green"; 
                                }
                            }
                        }
                    }
                    /////COLOR VERDE
                    else if (numberOfColor == 1)
                    {
                        //y todavia se puede poner el color verde
                        if (greens < 3)
                        {
                            //Sumamos uno al rojo
                            greens++;
                            //Ponemos el color en la posicion i
                            bottle.ColorsBottle[i].Color = "Green";
                        }
                        //Si ya hay 3
                        else
                        {
                            //Genera numero 0 o 1 
                            numberOfColor = random.Next(0, 2);
                            //Si el numero es 0
                            if (numberOfColor == 0)
                            {
                                //Y todavia no hay 3 rojos
                                if (reds < 3)
                                {
                                    //Sumamos a rojos
                                    reds++;
                                    //Asignamos el color verde en la botella
                                    bottle.ColorsBottle[i].Color = "Red";
                                }
                                else
                                {
                                    //Si no, la unica parte donde cabe es en azul
                                    blues++;
                                    //Agregamos el color azul.
                                    bottle.ColorsBottle[i].Color = "Blue";
                                }
                            }
                            //El numero fue 1
                            else
                            {
                                //Aun cabe en azules
                                if (blues < 3)
                                {
                                    //Sumamos en azules
                                    blues++;
                                    //Asignamos el color azul a la botella
                                    bottle.ColorsBottle[i].Color = "Blue";
                                }
                                else
                                {
                                    reds++;
                                    bottle.ColorsBottle[i].Color = "Red";
                                }
                            }
                        }
                    }
                    ///////////COLOR AZUL
                    else
                    {
                        //y todavia se puede poner el color azul
                        if (blues < 3)
                        {
                            //Sumamos uno al rojo
                            blues++;
                            //Ponemos el color en la posicion i
                            bottle.ColorsBottle[i].Color = "Blue";
                        }
                        //Si ya hay 3
                        else
                        {
                            //Genera numero 0 o 1 
                            numberOfColor = random.Next(0, 2);
                            //Si el numero es 0
                            if (numberOfColor == 0)
                            {
                                //Y todavia no hay 3 rojos
                                if (reds < 3)
                                {
                                    //Sumamos a rojos
                                    reds++;
                                    //Asignamos el color verde en la botella
                                    bottle.ColorsBottle[i].Color = "Red";
                                }
                                else
                                {
                                    //Si no, la unica parte donde cabe es en azul
                                    greens++;
                                    //Agregamos el color azul.
                                    bottle.ColorsBottle[i].Color = "Green";
                                }
                            }
                            //El numero fue 1
                            else
                            {
                                //Aun cabe en azules
                                if (greens < 3)
                                {
                                    //Sumamos en azules
                                    greens++;
                                    //Asignamos el color azul a la botella
                                    bottle.ColorsBottle[i].Color = "Green";
                                }
                                else
                                {
                                    reds++;
                                    bottle.ColorsBottle[i].Color = "Red";
                                }
                            }
                        }
                    }
                }
                ListOfBottles.Add(bottle);
            }
            foreach (var bottle in ListOfBottles)
            {
                if (bottle.ColorsBottle[0].Color == bottle.ColorsBottle[1].Color 
                    && bottle.ColorsBottle[2].Color == bottle.ColorsBottle[1].Color)
                {
                    var color = ListOfBottles[1].ColorsBottle.FirstOrDefault(x => x.Color != bottle.ColorsBottle[2].Color);
                    if (color != null)
                    {
                        bottle.ColorsBottle[2].Color = color.Color;
                    }
                    else
                    {
                        var color2 = ListOfBottles[0].ColorsBottle.FirstOrDefault(x => x.Color != bottle.ColorsBottle[2].Color);
                        if (color2 != null)
                        {
                            bottle.ColorsBottle[2].Color = color2.Color;
                        }
                    }
                }
            }
            bottle = new Bottle()
            {
                ColorsBottle = new List<ColorBlock>()
                {
                 new ColorBlock { Color = "" },
                 new ColorBlock { Color = "" },
                 new ColorBlock { Color = "" },
                }
            };
            ListOfBottles.Add(bottle);
            ListOfBottles.Add(bottle);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListOfBottles"));
        }

        public void ResolverJuego()
        {
            bottle.CalculateH(ListOfBottles);
            bottle.GenerarateSuccessors(ListOfBottles);
        }
    }
}
