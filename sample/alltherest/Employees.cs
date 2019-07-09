using System;
using System.Collections.Generic;
using System.Text;

namespace alltherest
{
    public interface IEmployee
    {
        int GetSalary();

        bool PayThePerson();

        public static bool CanAccessShareplan()
        {
            return false;
        }
    }

    public class Interne : IEmployee
    {
        private int _salary;

        private int _bankAccount;

        public int GetSalary()
        {
            return _salary;
        }

        public bool PayThePerson()
        {
            _bankAccount += _salary;
            return true;
        }
    }
}
