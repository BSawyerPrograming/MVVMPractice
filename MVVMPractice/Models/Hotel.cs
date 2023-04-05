using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPractice.Models;

public class Hotel
{
    private readonly ReservationBook _book;

    public string Name { get; }

    public Hotel(string name)
    {
        Name = name;

        _book= new ReservationBook();
    }

    public IEnumerable<Reservation> GetReservations()
    {
        return _book.GetReservations();
    }

    public void MakeReservation(Reservation reservation)
    {
        _book.AddReservation(reservation);
    }
}
