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
        private Nodo Compra(string cadena, Nodo hoja, int cantidad)
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
                    return Compra(cadena, hoja.Izquierdo, cantidad);
                }
                else
                {
                    return Compra(cadena, hoja.Derecho, cantidad);
                }
            }
            else
            {
                return null;
            }
        }
        public Nodo Compra(string cadena, int cantidad)
        {
            return Compra(cadena, Raiz, cantidad);
        }
        //private Nodo Eliminar(string cadena , Nodo hoja, Nodo padre)
        //{

        //    if (hoja != null)
        //    {
        //        int tem = hoja.Medicamentos.Nombre.CompareTo(cadena);
        //        if (cadena == hoja.Medicamentos.Nombre)
        //        {
        //            if (hoja.Derecho == null && hoja.Izquierdo == null)
        //            {
        //                int temp = padre.Medicamentos.Nombre.CompareTo(hoja.Medicamentos.Nombre);
        //                if (temp > 0)
        //                {
        //                    padre.Izquierdo = null;
        //                }
        //                else
        //                {
        //                    padre.Derecho = null;
        //                }
        //                return hoja;
        //            }
        //            //else if (hoja.Derecho != null)
        //            //{
        //            //    padre.Derecho = hoja.Derecho;
        //            //    return hoja;
        //            //}
        //            //else if (hoja.Izquierdo != null)
        //            //{
        //            //    padre.Izquierdo = hoja.Izquierdo;
        //            //    return hoja;
        //            //}
        //            else if (hoja.Derecho != null && hoja.Izquierdo != null)
        //            {

        //            }
        //        }
        //        if (tem > 0)
        //        {
        //            return Eliminar(cadena, hoja.Izquierdo,hoja);
        //        }
        //        else
        //        {
        //            return Eliminar(cadena, hoja.Derecho,hoja);
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        //public Nodo Eliminar(string cadena)
        //{
        //    return Eliminar(cadena, Raiz,Raiz); 
        //}
        public void Eliminar(string cadena)
        {
            Eliminar(Raiz, cadena);
        }
        private void Eliminar(Nodo hoja, string cadena)
        {
            if (hoja != null)
            {
                int tem = hoja.Medicamentos.Nombre.CompareTo(cadena);

                Nodo aux = null, aux1 = null, otro = null;
                if (tem > 0)
                {
                    Eliminar(hoja.Izquierdo, cadena);
                }
                else
                {
                    if (tem < 0)
                    {
                        Eliminar(hoja.Derecho, cadena);
                    }
                    else
                    {
                        otro = hoja;


                        if (otro != null)
                        {
                            if ((otro.Derecho == null) && (otro.Izquierdo == null))
                            {
                                otro = null;
                            }
                            else
                            {
                                if (otro.Derecho == null)
                                {
                                    hoja = otro.Izquierdo;

                                }
                                else
                                    if (otro.Izquierdo == null)
                                {
                                    hoja = otro.Derecho;

                                }
                                else
                                {
                                    aux = otro.Izquierdo;
                                    aux1 = aux;
                                    while (aux.Derecho != null)
                                    {
                                        aux1 = aux;
                                        aux = aux.Derecho;
                                    }
                                    otro.Medicamentos = aux.Medicamentos;
                                    otro = aux;
                                    aux1.Derecho = aux.Izquierdo;
                                    aux = null;

                                }
                            }
                        }
                        else { }
                    }

                }
            }
        }
    }
}