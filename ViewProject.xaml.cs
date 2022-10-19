﻿using Microsoft.EntityFrameworkCore;
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
    /// Lógica de interacción para ViewProject.xaml
    /// </summary>
    public partial class ViewProject : Window
    {
        public ViewProject()
        {
            InitializeComponent();
            Estado.Items.Add("Activo");
            Estado.Items.Add("Inactivo");
        }

        private void CreatedProject(object sender, RoutedEventArgs e)
        {
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
            }else{
                //created project with status inactive
                project = new Project()
                {
                    Name = Nombre.Text,
                    Status = Project.status.Inactive
                };
            }
            bd.projects.Add(project);

            if(bd.SaveChanges() > 0)
            {
                MessageBox.Show("Project created successfully");
            }
            else
            {
                MessageBox.Show("Project not created");
            }

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
