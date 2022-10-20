using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Lógica de interacción para ViewModifyTask.xaml
    /// </summary>
    public partial class ViewModifyTask : Window
    {
        public ViewModifyTask()
        {
            InitializeComponent();
            Contexto bd = new Contexto();
            List<Task> tasks= bd.tasks.ToList();
            foreach (Task task in tasks)
            {
                Proyecto.Items.Add(task.Name);

            }
            Estado.Items.Add("Activo");
            Estado.Items.Add("Inactivo");
        }

        private void CreatedTask(object sender, RoutedEventArgs e)
        {

            Contexto db = new Contexto();

            Task task = db.tasks.FirstOrDefault(t => t.Id == Proyecto.SelectedIndex + 1);

            if (Estado.SelectedItem.ToString() == "Activo")
            {
  
                task.Status = "Active";
            }
            else
            {
                task.Status = "Inactive";
            }

            task.progress = Avance.Text;

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

        private void Proyecto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Contexto db = new Contexto();

            Task task = db.tasks.FirstOrDefault(t => t.Id == Proyecto.SelectedIndex + 1);

            Avance.Text = task.progress.ToString();

            if (task.Status.ToString() == "Active")
            {
                Estado.SelectedItem = "Activo";
            }
            else
            {
                Estado.SelectedItem= "Inactivo";
            }
        }

     
    }
}
