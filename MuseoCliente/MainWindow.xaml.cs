﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuseoCliente.Connection;
using MuseoCliente.Connection.Objects;
namespace MuseoCliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Sala sala = new Sala();
        Estructuras.Observador observer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void itemClasif_Click(object sender, RoutedEventArgs e)
        {
            modClasificaciones frm = new modClasificaciones();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void itemPiezas_Click(object sender, RoutedEventArgs e)
        {
            modInventario frm = new modInventario();
            bdrContenedor.Child = frm;
        }

        private void itemEventos_Click(object sender, RoutedEventArgs e)
        {
            modEventos frm = new modEventos();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void itemInsta_Click(object sender, RoutedEventArgs e)
        {
            modInstalaciones frm = new modInstalaciones();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void itemInves_Click(object sender, RoutedEventArgs e)
        {
            modInvestigaciones frm = new modInvestigaciones();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void itemUsuarios_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void itemFotos_Click(object sender, RoutedEventArgs e)
        {
            modGaleria frm = new modGaleria();
            bdrContenedor.Child = frm;
        }

        private void itemUsuarios_Click_1(object sender, RoutedEventArgs e)
        {
            modUsuarios frm = new modUsuarios();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }
    }
}
