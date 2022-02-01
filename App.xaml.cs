using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Res.Models;
using Res.Exceptions;
using Res.ViewModels;
using Res.Stores;
using Res.Services;

namespace Res
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _hotel = new Hotel("ASD Suites");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //Hotel hotel = new Hotel("ASD Suites");

            //try
            //{
            //    hotel.MakeReservation(new Reservation(
            //    new RoomID(1, 3),
            //    "czb",
            //    new DateTime(2000, 1, 1),
            //    new DateTime(2000, 1, 2)));


            //    hotel.MakeReservation(new Reservation(
            //        new RoomID(1, 3),
            //        "czb",
            //        new DateTime(2000, 1, 3),
            //        new DateTime(2000, 1, 4)));
            //}
            //catch (ReservationConflictException ex)
            //{

            //}



            //IEnumerable<Reservation> reservations = hotel.GetReservations("czb");

            _navigationStore.CurrentViewModel = CreateMakeReservationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return new ReservationListingViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }

    }
}
