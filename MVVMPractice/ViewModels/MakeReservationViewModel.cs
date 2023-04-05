using MVVMPractice.Commands;
using MVVMPractice.Models;
using MVVMPractice.Services;
using MVVMPractice.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPractice.ViewModels;

public class MakeReservationViewModel: ViewModelBase
{
    private string? _username;
    public string Username
    {
        get { return _username; } 
        set 
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    private int _roomNumber;
    public int RoomNumber
    {
        get { return _roomNumber; }
        set
        {
            _roomNumber = value;
            OnPropertyChanged(nameof(RoomNumber));
        }
    }

    private int _floorNumber;
    public int FloorNumber
    {
        get { return _floorNumber; }
        set
        {
            _floorNumber = value;
            OnPropertyChanged(nameof(FloorNumber));
        }
    }

    private DateTime _startTime = DateTime.Now;
    public DateTime StartTime
    {
        get { return _startTime; }
        set
        {
            _startTime = value;
            OnPropertyChanged(nameof(StartTime));
        }
    }

    private DateTime _endTime = DateTime.Now;
    public DateTime EndTime
    {
        get { return _endTime; }
        set
        {
            _endTime = value;
            OnPropertyChanged(nameof(EndTime));
        }
    }

    public ICommand SubmitCommand { get; } = null!;
    public ICommand CancelCommand { get; } = null!;

    public MakeReservationViewModel(Hotel hotel, NavigationService reservationViewNavigationService)
    {
        SubmitCommand = new MakeReservationCommand(this, hotel, reservationViewNavigationService);
        CancelCommand = new NavigateCommand(reservationViewNavigationService);
    }

}
