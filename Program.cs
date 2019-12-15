using System;
using System.Collections.Generic;
using System.Linq;

namespace jurassic_park
{
    class Program
    {
        static List<Dinosaurid> Dinosaurs = new List<Dinosaurid>();
        static void AddDinosaur()
        {
            Console.WriteLine("What Dinosaur would you like to add?");
            var dinosaurName = Console.ReadLine();
            Console.WriteLine("Is the Dinosaur a carnivore or herbivore?");
            var dietType = Console.ReadLine();
            Console.WriteLine("What is the Dinosaur's weight?");
            var dinosaurWeight = Console.ReadLine();
            Console.WriteLine("What pen number is the dinosaur being kept?");
            var enclosureNumber = Console.ReadLine();
            var dinosaur = new Dinosaurid();
            dinosaur.Name=dinosaurName;
            dinosaur.DietType=dietType;
            dinosaur.Weight=dinosaurWeight;
            dinosaur.EnclosureNumber=enclosureNumber;
            dinosaur.DateAcquired=DateTime.Now;
            Dinosaurs.Add(dinosaur);
        }

        static void ViewDinosaur()
        {
            DisplayListofDinosaurids(Dinosaurs);
        }

        static void DisplayListofDinosaurids(IEnumerable<Dinosaurid> dinosaurs)
        {
            Console.WriteLine("Jurrasic Park has");
            Console.WriteLine("-------------------");
            foreach (var dinosaur in dinosaurs)
            {
                Console.WriteLine($"Name: {dinosaur.Name}, Diet: {dinosaur.DietType}, Weight: {dinosaur.Weight}, Enclosure: {dinosaur.EnclosureNumber}, Date Aqcuired: {dinosaur.DateAcquired}");
            }
        }
        static void RemoveDinosaur()
        {
            Console.WriteLine("What dinosaur would you like to remove?");
            var searchTerm=Console.ReadLine();
            var results = Dinosaurs
            .Where(dinosaur=>
            dinosaur.Name.ToLower()
            .Contains(searchTerm.ToLower()));
            Dinosaurs.remove(results);
        }

        static void TransferDinosaur()
        {
            Console.WriteLine("Transfering");
        }

        static void UnknownCommand()
        {
            Console.WriteLine("Unknown Command");
        }

        static void QuitProgramMessage()
        {
            Console.WriteLine("Quitting Program");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Jurassic Park Dinosaur Tracker!");
            var input="";
            while(input !="quit")
            {
                Console.WriteLine("what would you like to do?");
                Console.WriteLine("Avaialble commands are add,view, remove, transfer, and quit");
                input=Console.ReadLine().ToLower();
                if (input=="add")
                {
                    AddDinosaur();
                }
                else if (input =="view")
                {
                    ViewDinosaur();
                }
                else if(input=="remove")
                {
                    RemoveDinosaur();
                }
                else if(input=="transfer")
                {
                    TransferDinosaur();
                }
                else if(input=="quit")
                {
                    QuitProgramMessage();
                }
                else
                { 
                    UnknownCommand();
                }
            }
        }
    }
}
