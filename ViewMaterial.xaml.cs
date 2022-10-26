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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace SistemaProyecto
{
    /// <summary>
    /// Lógica de interacción para ViewMaterial.xaml
    /// </summary>
    public partial class ViewMaterial : Window
    {
        public ViewMaterial()
        {
            InitializeComponent();
            Contexto bd = new Contexto();
            List<Project> projects = bd.projects.ToList();

            foreach (Project project in projects)
            {
                Proyecto.Items.Add(project.Name);

            }


            List<Material> materials = bd.materials.ToList();

            foreach (Material material in bd.materials)
            {
                Material.ItemsSource = materials;
                Material.DisplayMemberPath = "name";
                Material.SelectedValuePath = "Id";
            }


        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void Nombre_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreatedTask(object sender, RoutedEventArgs e)
        {
           
            int cantStr = int.Parse(Cantidad.Text.ToString());
            int tareastr = int.Parse(Tarea.SelectedValue.ToString()) ;
            int MaterialStr = int.Parse(Material.SelectedValue.ToString());
          
            Contexto db = new Contexto();
            materialConsume materialconsume = new materialConsume() { MaterialId =MaterialStr, quantity = cantStr , date=DateTime.Now, TaskId=tareastr};
           
            db.materialConsumes.Add(materialconsume);

            if (db.SaveChanges() > 0)
            {
                MessageBox.Show("Material ingresado con exito");
            }
            else
            {
                MessageBox.Show("Error al ingresar el material");
            }

        }

        private void Proyecto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contexto db = new Contexto();

            List<Task> tasks = db.tasks.Where(t => t.ProjectId == Proyecto.SelectedIndex + 1).ToList();

            Tarea.ItemsSource = "";

            foreach (Task task in tasks)
            {
                Tarea.ItemsSource = tasks;
                Tarea.DisplayMemberPath = "Name";
                Tarea.SelectedValuePath = "Id";
            }
        }

        private void Material_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        //validacion para que solo se puedan ingresar valores numericos 
        private void Cantidad_PreviewtextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled =  new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Cantidad_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }  
}
