using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    public abstract class Person
    {
        // Загальні властивості
        protected string FirstName;
        protected string LastName;
        protected string Patronymic;
        protected int BirthDay;
        protected int BirthMonth;
        protected int BirthYear;

        // Абстрактні властивості
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract string Patronymic { get; set; }

        // Загальні методи
        public virtual void SetPersonalData()
        {
            Console.WriteLine("Enter your first name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter your last name: ");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter your patronymic: ");
            Patronymic = Console.ReadLine();
            Console.WriteLine("Enter your birth year: ");
            BirthYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your birth month: ");
            BirthMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your birth day: ");
            BirthDay = Convert.ToInt32(Console.ReadLine());
        }

        public virtual int CalculateAge()
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;

            int age = currentYear - BirthYear;
            if (currentMonth < BirthMonth || (currentMonth == BirthMonth && currentDay < BirthDay))
            {
                age--;
            }
            return age;
        }

        public abstract int CountLetterInLastName(char letter);
    }

}
