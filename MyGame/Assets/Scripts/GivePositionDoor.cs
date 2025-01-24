//using System;

//class GenGrid
//{
//    public static void Gen_Grid()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            int[,] maze = GenerateMaze();
//            Grid(maze);
//        }
//    }

//    static int[,] GenerateMaze()
//    {
//        int[,] maze = new int[6, 6];

//        Random rand = new Random();

//        for (int i = 0; i < 6; i++)
//        {
//            for (int j = 0; j < 6; j++)
//            {
//                maze[i, j] = 1; // �������� � ���������� ����� ��������� �������
//            }
//        }

//        for (int i = 1; i < 6; i += 2)
//        {
//            for (int j = 1; j < 6; j += 2)
//            {
//                maze[i, j] = 0; // ��������� ������� ����� �������
//            }
//        }

//        // ��������� ��������� ������
//        maze[0, 1] = 2;

//        // ����� �� ���������
//        maze[5, 4] = 3;

//        // ���������� ���� � ���������
//        GeneratePaths(maze, 0, 1, rand);

//        // ��������� �������
//        int objectX, objectY;
//        do
//        {
//            objectX = rand.Next(6);
//            objectY = rand.Next(6);
//        } while (maze[objectX, objectY] != 0 || (objectX == 0 && objectY == 1)); // ������ �� �� ������

//        maze[objectX, objectY] = 4;

//        return maze;
//    }


//    static void GeneratePaths(int[,] maze, int x, int y, Random rand)
//    {
//        int[] directions = { 1, 2, 3, 4 }; // 1 - ������, 2 - ����, 3 - �����, 4 - �����
//        Shuffle(directions, rand);

//        foreach (int direction in directions)
//        {
//            switch (direction)
//            {
//                case 1: // ������
//                    if (x + 2 < 6 && maze[x + 2, y] == 1)
//                    {
//                        maze[x + 1, y] = 0;
//                        maze[x + 2, y] = 0;
//                        GeneratePaths(maze, x + 2, y, rand);
//                    }
//                    break;
//                case 2: // ����
//                    if (y + 2 < 6 && maze[x, y + 2] == 1)
//                    {
//                        maze[x, y + 1] = 0;
//                        maze[x, y + 2] = 0;
//                        GeneratePaths(maze, x, y + 2, rand);
//                    }
//                    break;
//                case 3: // �����
//                    if (x - 2 > 0 && maze[x - 2, y] == 1)
//                    {
//                        maze[x - 1, y] = 0;
//                        maze[x - 2, y] = 0;
//                        GeneratePaths(maze, x - 2, y, rand);
//                    }
//                    break;
//                case 4: // �����
//                    if (y - 2 > 0 && maze[x, y - 2] == 1)
//                    {
//                        maze[x, y - 1] = 0;
//                        maze[x, y - 2] = 0;
//                        GeneratePaths(maze, x, y - 2, rand);
//                    }
//                    break;
//            }
//        }
//    }

//    static void Shuffle(int[] array, Random rand)
//    {
//        for (int i = array.Length - 1; i > 0; i--)
//        {
//            int index = rand.Next(i + 1);
//            int temp = array[index];
//            array[index] = array[i];
//            array[i] = temp;
//        }
//    }

//    static void Grid(int[,] maze)
//    {
//        for (int i = 0; i < 6; i++)
//        {
//            for (int j = 0; j < 6; j++)
//            {
//                Movement.mas[i, j] = maze[i, j];
//            }
//        }
//    }
//}