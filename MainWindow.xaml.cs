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
using OOP;

namespace OOP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        #region bind data to DataGrid.

        private void LoadGrid()
        {
            try
            {
                Connection.conn.Open();
                SqlCommand cmd = new SqlCommand("Select ReservationID,RoomID,DateFrom,DateTo,ReservationStatus,Name,LastName,Telephone,Email from Reservations inner join Clients on Clients.ID=Reservations.ClientID", Connection.conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                adp.Fill(dt, "LoadDataBinding");
                dataGridReservations.DataContext = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connection.conn.Close();
            }
        }

        #endregion bind data to DataGrid.

        private void dataGridReservations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView rowSelected = gd.SelectedItem as DataRowView;
            if (rowSelected != null)
            {
            }
        }

        private void reservationEditWindow_Click(object sender, RoutedEventArgs e)
        {
            reservationEditWindow objEditWindow = new reservationEditWindow();
            this.Visibility = Visibility.Hidden;
            objEditWindow.Show();
        }

        private void AddNewReservation_Click(object sender, RoutedEventArgs e)
        {
            addNewReservation objAddWindow = new addNewReservation();
            this.Visibility = Visibility.Hidden;
            objAddWindow.Show();
        }
    }
}