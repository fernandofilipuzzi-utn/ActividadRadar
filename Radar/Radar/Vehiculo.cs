using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar
{
    class Vehiculo
    {
        public string Patente { get; private set; }
        public double Velocidad { get; private set; }
        public bool EsOficial { get; private set; }

        public Vehiculo(string patente, double velocidad, bool esOficial) 
        {
            Patente = patente;
            Velocidad = velocidad;
            EsOficial = esOficial;
        }
        public bool VerificarVelocidadInfraccion()
        {
            return Velocidad < 50 || Velocidad > 90;
        }
    }
}
