using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploCRUD.Models
{
    public class Estudiante
    {
        private int ID;
        private String carnet;
        private String nombre;
        private String apellido;
        private String sexo;
        private String edad;

        //Para modificar
        public Estudiante(int iD, string carnet, string nombre, string apellido, string sexo, string edad)
        {
            ID1 = iD;
            this.Carnet = carnet;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Edad = edad;
        }

        //Para insertar
        public Estudiante(string carnet, string nombre, string apellido, string sexo, string edad)
        {
            this.Carnet = carnet;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Edad = edad;
        }

        //Para eliminar
        public Estudiante(int iD)
        {
            ID1 = iD;
        }

        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public string Carnet
        {
            get
            {
                return carnet;
            }

            set
            {
                carnet = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public string Edad
        {
            get
            {
                return edad;
            }

            set
            {
                edad = value;
            }
        }
    }
}