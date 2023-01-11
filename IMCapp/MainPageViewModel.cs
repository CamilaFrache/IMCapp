using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCapp
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private double weight = 70;
        private double height = 150;
        private const double Step = 1.0;

        public double Height
        {
            get => height;
            set
            {
                height = NextStep(value);
                UpdateIMC();
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                weight = NextStep(value);
                UpdateIMC();
            }
        }

        public double Imc
            => Math.Round(Weight / Math.Pow(Height / 100, 2), 2);

        public string Classification
        {
            get
            {
                if (Imc < 18.5)
                    return "Tu IMC esta por debajo de lo saludable";
                else if (Imc < 25)
                    return "Tu IMC es saludable";
                else 
                    return "Tu IMC esta por arriba de lo recomendado";    
            }
        }

        private void UpdateIMC()
        {
            RaisePropertyChanged(nameof(Imc));
            RaisePropertyChanged(nameof(Classification));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private double NextStep(double value)
            => Math.Round(value / Step) * Step;
        
    }
}
