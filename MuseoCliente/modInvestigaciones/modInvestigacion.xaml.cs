﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuseoCliente.Connection.Objects;
using System.Threading.Tasks;
using System.Collections;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modInvestigacion.xaml
	/// </summary>
	public partial class modInvestigacion : UserControl
	{
        //Pendiente Editor: Porque es el usuario que ingresa -
        Pieza piezas = new Pieza();
        Autor autores = new Autor();
        Investigacion investigacion = new Investigacion();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        bool publicado = false;
        public modInvestigacion()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Cargar datos
            cmbAutor.DisplayMemberPath = "nombre";
            cmbAutor.SelectedValuePath = "id";
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Investigación";
                //txtCodigoPieza.Text = pieza.codigo;
                //txtNombrePieza.Text = pieza.nombre;
                //cmbAutor.ItemsSource = piezas.nombre;

            }
            else
            {
                lblOperacion.Content = "Nueva Categoría";
                cmbAutor.ItemsSource = autores.regresarTodos();
                gvPiezasGuardadas.ItemsSource = new ArrayList();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            investigacion = (Investigacion) this.DataContext;
            // Error en la clase = investigacion.autor = Convert.ToInt16(cmbAutor.SelectedValue.ToString());
            // Pregunta: la fecha es con un Now()? o puede seleccionar fecha? investigacion.fecha = ????;
            investigacion.autor = (int) cmbAutor.SelectedValue;
            investigacion.editor = "JEscalante";
            List<string> listado = LinksReferencia.GetOptions();
           
            if (modificar == false)
            {
                //investigacion.guardar();
            }
            else
            {
                investigacion.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
            //Falta la clase para que investigacion tenga pieza
        }

        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string 
            // representing the plain text content of the TextRange. 
            return textRange.Text;
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            //Codigo para publicar en la web
            publicado = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = txtCodigo.Text;
            buscarPiezas(codigo);
        }
        private async void buscarPiezas(string codigo)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(()=>piezas.buscarNombre(codigo));
            await task;
            gvPiezas.ItemsSource = task.Result;
        }

        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigo.Text.Length > 3)
            {
                buscarPiezas(txtCodigo.Text);
            }
            else
            {
                gvPiezas.ItemsSource = null;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pieza piezaSeleccionada = (Pieza) gvPiezas.SelectedItem;

            gvPiezasGuardadas.ItemsSource = this.verificarPieza(piezaSeleccionada);
            gvPiezasGuardadas.Items.Refresh();
            //gvPiezasGuardadas.Items.Add(piezaSeleccionada);
        }
        private ArrayList verificarPieza(Pieza pieza)
        {
            ArrayList listado = (ArrayList) gvPiezasGuardadas.ItemsSource;
            Boolean existePieza = false;
            if (listado.Count == 0) 
            {
                listado.Add(pieza);
                existePieza = true;
            } 
            for (int i = 0; i < listado.Count; i++) 
            {
                Pieza piezaActual = (Pieza) listado[i];

                if (piezaActual.codigo == pieza.codigo)
                {
                    existePieza = true;
                    break;
                }
            }
            if (!existePieza)
                listado.Add(pieza);
            return listado;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ArrayList listado = (ArrayList)gvPiezasGuardadas.ItemsSource;
            Pieza piezaSeleccionada = (Pieza) gvPiezasGuardadas.SelectedItem;
            for (int i = 0; i < listado.Count; i++)
            {
                Pieza piezaActual = (Pieza)listado[i];
                if (piezaActual.codigo == piezaSeleccionada.codigo)
                {
                    listado.RemoveAt(i);
                    break;
                }
            }
            gvPiezasGuardadas.ItemsSource = listado;
            gvPiezasGuardadas.Items.Refresh();
        }
	}
}