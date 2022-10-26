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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaProyecto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the CreatedProject class
            ViewProject createdProject = new ViewProject();
            // Show the CreatedProject window
            createdProject.Show();
            // Close the MainWindow window
            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewTask viewTask = new ViewTask();
            viewTask.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewModifyTask viewModifyTask = new ViewModifyTask();
            viewModifyTask.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          ViewMaterial viewMaterial = new ViewMaterial();
            viewMaterial.Show();
            this.Close();
        }
    }
}
