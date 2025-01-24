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
//                maze[i, j] = 1; // Начинаем с заполнения всего лабиринта стенами
//            }
//        }

//        for (int i = 1; i < 6; i += 2)
//        {
//            for (int j = 1; j < 6; j += 2)
//            {
//                maze[i, j] = 0; // Оставляем проходы между стенами
//            }
//        }

//        // Начальное положение игрока
//        maze[0, 1] = 2;

//        // Выход из лабиринта
//        maze[5, 4] = 3;

//        // Генерируем пути в лабиринте
//        GeneratePaths(maze, 0, 1, rand);

//        // Добавляем предмет
//        int objectX, objectY;
//        do
//        {
//            objectX = rand.Next(6);
//            objectY = rand.Next(6);
//        } while (maze[objectX, objectY] != 0 || (objectX == 0 && objectY == 1)); // Объект не на старте

//        maze[objectX, objectY] = 4;

//        return maze;
//    }


//    static void GeneratePaths(int[,] maze, int x, int y, Random rand)
//    {
//        int[] directions = { 1, 2, 3, 4 }; // 1 - вправо, 2 - вниз, 3 - влево, 4 - вверх
//        Shuffle(directions, rand);

//        foreach (int direction in directions)
//        {
//            switch (direction)
//            {
//                case 1: // Вправо
//                    if (x + 2 < 6 && maze[x + 2, y] == 1)
//                    {
//                        maze[x + 1, y] = 0;
//                        maze[x + 2, y] = 0;
//                        GeneratePaths(maze, x + 2, y, rand);
//                    }
//                    break;
//                case 2: // Вниз
//                    if (y + 2 < 6 && maze[x, y + 2] == 1)
//                    {
//                        maze[x, y + 1] = 0;
//                        maze[x, y + 2] = 0;
//                        GeneratePaths(maze, x, y + 2, rand);
//                    }
//                    break;
//                case 3: // Влево
//                    if (x - 2 > 0 && maze[x - 2, y] == 1)
//                    {
//                        maze[x - 1, y] = 0;
//                        maze[x - 2, y] = 0;
//                        GeneratePaths(maze, x - 2, y, rand);
//                    }
//                    break;
//                case 4: // Вверх
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