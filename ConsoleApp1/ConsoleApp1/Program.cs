internal class Program
{ 
    private static Character player;

    private static string UserName;
           
    static void Main(string[] args)
    {
        GameStartIntro(); // 처음 시작 화면

        DisplayGameIntro();
    }

    static void GameStartIntro()
    {        
        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" ! ~ Dungeon Of Sparta ~ ! ");
        Console.ResetColor();
        Console.WriteLine();
        Console.Write(" 이름을 입력해주세요 : ");
        UserName = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine(" 직업을 선택해주세요 : ");
        Console.WriteLine();
        Console.WriteLine(" 1: 전사 2: 궁수 3: 도적 ");
        int input = CheckValidInput(1, 3);
        switch(input)
        {
            case 1:
                GameDataSetting(1);
                break;
            case 2:
                GameDataSetting(2);
                break;
            case 3:
                GameDataSetting(3);
                break;
        }

    }
    static void GameDataSetting(int input)
    {
        switch(input)
        {
            case 1:
                player = new Character(UserName, "전사", 1, 10, 5, 100, 1500);
                break;
            case 2:
                player = new Character(UserName, "궁수", 1, 15, 0, 60, 1500);
                break;
            case 3:
                player = new Character(UserName, "도적", 1, 12, 3, 80, 1500);
                break;
        }     
        
        // 아이템 정보 세팅
    }

    static void DisplayGameIntro()
    {
        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(" 스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine();
        Console.WriteLine(" 마을에서 아래 활동을 할 수 있습니다.");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("1. 상태보기 ");
        Console.WriteLine("2. 인벤토리 ");
        Console.WriteLine("3. 상점 가기 ");
        Console.WriteLine("4. 던전 가기 ");
        Console.WriteLine();
        Console.WriteLine(" 원하시는 행동을 입력해주세요. ");

        int input = CheckValidInput(1, 4);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                DisplayInventory();
                break;
            case 3:
                Shop();
                break;
            case 4:
                // 던전 가는 거 넣어주세요!
                break;
        }
    }
    static void Shop()
    {
        Console.Clear();
        Console.WriteLine("상점에 오신 것을 환영합니다 !");
        Console.WriteLine("아래에 물건을 구매하실 수 있습니다.");
        Console.WriteLine("현재 소지액: " + player.Gold);
        
    }
    static void DisplayMyInfo()
    {
        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" ~ 상태 ~");
        Console.WriteLine();        
        Console.WriteLine(" 캐릭터의 정보를 표시합니다. ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine($" 레벨 : {player.Level} ");
        Console.WriteLine();
        Console.WriteLine($" 이름 : {player.Name} ");
        Console.WriteLine();
        Console.WriteLine($" 직업 : {player.Job} ");        
        Console.WriteLine();
        Console.WriteLine($" 공격력 :{player.Atk} ");
        Console.WriteLine();
        Console.WriteLine($" 방어력 : {player.Def} ");
        Console.WriteLine();
        Console.WriteLine($" 체력 : {player.Hp} ");
        Console.WriteLine();
        Console.WriteLine($" 경험치 : {player.Exp} %");
        Console.WriteLine();
        Console.WriteLine($" Gold : {player.Gold} G");
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
        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" ~ 가방 ~ ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine(" 보유 중인 아이템을 관리할 수 있습니다. ");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" [아이템 목록] ");
        Console.ResetColor();
        Console.WriteLine();

        // 아이템 목록 정보 출력
        // 아이템 클래스 만들면 수정 필요!
        
        Console.WriteLine();
        Console.WriteLine(" 1. 장착 관리 ");
        Console.WriteLine();
        Console.WriteLine(" 0. 나가기 ");
        Console.WriteLine();
        Console.WriteLine(" 원하시는 행동을 입력해주세요! ");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                DisplayEquipment();
                break;
        }
    }
    static void DisplayEquipment()
    {
        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" ~ 장착 관리 ~ ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine(" 장착을 원하는 장비의 번호를 입력하세요 ");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" [아이템 목록] ");
        Console.ResetColor();
        Console.WriteLine();

        // 아이템 목록 정보 출력
        // 아이템 클래스 만들면 수정 필요!

        Console.WriteLine();
        Console.WriteLine(" 0. 나가기 ");
        Console.WriteLine();

        // 아이템 클래스 만들면 수정 필요!
        // 장착 & 해제 로직

        int input = CheckValidInput(0, 1);
        //if (input > 0 && input <= myitems.Count)
        //{
        //    int itemIndex = input - 1;
        //    Items choicedItem = myitems[itemIndex];

        //    choicedItem.IsEquipped = !choicedItem.IsEquipped;
        //    DisplayEquipment();
        //}
        //else if (input == 0)
        //{
        //    DisplayInventory();
        //}
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
    public int Gold { get; set;}
    public float Exp { get; set;}

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
}