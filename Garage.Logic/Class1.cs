namespace Garage.Logic;

public  class ParkingSpot
{
  public string LicensePlate { get; set; } = string.Empty;
  public DateTime EntryTime { get; set; }

  public ParkingSpot(string LicensePlate, DateTime EntryTime)
  {
    this.LicensePlate = LicensePlate;
    this.EntryTime = EntryTime;
  }
  

}
