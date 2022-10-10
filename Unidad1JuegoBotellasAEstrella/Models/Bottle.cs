using System;
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

                    //botella llena
                    if (secondBottleWithHmin.ColorsBottle[0].Color != "" && secondBottleWithHmin.ColorsBottle[1].Color != ""
                        && secondBottleWithHmin.ColorsBottle[2].Color != "")
                    {
                        //mover dos
                        if (secondBottleWithHmin.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color)
                        {
                            if (bottleWithHmin.ColorsBottle[2].Color == "") //si la pos 2 es vacía, los colores van a pos 2 y pos 1
                            {
                                //    //Vaciar los 2 colores en el botella.
                                bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                                bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[1];

                                //    //Sumar +1 a la G de todas las botellas

                                //aún queda espacio para otro color
                                var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                                var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                                var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();


                                if (bottle2 != null)
                                {
                                    bottleWithHmin.ColorsBottle[0] = bottle2.ColorsBottle[2];
                                    bottle2.ColorsBottle[2].Color = "";
                                }
                                else if (bottle1 != null)
                                {
                                    bottleWithHmin.ColorsBottle[0] = bottle1.ColorsBottle[1];
                                    bottle1.ColorsBottle[1].Color = "";
                                }
                                else if (bottle0 != null)
                                {
                                    bottleWithHmin.ColorsBottle[0] = bottle0.ColorsBottle[0];
                                    bottle0.ColorsBottle[0].Color = "";
                                }
                            }
                            else if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color)
                            //si la pos 2 es de color igual al que se va vaciar entonces , los colores nuevos son pos 1 y pos 0
                            {
                                //    //Vaciar los 2 colores en el botella.
                                bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                                bottleWithHmin.ColorsBottle[0] = secondBottleWithHmin.ColorsBottle[1];

                                //    //Sumar +1 a la G de todas las botellas
                            }

                            //Limpiar la botella de la cual se vaciaron los colores.
                            secondBottleWithHmin.ColorsBottle[0].Color = "";
                            secondBottleWithHmin.ColorsBottle[1].Color = "";

                        }
                        //colores 1 y 2 iguales
                        //else if (secondBottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[2].Color && secondBottleWithHmin.ColorsBottle[0].Color=="")
                        //{
                        //    if (bottleWithHmin.ColorsBottle[2].Color == "") //si la pos 2 es vacía, los colores van a pos 2 y pos 1
                        //    {
                        //        //    //Vaciar los 2 colores en el botella.
                        //        bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                        //        bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[1];

                        //        //    //Sumar +1 a la G de todas las botellas

                        //        //aún queda espacio para otro color
                        //        var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                        //        var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                        //        var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();


                        //        if (bottle2 != null)
                        //        {
                        //            bottleWithHmin.ColorsBottle[0] = bottle2.ColorsBottle[2];
                        //            bottle2.ColorsBottle[2].Color = "";
                        //        }
                        //        else if (bottle1 != null)
                        //        {
                        //            bottleWithHmin.ColorsBottle[0] = bottle1.ColorsBottle[1];
                        //            bottle1.ColorsBottle[1].Color = "";
                        //        }
                        //        else if (bottle0 != null)
                        //        {
                        //            bottleWithHmin.ColorsBottle[0] = bottle0.ColorsBottle[0];
                        //            bottle0.ColorsBottle[0].Color = "";
                        //        }
                        //    }
                        //    else if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color)
                        //    //si la pos 2 es de color igual al que se va vaciar entonces , los colores nuevos son pos 1 y pos 0
                        //    {
                        //        //    //Vaciar los 2 colores en el botella.
                        //        bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                        //        bottleWithHmin.ColorsBottle[0] = secondBottleWithHmin.ColorsBottle[1];

                        //        //    //Sumar +1 a la G de todas las botellas

                        //        //ya no hay espacio para color
                        //    }

                        //    //Limpiar la botella de la cual se vaciaron los colores.
                        //    secondBottleWithHmin.ColorsBottle[2].Color = "";
                        //    secondBottleWithHmin.ColorsBottle[1].Color = "";

                        //    //volver a calcular h
                        //    CalculateH(listBottles);
                        //}

                        //mover 1 (el de pos 0)
                        else if (bottleWithHmin.ColorsBottle[2].Color == "")
                        {//botella vacía
                            bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[0];

                            //quedan dos espacios
                            var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            if (bottle2 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle2.ColorsBottle[2];
                                bottle2.ColorsBottle[2].Color = "";
                            }
                            else if (bottle1 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle1.ColorsBottle[1];
                                bottle1.ColorsBottle[1].Color = "";
                            }
                            else if (bottle0 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle0.ColorsBottle[0];
                                bottle0.ColorsBottle[0].Color = "";
                            }
                            secondBottleWithHmin.ColorsBottle[0].Color = "";
                        }
                        else if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[0].Color && bottleWithHmin.ColorsBottle[1].Color=="" && bottleWithHmin.ColorsBottle[0].Color == "")
                        {//botella 2 espacio
                            bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[0];

                            //queda 1 espacio
                            var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            if (bottle2 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle2.ColorsBottle[2];
                                bottle2.ColorsBottle[2].Color = "";
                            }
                            else if (bottle1 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle1.ColorsBottle[1];
                                bottle1.ColorsBottle[1].Color = "";
                            }
                            else if (bottle0 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle0.ColorsBottle[0];
                                bottle0.ColorsBottle[0].Color = "";
                            }
                        }
                        else if (bottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[0].Color)
                        {//botella 1 espacio
                            bottleWithHmin.ColorsBottle[0] = secondBottleWithHmin.ColorsBottle[0];
                            secondBottleWithHmin.ColorsBottle[0].Color = "";

                           //botella llena
                        }
                        secondBottleWithHmin.ColorsBottle[0].Color = "";

                        //volver a calcular h
                        CalculateH(listBottles);
                    }


                    //botella con 1 espacio
                    else if (secondBottleWithHmin.ColorsBottle[0].Color == "" && secondBottleWithHmin.ColorsBottle[1].Color != ""
                       && secondBottleWithHmin.ColorsBottle[2].Color != "")
                    {
                        //mover dos
                        if (secondBottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[2].Color)
                        {
                            if (bottleWithHmin.ColorsBottle[2].Color == "") //si la pos 2 es vacía, los colores van a pos 2 y pos 1
                            {
                                //Vaciar los 2 colores en el botella.
                                bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                                bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[1];

                                //    //Sumar +1 a la G de todas las botellas

                                //aún queda espacio para otro color
                                var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                                var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                                var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();


                                if (bottle2 != null)
                                {
                                    bottleWithHmin.ColorsBottle[0] = bottle2.ColorsBottle[2];
                                    bottle2.ColorsBottle[2].Color = "";
                                }
                                else if (bottle1 != null)
                                {
                                    bottleWithHmin.ColorsBottle[0] = bottle1.ColorsBottle[1];
                                    bottle1.ColorsBottle[1].Color = "";
                                }
                                else if (bottle0 != null)
                                {
                                    bottleWithHmin.ColorsBottle[0] = bottle0.ColorsBottle[0];
                                    bottle0.ColorsBottle[0].Color = "";
                                }
                            }
                            else if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color)
                            //si la pos 2 es de color igual al que se va vaciar entonces , los colores nuevos son pos 1 y pos 0
                            {
                                //    //Vaciar los 2 colores en el botella.
                                bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                                bottleWithHmin.ColorsBottle[0] = secondBottleWithHmin.ColorsBottle[1];

                                //    //Sumar +1 a la G de todas las botellas
                            }

                            //Limpiar la botella de la cual se vaciaron los colores.
                            secondBottleWithHmin.ColorsBottle[0].Color = "";
                            secondBottleWithHmin.ColorsBottle[1].Color = "";

                        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //mover 1 (el de pos 1)
                        else if (bottleWithHmin.ColorsBottle[2].Color == "")
                        {//botella vacía
                            bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[1];
                            secondBottleWithHmin.ColorsBottle[1].Color = "";

                            //quedan dos espacios
                            var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[2].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[2].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[2].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            if (bottle2 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle2.ColorsBottle[2];
                                bottle2.ColorsBottle[2].Color = "";
                            }
                            else if (bottle1 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle1.ColorsBottle[1];
                                bottle1.ColorsBottle[1].Color = "";
                            }
                            else if (bottle0 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle0.ColorsBottle[0];
                                bottle0.ColorsBottle[0].Color = "";
                            }
                        }
                        else if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[0].Color && bottleWithHmin.ColorsBottle[1].Color == "" && bottleWithHmin.ColorsBottle[0].Color == "")
                        {//botella 2 espacio
                            bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[0];
                            secondBottleWithHmin.ColorsBottle[0].Color = "";

                            //queda 1 espacio
                            var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            if (bottle2 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle2.ColorsBottle[2];
                                bottle2.ColorsBottle[2].Color = "";
                            }
                            else if (bottle1 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle1.ColorsBottle[1];
                                bottle1.ColorsBottle[1].Color = "";
                            }
                            else if (bottle0 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle0.ColorsBottle[0];
                                bottle0.ColorsBottle[0].Color = "";
                            }
                        }
                        else if (bottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[0].Color)
                        {//botella 1 espacio
                            bottleWithHmin.ColorsBottle[0] = secondBottleWithHmin.ColorsBottle[0];
                            secondBottleWithHmin.ColorsBottle[0].Color = "";

                            //botella llena
                        }




                        //colores 1 y 2 iguales
                        //else if (secondBottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[2].Color && secondBottleWithHmin.ColorsBottle[0].Color=="")
                        //{
                        //    if (bottleWithHmin.ColorsBottle[2].Color == "") //si la pos 2 es vacía, los colores van a pos 2 y pos 1
                        //    {
                        //        //    //Vaciar los 2 colores en el botella.
                        //        bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                        //        bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[1];

                            //        //    //Sumar +1 a la G de todas las botellas

                            //        //aún queda espacio para otro color
                            //        var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            //        var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            //        var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();


                            //        if (bottle2 != null)
                            //        {
                            //            bottleWithHmin.ColorsBottle[0] = bottle2.ColorsBottle[2];
                            //            bottle2.ColorsBottle[2].Color = "";
                            //        }
                            //        else if (bottle1 != null)
                            //        {
                            //            bottleWithHmin.ColorsBottle[0] = bottle1.ColorsBottle[1];
                            //            bottle1.ColorsBottle[1].Color = "";
                            //        }
                            //        else if (bottle0 != null)
                            //        {
                            //            bottleWithHmin.ColorsBottle[0] = bottle0.ColorsBottle[0];
                            //            bottle0.ColorsBottle[0].Color = "";
                            //        }
                            //    }
                            //    else if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color)
                            //    //si la pos 2 es de color igual al que se va vaciar entonces , los colores nuevos son pos 1 y pos 0
                            //    {
                            //        //    //Vaciar los 2 colores en el botella.
                            //        bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[1];
                            //        bottleWithHmin.ColorsBottle[0] = secondBottleWithHmin.ColorsBottle[1];

                            //        //    //Sumar +1 a la G de todas las botellas

                            //        //ya no hay espacio para color
                            //    }

                            //    //Limpiar la botella de la cual se vaciaron los colores.
                            //    secondBottleWithHmin.ColorsBottle[2].Color = "";
                            //    secondBottleWithHmin.ColorsBottle[1].Color = "";

                            //    //volver a calcular h
                            //    CalculateH(listBottles);
                            //}

                            //mover 1 
                        else if (bottleWithHmin.ColorsBottle[2].Color == "")
                        {//botella vacía
                            bottleWithHmin.ColorsBottle[2] = secondBottleWithHmin.ColorsBottle[0];
                            secondBottleWithHmin.ColorsBottle[0].Color = "";

                            //quedan dos espacios
                            var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[2].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[2].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[1].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            if (bottle2 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle2.ColorsBottle[2];
                                bottle2.ColorsBottle[2].Color = "";
                            }
                            else if (bottle1 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle1.ColorsBottle[1];
                                bottle1.ColorsBottle[1].Color = "";
                            }
                            else if (bottle0 != null)
                            {
                                bottleWithHmin.ColorsBottle[1] = bottle0.ColorsBottle[0];
                                bottle0.ColorsBottle[0].Color = "";
                            }
                        }
                        else if (bottleWithHmin.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[0].Color && bottleWithHmin.ColorsBottle[1].Color == "" && bottleWithHmin.ColorsBottle[0].Color == "")
                        {//botella 2 espacio
                            bottleWithHmin.ColorsBottle[1] = secondBottleWithHmin.ColorsBottle[0];
                            secondBottleWithHmin.ColorsBottle[0].Color = "";

                            //queda 1 espacio
                            var bottle0 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[0].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle1 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            var bottle2 = listBottles.Where(x => x.H != 0 && x.ColorsBottle[2].Color == secondBottleWithHmin.ColorsBottle[0].Color && x.ColorsBottle[0].Color == "" && x.ColorsBottle[1].Color == "" && x.ColorsBottle != secondBottleWithHmin.ColorsBottle).OrderBy(x => x.H).FirstOrDefault();

                            if (bottle2 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle2.ColorsBottle[2];
                                bottle2.ColorsBottle[2].Color = "";
                            }
                            else if (bottle1 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle1.ColorsBottle[1];
                                bottle1.ColorsBottle[1].Color = "";
                            }
                            else if (bottle0 != null)
                            {
                                bottleWithHmin.ColorsBottle[0] = bottle0.ColorsBottle[0];
                                bottle0.ColorsBottle[0].Color = "";
                            }
                        }
                        else if (bottleWithHmin.ColorsBottle[1].Color == secondBottleWithHmin.ColorsBottle[0].Color)
                        {//botella 1 espacio
                            bottleWithHmin.ColorsBottle[0] = secondBottleWithHmin.ColorsBottle[0];
                            secondBottleWithHmin.ColorsBottle[0].Color = "";

                            //botella llena
                        }

                        //volver a calcular h
                        CalculateH(listBottles);
                    }











                    //botella con dos colores llenos
                    //mover un solo color
                    else if (secondBottleWithHmin.ColorsBottle[1].Color != "" && secondBottleWithHmin.ColorsBottle[2].Color != "")
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


                                //quedan dos espacios de color

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
/*
 * ver si se podrían mover dos colores
 * si sí
 *   se mueven
 *   si esa botella a donde se movieron aún tiene espacio, se busca otro color que se pueda mover ahí
 *   
 *si no
 *   vuelve a calcular h 
 *   busc
 *     
 */