# OOP_Projekt

Project requirements: https://dirask.com/posts/WSEI-2021-2022-lato-labN-1-ISN-Programowanie-obiektowe-labs-pa3ek1

Project is a simple demonstration of database based application that lets you store a list of reservations, clients, hotel rooms and payments.



# Prerequisites

You need the following tools in order to run/edit the solution.

* Microsoft Visual Studio (Latest recommended)

* Microsoft SQL Server (Latest recommended)



# Getting Started

The application requires a database to store the data. Follow the below steps to setup database.

1) Run the script 'hoteldb.sql' to create and populate database (MS SQL SERVER is required)
2) Set the connection string
    * Open OOP.sln (Visual Studio is required)
    * Go to App.config in Solution Explorer
    * Change data source in conectionString "localhost\SQLEXPRESS" to you localhost address
 


# Project Structure

Views: 
  * AddClient.xaml
  * AddNewReservation.xaml
  * AddPayment.xaml
  * App.xaml
  * MainWindow.xaml
  
Models:
  * Clients.cs
  * Connection.cs
  * Model1.cs
  * Payments.cs
  * Reservations.cs
  * Rooms.cs
  
  
  
 # Author
 
 [Kamila Marcinek](https://www.linkedin.com/in/kamilamarcinek521/)
