using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO
{
    class Program
    {
        string[] TYPES = new string[]
        {
            "Седан",
            "Хетчбек",
            "Универсал",
            "Пикап",
            "Грузовая",
            "Лимузин",
            "Спец техника"
        };

        public struct Car
        {
            private string _mark;
            private string _manufacturer;
            private string _type;
            private DateTime _date_of_manufacture;
            private DateTime _date_of_registration;

            string mark
            {
                get
                {
                    return _mark;
                }
            }
            string manufacturer
            {
                get
                {
                    return _manufacturer;
                }
            }
            string type
            {
                get
                {
                    return _type;
                }
            }
            DateTime date_of_manufacture
            {
                get
                {
                    return _date_of_manufacture;
;
                }
            }
            DateTime date_of_registration
            {
                get
                {
                    return _date_of_registration;
                }
            }

            public void PrintCars()
            {

            }
            
            public void WriteNew()
            {

            }
            
            public void PrintFilterCars()
            {

            }

        }

        public struct Filter
        {
            string mark;
            string manufacture;
            string type;
            DateTime since_date_of_manufacture;
            DateTime till_date_of_manufacture;
            DateTime since_date_of_registration;
            DateTime till_date_of_registration;

        }

        static void Main(string[] args)
        {

        }
    }
}
