﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Unidad1JuegoBotellasAEstrella.Models
{
    public class Bottle
    {
        public int G { get; set; }
        public int H { get; set; }
        public int F => H + G;

        public List<ColorBlock> ColorsBottle { get; set; }
        public Bottle()
        {
            ColorsBottle = new List<ColorBlock>();
        }

        public void CalculateH(List<Bottle> bottles)
        {
            //reiniciar el h cada que se vuelva a calcular
            bottles.ForEach(x => x.H = 0);

            var backColor = "";
            foreach (var bottle in bottles)
            {
                foreach (var colors in bottle.ColorsBottle)
                {
                    if (backColor == colors.Color)
                    {
                        backColor = colors.Color;
                    }
                    else
                    {
                        bottle.H++;
                        backColor = colors.Color;
                    }
                }
                backColor = "";
            }
        }
        public List<Bottle> GenerarateSuccessors(List<Bottle> listBottles)
        {
            //Debemos de buscar el que tiene la H minima y lo vaciamos en el vacio
            //Luego buscamos el que tenga la H minima de nuevo que en este caso seria la que acabamos de vaciar
            //luego buscariamos en todas las botellas a ver si en la de mero arriba es del mismo color que acabamos de vaciar
            //En caso de que no, buscamos de nuevo la H minima y la vaciamos en el otro vacio que en este caso seria el que tiene
            //La h minima.
            //Luego volvemos a agarrar el de los vacios que tendra un solo color y checamos si en el de mero arriba hay algun
            //Color que sea el mismo, si no hay buscamos la H minima y empezamos a vaciar en los demas (los que no estaban vacios).

            //en caso de que no se pueda vaciar (Agregar variable o propiedad de no se puede vaciar o pasar a cerrados)
            //en ninguno buscaremos la H minima de nuevo, en caso de que tengan la misma todas las botellas que tome la primera
            // que encuentre y la vaciamos en el segundo que tenga la H minima y asi va el juego repetiendo hasta acabar
            //Si todos tienen la misma H deberiamos tomar el color y buscar en otra botella de las que solo tendran un color
            //El mismo color
            //((((((((((((CLAVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE)))))))))))))))))))))/////////////////////////////////////
            //Debemos tambien vaciar el que tiene mas H en el que tiene menos H para no desperdiciar movimientos 
            //Casi lo tengo, ya dormire, bay, eres increible.


            ///// PENDIENTE VER COMO RESTAR H O LIMPIAR TODAS LAS H Y VOLVERLAS A CALCULAR CUANDO SE MUEVE UN COLOR.
            //// PORQUE YO EN MI METODO SOLO SUMO EN LA H PERO FALTARIA VER DONDE PONER RESTAR LA H O LIMPIAR LA H.

            //Obtener la botella con la H minima
            do //meintras alguna botella aun no tenga 0 en su h, quiere decir que aún no está resuelta
            {
                var bottleWithHmin = listBottles.OrderBy(x => x.H).FirstOrDefault();
                var secondBottleWithHmin = listBottles.Where(x => x.H != 0).OrderBy(x => x.H).FirstOrDefault();

                if (bottleWithHmin != null && secondBottleWithHmin != null)
                {
                    //Si los colores de la botella en las 3 posiciones son iguales eliminamos la botella.
                    if (bottleWithHmin.ColorsBottle[0].Color == bottleWithHmin.ColorsBottle[1].Color
                        && bottleWithHmin.ColorsBottle[1].Color == bottleWithHmin.ColorsBottle[2].Color)
                    {
                        if (bottleWithHmin.ColorsBottle[0].Color != "")
                            //Borramos de la lista la botella para que ya no lo tome en cuenta cuando calculemos H y busquemos sucesores
                            listBottles.Remove(bottleWithHmin);
                        //Sumar +1 a la G de todas las botellas

                    }
                    if (secondBottleWithHmin.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color
                        && secondBottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[2].Color)
                    {
                        listBottles.Remove(secondBottleWithHmin);
                        //Sumar +1 a la G de todas las botellas
                    }


                    //Si los colores de la posicion 2 y 1 son iguales moveremos los 2 al de la H minima siempre y cuando
                    //Quepa y sea del mismo color o este vacio
                    if (secondBottleWithHmin.ColorsBottle[0].Color != "" && secondBottleWithHmin.ColorsBottle[1].Color != "")
                    {//que no sean colores vacíos
                        if (secondBottleWithHmin.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color ||
                       secondBottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[2].Color)
                        {
                            //Si la botella con H minimo en la posicion cero es igual al color 
                            //de la segunda botella en la posicion 1. esto para ver si se puede mover o no.
                            if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color || bottleWithHmin.ColorsBottle[2].Color == ""
                                )
                            {
                                ////Verificar que este vacio el color en la posicion 1 y 2 para vaciar los 2 colores
                                //if (bottleWithHmin.ColorsBottle[1].Color == "")
                                //{
                                //    //Vaciar los 2 colores en el botella.
                                //    bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                                //    bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[2];
                                //    //Limpiar la botella de la cual se vaciaron los colores.
                                //    secondBottleWithHmin.ColorsBottle[1].Color = "";
                                //    secondBottleWithHmin.ColorsBottle[1].Color = "";
                                //    //Sumar +1 a la G de todas las botellas
                                //}
                                //else
                                //{
                                //    //No podemos vaciar los 2 colores aqui porque no cabe
                                //}
                                if (bottleWithHmin.ColorsBottle[2].Color == "") //si la pos 2 es vacía, los colores van a pos 2 y pos 1
                                {
                                    //    //Vaciar los 2 colores en el botella.
                                    bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                                    bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[1];

                                    //    //Sumar +1 a la G de todas las botellas
                                }
                                else //si la pos 2 es de color igual al que se va vaciar entonces , los colores nuevos son pos 1 y pos 0
                                {
                                    //    //Vaciar los 2 colores en el botella.
                                    bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                                    bottleWithHmin.ColorsBottle[0] = secondBottleWithHmin.ColorsBottle[1];

                                    //    //Sumar +1 a la G de todas las botellas
                                }
                                //Limpiar la botella de la cual se vaciaron los colores.
                                if (secondBottleWithHmin.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color)
                                {
                                    secondBottleWithHmin.ColorsBottle[0].Color = "";
                                    secondBottleWithHmin.ColorsBottle[1].Color = "";
                                }
                                else
                                {
                                    secondBottleWithHmin.ColorsBottle[2].Color = "";
                                    secondBottleWithHmin.ColorsBottle[1].Color = "";
                                }
                                //volver a calcular h
                                CalculateH(listBottles);
                            }
                        }
                    }                   
                    //mover un solo color
                    else
                    {
                        //Ver si esta completamente vacio movemos el color ahi
                        if (bottleWithHmin.ColorsBottle[2].Color == "" && bottleWithHmin.ColorsBottle[1].Color == "" && bottleWithHmin.ColorsBottle[0].Color == "")
                        {
                            //El color de la segunda botella con H minima pasa a la primera
                            if (secondBottleWithHmin.H == 3) //hay 3 colores en la botella, se mueve el de arriba pos 0
                            {                                
                                bottleWithHmin.ColorsBottle[2].Color = secondBottleWithHmin.ColorsBottle[0].Color;
                                //Quitar el color de la segunda botella.
                                secondBottleWithHmin.ColorsBottle[0].Color = "";
                            }
                            else if (secondBottleWithHmin.H == 2)
                            {
                                //no pueden ser 3 bloques 2 colores, pq se hubiera movido en el if de arriba, entonces son 2 bloques pos 2 y pos 1
                                bottleWithHmin.ColorsBottle[2].Color = secondBottleWithHmin.ColorsBottle[1].Color;
                                //Quitar el color de la segunda botella.
                                secondBottleWithHmin.ColorsBottle[1].Color = "";
                            }
                            else if (secondBottleWithHmin.H == 1)
                            {
                                bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[2];
                                //Quitar el color de la segunda botella.
                                secondBottleWithHmin.ColorsBottle[2].Color = "";
                            }
                            CalculateH(listBottles);
                            // Sumar +1 a la G de todas las botellas.
                        }

                        else if (bottleWithHmin.ColorsBottle[1].Color == "" && bottleWithHmin.ColorsBottle[0].Color == "") //si tiene 2 pos vacías
                        {
                            if (secondBottleWithHmin.H == 3) //hay 3 colores en la botella, se mueve el de arriba pos 0
                            {
                                if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[0].Color)
                                {
                                    if (bottleWithHmin.ColorsBottle[1].Color == "")
                                    {
                                        //El color de la segunda botella con H minima pasa a la primera
                                        bottleWithHmin.ColorsBottle[1].Color = secondBottleWithHmin.ColorsBottle[0].Color;
                                        //Quitar el color de la segunda botella.
                                        secondBottleWithHmin.ColorsBottle[0].Color = "";
                                        // Sumar +1 a la G de todas las botellas.
                                    }
                                }
                            }
                            else if (secondBottleWithHmin.H == 2)
                            {
                                //no pueden ser 3 bloques 2 colores, pq se hubiera movido en el if de arriba, entonces son 2 bloques pos 2 y pos 1
                                if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color)
                                {
                                    if (bottleWithHmin.ColorsBottle[1].Color == "")
                                    {
                                        //El color de la segunda botella con H minima pasa a la primera
                                        bottleWithHmin.ColorsBottle[1].Color = secondBottleWithHmin.ColorsBottle[1].Color;
                                        //Quitar el color de la segunda botella.
                                        secondBottleWithHmin.ColorsBottle[1].Color = "";
                                        // Sumar +1 a la G de todas las botellas.
                                    }
                                }
                            }
                            else
                            {
                                bottleWithHmin.ColorsBottle[1].Color = secondBottleWithHmin.ColorsBottle[2].Color;
                                //Quitar el color de la segunda botella.
                                secondBottleWithHmin.ColorsBottle[2].Color = "";
                            }
                            CalculateH(listBottles);
                            //Ver si podria quedar el color en la posicion 1
                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            //if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[2].Color)
                            //{
                            //    //Ver si la posicion 1 esta vacio para poner el color ahi
                            //    if (bottleWithHmin.ColorsBottle[1].Color == "")
                            //    {
                            //        //El color de la segunda botella con H minima pasa a la primera
                            //        bottleWithHmin.ColorsBottle[1].Color = secondBottleWithHmin.ColorsBottle[2].Color;
                            //        //Quitar el color de la segunda botella.
                            //        secondBottleWithHmin.ColorsBottle[2].Color = "";
                            //        // Sumar +1 a la G de todas las botellas.
                            //    }
                            //    //No esta vacio la posicion 1 de la botella
                            //    else
                            //    {
                            //        //Ver si el color de la botella 2 puede quedar en la posicion 2 de la botella 1
                            //        if (bottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[2].Color)
                            //        {
                            //            if (bottleWithHmin.ColorsBottle[2].Color == "")
                            //            {
                            //                //El color de la segunda botella con H minima pasa a la primera
                            //                bottleWithHmin.ColorsBottle[2].Color = secondBottleWithHmin.ColorsBottle[2].Color;
                            //                //Quitar el color de la segunda botella.
                            //                secondBottleWithHmin.ColorsBottle[2].Color = "";
                            //            }
                            //            else
                            //            {
                            //                //Quiere decir que aqui no cabe nada, debemos volver a calcular H y todo eso

                            //            }
                            //        }
                            //        else
                            //        {
                            //            //Quiere decir que no son del mismo color, debemos volver a calcular H
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    //Quiere decir que no son del mismo color, debemos volver a calcular H   
                            //}
                        }
                    }
                }
            }
            while (listBottles.Any(x => x.H != 0));


            return null;
        }
    }
}
