﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Clasificacion:ResourceObject<Clasificacion>
    {
        [JsonProperty]
        public int coleccion { get; set; }
        [JsonProperty]
        public int categoria { get; set; }
        [JsonProperty]
        public int ficha { get; set; }
        [JsonProperty]
        public String nombre { get; set; }
        [JsonProperty]
        public String codigo { get; set; }

        public Clasificacion() : base("/v1/clasificacion/")
        {

        }
        public void guardar()
        {
            try
            {
                this.Create();
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(3, "No se ha guardado la Informacion en la base de datos");
                }
            }
        }

        public void modificar(string id)
        {
            try
            {
                this.Save(id);
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(4, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }

        public ArrayList consultarColeccion(int coleccion)
        {
            List<Clasificacion> listaNueva = new List<Clasificacion>();
            try
            {
                List<Clasificacion> todasPiezas = this.GetAsCollection();
                foreach (Clasificacion clasificaion in todasPiezas)
                {
                    if (clasificaion.coleccion == coleccion)
                        listaNueva.Add(clasificaion);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con coleccion: " + coleccion);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con coleccion: " + coleccion);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarCategoria(int categoria)
        {
            List<Clasificacion> listaNueva = new List<Clasificacion>();
            try
            {
                List<Clasificacion> todasPiezas = this.GetAsCollection();
                foreach (Clasificacion clasificaion in todasPiezas)
                {
                    if (clasificaion.categoria == categoria)
                        listaNueva.Add(clasificaion);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con categoria: " + categoria);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con categoria: " + categoria);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarFicha(int ficha)
        {
            List<Clasificacion> listaNueva = new List<Clasificacion>();
            try
            {
                List<Clasificacion> todasPiezas = this.GetAsCollection();
                foreach (Clasificacion clasificaion in todasPiezas)
                {
                    if (clasificaion.ficha == ficha)
                        listaNueva.Add(clasificaion);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con ficha: " + ficha);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con ficha: " + ficha);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarNombre(string nombre)
        {
            List<Clasificacion> listaNueva = new List<Clasificacion>();
            try
            {
                List<Clasificacion> todasPiezas = this.GetAsCollection();
                foreach (Clasificacion clasificaion in todasPiezas)
                {
                    if (clasificaion.nombre.Contains(nombre))
                        listaNueva.Add(clasificaion);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con nombre: " + nombre);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con nombre: " + nombre);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarCodigo(string codigo)
        {
            List<Clasificacion> listaNueva = new List<Clasificacion>();
            try
            {
                List<Clasificacion> todasPiezas = this.GetAsCollection();
                foreach (Clasificacion clasificaion in todasPiezas)
                {
                    if (clasificaion.codigo.Contains(codigo))
                        listaNueva.Add(clasificaion);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con codigo: " + codigo);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con codigo: " + codigo);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList regresarPieza()
        {
            ArrayList listaNueva = null;
            try
            {
                Pieza Pieza = new Pieza();
                List<Pieza> Piezas = Pieza.GetAsCollection(Pieza.resource_uri + "?clasificacion=" + this.id);
                listaNueva = new ArrayList(Piezas);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontraron piezas de este autor");
            }
            return listaNueva;
        }

        public ArrayList consultarNombre(string nombre)//1
        {
            List<Clasificacion> listaNueva = null;
            try
            {
                string consultarNombre = "?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public void regresarObjeto(int id)//2
        {
            try
            {
                Clasificacion fichaTemp = this.Get(id.ToString());
                if (fichaTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = fichaTemp.id;
                this.coleccion = fichaTemp.coleccion;
                this.categoria = fichaTemp.categoria;
                this.ficha = fichaTemp.ficha;
                this.nombre = fichaTemp.nombre;
                this.codigo = fichaTemp.codigo;
            
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
        }

        public void regresarObjeto()//3
        {
            regresarObjeto(this.id);
        }

        public ArrayList regresarPieza()//4
        {
            List<Pieza> listaNueva = null;
            try
            {
                Pieza clas = new Pieza();
                string consulta = "?clasificacion=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }
      }
}
