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

namespace OOP.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddPayment.xaml
    /// </summary>
    public partial class AddPayment : Window
    {
        public AddPayment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// add new payment and update reservation status to "Paid"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model1 db = new Model1(Connection.conn);
                var costHelper = PaymentCost.Text.ToString();
                costHelper = costHelper.Replace('.',',');
                float cost = float.Parse(costHelper);

                db.Payments.Add(entity: new Payments { FVID = int.Parse(PaymentReservationId.Text), Cost= cost });
                db.SaveChanges();

                var context = new Reservations();
                var reservation = new Reservations { ReservationID = int.Parse(PaymentReservationId.Text) };
                reservation.ReservationStatus = "Paid";
                db.Reservations.Attach(reservation);
                db.Entry(reservation).Property("ReservationStatus").IsModified = true;
                db.SaveChanges();

                MessageBox.Show("Payment added sucessfully");
                this.Visibility = Visibility.Hidden;
                    
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
        /// Hide AddPAyment window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
