using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Unidad1Programa3
{
    public class Juego : INotifyPropertyChanged
    {
        private ushort numeroAA;
        private byte op;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool JuegoIniciado { get; set; } = false;
        public string? Resultado { get; set; }
        public byte Oportunidades
        {
            get { return op; }
        }
        public ushort final { get; set; }
        public void Iniciar()
        {
            Random r = new Random();
            numeroAA = (ushort)r.Next(1, 5001);
            op = 10;
            Resultado = "Pista";
            JuegoIniciado = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Jugar()
        {
            if (final == numeroAA)
            {
                JuegoIniciado = false;
                Resultado = "Felicidades ganaste";
                final = 0;
            }
            else
            {
                op--;
                if (op == 0)
                {
                    JuegoIniciado = false;
                    Resultado = "Lo siento,te quedaste sin oportunidades";
                    final = 0;
                }
                else
                {
                    if (numeroAA > final)
                    {
                        Resultado = "El numero a adivinar es mayor";
                    }
                    if (numeroAA < final)
                    {
                        Resultado = "El numeroa adivinar es menor";
                    }
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public ICommand IniciarComando { get; set; }
        public ICommand JugarComando { get; set; }

        public Juego()
        {
            IniciarComando = new RelayCommand(Iniciar);
            JugarComando = new RelayCommand(Jugar);
        }

    }
}



    
    

