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

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modUsuarios.xaml
	/// </summary>
	public partial class modUsuarios : UserControl
	{
        Connection.Objects.Usuario usuarios = new Connection.Objects.Usuario();
        Connection.Objects.Autor autores = new Connection.Objects.Autor();
        public Border borde;
        public modUsuarios()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            gvActivos.ItemsSource = usuarios.regresarTodos();
            gvVoluntarios.ItemsSource = autores.regresarTodos();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            modNuevoU frm = new modNuevoU();
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            modResultadosUsers frm = new modResultadosUsers();
            frm.busqueda = txtBuscar.Text;
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnNuevoAu_Click(object sender, RoutedEventArgs e)
        {
            modAutor frm = new modAutor();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void gvActivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
	}
}