using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirTicketsNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passengersNumber;
            string destination;
            string company;
            string[] names;
            decimal price;
            decimal discount;

            ShowGreetings();
            Thread.Sleep(300);

            passengersNumber = GetPassengersNumber();    //got passengers

            destination = Getdestination();              //got destination

            price = GetPrice(destination);               //got price      

            company = GetCompany();                      // got company

            discount = GetDiscount(company);             //got discount

            names = GetPassengersName(passengersNumber);  //got passenger's names



            PrintTicket(price, discount, company, names, destination, passengersNumber);  //print all details combined

            Thread.Sleep(300);

        }

        static decimal GetDiscount(string company)
        {
            switch (company)
            {
                case "British Airlines": return 10;
                case "KLM": return 20;
                case "Aegean": return 15;
                default: return -1;
            }
        }

        static int GetPassengersNumber()
        {

            ShowMenuPassengers();
            Thread.Sleep(300);

            string input = Console.ReadLine();

            int number = Convert.ToInt32(input);

            return number;

        }

        static string Getdestination()
        {
            

            string choice = "";

            

            do
            {
                Thread.Sleep(300);
                ShowDestinations();
                string desInput = Console.ReadLine();

                switch (desInput)
                {
                    case "1": choice = "Athens - London"; break;
                    case "2": choice = "Athens - Amsterdam"; break;
                    case "3": choice = "Athens - Berlin"; break;

                    default: choice = "wrong"; Console.WriteLine("Please choose between 1 and 3"); break;
                }
               
                

            } while (choice == "wrong");

            return choice;

        }

        static decimal GetPrice(string destination)
        {
            switch (destination)
            {
                case "Athens - London": return 500;
                case "Athens - Amsterdam": return 400;
                case "Athens - Berlin": return 300;

                default: return -1;
            }

        }

        static string GetCompany()
        {
            Thread.Sleep(300);
            ShowMenuCompany();

            string companyChoice = "";
            string compInput = Console.ReadLine();

            switch (compInput)
            {
                case "1": companyChoice = "British Airlines"; break;
                case "2": companyChoice = "Athens - Amsterdam$"; break;
                case "3": companyChoice = "Athens - Berlin"; break;

                default: companyChoice = "Please choose between 1 and 3"; break;

            }

            return companyChoice;
        }

        static string[] GetPassengersName(int passengersNumber)
        {
            Thread.Sleep(300);
            CreatePassengers();

            string nameInput;
            string[] PassArray = new string[passengersNumber];

            for (int i = 0; i < passengersNumber; i++)
            {
                nameInput = Console.ReadLine();
                PassArray[i] = nameInput;
            }

            return PassArray;
        }



        static void ShowMenuPassengers()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many passengers will travel?");

        }

        static void ShowGreetings()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello Adventurer");
            Console.ResetColor();
        }

        static void ShowDestinations()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose your destination");
            Console.WriteLine("1 - Athens - London - 500$");
            Console.WriteLine("2 - Athens - Amsterdam - 400$");
            Console.WriteLine("3 - Athens - Berlin - 300$");
            Console.ResetColor();
        }




        static void CreatePassengers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please provide passengers fullnames");
            Console.ResetColor();
        }

        static void ShowMenuCompany()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose your prefered company");
            Console.WriteLine("1 - British Airlines - 10%");
            Console.WriteLine("2 - KLM - 20%");
            Console.WriteLine("3 - Aegean - 15%");
            Console.ResetColor();

        }

        static void PrintTicket(decimal price, decimal discount, string company, string[] names, string destination, int passengersNumber)
        {

            Console.WriteLine("TICKET DETAILS:");

            Console.WriteLine($"{names.Length} passengers will travel to {destination} with {company}");
            Console.WriteLine($"-------------Passenger Names----------------");

            foreach (string name in names)
            {
                Console.WriteLine($"/////////////////{name}/////////////////");
            }
            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"Total Price: {(price - price * discount / 100) * passengersNumber}");


        }

    }
}
