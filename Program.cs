using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISRPO
{
    class Program
    {

        static void Main(string[] args)
        {
            // Устанавливаем стандартные значения фильтра, чтобы ничего не остеивалось
            Filter.SetDefaultValues();

            // Главное меню программы
            while(true)
            {
                // Выводим меню
                Console.WriteLine("--- МЕНЮ ---");
                Console.WriteLine("1. Ввести в список еще один элемент.");
                Console.WriteLine("2. Вывести весь список.");
                Console.WriteLine("3. Вывести отфильтрованный список.");
                Console.WriteLine("4. Ввести значения фильтра.");
                Console.WriteLine("5. Сброс значения фильтра.");
                Console.WriteLine("0. Выйти из программы.");
                Console.Write("\n" + "Введите команду: ");

                // Считываем выбранный пункт
                char ch = char.Parse(Console.ReadLine());

                // Выбираем действие в зависимости от выбранного пункта меню
                switch (ch)
                {
                    case '1':
                        NewCar();
                        break;
                    case '2':
                        PrintCars(Cars);
                        break;
                    case '3':
                        PrintFilteredCars(Cars, Filter);
                        break;
                    case '4':
                        Filter.InputFilterValues();
                        break;
                    case '5':
                        Filter.SetDefaultValues();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Список всех Автомобилей
        static List <Car> Cars = new List<Car>();

        // Значения фильтра
        static FilterStruct Filter = new FilterStruct();

        // Возможные типы автомобилей
        static string[] TYPES = new string[]
        {
            "Седан",
            "Хетчбек",
            "Универсал",
            "Пикап",
            "Грузовая",
            "Лимузин",
            "Спецтехника"
        };

        // Структура "Автомобиль"
        public struct Car
        {
            public string mark;                   // Марка
            public string manufacturer;           // Производитель
            public string type;                   // Тип
            public DateTime date_of_manufacture;  // Дата производства
            public DateTime date_of_registration; // Дата регистрации
            
            // Создание нового объекта
            public Car(string mark, string manufacturer, string type, DateTime date_of_manufacture, DateTime date_of_registration)
            {
                this.mark = mark;
                this.manufacturer = manufacturer;
                this.type = type;
                this.date_of_manufacture = date_of_manufacture;
                this.date_of_registration = date_of_registration;
            }

        }

        // Структура "Фильтр"
        public struct FilterStruct
        {
            public string mark;                            // Марка
            public string manufacturer;                    // Производитель
            public string type;                            // Тип
            public DateTime since_date_of_manufacture;     // Дата производства начало
            public DateTime till_date_of_manufacture;      // Дата производства окончание
            public DateTime since_date_of_registration;    // Дата регистрации начало
            public DateTime till_date_of_registration;     // Дата регистрации окончание

            // Конструктор по умолчанию
            public void SetDefaultValues()
            {
                this.mark = null;
                this.manufacturer = null;
                this.type = null;
                // Дата начало - максимальная дата
                // Дата конца - минимальная, чтобы изначально ничего не отбрасывало
                this.since_date_of_manufacture = new DateTime(01, 01, 01); 
                this.till_date_of_manufacture = new DateTime(9999, 01, 01);
                this.since_date_of_registration = new DateTime(01, 01, 01);
                this.till_date_of_registration = new DateTime(9999, 01, 01); 
            }

            // Ввод значений фильтра
            public void InputFilterValues()
            {
                Console.WriteLine();
                // Меню вывода меню фильтра полей
                Console.WriteLine("Поле фильтра для ввода значения: ");
                Console.WriteLine("1.Марка");
                Console.WriteLine("2.Производитель");
                Console.WriteLine("3.Тип");
                Console.WriteLine("4.Дата производства минимальная");
                Console.WriteLine("5.Дата производства максимальная");
                Console.WriteLine("6.Дата регистрации минимальная");
                Console.WriteLine("7.Дата регистрации максимальная");

                // Считываем выбранный пункт
                char ch = char.Parse(Console.ReadLine());

                // Действие в зависимости от введенного значения
                switch (ch)
                {
                    case '1': // Вводим значение для марки
                        Console.WriteLine("Марка: ");
                        this.mark = Console.ReadLine();
                        break;

                    case '2':// Вводим значения для производетеля
                        Console.WriteLine("Производитель: ");
                        this.manufacturer = Console.ReadLine();
                        break;

                    case '3':// Вводим значения для типа
                        // Выводим варианты
                        Console.WriteLine("Тип авто : ");
                        for (int i = 0; i < TYPES.Length; i++)
                        {
                            Console.WriteLine("  " + (i + 1) + "." + TYPES[i]);
                        }

                        // Пробуем найти этот тип
                        try
                        {
                            this.type = TYPES[int.Parse(Console.ReadLine()) - 1];
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка добавления! Данные не корректны");
                        }
                        break;

                    case '4':// Вводим дату производства минимальную
                        Console.WriteLine("Дата производства минимальная (dd.mm.yyyy) : ");
                        this.since_date_of_manufacture = DateTime.Parse(Console.ReadLine());                  
                        break;

                    case '5':// Вводим дату производства максимальную
                        Console.WriteLine("Дата производства максимальная (dd.mm.yyyy) : ");
                        this.till_date_of_manufacture = DateTime.Parse(Console.ReadLine());
                        break;

                    case '6':// Вводим дату регистрации минимальную
                        Console.WriteLine("Дата регистрации минимальная (dd.mm.yyyy) : ");
                        this.since_date_of_registration = DateTime.Parse(Console.ReadLine());
                        break;

                    case '7':// Вводим дату регистрации максимальную
                        Console.WriteLine("Дата регистрации максимальная (dd.mm.yyyy) : ");
                        this.till_date_of_registration = DateTime.Parse(Console.ReadLine());
                        break;
                }
            }

        }

        // Ввод нового Автомобиля
        public static void NewCar()
        {
            Console.Clear();

            Console.WriteLine("Ввод нового автомобиля");

            Console.WriteLine("Марка: ");
            string mark = Console.ReadLine();

            Console.WriteLine("Производитель: ");
            string manufacturer = Console.ReadLine();

            // Выводим варианты типов
            Console.WriteLine("Тип авто : ");
            for (int i = 0; i < TYPES.Length; i++)
            {
                Console.WriteLine("  " + (i + 1) + "." + TYPES[i]);
            }

            // Пробуем найти этот тип в списке
            string type = "";
            try
            {
                type = TYPES[int.Parse(Console.ReadLine()) - 1];
            }
            catch
            {
                Console.WriteLine("Ошибка добавления! Данные не корректны");
                return;
            }
            
            Console.WriteLine("Дата производства (dd.mm.yyyy) : ");
            DateTime date_of_manufacture = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Дата регистрации (dd.mm.yyyy) : ");
            DateTime date_of_registration = DateTime.Parse(Console.ReadLine());
            
            // Пробуем добавить новый объект
            try
            {
                Cars.Add(new Car(mark, manufacturer, type, date_of_manufacture, date_of_registration));
                Console.WriteLine("Автомобиль успешно добавлен");
            }
            catch
            {
                Console.WriteLine("Ошибка добавления! Данные не корректны");
            }

            Console.ReadLine();
        }

        // Метод вывода списка всех элементов на входе Список<Car> для вывода
        static public void PrintCars(List<Car> Cars)
        {
            Console.Clear();
            
            foreach (Car El in Cars)
            {
                Console.Write("Марка: ");
                Console.WriteLine(El.mark);
                Console.Write("Производитель: ");
                Console.WriteLine(El.manufacturer);
                Console.Write("Тип авто : ");
                Console.WriteLine(El.type);
                Console.Write("Дата производства (dd.mm.yyyy) : ");
                Console.WriteLine(El.date_of_manufacture.ToString("d"));
                Console.Write("Дата регистрации (dd.mm.yyyy) : ");
                Console.WriteLine(El.date_of_registration.ToString("d"));
                Console.WriteLine();
            }
            Console.ReadLine();
        }


        //  Метод вывода отфильтрованного списка элементов 
        static public void PrintFilteredCars(List<Car> Cars, FilterStruct Filter)
        {
            // Результирующий список
            List<Car> result = new List<Car>();

            MatchCollection matches;
            
            // Регулярные выражения на основе введенных полей фильтра
            Regex regex_mark = new Regex(Filter.mark);
            Regex regex_manufacturer = new Regex(Filter.manufacturer);


            foreach (Car El in Cars)
            {
                // Содержится ли подстрока
                // "ud" содержится в "Audi" 
                matches = regex_mark.Matches(El.mark);
                if (matches.Count == 0)
                    continue;

                // Ищем совпадения в строке
                matches = regex_manufacturer.Matches(El.manufacturer);
                if (matches.Count == 0)
                    continue;
                
                // Ищем совпаднеия в строке
                if (Filter.type.Length > 0 & El.type != Filter.type)
                    continue;

                // Дата производства раньше минимальной даты(даты С) - то пропускаем
                if (El.date_of_manufacture < Filter.since_date_of_manufacture)
                    continue;

                // Дата производства позже максимальной даты(даты С) - то пропускаем
                if (El.date_of_manufacture > Filter.till_date_of_manufacture)
                    continue;

                // Дата регистрации раньше минимальной даты(даты С) - то пропускаем
                if (El.date_of_registration < Filter.since_date_of_registration)
                    continue;

                // Дата регистрации позже максимальной даты(даты С) - то пропускаем
                if (El.date_of_registration > Filter.till_date_of_registration)
                    continue;

                // Если мы тут то все поля удовлетворяют
                result.Add(El);
            }

            // Выводим отфильтрованный список
            PrintCars(result);
        }
    }
}
