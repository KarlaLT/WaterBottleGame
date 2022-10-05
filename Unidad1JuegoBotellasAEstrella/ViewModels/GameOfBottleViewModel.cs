using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unidad1JuegoBotellasAEstrella.Models;

namespace Unidad1JuegoBotellasAEstrella.ViewModels
{
    public class GameOfBottleViewModel
    {
        public List<Bottle> ListOfBottles { get; set; } = new List<Bottle>();
        public int reds = 0;
        public int greens = 0;
        public int blues = 0;
        public GameOfBottleViewModel()
        {
            ListOfBottles.Add(
            new Bottle
            {
             ColorsBottle = new List<ColorBlock>()
            {
                 new ColorBlock { Color = "Red" },
                 new ColorBlock { Color = "Blue" },
                 new ColorBlock { Color = "Green" },
            }
            });
            ListOfBottles.Add(
             new Bottle
             {
                 ColorsBottle = new List<ColorBlock>()
             {
                 new ColorBlock { Color = "Red" },
                 new ColorBlock { Color = "Blue" },
                 new ColorBlock { Color = "Green" },
             }
             });
            ListOfBottles.Add(
            new Bottle
            {
                ColorsBottle = new List<ColorBlock>()
            {
                 new ColorBlock { Color = "Red" },
                 new ColorBlock { Color = "Blue" },
                 new ColorBlock { Color = "Green" },
            }
            });
            ListOfBottles.Add(
            new Bottle
            {
                ColorsBottle = new List<ColorBlock>()
            {
                 new ColorBlock { Color = "" },
                 new ColorBlock { Color = "" },
                 new ColorBlock { Color = "" },
            }
            });
            ListOfBottles.Add(
            new Bottle
            {
                ColorsBottle = new List<ColorBlock>()
            {
                 new ColorBlock { Color = "" },
                 new ColorBlock { Color = "" },
                 new ColorBlock { Color = "" },
            }
            });
            FillBottles();
        }
        public void FillBottles()
        {
            //Lista de todas las botellas
            
            Random random = new Random();
            foreach (var bottle in ListOfBottles)
            {
                for (int i = 0; i < 3; i++)
                {
                    //Crea un numero entreo desde 0 a 2
                   var numberOfColor = random.Next(0, 3);
                    //Si es 0
                   if(numberOfColor == 0)
                    {
                        //y todavia se puede poner el color rojo
                        if(reds < 3)
                        {
                            //Sumamos uno al rojo
                            reds++;
                            //Ponemos el color en la posicion i
                            bottle.ColorsBottle[i].Color = "Red";
                        }
                        //Si ya hay 3
                        else
                        {
                            //Genera numero 0 o 1 
                            numberOfColor = random.Next(0, 2);
                            //Si el numero es 0
                            if(numberOfColor == 0)
                            {
                                //Y todavia no hay 3 verdes
                                if(greens < 3)
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
                                if(blues < 3)
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
                    else if(numberOfColor == 1)
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
            }
        }
    }
}
