using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPractice.Models;

public class RoomID
{
    public int FloorNumber { get; }
    public int RoomNumber { get; }

    public RoomID(int floorNumber, int roomNumber)
    {
        FloorNumber = floorNumber;
        RoomNumber = roomNumber;
    }

    public override string ToString()
    {
        return $"{FloorNumber}{RoomNumber}";
    }

    public override bool Equals(object? obj)
    {
        return obj is RoomID roomID &&
            FloorNumber == roomID.FloorNumber && 
            RoomNumber==roomID.RoomNumber;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FloorNumber, RoomNumber);
    }

    public static bool operator ==(RoomID r1, RoomID r2)
    {
        if (r1 is null && r2 is null)
        {
            return true;
        }

        return !(r1 is null) && r1.Equals(r2);
    }

    public static bool operator !=(RoomID r1, RoomID r2)
    {
        return !(r1 == r2);
    }
}
