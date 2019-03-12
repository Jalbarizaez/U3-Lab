using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Uni3_E.Models;

namespace Uni3_E.Controllers
{
    public class ArbolController : Controller
    {
        static List<Nodo> simulacion = new List<Nodo>();
        static Arbol_B Arbol = new Arbol_B();
        static private void archvio(Arbol_B arbol)
        {
            Arbol.Creacion();
            using (StreamReader archivo = new StreamReader("C:/Users/jealb/OneDrive/Escritorio/doc.csv"))//Direccion del archivo modificado el archivo se encuentra en la carpeta app_data
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
            StreamWriter MyFile = new StreamWriter(@"C:/Users/jealb/OneDrive/Escritorio/json.json");//Direccion donde se creara el archivo json

            XmlSerializer Serializer = new XmlSerializer(typeof(Nodo));

            var temporal = Arbol.pre_orden();
            foreach (var item in temporal)
            {
                Nodo tmp = item;
                Serializer.Serialize(MyFile, tmp);
            }
            return View(temporal);
        }
        public ActionResult In_Orden()
        {
            StreamWriter MyFile = new StreamWriter(@"C:/Users/jealb/OneDrive/Escritorio/json.json");//Direccion donde se creara el archivo json

            XmlSerializer Serializer = new XmlSerializer(typeof(Nodo));
            var temporal = Arbol.in_orden();
            foreach (var item in temporal)
            {
                Nodo tmp = item;
                Serializer.Serialize(MyFile, tmp);
            }
            return View(temporal);
        }
        public ActionResult Post_Orden()
        {
            StreamWriter MyFile = new StreamWriter(@"C:/Users/jealb/OneDrive/Escritorio/json.json");//Direccion donde se creara el archivo json

            XmlSerializer Serializer = new XmlSerializer(typeof(Nodo));
            var temporal = Arbol.post_orden();
            foreach(var item in temporal )
            {
                Nodo tmp = item;
                Serializer.Serialize(MyFile, tmp);
            }
            
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
            if(temporal.Medicamentos.Cantidad ==0)
            {
                Nodo sim = new Nodo();
                sim = temporal;
                simulacion.Add(sim);
                Arbol.Eliminar(Request.Form["Nombre Medicamento"]);
            }
            
            Nodo respesta = new Nodo();
            respesta.Medicamentos.Nombre = cadena;
            return View(respesta);
        }
        public ActionResult Simulacion()
        {
            Random numro = new Random();
            foreach(var item in simulacion)
            {
                Nodo temp = new Nodo();
                temp = item;
                temp.Izquierdo = null;
                temp.Derecho = null;
                temp.Medicamentos.Cantidad = numro.Next(0, 15);
                Arbol.Insertar(temp);
            }
            simulacion.Clear();
            return View();
        }
    }


} 