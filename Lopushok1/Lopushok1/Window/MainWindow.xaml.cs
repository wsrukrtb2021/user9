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
using System.IO;
using System.Data.SqlClient;
using Lopushok1.Class;
using Lopushok1.Control;

namespace Lopushok1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        internal void Load_data(string a)
        {
            list.Children.Clear();
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"Select  Product.ID, Product.Title, Product.ProductTypeID, Product.ArticleNumber, Product.Image, Product.ProductionPersonCount, 
                    Product.ProductionWorkshopNumber, Product.MinCostForAgent FROM dbo.Product" + a, connection);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product_List product = new Product_List();
                        product.ID.Content = reader[0];
                        product.Title.Content = reader[1];
                        product.Product_Type.Content = reader[2];
                        product.Article.Content = reader[3];
                        //product.photo.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + reader[4].ToString().Replace(".jpg", ".jpeg")));
                        product.ProductionPerson.Content = reader[5];
                        product.ProductionWork.Content = reader[6];
                        product.MinCost.Content = reader[7];
                        product.main = this;
                        list.Children.Add(product);
                    }
                }
            }
        }
     
        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_data("");
        }
        private void Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load_data("");
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filtr != null)
            {
                Load_data("");
            }
        }

 
    }
}
