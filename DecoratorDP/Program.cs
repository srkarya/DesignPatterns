using DecoratorDP.ConcreteComponent;
using DecoratorDP.ConcreteDecorator;
using DecoratorDP.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDP
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new Hyndai();
            CarDecorator carDecorator = new OfferPrice(car);
            Console.WriteLine(string.Format("Make :{0}  Price:{1} " + "DiscountPrice : {2}"
               , carDecorator.Make, carDecorator.GetPrice().ToString(),
               carDecorator.GetDiscountedPrice().ToString()));

            Console.ReadLine();
        }
    }
}
