using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni3_E.Models
{
    public class Arbol_B
    {
        public List<Nodo> Inorden = new List<Nodo>();
        public List<Nodo> Preorden = new List<Nodo>();
        public List<Nodo> Postorden = new List<Nodo>();
        public Nodo Raiz { get; set; }
        public void Creacion()
        {
            Raiz = null;
        }
        private void Insertar(Nodo temporal, Nodo hoja)
        {
            int tem = hoja.Medicamentos.Nombre.CompareTo(temporal.Medicamentos.Nombre);
            if (tem > 0)
            {
                if (hoja.Izquierdo != null)
                {
                    Insertar(temporal, hoja.Izquierdo);
                }
                else
                {
                    hoja.Izquierdo = temporal;
                }
            }
            else if (tem <= 0)
            {
                if (hoja.Derecho != null)
                {
                    Insertar(temporal, hoja.Derecho);
                }
                else
                {
                    hoja.Derecho = temporal;
                }
            }

        }

        public void Insertar(Nodo temporal)
        {
            if (Raiz == null)
            {
                Raiz = temporal;
            }
            else
            {
                Insertar(temporal, Raiz);
            }
        }
        public List<Nodo> pre_orden()
        {
            Preorden.Clear();
            pre_orden(Raiz);
            return Preorden;
        }
        private void pre_orden(Nodo hoja)
        {
            if (hoja != null)
            {
                Preorden.Add(hoja);
                pre_orden(hoja.Izquierdo);
                pre_orden(hoja.Derecho);

            }
        }
        public List<Nodo> post_orden()
        {
            Postorden.Clear();
            post_orden(Raiz);
            return Postorden;
        }
        private void post_orden(Nodo hoja)
        {
            if (hoja != null)
            {
                post_orden(hoja.Izquierdo);
                post_orden(hoja.Derecho);
                Postorden.Add(hoja);

            }
        }
        public List<Nodo> in_orden()
        {
            Inorden.Clear();
            in_orden(Raiz);
            return Inorden;
        }
        private void in_orden(Nodo hoja)
        {
            if (hoja != null)
            {
                in_orden(hoja.Izquierdo);
                Inorden.Add(hoja);
                in_orden(hoja.Derecho);
            }
        }

        private Nodo busqueda(string cadena, Nodo hoja)
        {

            if (hoja != null)
            {
                int tem = hoja.Medicamentos.Nombre.CompareTo(cadena);
                if (cadena == hoja.Medicamentos.Nombre)
                {
                    return hoja;
                }
                if (tem > 0)
                {
                    return busqueda(cadena, hoja.Izquierdo);
                }
                else
                {
                    return busqueda(cadena, hoja.Derecho);
                }
            }
            else
            {
                return null;
            }
        }
        public Nodo busqueda(string cadena)
        {
            return busqueda(cadena, Raiz);
        }
        private Nodo Compra(string cadena, Nodo hoja,int cantidad)
        {

            if (hoja != null)
            {
                int tem = hoja.Medicamentos.Nombre.CompareTo(cadena);
                if (cadena == hoja.Medicamentos.Nombre)
                {
                     hoja.Medicamentos.Cantidad = hoja.Medicamentos.Cantidad - cantidad;
                    return hoja;
                }
                if (tem > 0)
                {
                     return Compra(cadena, hoja.Izquierdo,cantidad);
                }
                else
                {
                     return Compra(cadena, hoja.Derecho,cantidad);
                }
            }
            else
            {
                return null;
            }
        }
        public Nodo Compra(string cadena,int cantidad)
        {
             return Compra(cadena, Raiz,cantidad);
        }
    }
}