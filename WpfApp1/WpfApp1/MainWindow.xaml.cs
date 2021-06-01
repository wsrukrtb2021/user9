using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
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


   
       

namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            internal void Load_data(string a)
            {
                list.Children.Clear();
                using (SqlConnection connection = new SqlConnection(Class1.String))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($@"SELECT * from Material" + a, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                        Users mat = new Users();
                            mat.ID.Content = reader[0];
                            mat.Title.Content = reader[1];
                            mat.MaterialTypeID.Content = reader[2];
                            mat.Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + reader[3]));
                            mat.Cost.Content = reader[4];
                            mat.Description.Content = reader[5];
                            mat.MinCount.Content = reader[6];
                            mat.CountInPack.Content = reader[7];
                            mat.Unit.Content = reader[8];
                            list.Children.Add(mat);
                        }
                    }
                }

            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                Load_data("");
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Search_TextChanged(object sender, TextChangedEventArgs e)
            {
                Load_data("");
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {

            }
        }
    }
