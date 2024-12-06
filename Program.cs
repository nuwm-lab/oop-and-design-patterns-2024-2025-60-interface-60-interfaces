using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    class Human
    {
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public int BirthDay;
        public int BirthMonth;
        public int BirthYear;

        // Віртуальний метод для введення даних
        public virtual void InputData()
        {
            Console.Write("Введіть ім'я: ");
            FirstName = Console.ReadLine();

            Console.Write("Введіть прізвище: ");
            LastName = Console.ReadLine();

            Console.Write("Введіть по-батькові: ");
            MiddleName = Console.ReadLine();

            Console.Write("Введіть день народження: ");
            BirthDay = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть місяць народження: ");
            BirthMonth = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть рік народження: ");
            BirthYear = Convert.ToInt32(Console.ReadLine());
        }

        // Віртуальний метод для обчислення віку
        public virtual void CalculateAge()
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - BirthYear;

            if (currentDate.Month < BirthMonth ||
                (currentDate.Month == BirthMonth && currentDate.Day < BirthDay))
            {
                age--;
            }

            Console.WriteLine($"Вік людини: {age} років");
        }

        // Віртуальний метод для підрахунку літер
        public virtual void CountLetterOccurrences()
        {
            Console.Write("Введіть літеру для пошуку в прізвищі: ");
            char letter = Console.ReadKey().KeyChar;
            Console.WriteLine();

            int count = 0;
            foreach (char c in LastName)
            {
                if (char.ToLower(c) == char.ToLower(letter))
                {
                    count++;
                }
            }

            Console.WriteLine($"Кількість входжень літери '{letter}' у прізвищі: {count}");
        }
    }

    // Похідний клас
    class ExtendedHuman : Human
    {
        public string FavoriteHobby;

        // Перевизначення методу для введення даних
        public override void InputData()
        {
            base.InputData();

            Console.Write("Введіть улюблене хобі: ");
            FavoriteHobby = Console.ReadLine();
        }

        // Перевизначення виводу додаткової інформації
        public override void CountLetterOccurrences()
        {
            base.CountLetterOccurrences();
            Console.WriteLine($"Улюблене хобі: {FavoriteHobby}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть режим: 1 - Базова людина, 2 - Розширена людина");
            char userChoice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // Динамічне створення об'єкту
            Human person;
            if (userChoice == '1')
            {
                person = new Human();
            }
            else
            {
                person = new ExtendedHuman();
            }

            // Використання віртуальних методів
            person.InputData();
            person.CalculateAge();
            person.CountLetterOccurrences();

            Console.WriteLine("\nПрограму завершено.");
        }
    }
}
