using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Country arstotzka = new Country();
            arstotzka.Amnesty();
        }
    }

    class Country
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Country()
        {
            CreatorCriminal creatorCriminal = new CreatorCriminal();

            int amountCriminals = 50;

            for (int i = 0; i < amountCriminals; i++)
                _criminals.Add(creatorCriminal.GenerateCriminal());
        }

        public void Amnesty(string crime = "Антиправительственное")
        {
            Console.WriteLine("\nСписок до амнистии:\n");
            ShowCriminals();
            
            List<Criminal> filteredCriminals = _criminals.Where(criminal => criminal.Crime == crime).Select(criminal => criminal).ToList();

            foreach(Criminal criminal in filteredCriminals)
                DeleteCriminal(criminal);

            Console.WriteLine("\nСписок после амнистии:\n");
            ShowCriminals();
        }

        private void ShowCriminals()
        {
            foreach (Criminal criminal in _criminals)
                criminal.ShowCriminal();
        }

        private void DeleteCriminal(Criminal criminal)
        {
            _criminals.Remove(criminal);
        }
    }

    class CreatorCriminal
    {
        public Criminal GenerateCriminal()
        {
            return new Criminal(GetLastName(), GetFirstName(), GetSurname(), GetCrime());
        }

        private string GetLastName()
        {
            List<string> names = new List<string>() { "Громов", "Johnson", "Смирнов", "Мартиросян", "Smith", "Аракчеев", "Шевченко" };

            return names[UserUtils.GenerateRandomNumber(0, names.Count - 1)];
        }

        private string GetFirstName()
        {
            List<string> names = new List<string>() { "Иван", "Боб", "Зураб", "Смит", "Гомер", "Михаил" };

            return names[UserUtils.GenerateRandomNumber(0, names.Count - 1)];
        }

        private string GetSurname()
        {
            List<string> names = new List<string>() { "John", "Владимирович", "Павлович", "Зурабович" };

            return names[UserUtils.GenerateRandomNumber(0, names.Count - 1)];
        }

        private string GetCrime()
        {
            List<string> crimes = new List<string>() { "Антиправительственное", "Кража", "Убийство", "Мошенничество"};

            return crimes[UserUtils.GenerateRandomNumber(0, crimes.Count - 1)];
        }
    }

    class Criminal
    {
        private string _lastName;
        private string _firstName;
        private string _surname;

        public Criminal(string lastName, string firstName, string surname, string crime)
        {
            _lastName = lastName;
            _firstName = firstName;
            _surname = surname;
            Crime = crime;
        }

        public string Crime { get; private set; }

        public void ShowCriminal()
        {
            Console.WriteLine($"{_lastName}-{_firstName}-{_surname}-{Crime}");
        }
    }

    class UserUtils
    {
        private static Random random = new Random();

        public static int GenerateRandomNumber(int minLimitRandom, int maxLimitRandom)
        {
            return random.Next(minLimitRandom, maxLimitRandom);
        }
    }
}
