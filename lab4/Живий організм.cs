using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public interface IReproducible
    {
        void Reproduce();
    }

    public interface IPredator
    {
        void Hunt(LivingOrganism target);
    }

    public class LivingOrganism
    {
        public double Energy { get; set; }
        public int Age { get; set; }
        public double Size { get; set; }
    }

    public class Animal : LivingOrganism, IPredator, IReproducible
    {
        public Animal()
        {
            Energy = 100;
            Age = 5;
            Size = 1.0;
        }
        public string Habitat { get; set; } = "forest";
        public bool IsCarnivorous { get; set; } = true;

        public void Hunt(LivingOrganism target)
        {
            Console.WriteLine("The animal is hunting!");
        }

        public void Reproduce()
        {
            Console.WriteLine("The animal is reproducing!");
        }
    }

    public class Plant : LivingOrganism, IReproducible
    {
        public Plant()
        {
            Energy = 100;
            Age = 1;
            Size = 1.0;
        }
        public string Color { get; set; } = "purple";
        public bool HasFlowers { get; set; } = true;

        public void Reproduce()
        {
            Console.WriteLine("The plant is reproducing!");
        }
    }

    public class Microorganism : LivingOrganism, IReproducible
    {
        public Microorganism()
        {
            Energy = 100;
            Age = 3;
            Size = 1.0;
        }
        public string Microbiome { get; set; } = "water";
        public bool IsSingleCelled { get; set; } = false;

        public void Reproduce()
        {
            Console.WriteLine("The microorganism is reproducing!");
        }
    }

    public class Ecosystem
    {
        public List<LivingOrganism> Organisms { get; set; }

        public void SimulateInteractions()
        {
            foreach (var organism in Organisms)
            {
                if (organism is Animal animal)
                {
                    animal.Hunt(organism);
                }
                else if (organism is IReproducible reproducibleOrganism)
                {
                    reproducibleOrganism.Reproduce();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ecosystem ecosystem = new Ecosystem();
            ecosystem.Organisms = new List<LivingOrganism>
            {
                new Animal(),
                new Plant(),
                new Microorganism()
            };

            ecosystem.SimulateInteractions();
        }
    }
}