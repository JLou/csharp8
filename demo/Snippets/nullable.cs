using System;

namespace Snippets
{
    public class NullableRefType
    {
        #region nullable
        public static void Main()
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