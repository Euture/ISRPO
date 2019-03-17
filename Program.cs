﻿using System;
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
            filter.SetDefaultValues();
        }

        //Список всех Автомобилей
        static List <Car> Cars = new List<Car>();

        //Значения фильтра
        static Filter filter = new Filter();

        static string[] TYPES = new string[]
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
            public string mark;                   //Марка
            public string manufacturer;           //Производитель
            public string type;                   //Тип
            public DateTime date_of_manufacture;  //Дата производства
            public DateTime date_of_registration; //Дата регистрации
            
            //Создание нового объекта
            public Car(string mark, string manufacturer, string type, DateTime date_of_manufacture, DateTime date_of_registration)
            {
                this.mark = mark;
                this.manufacturer = manufacturer;
                this.type = type;
                this.date_of_manufacture = date_of_manufacture;
                this.date_of_registration = date_of_registration;
            }

        }

        //Структура "Фильтр"
        public struct Filter
        {
            string mark;                            //Марка
            string manufacturer;                    //Производитель
            string type;                            //Тип
            DateTime since_date_of_manufacture;     //Дата производства начало
            DateTime till_date_of_manufacture;      //Дата производства окончание
            DateTime since_date_of_registration;    //Дата регистрации начало
            DateTime till_date_of_registration;     //Дата регистрации окончание

            //Конструктор по умолчанию
            public void SetDefaultValues()
            {
                this.mark = "";
                this.manufacturer = "";
                this.type = "";
                //Дата начало - максимальная дата
                //Дата конца - минимальная, чтобы изначально ничего не отбрасывало
                this.since_date_of_manufacture = new DateTime(9999, 01, 01);
                this.till_date_of_manufacture = new DateTime(01, 01, 01);
                this.since_date_of_registration = new DateTime(9999, 01, 01);
                this.till_date_of_registration = new DateTime(01, 01, 01);
            }

            //Ввод значений фильтра
            public void InputFilterValues()
            {
                Console.Clear();
                Console.WriteLine("Ввод значений фильтра");

                Console.WriteLine("Марка: ");
                this.mark = Console.ReadLine();

                Console.WriteLine("Производитель: ");
                this.manufacturer = Console.ReadLine();

                Console.WriteLine("Тип авто : ");
                for (int i = 0; i < TYPES.Length; i++)
                {
                    Console.WriteLine("  " + (i + 1) + "." + TYPES[i]);
                }
                this.type = TYPES[int.Parse(Console.ReadLine()) - 1];

                Console.WriteLine("Дата производства С (dd.mm.yyyy) : ");
                this.since_date_of_manufacture = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Дата производства ПО (dd.mm.yyyy) : ");
                this.till_date_of_manufacture = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Дата регистрации С (dd.mm.yyyy) : ");
                this.since_date_of_registration = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Дата регистрации ПО (dd.mm.yyyy) : ");
                this.till_date_of_registration = DateTime.Parse(Console.ReadLine());     
            }

        }

        //Ввод нового Автомобиля
        public static void NewCar()
        {
            Console.Clear();
            Console.WriteLine("Ввод нового автомобиля");

            Console.WriteLine("Марка: ");
            string mark = Console.ReadLine();

            Console.WriteLine("Производитель: ");
            string manufacturer = Console.ReadLine();

            Console.WriteLine("Тип авто : ");
            for (int i = 0; i < TYPES.Length; i++)
            {
                Console.WriteLine("  " + (i + 1) + "." + TYPES[i]);
            }
            string type = TYPES[int.Parse(Console.ReadLine()) - 1];

            Console.WriteLine("Дата производства (dd.mm.yyyy) : ");
            DateTime date_of_manufacture = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Дата регистрации (dd.mm.yyyy) : ");
            DateTime date_of_registration = DateTime.Parse(Console.ReadLine());

            Cars.Add(new Car(mark, manufacturer, type, date_of_manufacture, date_of_registration));
        }

        //Метод вывода списка всех элементов 
        static public void PrintCars()
        {

        }


        //Метод вывода отфильтрованного списка элементов 
        static public void PrintFilteredCars()
        {

        }

        // Метод вывода меню
        static public void Menu()
        {
            Console.Clear();
            //Выводим меню, его пункты с соответствующими цифрами\символами
            Console.WriteLine("--- МЕНЮ ---");
            Console.WriteLine("1. Ввести в список еще один элемент.");
            Console.WriteLine("2. Вывести весь список.");
            Console.WriteLine("3. Вывести отфильтрованный список.");
            Console.WriteLine("4. Ввести значения фильтра.");
            Console.WriteLine("5. Выйти из программы.");
            Console.Write("\n" + "Введите команду: ");

            char ch = char.Parse(Console.ReadLine());

            switch (ch)
            {
                case '1':
                    NewCar();
                    break;
                case '2':
                    PrintCars();
                    break;
                case '3':
                    PrintFilteredCars();
                    break;
                case '4':
                    filter.InputFilterValues();
                    break;
                case '5':
                    //exit
                    break;


            }
        }
    }
}
