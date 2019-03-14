﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BetaLabUnidad3.Singleton;
using System.ComponentModel;
using BetaLabUnidad3.Models;

namespace BetaLabUnidad3.Models
{
    public class Med : IComparable
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Nombre de Medicamento")]
        public string Nombre { get; set; }
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [DisplayName("Casa Medica")]
        public string casa { get; set; }
        [DisplayName("Precio de Medicamento")]
        public double precio { get; set; }
        [DisplayName("En existencia")]
        public int existencia { get; set; }

        public int pedido { get; set; }

        public void AgregarALista(Med medicamento)
        {
            DataAlmacenada.Instancia.ListaMed.Add(medicamento); //
        }

        public void AgregarAArbol(Med medicamento)
        {
            DataAlmacenada.Instancia.ArbolMed.AgregarNodoR(medicamento.Nombre, medicamento.id);
        }

        public int CompareTo(object obj)
        {
            var comparable = (Med)obj;
            return Nombre.CompareTo(comparable.Nombre);
        }
    }
}