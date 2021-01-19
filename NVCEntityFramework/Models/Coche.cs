using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    public class Coche : ICoche
    {
        public string Marca { get; set; }
        public String Modelo { get; set; }
        public String Imagen { get; set; }
        public int VelocidadMaxima {get;set;}
        public int Velocidad { get; set; }


        public Coche()
        {
            this.Marca = "Duesenberg";
            this.Modelo = "SSJ";
            this.Imagen = "DuesenbergSSJ.jpg";
            this.VelocidadMaxima =180;
            this.Velocidad = 0;
        }
        public void Acelerar()
        {
            this.Velocidad += 10;
            if (this.Velocidad >= this.VelocidadMaxima)
            {
                this.Velocidad = this.VelocidadMaxima;
            }
        }
        public void Frenar()
        {
            this.Velocidad -= 10;
            if (this.Velocidad <= 0)
            {
                this.Velocidad = 0;
            }
        }

    }
}
