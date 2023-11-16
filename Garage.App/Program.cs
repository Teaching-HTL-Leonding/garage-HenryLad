using Garage.Logic;
int selectedOption;
GarageSpot garage = new GarageSpot();
do{
System.Console.WriteLine("1) Enter a car entry ");
System.Console.WriteLine("2) Enter a car exit ");
System.Console.WriteLine("3) Genrate a report ");
System.Console.WriteLine("4) Exit ");
Console.Write("What do you want to do : ");
selectedOption = int.Parse(System.Console.ReadLine()!);
switch(selectedOption)
{
   case 1:
         System.Console.Write("Enter parking spot number : ");
         int parkingSpotNumber = int.Parse(System.Console.ReadLine()!);
         if(garage.IsOcuppied(parkingSpotNumber)){System.Console.WriteLine("The spot is occupied"); continue; }
         System.Console.Write("Enter license plate : ");
         string licensePlate = System.Console.ReadLine()!;   
         System.Console.Write("Enter entry time : ");
         DateTime entryTime = DateTime.Parse(System.Console.ReadLine()!);
         garage.TryOccupy(parkingSpotNumber, licensePlate, entryTime);
   break;
      case 2:
            System.Console.Write("Enter parking spot number : ");
            parkingSpotNumber = int.Parse(System.Console.ReadLine()!);
            if(!garage.IsOcuppied(parkingSpotNumber)){System.Console.WriteLine("The spot is not occupied"); continue; }
            System.Console.Write("Enter exit time : ");
            DateTime exitTime = DateTime.Parse(System.Console.ReadLine()!);
            decimal price;
            garage.TryExit(parkingSpotNumber, exitTime, out price);
            System.Console.WriteLine($"The price is {price} Euros");
      break;
      case 3:
            System.Console.WriteLine(garage.GenerateReport());
      break;
}
}while(selectedOption != 4);
System.Console.WriteLine("Goodbye");