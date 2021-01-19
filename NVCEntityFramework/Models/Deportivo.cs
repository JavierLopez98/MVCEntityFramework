using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Models
{
    public class Deportivo : Coche,ICoche
    {

        public Deportivo(String marca,String modelo,String imagen,int velocidadmaxima)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Imagen = imagen;
            this.Velocidad = 0;
            this.VelocidadMaxima = velocidadmaxima;
        }

        public Deportivo()
        {
            this.Marca = "Ford";
            this.Modelo = "Mustang";
            this.Imagen = "mustang.jpg";
            this.Velocidad = 0;
            this.VelocidadMaxima = 240;
        }

    }
}
