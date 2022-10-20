using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace SistemaProyecto
{
    //TODO: mostrar tarea por proyecto 
    /// <summary>
    /// Lógica de interacción para ViewModifyTask.xaml
    /// </summary>
    public partial class ViewModifyTask : Window
    {
        public ViewModifyTask()
        {
            InitializeComponent();
            Contexto bd = new Contexto();
            List<Project> projects = bd.projects.ToList();
            foreach (Project project in projects)
            {
                Proyecto.Items.Add(project.Name);

            }
            Estado.Items.Add("Activo");
            Estado.Items.Add("Inactivo");
            Estado.Items.Add("Terminado");
        }

        private void CreatedTask(object sender, RoutedEventArgs e)
        {

            Contexto db = new Contexto();
            string idStr = Tarea.SelectedValue.ToString();
            int id = int.Parse(idStr);
            Task task = db.tasks.FirstOrDefault(t => t.Id == id);
            
            if (Estado.SelectedItem.ToString() == "Activo")
            {

                task.Status = "Active";
            }
            else if (Estado.SelectedItem.ToString() == "Inactivo")
            {
                task.Status = "Inactive";
            }
            else
            {
                task.Status = "Terminated";
            }

            task.progress = (int)sProgrees.Value;


            db.tasks.Update(task);

            if (db.SaveChanges() > 0)
            {
                MessageBox.Show("Tarea modificada con exito");
            }
            else
            {
                MessageBox.Show("Error al modificar la tarea");
            }

        }
        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Tarea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Contexto db = new Contexto();
            int id = 0;
            if (Tarea.SelectedIndex != -1)
            {
                string idStr = Tarea.SelectedValue.ToString();
                id = int.Parse(idStr);
                Task task = db.tasks.FirstOrDefault(t => t.Id == id);

                sProgrees.Value = task.progress;

                pbProgress.Value = task.progress;

                if (task.Status.ToString() == "Active")
                {
                    Estado.SelectedItem = "Activo";
                }
                else if (task.Status.ToString() == "Inactive")
                {
                    Estado.SelectedItem = "Inactivo";
                }
                else
                {
                    Estado.SelectedItem = "Terminado";
                }

            }
            else
            {
                 sProgrees.Value = 0;
                 pbProgress.Value = 0;
                 Estado.SelectedItem = "Activo";
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

        private void sProgrees_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            pbProgress.Value = (int)sProgrees.Value;
        }
    }
}
