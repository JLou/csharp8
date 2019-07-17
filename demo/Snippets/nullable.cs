using System;

namespace Nullable
{
    class Program
    {
        #region main
        static void Main(string[] args)
        {
            Car car = null;

            Console.WriteLine(car.Name);
            
            /*
                Car?
                if (car != null)
                car!.Name
             */
        }
        #endregion
    }

    #region car-class
    class Car
    {
        public string Name { get; }
        public Car(string _name)
        {
            Name = _name;
        }
    }
    #endregion
}