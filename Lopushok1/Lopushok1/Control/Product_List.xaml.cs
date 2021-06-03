using Lopushok1.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Lopushok1.Control
{
    /// <summary>
    /// Логика взаимодействия для Product_List.xaml
    /// </summary>
    public partial class Product_List : UserControl
    {
        public Product_List()
        {
            InitializeComponent();
        }
        public MainWindow main;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                if (MessageBox.Show("Хотите удалить агента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($@"DELETE FROM [dbo].[Product] WHERE ID = '{ID.Content}'", connection);
                    command.ExecuteNonQuery();
                    main.Load_data("");
                }
                else
                {

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
  
        }
    }
}
