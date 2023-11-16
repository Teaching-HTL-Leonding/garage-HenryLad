namespace Garage.Logic;

public class GarageSpot
{
   public ParkingSpot[] parkingSpots { get; } = new ParkingSpot[50];

   public bool IsOcuppied(int parkingSpotNumber)
   {
      if(parkingSpots[parkingSpotNumber] == null)
      {
         return false;
      }
      else{return true;}
   }
   public bool TryOccupy(int ParkingSpotNumber, string licensePlate, DateTime entryTime)
   {
      if(parkingSpots[ParkingSpotNumber] == null)
      {
         parkingSpots[ParkingSpotNumber] = new ParkingSpot(licensePlate, entryTime);
         parkingSpots[ParkingSpotNumber].LicensePlate = licensePlate;
         parkingSpots[ParkingSpotNumber].EntryTime = entryTime;
         return true;
      }
      else{return false;}
   }
   public bool TryExit(int ParkingSpotNumber, DateTime exitTime, out decimal price)
   {
      price = 0;
      double duration = (double)(exitTime - parkingSpots[ParkingSpotNumber].EntryTime).TotalMinutes;
      if(duration < 15){price = 0; return true;}
      else if(duration > 15)
      {
         for(int i = 0; i < duration; i++)
         {
            duration -= 30;
            price += 3m;
         }
         return true;
      }
      return false;      
   }
   public string GenerateReport()
    {
        string report = "| Spot | License Plate |\n| ---- | ------------- |";

        for (int i = 0; i < parkingSpots.Length; i++)
        {
            ParkingSpot parkingSpot = parkingSpots[i];

            report += $"\n| {i + 1,-4} |";

            if (parkingSpot == null) { report += "               |"; }
            else
            {
                report += $" {parkingSpot.LicensePlate,-13} |";
            }
        }
        return report;
    }
}