using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Unidad1JuegoBotellasAEstrella.Models
{
    public class ColorBlock:INotifyPropertyChanged
    {
        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color")); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
