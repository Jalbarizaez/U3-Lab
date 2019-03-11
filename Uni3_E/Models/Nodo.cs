using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni3_E.Models
{
    public class Nodo
    {
        public Medicamento Medicamentos = new Medicamento();
        public Nodo Padre { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
        //Constructor
        public Nodo()
        { }
        public Nodo(Medicamento Medicamentos)
        {
            this.Medicamentos = Medicamentos;
        }
        public Nodo(Medicamento Medicamentos, Nodo izquierdo, Nodo derecho, Nodo padre)
        {
            this.Medicamentos = Medicamentos;
            this.Izquierdo = izquierdo;
            this.Derecho = derecho;
            this.Padre = padre;
        }
        public bool EsRaiz()
        {
            if (Padre != null)
                return false;
            return true;
        }
        public bool ExisteIzquierdo()
        {
            if (Izquierdo != null)
                return true;
            return false;
        }
        public bool ExisteDerecho()
        {
            if (Derecho != null)
                return true;
            return false;
        }
        public bool TieneMedicamento()
        {
            if (Medicamentos != null)
                return true;
            return false;
        }
    }
}