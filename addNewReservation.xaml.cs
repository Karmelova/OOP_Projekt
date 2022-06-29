using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Logika interakcji dla klasy addNewReservation.xaml
    /// </summary>
    public partial class addNewReservation : Window
    {
        public addNewReservation()
        {
            InitializeComponent();
            LoadClients();
        }

        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        private void LoadClients()
        {
            try
            {
                Connection.conn.Open();
                SqlCommand cmd = new SqlCommand("Select ID,Name,LastName,DocumentID,Telephone,Email FROM Clients", Connection.conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dtClients = new DataSet();
                adp.Fill(dtClients, "LoadClientsBinding");
                dataGridClients.DataContext = dtClients;
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

        private void DateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = (DateTime)((DatePicker)sender).SelectedDate;
            DateTime today = DateTime.Today;
            int result = DateTime.Compare(today, date
                );
            if (result > 0)
            {
                MessageBox.Show("It's not allowed to select past date!");
            }
        }

        private void DateEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime startDate = (DateTime)DateStart.SelectedDate;
            DateTime date = (DateTime)((DatePicker)sender).SelectedDate;
            DateTime today = DateTime.Today;
            int result = DateTime.Compare(today, date);
            int result2 = DateTime.Compare(startDate, date);
            if (result > 0)

                MessageBox.Show("It's not allowed to select past date!");
            else if (result == 0 || result2 >= 0)
                MessageBox.Show("Reservation must last at least one day!");

            LoadRooms();
        }

        private void LoadRooms()
        {
            try
            {
                DateTime startDate = (DateTime)DateStart.SelectedDate;
                DateTime endDate = (DateTime)DateEnd.SelectedDate;
                string dateFrom = startDate.ToString("yyyy-MM-dd");
                string dateTo = endDate.ToString("yyyy-MM-dd");
                Connection.conn.Open();

                SqlCommand cmd = new SqlCommand($"SELECT Rooms.RoomID,Standard,MinPerson,MaxPerson FROM Rooms WHERE RoomID NOT IN (SELECT Rooms.RoomID FROM Rooms INNER JOIN Reservations ON Reservations.RoomID=Rooms.RoomID WHERE Reservations.DateFrom BETWEEN '{dateFrom}' AND '{dateTo}')", Connection.conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet dtRooms = new DataSet();
                adp.Fill(dtRooms, "AvailableRoomsList");
                dataGridRooms.DataContext = dtRooms;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}