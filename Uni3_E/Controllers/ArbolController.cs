using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uni3_E.Models;

namespace Uni3_E.Controllers
{
    public class ArbolController : Controller
    {
        static Arbol_B Arbol = new Arbol_B();
        static private void archvio(Arbol_B arbol)
        {
            Arbol.Creacion();
            using (StreamReader archivo = new StreamReader("C:/Users/jealb/OneDrive/Escritorio/doc.csv"))
            {

                while (archivo.Peek() > -1)
                {

                    string linea = archivo.ReadLine();
                    string[] temp = linea.Split(',');
                    if (temp.Length == 6 && temp[0].Contains("id") == false)
                    {

                        int a = Convert.ToInt16(temp[0]);
                        string b = temp[1];
                        string c = temp[2];
                        string d = temp[3];
                        string[] dolar = temp[4].Split('$');
                        double e = Convert.ToDouble(dolar[1]);
                        int f = Convert.ToInt16(temp[5]);
                        Nodo tempo = new Nodo();
                        tempo.Medicamentos.Id = a;
                        tempo.Medicamentos.Nombre = b;
                        tempo.Medicamentos.Descripcion = c;
                        tempo.Medicamentos.CasaFarmaceutica = d;
                        tempo.Medicamentos.Precio = e;
                        tempo.Medicamentos.Cantidad = f;
                        tempo.Derecho = null;
                        tempo.Izquierdo = null;

                        Arbol.Insertar(tempo);
                    }
                }
            }
        }

        // GET: Arbol
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Bienvenida()
        {
            archvio(Arbol);
            return View();
        }
        public ActionResult Pre_Orden()
        {
            var temporal = Arbol.pre_orden();
            return View(temporal);
        }
        public ActionResult In_Orden()
        {
            var temporal = Arbol.in_orden();
            return View(temporal);
        }
        public ActionResult Busqueda()
        {
            return View();
        }
        public ActionResult RBusqueda()
        {
            Nodo temporal = Arbol.busqueda(Request.Form["Nombre Medicamento"]);
            return View(temporal);
        }
        public ActionResult Compra()
        {
            return View();
        }
        public ActionResult RCompra()
        {
            string cadena = "";
            Nodo temporal = Arbol.busqueda(Request.Form["Nombre Medicamento"]);
            if ( temporal == null)
            {
                cadena = "El medicamento que busco no se encuentra";
            }
            else if(temporal.Medicamentos.Cantidad >= Convert.ToInt16(Request.Form["Cantidad"]))
            {
                cadena = "Su total a pagar es: $" + (temporal.Medicamentos.Precio * Convert.ToInt16(Request.Form["Cantidad"])).ToString();
                temporal =Arbol.Compra(Request.Form["Nombre Medicamento"], Convert.ToInt16(Request.Form["Cantidad"]));
            }
            else
            {
                cadena = "No se pudo realizar la compra dado que supera la cantidad de medicamentos que posee el sistema";
            }
            Nodo respesta = new Nodo();
            respesta.Medicamentos.Nombre = cadena;
            return View(respesta);
        }
    }


} 