using OOP.Models;
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
using System.Windows.Shapes;

namespace OOP
{
    /// <summary>
    /// Logika interakcji dla klasy AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Hide window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Add new client to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model1 db = new Model1(Connection.conn);

                if (ClientName.Text != "" && ClientLastName.Text != "" && ClientDocumentID.Text != "")
                {
                    db.Clients.Add(entity: new Clients { Name = ClientName.Text, LastName = ClientLastName.Text, DocumentID = ClientDocumentID.Text, Telephone = ClientTelephone.Text, Email = ClientEmail.Text });
                    db.SaveChanges();
                    MessageBox.Show("Client added successfully");
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("Complete form first!");
            }
            finally
            {
                Connection.conn.Close();
            }
        }
    }

    internal class hoteldbEntities
    {
        private SqlConnection conn;

        public hoteldbEntities(SqlConnection conn)
        {
            this.conn = conn;
        }
    }
}