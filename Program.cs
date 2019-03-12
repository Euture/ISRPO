using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPO
{
    class Program
    {
        static void Main(string[] args)
        {

        }


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

        //Структура "Автомобиль"
        public struct Car
        {
            private string _mark;                   //Марка
            private string _manufacturer;           //Производитель
            private string _type;                   //Тип
            private DateTime _date_of_manufacture;  //Дата производства
            private DateTime _date_of_registration; //Дата регистрации

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

            //Метод вывода списка всех элементов 
            public void PrintCars()
            {

            }

            //Метод ввода нового элемента 
            public void WriteNew()
            {

            }

            //Метод вывода отфильтрованного списка элементов 
            public void PrintFilterCars()
            {

            }

        }

        //Структура "Фильтр"
        public struct Filter
        {
            string mark;                            //Марка
            string manufacture;                     //Производитель
            string type;                            //Тип
            DateTime since_date_of_manufacture;     //Дата производства начало
            DateTime till_date_of_manufacture;      //Дата производства окончание
            DateTime since_date_of_registration;    //Дата регистрации начало
            DateTime till_date_of_registration;     //Дата регистрации окончание

        }
    }
}
