//using System;
//using UnityEditor;
//using UnityEngine.UIElements;

//class Program
//{
//    //static void Rand(int rnd, int[,] arr, int i0, int j0, int rows, int columns)
//    //{
//    //    if (rnd == 1)
//    //    {
//    //        for (int i = i0; i >= 0; i--)
//    //            arr[i, j0] = 0;
//    //    }
//    //    if (rnd == 2)
//    //    {
//    //        for (int j = j0; j < columns; j++)
//    //            arr[i0, j] = 0;
//    //    }
//    //    if (rnd == 3)
//    //    {
//    //        for (int j = j0; j >= 0; j--)
//    //            arr[i0, j] = 0;
//    //    }
//    //    if (rnd == 4)
//    //    {
//    //        for (int i = i0; i < rows; i++)
//    //            arr[i, j0] = 0;
//    //    }
//    //    if (rnd == 5)
//    //    {
//    //        int i = i0;
//    //        int j = j0;
//    //        while (true)
//    //        {
//    //            if (i == 0 || j + 1 == columns)
//    //                break;
//    //            j++;
//    //            arr[i, j] = 0;
//    //            i--;
//    //            arr[i, j] = 0;
//    //        }
//    //    }
//    //    if (rnd == 6)
//    //    {
//    //        int i = i0;
//    //        int j = j0;
//    //        while (true)
//    //        {
//    //            if (i == 0 || j == 0)
//    //                break;
//    //            j--;
//    //            arr[i, j] = 0;
//    //            i--;
//    //            arr[i, j] = 0;
//    //        }
//    //    }
//    //    if (rnd == 7)
//    //    {
//    //        int i = i0;
//    //        int j = j0;
//    //        while (true)
//    //        {
//    //            if (i + 1 == rows || j + 1 == columns)
//    //                break;
//    //            j++;
//    //            arr[i, j] = 0;
//    //            i++;
//    //            arr[i, j] = 0;
//    //        }
//    //    }
//    //    if (rnd == 8)
//    //    {
//    //        int i = i0;
//    //        int j = j0;
//    //        while (true)
//    //        {
//    //            if (i + 1 == rows || j == 0)
//    //                break;
//    //            j--;
//    //            arr[i, j] = 0;
//    //            i++;
//    //            arr[i, j] = 0;
//    //        }
//    //    }
//    //}
//    //static void Find()
//    //{
//    //    int rows = 11;
//    //    int columns = 11;
//    //    int iterator = 0;
//    //    int[,] arr = new int[rows, columns];

//    //    for (int i = 0; i < rows; i++)
//    //    {
//    //        for (int j = 0; j < columns; j++)
//    //        {
//    //            arr[i, j] = 1;
//    //        }
//    //    }
//    //    Random rand = new Random();
//    //    int i0 = rand.Next(1, 10);
//    //    int j0 = rand.Next(1, 10);
//    //    arr[i0, j0] = 0;
//    //    arr[i0 - 1, j0] = 0;
//    //    arr[i0 - 1, j0 + 1] = 0;
//    //    arr[i0 - 1, j0 - 1] = 0;
//    //    arr[i0 + 1, j0] = 0;
//    //    arr[i0 + 1, j0 + 1] = 0;
//    //    arr[i0 + 1, j0 - 1] = 0;
//    //    arr[i0, j0 - 1] = 0;
//    //    arr[i0, j0 + 1] = 0;

//    //    while (iterator != 15)
//    //    {
//    //        int rnd = rand.Next(1, 9);
//    //        Rand(rnd, arr, i0, j0, rows, columns);
//    //        iterator++;
//    //        while (true)
//    //        {
//    //            int findi = rand.Next(1, 10);
//    //            int findj = rand.Next(1, 10);
//    //            if (arr[findi, findj] == 0)
//    //            {
//    //                i0 = findi;
//    //                j0 = findj;
//    //                break;
//    //            }
//    //        }
//    //    }
//    //    while (true)
//    //    {
//    //        int findi = rand.Next(1, 10);
//    //        int findj = rand.Next(1, 10);

//    //        if (arr[findi, findj] == 0)
//    //        {
//    //            arr[findi, findj] = 2;
//    //            break;
//    //        }
//    //    }
//    //    while (true)
//    //    {
//    //        int findi = rand.Next(1, 10);
//    //        int findj = rand.Next(1, 10);

//    //        if (arr[findi, findj] == 0)
//    //        {
//    //            arr[findi, findj] = 3;
//    //            break;
//    //        }
//    //    }
//    //    while (true)
//    //    {
//    //        int findi = rand.Next(1, 11);
//    //        int findj = rand.Next(1, 11);

//    //        if (arr[findi, findj] == 0 && (findi == 0 || findj == 0 || findi == 10 || findj == 10))
//    //        {
//    //            arr[findi, findj] = 4;
//    //            break;
//    //        }
//    //    }
//    //}
//    void Gen_Grid()
//    {
//        float l = 19 / Movement.speed + 1;
//        int len = (int)l;
//        Random rand = new Random();
//        int lenth = rand.Next(0, len + 1);
//        int iter = rand.Next(0, len + 1);
//        int jter = rand.Next(0, len + 1);
//        while (iter != 0 || jter != 0 || iter != 6 || jter != 6)
//        {
//            iter = rand.Next(0, len + 1);
//            jter = rand.Next(0, len + 1);
//        }
//        if (iter == 0)
//        {
//            jter = rand.Next(0, len + 1);
//            for (int i = 0; i < jter; i++)
//            {
//                Movement.mas[iter, i] = 1;
//            }
//        }
//        else if (iter == 6)
//        {
//            jter = rand.Next(0, len + 1);
//            for (int i = jter; i > 0; i--)
//            {
//                Movement.mas[iter, i] = 1;
//            }
//        }
//        else if (jter == 0)
//        {
//            iter = rand.Next(0, len + 1);
//            for (int i = 0; i < iter; i++)
//            {
//                Movement.mas[i, jter] = 1;
//            }
//        }
//        else
//        {
//            iter = rand.Next(0, len + 1);
//            for (int i = iter; i > 0; i--)
//            {
//                Movement.mas[i, jter] = 1;
//            }
//        }


//    }

   


//}