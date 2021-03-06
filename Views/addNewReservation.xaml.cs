using OOP.Models;

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

        /// <summary>
        /// This method loads data to datagrid named dataGridClients
        /// </summary>
        public void LoadClients()
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


        /// <summary>
        /// Validate datepickers, and then load rooms that is not reserved between selected by user dates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Load datagrid named dataGridRooms
        /// </summary>
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


        /// <summary>
        /// Add new reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model1 db = new Model1(Connection.conn);
                int clientIDint = int.Parse(ClientID.Text);
                int roomIdint = int.Parse(RoomID.Text);
                DateTime startDate = (DateTime)DateStart.SelectedDate;
                DateTime endDate = (DateTime)DateEnd.SelectedDate;
                string getStatuts = StatusesCb.SelectedItem.ToString();
                getStatuts = getStatuts.Remove(0, 38);

                db.Reservations.Add(entity: new Reservations { RoomID = (short)roomIdint, ClientID = clientIDint, ReservationStatus = $"{getStatuts}", DateFrom = startDate, DateTo = endDate });
                db.SaveChanges();
                MessageBox.Show("Reservation added successfully");
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


        /// <summary>
        /// Show AddClient window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddClient objAddClient = new AddClient();
            objAddClient.Show();
        }


        /// <summary>
        /// Reload data in dataGridClients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refreshbtn_Click(object sender, RoutedEventArgs e)
        {
            LoadClients();
        }
    }
}