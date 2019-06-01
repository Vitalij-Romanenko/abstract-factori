using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World(new Wood_World_Factori());
            world.RynFoodChain();
            world = new World(new SeaWorldFactori());
            world.RynFoodChain();
        }
    }

    class World
    {
        public World ( World_Faktori world_Faktori)
        {
            plant = world_Faktori.CreatePlant();
            herbiwore = world_Faktori.CreateHerbiwore();
            predator = world_Faktori.CreatePredator();            
        }
        private Plant plant;
        private Herbiwore herbiwore;
        private Predator predator;
        public void RynFoodChain()
        {
            plant.grow();
            herbiwore.eat(plant);
            predator.eat(herbiwore);
        }
    }


    abstract class World_Faktori
    {
        public abstract Plant CreatePlant();
        public abstract Herbiwore CreateHerbiwore();
        public abstract Predator CreatePredator();
    }

    class Wood_World_Factori : World_Faktori
    {
        public override Herbiwore CreateHerbiwore()
        {
            return new Rabbit {Name = " кролик "  } ;
        }

        public override Plant CreatePlant()
        {
            return new Grass { Name = " трава " };
        }

        public override Predator CreatePredator()
        {
            return new Wolf { Name = " волк " };
        }
    }

    class SeaWorldFactori : World_Faktori
    {
        public override Herbiwore CreateHerbiwore()
        {
            return new Fish { Name = " рыба " };
        }

        public override Plant CreatePlant()
        {
            return new SeaWeed { Name = " водоросли " };
        }

        public override Predator CreatePredator()
        {
            return new Shark { Name = " акула " };
        }
    }
    abstract class Plant
    {
        public abstract void grow();
        public string Name { set; get; }

    }

    class Grass : Plant
    {
        public override void grow()
        {
            Console.WriteLine($"{Name} растет");
            
        }

    }
    class SeaWeed : Plant
    {
        public override void grow()
        {
            Console.WriteLine($"{Name} растет");
        }
    }


    abstract class Herbiwore
    {
        public abstract void eat(Plant plant);
        public string Name { set; get; }
    }

    class Rabbit : Herbiwore
    {
        public override void eat (Plant plant)
        {
            Console.WriteLine($"{Name} ест {plant.Name} ");
        }
       
    }

    class Fish : Herbiwore
    {
        public override void eat(Plant plant)
        {
            Console.WriteLine($"{Name} ест {plant.Name} ");
        }

    }

    abstract class Predator
    {
        public abstract void eat(Herbiwore herbiwore);
        public string Name { set; get; }
    }
    class Wolf : Predator
    {
        public override void eat(Herbiwore herbiwore)
        {
            Console.WriteLine($"{Name} ест { herbiwore.Name} ");
        }

    }
        class Shark : Predator
    {
        public override void eat(Herbiwore herbiwore)
        {
            Console.WriteLine($"{Name} ест { herbiwore.Name} ");
        }

    }
}

