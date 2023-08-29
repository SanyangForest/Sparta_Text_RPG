using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dungeon
    {
        Character newCharacter = new Character("Chad", "전사", 1, 10, 5, 100, 1500);
         
        internal void ChoiceDungeon()
        {

            Dungeon dungeon = new Dungeon();
            Console.Clear();
            Console.WriteLine("1. 마을");
            Console.WriteLine("2. 베틀");
            Console.WriteLine("진입하시겠습니까?");

            int input = Program.CheckValidInput(1, 2);
            switch (input)
            {
                case 0:
                    Program.DisplayGameIntro();
                    break;
                case 1:
                    dungeon.Battle();
                    break;
            }


        }

        public void Battle()
        {
            string[] monsterNames = { "대포미니언", "미니언", "공허충" };
            Random random = new Random();

            int randomIndex = random.Next(monsterNames.Length);
            Monster newMonster = new Monster(monsterNames[randomIndex]);

            Console.WriteLine($"{newMonster.Name}가 등장했다!");
            newMonster.StatusRender(newMonster.Name);


            Console.WriteLine("1. 때린다");
            Console.WriteLine("2. 스킬");
            Console.WriteLine("3. 도망간다");
        }

        enum STARTSELECT
        {
            SLELCTTOWN,
            SLELCBETTLE,
            NONSELECT

        }

       



    }

    class FightUnit
    {
        public String Name = "None";
        protected int AT = 10;
        public int HP = 50;
        protected int MaxHp = 100;
        protected int LV;


        public void StatusRender(string _name)
        {
            Name = _name;
            Console.WriteLine(Name);
            Console.WriteLine("의능력치-----------------------------------------------");
            Console.Write("공격력:");
            Console.WriteLine(AT);
            //50/100
            Console.Write("체력:");
            Console.Write(HP);
            Console.Write("/");
            Console.WriteLine(MaxHp);
            Console.WriteLine("-----------------------------------------------");
        }
        public void BattleLogic(string _Name)
        {


            Console.WriteLine($"Lv.{LV} {Name} 의 공격!");
            Console.WriteLine($" {_Name} 을(를) 맞췄습니다.  [데미지: {AT}]");

            Console.WriteLine($"Lv.{LV} {Name}");
            Console.WriteLine($"HP{HP}-> {HP -= AT}");
            Console.WriteLine($"HP {HP}");


        }


    }


   
    class Monster : FightUnit
    {

        public string Name { get; }
        public Monster(string _Name)
        {

            Name = _Name;
            LV = 1;
        }
    }

}
