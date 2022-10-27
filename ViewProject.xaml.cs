using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para ViewProject.xaml
    /// </summary>
    public partial class ViewProject : Window
    {
        public ViewProject()
        {
            InitializeComponent();
            Estado.Items.Add("Activo");
            Estado.Items.Add("Inactivo");
            Estado.Items.Add("Terminado");
        }

        private void CreatedProject(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Nombre.Text))
            {
                MessageBox.Show("Por favor llene el nombre");
                return;
            }
            Contexto bd = new Contexto();
            string status = Estado.SelectedValue.ToString();
            Project project;
            if (status == "Activo")
            {
                //created project with status inactive
                project = new Project()
                {
                    Name = Nombre.Text,
                    Status= Project.status.Active
                };
            }else if (status == "Inactivo"){
                //created project with status inactive
                project = new Project()
                {
                    Name = Nombre.Text,
                    Status = Project.status.Inactive
                };
            }else{
                //created project with status terminated
                project = new Project()
                {
                    Name = Nombre.Text,
                    Status = Project.status.terminated
                };
            }
            bd.projects.Add(project);

            if(bd.SaveChanges() > 0)
            {
                MessageBox.Show("Proyecto creado con éxito");
                Nombre.Text = "";
            }
            else
            {
                MessageBox.Show("Error al crear el proyecto");
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

        private void Nombre_PreviewtextInput(object sender, TextCompositionEventArgs e)
        {
            
  
        }
    }
}
