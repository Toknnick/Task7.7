using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Barrack barrack = new Barrack();
            barrack.Work();
        }
    }

    class Barrack
    {
        List<Soldier> _firstSquadOfSoldiers = new List<Soldier>();
        List<Soldier> _secondSquadOfSoldiers = new List<Soldier>();

        public Barrack()
        {
            AddSoldiers(_firstSquadOfSoldiers);
            AddSoldiers(_secondSquadOfSoldiers);
        }

        public void Work()
        {
            ShowAllSquads();
            MoveSoldiers();
            Console.WriteLine("Перенос прошел успешно! \n");
            ShowAllSquads();
        }

        private void MoveSoldiers()
        {
            IEnumerable<Soldier> transferredSoldiers = _firstSquadOfSoldiers.Where(soldier => soldier.SurName.StartsWith("Б"));
            _secondSquadOfSoldiers = _secondSquadOfSoldiers.Union(transferredSoldiers).ToList();
            _firstSquadOfSoldiers.RemoveAll(soldierInFirstSquad => _secondSquadOfSoldiers.Any(soldierInSecondSquad => soldierInFirstSquad.SurName == soldierInSecondSquad.SurName));
        }

        private void ShowAllSquads()
        {
            ShowSoldiers("Первый", _firstSquadOfSoldiers);
            ShowSoldiers("Второй", _secondSquadOfSoldiers);
        }

        private void ShowSoldiers(string text, List<Soldier> soldiers)
        {
            Console.WriteLine($"{text} отряд:");

            foreach (Soldier soldier in soldiers)
            {
                soldier.ShowInfo();
            }

            Console.WriteLine();
        }

        private void AddSoldiers(List<Soldier> soldiers)
        {
            Random random = new Random();
            int minSoldiers = 2;
            int maxSoldiers = 10;
            int countOfSoldiers = random.Next(minSoldiers,maxSoldiers);
            int countOfRanks = 3;

            for (int i = 0; i < countOfSoldiers; i++)
            {
                int numberOfRank = random.Next(countOfRanks);
                soldiers.Add(new Soldier(SetSurNameOfsoldier(_firstSquadOfSoldiers.Count + _secondSquadOfSoldiers.Count), SetRankOfsoldier(numberOfRank)));
            }
        }

        private string SetSurNameOfsoldier(int numberOfName)
        {
            List<string> surNamesOfsoldiers = new List<string>
            {
            "Богомолов",
            "Богданов",
            "Виноградов",
            "Мухин",
            "Зубов",
            "Мельников",
            "Александров",
            "Федорова",
            "Соколов",
            "Кочетков",
            "Куликова",
            "Фролова",
            "Черепанова",
            "Нечаева",
            "Алексеев",
            "Климов",
            "Зотов",
            "Филимонова",
            "Демьянова",
            "Третьякова",
            };
            string surName = surNamesOfsoldiers[numberOfName];
            return surName;
        }

        private string SetRankOfsoldier(int numberOfRank)
        {
            List<string> ranksOfsoldiers = new List<string>
            {
            "сержант",
            "капитан",
            "генерал",
            };
            string rank = ranksOfsoldiers[numberOfRank];
            return rank;
        }
    }
    class Soldier
    {
        private string _rank;

        public string SurName { get; private set; }

        public Soldier(string name, string rank)
        {
            SurName = name;
            _rank = rank;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{SurName}. Звание: {_rank}.");
        }
    }
}
