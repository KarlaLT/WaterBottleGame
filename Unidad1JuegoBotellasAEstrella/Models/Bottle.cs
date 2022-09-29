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
        //public string ColorA { get; set; } = "";
        //public string ColorB { get; set; } = "";
        //public string ColorC { get; set; } = "";

        public List<ColorBlock> ColorsBottle { get; set; } = new List<ColorBlock>();

        public Bottle()
        {
            ColorsBottle.Add(new ColorBlock { Color = "Red" });
            ColorsBottle.Add(new ColorBlock { Color = "Green" });
            ColorsBottle.Add(new ColorBlock { Color = "Red" });
        }
        //Hay 2 maneras, hacer una clase botella con las 3 propiedades o una clase botella con una sola propiedad para tener una lista
        //de botellas que en realidad serian las particiones.
        public void CalculateHIndividual(List<Bottle> botellas)
        {
            int h = 0;
            foreach (Bottle bottle in botellas)
            {

            }
            var backColor = "";
            foreach (var color in ColorsBottle)
            {
                    if (backColor == color.Color)
                    {
                        backColor = color.Color;                       
                    }
                    else
                    {
                        H++;
                        backColor = color.Color;
                    }
            }
        }
        public List<Bottle> GenerarateSuccessors()
        {
            return null;
        }
    }
}
