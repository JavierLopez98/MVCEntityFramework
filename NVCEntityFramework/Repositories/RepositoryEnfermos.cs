using NVCEntityFramework.Data;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Repositories
{
    public class RepositoryEnfermos
    {
        private EnfermosContext context;
        public RepositoryEnfermos(EnfermosContext context)
        {
            this.context = context;
        }
        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.context.Enfermos select datos;
            return consulta.ToList();
        }
        public Enfermo BuscarEnfermo(int inscripcion)
        {
            var consulta = from datos in this.context.Enfermos where datos.Inscripcion == inscripcion select datos;
            if (consulta.Count() == 0) return null;
            else return consulta.First();
        }

        public List<Genero> GetGeneros()
        {
            var consulta = (from datos in this.context.Enfermos select datos.Genero).Distinct();
            List<Genero> generos = new List<Genero>();
            foreach(String dato in consulta)
            {
                Genero gen = new Genero();
                gen.Value = dato;
                if (dato.ToLower() == "f")
                {
                    gen.Text = "Femenino";
                }
                else gen.Text = "Masculino";
                generos.Add(gen);
            }

            return generos;
        }

        public List<Enfermo> GetEnfermosGenero(String genero)
        {
            var consulta = from datos in this.context.Enfermos where datos.Genero == genero select datos;
            return consulta.ToList();
        }

        public void EliminarEnfermo(int inscripcion)
        {
            Enfermo enf = this.BuscarEnfermo(inscripcion);

            this.context.Enfermos.Remove(enf);
            this.context.SaveChanges();
        }
        public void InsertarEnfermo(int inscripcion,String apellido,String direccion, DateTime fechanac,String genero,String nss)
        {
            Enfermo enf = new Enfermo();
            enf.Inscripcion = inscripcion;
            enf.Apellido = apellido;
            enf.Direccion = direccion;
            enf.FechaNacimiento = fechanac;
            enf.Genero = genero;
            enf.NSS = nss;
            this.context.Enfermos.Add(enf);
            this.context.SaveChanges();
        }
        public void ModificarEnfermo(int inscripcion, String apellido, String direccion, DateTime fechanac, String genero, String nss)
        {
            Enfermo enf = this.BuscarEnfermo(inscripcion);
            enf.Inscripcion = inscripcion;
            enf.Apellido = apellido;
            enf.Direccion = direccion;
            enf.FechaNacimiento = fechanac;
            enf.Genero = genero;
            enf.NSS = nss;
            
            this.context.SaveChanges();
        }


    }
}
