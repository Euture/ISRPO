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
                    WriteNew();
                break;
                case '2':
                    PrintCars();
                break;
                case '3':
                    PrintFilterCars();
                break;
                case '4':
                    FilterValues();
                break;
                case '5':
                    //exit
                    break;


            }
        }

        //Структура "Автомобиль"
        public struct Car
        {
            private string _mark;                   //Марка
            private string manufacturer;           //Производитель
            private string type;                   //Тип
            private DateTime date_of_manufacture;  //Дата производства
            private DateTime date_of_registration; //Дата регистрации

            //Метод вывода списка всех элементов 
            public void PrintCars()
            {

            }

            //Метод ввода нового элемента 
            private void WriteNew()
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

            //Метод ввода значения фильтра
            private static void FilterValues()
            {

            }

        } 
    
    }
   
}
