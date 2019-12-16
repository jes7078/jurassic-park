using System;
using System.Collections.Generic;
using System.Linq;

namespace jurassic_park
{
    class Program
    {
        // static List<Dinosaurid> Dinosaurs = new List<Dinosaurid>();

        static JurassicContext Db = new JurassicContext();
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
            // Dinosaurs.Add(dinosaur);
            Db.Dinosaurids.Add(dinosaur);
            Db.SaveChanges();
        }

        static void ViewDinosaur()
        {
            DisplayListofDinosaurids(Db.Dinosaurids);
        }

        static void DisplayListofDinosaurids(IEnumerable<Dinosaurid> dinosaurs)
        {
            Console.WriteLine("Jurrasic Park has");
            Console.WriteLine("-------------------");
            var date=dinosaurs.OrderBy(x=>x.DateAcquired);
            
            foreach (var dinosaur in date)
            {
                Console.WriteLine($"Id: {dinosaur.Id}, Name: {dinosaur.Name}, Diet: {dinosaur.DietType}, Weight: {dinosaur.Weight}, Enclosure: {dinosaur.EnclosureNumber}, Date Acquired: {dinosaur.DateAcquired}");
            }
        }
        static void DietSummary(IEnumerable<Dinosaurid> dinosaurs)
        {
            Console.WriteLine("Jurrassic Park has");
            Console.WriteLine("--------------------");
            int carnivore=0;
            int herbivore=0;
            foreach(var dinosaur in dinosaurs)
            {
                if(dinosaur.DietType=="carnivore")
                {
                    carnivore++;
                }
                else if (dinosaur.DietType=="herbivore")
                {
                    herbivore++;
                }
                Console.WriteLine("Carnivores: " + carnivore);
                Console.WriteLine("Herbivores: " + herbivore);
            }
        }
          static void Heaviest(IEnumerable<Dinosaurid> dinosaurs)
        {
            Console.WriteLine("Jurrassic Park's three Heaviest dinosaurs");
            Console.WriteLine("--------------------");
            var heaviest=dinosaurs.OrderByDescending(x=>x.Weight).Take(3);
            foreach(var dinosaur in heaviest)
            {
            Console.WriteLine($"Name: {dinosaur.Name},Weight: {dinosaur.Weight}");
            }
        }

        static void NeedsASheep(IEnumerable<Dinosaurid> dinosaurs)
        {
            var lightest=dinosaurs.Where(n=>n.DietType=="carnivore").OrderBy(x=>x.Weight).Take(1);
            foreach(var dinosaur in lightest)
            {
            Console.WriteLine($"Name: {dinosaur.Name},Weight:{dinosaur.Weight} needs a sheep.");
            }
        }
        static void RemoveDinosaur()
        {
            Console.WriteLine("What dinosaur would you like to remove?");
            var searchTerm=Console.ReadLine();
            var results = Db.Dinosaurids
            .FirstOrDefault(dinosaur=>
            dinosaur.Name.ToLower()
            ==searchTerm.ToLower());
            Db.Dinosaurids.Remove(results);
            Console.WriteLine("Dinosaur Removed");
            Db.SaveChanges();
        }

        static void Hatch(IEnumerable<Dinosaurid> dinosaurs)
        {
            string[] names = {"Amy", "Brian", "Charlie", "Diane"};
            var random = new Random((int)DateTime.Now.Ticks);
            var nameRandomValue=random.Next(0,4);
            var weightRandomValue=random.Next(1,101);
            var dietRandomValue=random.Next(0,2);
            string weight = weightRandomValue.ToString();
            string[] diet = {"carnivore", "herbivore"};
             var dinosaur = new Dinosaurid();
            dinosaur.Name=names[nameRandomValue];
            dinosaur.DietType=diet[dietRandomValue];
            dinosaur.Weight=weight;
            dinosaur.DateAcquired=DateTime.Now;
            Db.Dinosaurids.Add(dinosaur);
            Db.SaveChanges();

        }

        static void TransferDinosaur()
        {
            Console.WriteLine("What dinosaur would you like to transfer?");
            var result=Console.ReadLine();
            Console.WriteLine("What pen would you like to transfer the dinosaur to?");
            var location = Console.ReadLine();

            var transfer = Db.Dinosaurids.FirstOrDefault(dinosaur =>dinosaur.Name.ToLower() == result.ToLower());
            transfer.EnclosureNumber=location;
            Console.WriteLine("dinosaur transferred.");
            Db.SaveChanges();
        }

        static void Release()
        {
            Console.WriteLine("What dinosaur would you like to release?");
            var result=Console.ReadLine();
            var releasing = Db.Dinosaurids.FirstOrDefault(dinosaur=>dinosaur.Name.ToLower() == result.ToLower());
            releasing.EnclosureNumber=null;
            Console.WriteLine("dinosaur released, run fast!!!");
            Db.SaveChanges();

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
                Console.WriteLine("Available commands are add,view, remove, transfer, diet, heaviest, hatch, release, needs a sheep, and quit");
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
                else if(input=="diet")
                {
                    DietSummary(Db.Dinosaurids);
                }
                 else if(input=="heaviest")
                {
                    Heaviest(Db.Dinosaurids);
                }
                else if(input=="needs a sheep")
                {
                    NeedsASheep(Db.Dinosaurids);
                }
                else if(input=="hatch")
                {
                    Hatch(Db.Dinosaurids);
                }
                else if(input=="quit")
                {
                    QuitProgramMessage();
                }
                else if(input=="release")
                {
                    Release();
                }
                else
                { 
                    UnknownCommand();
                }
            }
        }
    }
}
