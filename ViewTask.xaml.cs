using System;
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
using System.Windows.Shapes;

namespace SistemaProyecto
{
    /// <summary>
    /// Lógica de interacción para ViewTask.xaml
    /// </summary>
    public partial class ViewTask : Window
    {
        public ViewTask()
        {
            InitializeComponent();
            Contexto bd = new Contexto();
            
            List<Project> projects = bd.projects.Where(p => p.Status == Project.status.Active).ToList();

            foreach (Project project in projects)
            {
                Proyecto.ItemsSource = projects;
                Proyecto.DisplayMemberPath = "Name";
                Proyecto.SelectedValuePath = "Id";

            }

            Estado.Items.Add("Activo");
            Estado.Items.Add("Inactivo");
            Estado.Items.Add("Terminado");
        }


        private void CreatedTask(object sender, RoutedEventArgs e)
        {
            if (Proyecto.SelectedItem == null || Estado.SelectedItem == null || string.IsNullOrEmpty(Nombre.Text))
            {
                MessageBox.Show("Por favor llene todos los campos");
                return;
            }
            int id = (int)Proyecto.SelectedValue;
            Task task = new Task() { Name=Nombre.Text ,ProjectId=id};
            if (Estado.SelectedItem.ToString() == "Activo")
            {
                task.Status = "Active";
            }
            else if(Estado.SelectedItem.ToString() == "Inactivo")
            {
                task.Status = "Inactive";
            }
            else
            {
                task.Status = "Terminated";
            }

            task.progress = (int)sProgrees.Value;

            Contexto bd = new Contexto();
            bd.tasks.Add(task);

            if (bd.SaveChanges() > 0)
            {
                MessageBox.Show("Tarea creada con éxito");
                Nombre.Text = "";
                Proyecto.SelectedItem = null;
                Estado.SelectedItem = null;
                sProgrees.Value = 0;
            }
            else
            {
                MessageBox.Show("Error al crear la tarea");
            }

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Estado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void sProgrees_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            pbProgress.Value = (int)sProgrees.Value;
        }

        private void Proyecto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Nombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
