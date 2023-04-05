using MVVMPractice.Models;
using System;
using System.Runtime.Serialization;

namespace MVVMPractice.Exceptions;

internal class ReservationConflictException : Exception
{
    public Reservation ExisistingReservation { get;}
    public Reservation IncomingReservation { get; }

    public ReservationConflictException(Reservation exisistingReservation, Reservation incomingReservation)
    {
        ExisistingReservation = exisistingReservation;
        IncomingReservation = incomingReservation;
    }

    public ReservationConflictException(string? message, Reservation exisistingReservation, Reservation incomingReservation) : base(message)
    {
        ExisistingReservation = exisistingReservation;
        IncomingReservation = incomingReservation;
    }

    public ReservationConflictException(string? message, Exception? innerException, Reservation exisistingReservation, Reservation incomingReservation) : base(message, innerException)
    {
        ExisistingReservation = exisistingReservation;
        IncomingReservation = incomingReservation;
    }

}