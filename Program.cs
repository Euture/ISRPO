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
            // Главное меню программы
            while (true)
            {
                // Выводим меню
                Console.WriteLine("--- МЕНЮ ---");
                Console.WriteLine("1. Ввести в список еще один элемент.");
                Console.WriteLine("2. Вывести весь список.");
                Console.WriteLine("3. Вывести отфильтрованный список.");
                Console.WriteLine("4. Ввести значения фильтра.");
                Console.WriteLine("0. Выйти из программы.");
                Console.Write("\n" + "Введите команду: ");

                // Считываем выбранный пункт
                char ch = char.Parse(Console.ReadLine());

                // Выбираем действие в зависимости от выбранного пункта меню
                switch (ch)
                {
                    case '1':
                        // Ввод нового элемента.
                        Car.NewCar();
                        break;

                    case '2':
                        // Вывод списка элементов.
                        Car.PrintCars(Cars);
                        break;

                    case '3':
                        // Вывод отфильтрованного списка
                        Car.PrintFilteredCars(Cars, Filter);
                        break;

                    case '4':
                        // Ввод значения фильтра.
                        Filter.InputFilterValues();
                        break;

                    case '0':
                        // Выход 
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Пустые значения в фильтре
        static List<String> EMPTY_VALUES = new List<String> { null, "" };

        // Список всех Автомобилей
        static List<Car> Cars = new List<Car>();

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

        // Автомобиль
        public struct Car
        {
            public string mark;                   // Марка
            public string manufacturer;           // Производитель
            public string type;                   // Тип
            public DateTime date_of_manufacture;  // Дата производства
            public DateTime date_of_registration; // Дата регистрации

            // Создание нового объекта
            public Car(string mark, string manufacturer, string type, DateTime date_of_manufacture, DateTime date_of_registration)
            /* 
                Параметры:
                    mark                - марка авто
                    manufacturer        - производитель авто
                    type                - тип авто
                    date_of_manufacture - дата производства
                    date_of_registation - дата регистрации
            */
            {
                this.mark = mark;
                this.manufacturer = manufacturer;
                this.type = type;
                this.date_of_manufacture = date_of_manufacture;
                this.date_of_registration = date_of_registration;
            }

            // Ввод нового Автомобиля
            public static void NewCar()
            {
                // Вывод строки пояснения
                Console.WriteLine("Ввод нового автомобиля");

                // Марка
                Console.WriteLine("Марка: ");
                string mark = Console.ReadLine();

                // Производитель 
                Console.WriteLine("Производитель: ");
                string manufacturer = Console.ReadLine();

                // Тип авто
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

                // Дата производства
                Console.WriteLine("Дата производства (dd.mm.yyyy) : ");
                DateTime date_of_manufacture = DateTime.Parse(Console.ReadLine());

                // Дата регистрации
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

            // Вывод списка элементов
            static public void PrintCars(List<Car> Cars)
            /*
                Параметры:
                    Cars - список авто для вывода
            */
            {
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

            // Вывод отфильтрованного списка элементов 
            static public void PrintFilteredCars(List<Car> Cars, FilterStruct Filter)
            /*
                Параметры:
                    Cars    - список авто для фильтрации
                    Filter  - фильтра по которому происходит фильтрация
            */
            {
                // Если фильтр сброшен
                if (!Filter.ChangedValues())
                {
                    // Выводим входной список
                    PrintCars(Cars);
                    return;
                }

                // Признаки на пустоe(стандартное) значение
                Boolean default_mark = false,
                        default_manufacturer = false,
                        default_type = false,
                        default_since_date_of_manufacture = false,
                        default_till_date_of_manufacture = false,
                        default_since_date_of_registration = false,
                        default_till_date_of_registration = false;
                // Регулярные выражения
                Regex regex_mark = null;
                Regex regex_manufacturer = null;
                // Результат поиска по регулярному выражению
                MatchCollection matches;
                // Результирующий список
                List<Car> result = new List<Car>();

                // Устанавливаем признаки 
                if (EMPTY_VALUES.Contains(Filter.mark))
                    default_mark = true;
                else
                {
                    regex_mark = new Regex(Filter.mark); // Регулярное выражения на основе введенного поля фильтра
                }
                if (EMPTY_VALUES.Contains(Filter.manufacturer))
                    default_manufacturer = true;
                else
                {
                    regex_manufacturer = new Regex(Filter.manufacturer); // Регулярное выражения на основе введенного поля фильтра
                }
                if (EMPTY_VALUES.Contains(Filter.type))
                    default_type = true;
                if (EMPTY_VALUES.Contains(Filter.since_date_of_manufacture))
                    default_since_date_of_manufacture = true;
                if (EMPTY_VALUES.Contains(Filter.till_date_of_manufacture))
                    default_till_date_of_manufacture = true;
                if (EMPTY_VALUES.Contains(Filter.since_date_of_registration))
                    default_since_date_of_registration = true;
                if (EMPTY_VALUES.Contains(Filter.till_date_of_registration))
                    default_till_date_of_registration = true;

                // Фильтруем входной список
                foreach (Car El in Cars)
                {
                    // Марка
                    if (!default_mark)
                    {
                        // Содержится ли подстрока
                        // "ud" содержится в "Audi" 
                        matches = regex_mark.Matches(El.mark);
                        if (matches.Count == 0)
                            continue;
                    }

                    // Производитель
                    if (!default_manufacturer)
                    {
                        // Ищем совпадения в строке
                        matches = regex_manufacturer.Matches(El.manufacturer);
                        if (matches.Count == 0)
                            continue;
                    }

                    // Тип авто
                    if (!default_type)
                    {
                        // Ищем совпаднеия в строке
                        if (Filter.type.Length > 0 & El.type != Filter.type)
                            continue;
                    }

                    // Дата производства
                    if (!default_since_date_of_manufacture)
                    {
                        // Дата производства раньше минимальной даты(даты С) - то пропускаем
                        if (El.date_of_manufacture < DateTime.Parse(Filter.since_date_of_manufacture))
                            continue;
                    }
                    if (!default_till_date_of_manufacture)
                    {
                        // Дата производства позже максимальной даты(даты С) - то пропускаем
                        if (El.date_of_manufacture > DateTime.Parse(Filter.till_date_of_manufacture))
                            continue;
                    }

                    // Дата регистрации
                    if (!default_since_date_of_registration)
                    {
                        // Дата регистрации раньше минимальной даты(даты С) - то пропускаем
                        if (El.date_of_registration < DateTime.Parse(Filter.since_date_of_registration))
                            continue;
                    }
                    if (!default_till_date_of_registration)
                    {
                        // Дата регистрации позже максимальной даты(даты С) - то пропускаем
                        if (El.date_of_registration > DateTime.Parse(Filter.till_date_of_registration))
                            continue;
                    }

                    // Если мы тут, то все поля удовлетворяют
                    result.Add(El);
                }

                // Выводим отфильтрованный список
                PrintCars(result);
            }
        }

        // Фильтр
        public struct FilterStruct
        {
            public string mark;                         // Марка
            public string manufacturer;                 // Производитель
            public string type;                         // Тип
            public string since_date_of_manufacture;    // Дата производства начало
            public string till_date_of_manufacture;     // Дата производства окончание
            public string since_date_of_registration;   // Дата регистрации начало
            public string till_date_of_registration;    // Дата регистрации окончание

            // Ввод значений фильтра
            public void InputFilterValues()
            {
                // Вывод меню полей фильтра 
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
                    case '1':
                        // Вводим значение для марки
                        Console.WriteLine("Марка: ");
                        this.mark = Console.ReadLine();
                        break;

                    case '2':
                        // Вводим значения для производителя
                        Console.WriteLine("Производитель: ");
                        this.manufacturer = Console.ReadLine();
                        break;

                    case '3':
                        // Вводим значения для типа
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
                            this.type = "";
                            Console.WriteLine("Ошибка добавления! Данные не корректны");
                        }
                        break;

                    case '4':
                        // Вводим дату производства минимальную
                        Console.WriteLine("Дата производства минимальная (dd.mm.yyyy) : ");
                        this.since_date_of_manufacture = Console.ReadLine();
                        break;

                    case '5':
                        // Вводим дату производства максимальную
                        Console.WriteLine("Дата производства максимальная (dd.mm.yyyy) : ");
                        this.till_date_of_manufacture = Console.ReadLine();
                        break;

                    case '6':
                        // Вводим дату регистрации минимальную
                        Console.WriteLine("Дата регистрации минимальная (dd.mm.yyyy) : ");
                        this.since_date_of_registration = Console.ReadLine();
                        break;

                    case '7':
                        // Вводим дату регистрации максимальную
                        Console.WriteLine("Дата регистрации максимальная (dd.mm.yyyy) : ");
                        this.till_date_of_registration = Console.ReadLine();
                        break;
                }
            }

            // Проверка всех полей на отличия от пустого(стандартного) значения
            public bool ChangedValues()
            {
                if (!EMPTY_VALUES.Contains(this.mark))
                    return true;
                if (!EMPTY_VALUES.Contains(this.manufacturer))
                    return true;
                if (!EMPTY_VALUES.Contains(this.type))
                    return true;
                if (!EMPTY_VALUES.Contains(this.since_date_of_manufacture))
                    return true;
                if (!EMPTY_VALUES.Contains(this.till_date_of_manufacture))
                    return true;
                if (!EMPTY_VALUES.Contains(this.since_date_of_registration))
                    return true;
                if (!EMPTY_VALUES.Contains(this.till_date_of_registration))
                    return true;
                return false;
            }
        }
    }
}
