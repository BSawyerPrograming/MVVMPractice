using MVVMPractice.Exceptions;
using MVVMPractice.Models;
using MVVMPractice.Services;
using MVVMPractice.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMPractice.Commands;

public class MakeReservationCommand : CommandBase
{
    private readonly Hotel _hotel;
    private readonly NavigationService _reservationViewNavigationService;
    private readonly MakeReservationViewModel _makeReservationViewModel;

    public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel,
        Hotel hotel, NavigationService reservationViewNavigationService)
    {
        _makeReservationViewModel= makeReservationViewModel;
        _hotel = hotel;
        _reservationViewNavigationService = reservationViewNavigationService;
        _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    public override bool CanExecute(object? parameter)
    {
        return !string.IsNullOrEmpty(_makeReservationViewModel.Username) && base.CanExecute(parameter) 
            && _makeReservationViewModel.FloorNumber > 0 && _makeReservationViewModel.RoomNumber > 0;
    }

    public override void Execute(object? parameter)
    {
        var reservation = new Reservation(
            new RoomID(_makeReservationViewModel.FloorNumber,_makeReservationViewModel.RoomNumber),
            _makeReservationViewModel.Username,
            _makeReservationViewModel.StartTime,
            _makeReservationViewModel.EndTime);

        try
        {
            _hotel.MakeReservation(reservation);

            MessageBox.Show("Successfully reserved room", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);

            _reservationViewNavigationService.Navigate();

        }
        catch (ReservationConflictException)
        {
            MessageBox.Show("This room is not available at those times", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        
    }
    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
    if (e.PropertyName == nameof(MakeReservationViewModel.Username) || 
            e.PropertyName == nameof(MakeReservationViewModel.FloorNumber) ||
            e.PropertyName == nameof(MakeReservationViewModel.RoomNumber))
    {
        OnCanExecuteChanged();
    }
}
}
