using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeTheTrolls
{
    class Program
    {
        public static Coordinate Adventurer { get; set; }
        public static Coordinate Troll1 { get; set; }
        public static Coordinate Troll2 { get; set; }
        public static Coordinate Troll3 { get; set; }
        public static bool gameOver = false;
        static Random rnd = new Random();
        static Random rnd2 = new Random(11);
        static Random rnd3 = new Random(65);
        static Random rnd4 = new Random(34);
        // 38 x 23
        // width x height
        static string[] maze = {"#####################################",
                                "# #       #       #     #         # #",
                                "# # ##### # ### ##### ### ### ### # #",
                                "#       #   # #     #     # # #   # #",
                                "##### # ##### ##### ### # # # ##### #",
                                "#   # #       #     # # # # #     # #",
                                "# # ####### # # ##### ### # ##### # #",
                                "# #       # # #   #     #     #   # #",
                                "# ####### ### ### # ### ##### # ### #",
                                "#     #   # #   # #   #     # #     #",
                                "# ### ### # ### # ##### # # # #######",
                                "#   #   # # #   #   #   # # #   #   #",
                                "####### # # # ##### # ### # ### ### #",
                                "#     # #     #   # #   # #   #     #",
                                "# ### # ##### ### # ### ### ####### #",
                                "# #   #     #     #   # # #       # #",
                                "# # ##### # ### ##### # # ####### # #",
                                "# #     # # # # #     #       # #   #",
                                "# ##### # # # ### ##### ##### # #####",
                                "# #   # # #     #     # #   #       #",
                                "# # ### ### ### ##### ### # ##### # #",
                                "# #         #     #       #       # #",
                                "#X###################################" };

        static string[] winningText =
        {
"          _____                    _____                    _____                    _____                    _____                    _____          ",
"         /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\         ",
"        /::\\____\\                /::\\    \\                /::\\____\\                /::\\____\\                /::\\    \\                /::\\    \\        ",
"       /:::/    /                \\:::\\    \\              /::::|   |               /::::|   |               /::::\\    \\              /::::\\    \\       ",
"      /:::/   _/___               \\:::\\    \\            /:::::|   |              /:::::|   |              /::::::\\    \\            /::::::\\    \\      ",
"     /:::/   /\\    \\               \\:::\\    \\          /::::::|   |             /::::::|   |             /:::/\\:::\\    \\          /:::/\\:::\\    \\     ",
"    /:::/   /::\\____\\               \\:::\\    \\        /:::/|::|   |            /:::/|::|   |            /:::/__\\:::\\    \\        /:::/__\\:::\\    \\    ",
"   /:::/   /:::/    /               /::::\\    \\      /:::/ |::|   |           /:::/ |::|   |           /::::\\   \\:::\\    \\      /::::\\   \\:::\\    \\   ",
"  /:::/   /:::/   _/___    ____    /::::::\\    \\    /:::/  |::|   | _____    /:::/  |::|   | _____    /::::::\\   \\:::\\    \\    /::::::\\   \\:::\\    \\  ",
" /:::/___/:::/   /\\    \\  /\\   \\  /:::/\\:::\\    \\  /:::/   |::|   |/\\    \\  /:::/   |::|   |/\\    \\  /:::/\\:::\\   \\:::\\    \\  /:::/\\:::\\   \\:::\\____\\ ",
"|:::|   /:::/   /::\\____\\/::\\   \\/:::/  \\:::\\____\\/:: /    |::|   /::\\____\\/:: /    |::|   /::\\____\\/:::/__\\:::\\   \\:::\\____\\/:::/  \\:::\\   \\:::|    |",
"|:::|__/:::/   /:::/    /\\:::\\  /:::/    \\::/    /\\::/    /|::|  /:::/    /\\::/    /|::|  /:::/    /\\:::\\   \\:::\\   \\::/    /\\::/   |::::\\  /:::|____|",
"  \\::::::/   /:::/    /    \\::::::/    /                   |::|/:::/    /           |::|/:::/    /    \\:::\\   \\:::\\    \\            |:::::::::/    /",
"   \\::::/___/:::/    /      \\::::/____/                    |::::::/    /            |::::::/    /      \\:::\\   \\:::\\____\\           |::|\\::::/    /",
"    \\:::\\__/:::/    /        \\:::\\    \\                    |:::::/    /             |:::::/    /        \\:::\\   \\::/    /           |::| \\::/____/",
"     \\::::::::/    /          \\:::\\    \\                   |::::/    /              |::::/    /          \\:::\\   \\/____/            |::|  ~|",
"      \\::::::/    /            \\:::\\    \\                  /:::/    /               /:::/    /            \\:::\\    \\                |::|   | "      ,
"       \\::::/    /              \\:::\\____\\                /:::/    /               /:::/    /              \\:::\\____\\               \\::|   |  "   ,
"        \\::/____/                \\::/    /                \\::/    /                \\::/    /                \\::/    /                \\:|   |   "   ,
"         ~~                       \\/____/                  \\/____/                  \\/____/                  \\/____/                  \\|___|    "

        };
        

        static void Main(string[] args)
        {
            initializeGame();

            ConsoleKeyInfo keyInfo;
            // while ESC (quit) isn't pressed
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape && gameOver == false) {
                switch(keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        moveAllTrolls();
                        if (trollCollision()) youLose();
                        moveExplorer(0, -1, "^");
                        break;
                    case ConsoleKey.RightArrow:
                        moveAllTrolls();
                        if (trollCollision()) youLose();
                        moveExplorer(1, 0, ">");
                        break;
                    case ConsoleKey.LeftArrow:
                        moveAllTrolls();
                        if (trollCollision()) youLose();
                        moveExplorer(-1, 0, "<");
                        break;
                    case ConsoleKey.DownArrow:
                        moveAllTrolls();
                        if (trollCollision()) youLose();
                        moveExplorer(0, 1, "v");
                        break;
                }
                if (trollCollision()) youLose();
            }
            Console.ReadLine();
        }

        static void youLose()
        {
            gameOver = true;
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("Oh no! You were eaten by a troll!");
        }

        static void spawnTroll1()
        {
            int xCoord = rnd.Next(1, 36);
            int yCoord = rnd.Next(2, 20);
            Troll1 = new Coordinate() {
                X = xCoord,
                Y = yCoord,
             };
            // If the troll is in a valid position
            if (canMove(Troll1)) {
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("T");
            }
            // try again
            else
            {
                spawnTroll1();
            }
        }

        static void spawnTroll2()
        {
            int xCoord = rnd.Next(1, 36);
            int yCoord = rnd.Next(2, 20);

            Troll2 = new Coordinate()
            {
                X = xCoord,
                Y = yCoord
            };
            // If the troll is in a valid position
            if (canMove(Troll2))
            {
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("T");
            }
            // try again
            else
            {
                spawnTroll2();
            }
        }

        static void spawnTroll3()
        {
            int xCoord = rnd.Next(1, 36);
            int yCoord = rnd.Next(2, 20);

            Troll3 = new Coordinate()
            {
                X = xCoord,
                Y = yCoord
            };
            // If the troll is in a valid position
            if (canMove(Troll3))
            {
                Console.SetCursorPosition(xCoord, yCoord);
                Console.Write("T");
            }
            // try again
            else
            {
                spawnTroll3();
            }
        }

        static void moveExplorer(int x, int y, string hero)
        { 
            Coordinate newDude = new Coordinate()
            {
                X = Adventurer.X + x,
                Y = Adventurer.Y + y
            };

            if (canMove(newDude))
            {
                RemoveExplorer();
                
                Console.SetCursorPosition(newDude.X, newDude.Y);
                Console.Write(hero);

                Adventurer = newDude;
            }
            
        }
          

        static void moveTroll1(int x, int y)
        {
            // create a new coordinate object to see if the move is valid
            Coordinate newTroll = new Coordinate()
            {
                X = Troll1.X + x,
                Y = Troll1.Y + y
            };

            if (canMove(newTroll))
            {
                removeTroll(Troll1);
                Console.SetCursorPosition(newTroll.X, newTroll.Y);
                Console.Write("T");
                

                Troll1 = newTroll;
            }
            else
            {
                
                int[] dir = getTrollDirection();
                moveTroll1(dir[0], dir[1]);
            }
        }
        static void moveTroll2(int x, int y)
        {
            Coordinate newTroll = new Coordinate()
            {
                X = Troll2.X + x,
                Y = Troll2.Y + y
            };
                      

            if (canMove(newTroll))
            {
                removeTroll(Troll2);
                Console.SetCursorPosition(newTroll.X, newTroll.Y);
                Console.Write("T");

                Troll2 = newTroll;
            }
            else
            {
                // try a new direction
                int[] dir = getTrollDirection();
                moveTroll2(dir[0], dir[1]);
            }
        }
        static void moveTroll3(int x, int y)
        {
            Coordinate newTroll = new Coordinate()
            {
                X = Troll3.X + x,
                Y = Troll3.Y + y
            };


            if (canMove(newTroll))
            {
                removeTroll(Troll3);
                Console.SetCursorPosition(newTroll.X, newTroll.Y);
                Console.Write("T");

                Troll3 = newTroll;
            }
            else
            {
                // try a new direction
                int[] dir = getTrollDirection();
                moveTroll3(dir[0], dir[1]);
            }
        }

        static void removeTroll(Coordinate troll)
        {
            Console.SetCursorPosition(troll.X, troll.Y);
            Console.Write(" ");
        }

        static int[] getTrollDirection()
        {
            int dir = rnd.Next(1, 5);
            int x = 0;
            int y = 0;
            switch (dir)
            {
                case 1: // UP
                    y = -1;
                    // x stays the same
                    break;
                case 2: // Down
                    y = 1;
                    // x stays the same
                    break;
                case 3: // Left
                    x = -1;
                    break;
                case 4: // Right
                    x = 1;
                    break;
            }
            int[] coords = new int[2] { x, y };

            return coords;
        }

        static void moveAllTrolls()
        {
            int[] c1;
            int[] c2;
            int[] c3;
            // Trolllllsss
            // rand(1, 5) // 1 is inclusive and 5 is exclusive
            // we will get a value between 1 and 4
            // Up, Down, Left, Right
            // Check if canMove(), otherwise try again
            c1 = getTrollDirection();
            c2 = getTrollDirection();
            c3 = getTrollDirection();
            // Set troll directions and moving booleans
            
            moveTroll1(c1[0], c1[1]);
            moveTroll2(c2[0], c2[1]);
            moveTroll3(c3[0], c3[1]);
        }

        static bool canMove(Coordinate guy)
        {
            // is it out of the screen?
            if (guy.X < 0 || guy.X > Console.WindowWidth) return false;
            if (guy.Y < 0 || guy.Y > Console.WindowHeight) return false;
            if (maze[guy.Y].Substring(guy.X, 1).Equals("#")) return false;
            // If a troll hits the X it is an invalid move
            if (maze[guy.Y].Substring(guy.X, 1).Equals("X")) return false;
            // If the adventurer hits the X it is a valid move
            if (maze[Adventurer.Y].Substring(Adventurer.X, 1).Equals("X"))
            {
                winGame();
                return false;
            }
            return true;
        }

        static bool trollCollision()
        {
            // Did the adventurer hit a troll??
            // Check Adventurer coordinates against Troll coordinates
            if (Adventurer.X == Troll1.X && Adventurer.Y == Troll1.Y) return true;
            if (Adventurer.X == Troll2.X && Adventurer.Y == Troll2.Y) return true;
            if (Adventurer.X == Troll3.X && Adventurer.Y == Troll3.Y) return true;

            return false;
        }

        static void RemoveExplorer()
        {
            Console.SetCursorPosition(Adventurer.X, Adventurer.Y);
            Console.Write(" ");
        }
             

        static void initializeGame()
        {
            // Make the Console look pretty
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            // Write maze
            for (int i = 0; i < maze.Length; i++)
            {
                Console.WriteLine(maze[i]);
            }
            
            int left = rnd4.Next(5, 30);
            int down = rnd4.Next(1, 20);

            // Set dora's coordinates 
            Adventurer = new Coordinate()
            {
                // Random position
                
                X = 25, // left
                Y = 10 // down
            };

            
            spawnTroll1();
            spawnTroll2();
            spawnTroll3();
            moveExplorer(0, 0, ">");
        }

        static void winGame()
        {
            gameOver = true;
            Console.Clear();
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            
            for (int i = 0; i<winningText.Length; i++)
            {
                Console.WriteLine(winningText[i]);
            }
            Console.WriteLine("Congratulations! You escaped the trolls. Press Enter to continue");
        }
    }



    class Coordinate
    {
        public int X { get; set; } // dist left
        public int Y { get; set; } // dist top
    }
}
