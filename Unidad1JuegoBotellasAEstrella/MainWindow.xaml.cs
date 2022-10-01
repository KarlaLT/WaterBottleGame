using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unidad1JuegoBotellasAEstrella.Models;

namespace Unidad1JuegoBotellasAEstrella
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bottle bottle = new Bottle();
        public List<ColorBlock> ColorsBottle1 { get; set; } = new List<ColorBlock>();
        public List<ColorBlock> ColorsBottle2 { get; set; } = new List<ColorBlock>();
        public List<ColorBlock> ColorsBottle3 { get; set; } = new List<ColorBlock>();
        public List<ColorBlock> ColorsBottle4 { get; set; } = new List<ColorBlock>();
        public List<ColorBlock> ColorsBottle5 { get; set; } = new List<ColorBlock>();

        public MainWindow()
        {
            InitializeComponent();
            //Colores primer botella
            ColorsBottle1.Add(new ColorBlock { Color = "Red" });
            ColorsBottle1.Add(new ColorBlock { Color = "Green" });
            ColorsBottle1.Add(new ColorBlock { Color = "Red" });
            //Colores segunda botella
            ColorsBottle2.Add(new ColorBlock { Color = "Green" });
            ColorsBottle2.Add(new ColorBlock { Color = "Blue" });
            ColorsBottle2.Add(new ColorBlock { Color = "Blue" });
            //Colores tercera botella
            ColorsBottle3.Add(new ColorBlock { Color = "Blue" });
            ColorsBottle3.Add(new ColorBlock { Color = "Green" });
            ColorsBottle3.Add(new ColorBlock { Color = "Red" });
            //Colores cuarta botella
            ColorsBottle4.Add(new ColorBlock { Color = "" });
            ColorsBottle4.Add(new ColorBlock { Color = "" });
            ColorsBottle4.Add(new ColorBlock { Color = "" });
            //COlores quinta botella
            ColorsBottle5.Add(new ColorBlock { Color = "" });
            ColorsBottle5.Add(new ColorBlock { Color = "" });
            ColorsBottle5.Add(new ColorBlock { Color = "" });

            //Lista de todas las botellas
            List<Bottle> bottles = new List<Bottle> {
                //Botella 1
                new Bottle { ColorsBottle = ColorsBottle1 },
                //Botella 2
                new Bottle { ColorsBottle = ColorsBottle2 },
                //Botella 3
                new Bottle { ColorsBottle = ColorsBottle3 },
                //Botella 4
                new Bottle { ColorsBottle = ColorsBottle4 },
                //Botella 5
                new Bottle { ColorsBottle = ColorsBottle5 }
            };
            bottle.CalculateH(bottles);
            int numberOfBottle = 0;
            foreach (var bottle in bottles)
            {
                numberOfBottle++;
                MessageBox.Show($"Botella {numberOfBottle}: H = {bottle.H}");
            }      
            bottle.GenerarateSuccessors(bottles);
        }
    }
}
