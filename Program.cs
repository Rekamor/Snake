public class Program
{
    static void Main()
    {
        int direction = 0;
        int[,] world = new int[9,9];
        int[,] newworld = new int[9,9];
        world[4,4] = 1;
        int snakelength = 1;
        Random randomx = new Random();
        Random randomy = new Random();
        
        while (true)
        {
            System.Threading.Thread.Sleep(300);
            Console.WriteLine("\n\n");
            Print(world);
            Control(ref direction);

            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    switch (world[i, j])
                    {
                        case 1:
                            newworld[i, j] = snakelength + 2;
                            
                            switch (direction)
                            {
                                case 0:
                                    newworld[i - 1, j] = 1;
                                    break;
                                case 1:
                                    newworld[i, j - 1] = 1;
                                    break;
                                case 2:
                                    newworld[i + 1, j] = 1;
                                    break;
                                case 3:
                                    newworld[i, j + 1] = 1;
                                    break;
                            }
                            break;
                        case 0:
                        case 2:
                            break;
                        default:
                            newworld[i, j] = world[i, j] - 1;
                            
                            if (newworld[i, j] == 2)
                            {
                                newworld[i, j] = 0;
                            }
                            break;
                    }
                }
            }
            
            world = newworld;
        }
    } 
    
    static void Print(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.WriteLine();
            
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                switch (arr[i, j])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
                Console.Write("["+ arr[i,j] +"]");
            }
        }
    }

    static void Control(ref int dir)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                dir = 0;
                break;
            case ConsoleKey.RightArrow:
                dir = 3;
                break;
            case ConsoleKey.DownArrow:
                dir = 2;
                break;
            case ConsoleKey.LeftArrow:
                dir = 1;
                break;
            case ConsoleKey.None:
                break;
        }
    }
}
