using MVVMPractice.Commands;
using MVVMPractice.Models;
using MVVMPractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPractice.ViewModels;

public class ReservationListingViewModel: ViewModelBase
{
    private Hotel _hotel;
    private readonly ObservableCollection<ReservationViewModel> _reservations;

    public IEnumerable<ReservationViewModel> Reservations => _reservations;
    
    public ICommand MakeReservationCommand { get; } = null!;

    public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
    {
        _hotel = hotel;
        _reservations = new ObservableCollection<ReservationViewModel>();

        MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);

        UpdateReservations();
    }

    private void UpdateReservations()
    {
        _reservations.Clear();

        foreach (Reservation reservation in _hotel.GetReservations())
        {
            ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }
    }
}
