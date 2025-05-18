using System;


namespace manchala
{
    class Manqale
    {
        string firstP, secondP;
        int starter;
        int move;
        public Manqale(string arg1, string arg2,int arg3)
        {
            firstP = arg1;
            secondP = arg2;
            starter = arg3;
        }
        public void Play()
        {
            Game();
        }
        private void Game()
        {
            int[] MB = new int[14];
            int[] limits = new int[2];
            int beans, target, skipper, rightLine, leftLine;
            bool is_our_turn = true;
            bool game_over = false;
            int place;
            for (int i = 1; i <= 14; i++)
                MB[i - 1] = starter;
            MB[6] = MB[13] = 0;

            string shortName1 = firstP, shortName2 = secondP;
            if (shortName1.Length > 3)
                shortName1 = shortName1.Remove(3);
            if (shortName2.Length > 3)
                shortName2 = shortName2.Remove(3);


            while (!game_over)
            {
                ShowBoard(MB, shortName1.ToUpper().ToCharArray(), shortName2.ToUpper().ToCharArray());


                leftLine = rightLine = 0;
                for (int i = 0; i < 6; i++)
                    rightLine += MB[i];
                for (int i = 7; i < 13; i++)
                    leftLine += MB[i];
                if (is_our_turn && rightLine == 0)
                {
                    MB[13] += leftLine;
                    for (int i = 7; i < 13; i++)
                        MB[i] = 0;
                    game_over = true;
                }
                else if (!is_our_turn && leftLine == 0)
                {
                    MB[6] += leftLine;
                    for (int i = 0; i < 6; i++)
                        MB[i] = 0;
                    game_over = true;
                }

                if (game_over)
                {
                    ShowBoard(MB,shortName1.ToUpper().ToCharArray(), shortName2.ToUpper().ToCharArray());
                    if (MB[13] > MB[6]) {
                        Console.Write(secondP);
                        Console.WriteLine(" wins!"); 
                    }
                    else if (MB[13] < MB[6])
                    {
                        Console.Write(firstP);
                        Console.WriteLine(" wins!");
                    }
                    else Console.WriteLine("Draw!");
                    continue;
                }

                if (is_our_turn)
                {
                    Console.Write(firstP);
                    Console.WriteLine(" to move:");
                }
                else
                {
                    Console.Write(secondP);
                    Console.WriteLine(" to move:");
                }

                getMove(MB,is_our_turn);
                
                
                if (is_our_turn)
                {
                    beans = MB[move - 1];
                    MB[move - 1] = 0;
                    target = 6;
                    skipper = 13;
                    limits[0] = 0;
                    limits[1] = 5;
                }
                else
                {
                    move = 14 - move;
                    beans = MB[move - 1];
                    MB[move - 1] = 0;
                    target = 13;
                    skipper = 6;
                    limits[0] = 7;
                    limits[1] = 12;
                }
                for (int i = beans; i > 0; i--)
                {
                    move++;
                    place = (move - 1) % 14;
                    if (place == skipper)
                    {
                        i++;
                        continue;
                    }
                    MB[place]++;

                    if (i == 1 && place == target)
                        is_our_turn = !is_our_turn;
                    else if (i == 1 && MB[place] == 1 && limits[0] <= place && place <= limits[1] && MB[12 - place] > 0)
                    {
                        MB[target] += MB[place];
                        MB[target] += MB[12 - place];
                        MB[place] = 0;
                        MB[12 - place] = 0;
                    }
                }
                is_our_turn = !is_our_turn;
            }
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            System.Diagnostics.Process.Start("manchala.exe");
        }

        void getMove(int[] mancala_board, bool is_our_turn,bool rep=false)
        {
            int a = 0;
            if(rep)
            {
                Console.Write("invalid input,try again\n");
            }
            try
            {
                a = Convert.ToInt16(Console.ReadLine());
                rep = false;
            }
            catch(Exception e)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                rep = true;
                getMove(mancala_board, is_our_turn, rep);
                return;
            }

            if (rep)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }

            if (a > 0 && a < 7)
            {
                if ((is_our_turn && mancala_board[a - 1] != 0) || (!is_our_turn && mancala_board[14 - a - 1] != 0))
                {
                    move = a;
                    rep = false;
                }
                else
                    rep = true;
            }
            else
                rep = true;

            if (rep) getMove(mancala_board, is_our_turn, rep);

        }

        private void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        void ShowBoard(int[] mancala_board, char[] firstP, char[] secondP)
        {
            Console.Clear();
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.Write("\t");
            Console.Write(firstP);
            Console.Write("\t|\t\t" + mancala_board[6] + "\t\t|\n");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t\t|-------------------------------|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t6\t|\t" + mancala_board[7] + "\t|\t" + mancala_board[5] + "\t|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t\t|-------------------------------|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t5\t|\t" + mancala_board[8] + "\t|\t" + mancala_board[4] + "\t|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t\t|-------------------------------|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t4\t|\t" + mancala_board[9] + "\t|\t" + mancala_board[3] + "\t|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t\t|-------------------------------|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t3\t|\t" + mancala_board[10] + "\t|\t" + mancala_board[2] + "\t|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t\t|-------------------------------|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t2\t|\t" + mancala_board[11] + "\t|\t" + mancala_board[1] + "\t|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t\t|-------------------------------|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t1\t|\t" + mancala_board[12] + "\t|\t" + mancala_board[0] + "\t|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.WriteLine("\t\t|-------------------------------|");
            Console.WriteLine("\t\t|\t\t\t\t|");
            Console.Write("\t");
            Console.Write(secondP);
            Console.Write("\t|\t\t" + mancala_board[13] + "\t\t|\n");
            Console.WriteLine("\t\t|\t\t\t\t|");
        }
    }
}
