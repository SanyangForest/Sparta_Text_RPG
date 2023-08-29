internal class Program //커밋 해보기
{
    private static Character player;

    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

        // 아이템 정보 세팅
    }

    static void DisplayGameIntro()
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                Shop();
                break;
        }
    }
    static void Shop()
    {
        Console.Clear();
        Console.WriteLine("상점에 오신 것을 환영합니다 !");
        Console.WriteLine("아래에 물건을 구매하실 수 있습니다.");
        Console.WriteLine("현재 소지액: " + player.Gold);
        Console.WriteLine("1. 도란검 . 100원");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 1); //인수가 3개 이상쓰면 안되어서 일단은 2개 해놨는데 해결하면 여러개 추가 예정
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                BuyItem("도란검", 100);
                break;
        }
    }



    static void BuyItem(string itemName, int itemPrice)
    {
        if (player.Gold >= itemPrice)
        {
            player.ModifyGold(-itemPrice);
            Console.WriteLine(itemName + "을(를) 구매했습니다.");
            Console.WriteLine("남은 소지액: " + player.Gold);
        }
        else
        {
            Console.WriteLine("소지금이 부족합니다.");
        }

        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }


    static void DisplayMyInfo()
    {
        Console.Clear();

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보르 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name}({player.Job})");
        Console.WriteLine($"공격력 :{player.Atk}");
        Console.WriteLine($"방어력 : {player.Def}");
        Console.WriteLine($"체력 : {player.Hp}");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    static void DisplayInventory()
    {

    }

    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }

            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}


public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Gold;
    public int Go1d
    {
        get { return Go1d; }
        private set { Go1d = value; }
    }

    public Character(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }

    public void ModifyGold(int amount)
    {
        Go1d += amount;
    }
}

//커밋해보기