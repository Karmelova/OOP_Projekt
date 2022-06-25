using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace OOP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MySqlConnection Connection

        private SqlConnection conn = new
        SqlConnection(ConfigurationManager.ConnectionStrings["hoteldbEntities"].ConnectionString);

        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        #endregion MySqlConnection Connection

        #region bind data to DataGrid.

        private void LoadGrid()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select ReservationID,RoomID,DateFrom,DateTo,StatusName,Name,LastName,Telephone,Email from Reservations,Clients,Statuses where Clients.ID=Reservations.ClientID and Reservations.Status=Statuses.ID", conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridReservations.ItemsSource = dt.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion bind data to DataGrid.
    }
}