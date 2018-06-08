using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDP.Decorator
{
    public abstract class CarDecorator : ICar
    {
        private ICar _ICar;

        public CarDecorator(ICar car)
        {
            _ICar = car;
        }

        public string Make
        {
            get
            {
                return _ICar.Make;
            }
        }

        public double GetPrice()
        {
            return _ICar.GetPrice();
        }

        public abstract double GetDiscountedPrice();
    }
}
