using System;
using System.Collections.Generic;

public class Node
{
    public int x, y;
    public int g; // стоимость пути от начального узла до текущего узла
    public int h; // эвристическая оценка стоимости пути от текущего узла до конечного узла
    public int f; // общая стоимость узла (f = g + h)
    public Node parent;
    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void CalculateF()
    {
        f = g + h; //вычисление общей стоимости узла
    }
}



public class AStar
{
    public static List<Node> FindPath(int[,] grid, Node start, Node end)
    {
        List<Node> openList = new List<Node>(); // список открытых узлов
        List<Node> closedList = new List<Node>(); // список закрытых узлов


        openList.Add(start); // помещаем начальный узел в openList

        while (openList.Count > 0) // основной цикл поиска пути
        {
            Node currentNode = openList[0];
            for (int i = 1; i < openList.Count; i++) // находим узел с наименьшей общей стоимостью f
            {
                if (openList[i].f < currentNode.f || (openList[i].f == currentNode.f && openList[i].h < currentNode.h))
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode); // переносим текущий узел из openList в closedList
            closedList.Add(currentNode);

            if (currentNode.x == end.x && currentNode.y == end.y) // проверяем, является ли текущий узел конечным
            {
                List<Node> path = new List<Node>();
                while (currentNode != null) // если да, возвращаем список узлов, представляющих путь от начального до конечного узла
                {
                    path.Add(currentNode);
                    currentNode = currentNode.parent;
                }
                path.Reverse(); // путь восстанавливается, начиная с конечного узла
                return path; // возвращаем найденный путь
            }

            // формируем список соседних узлов
            List<Node> neighbours = new List<Node>();
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue; // пропускаем текущий узел
                    int newX = currentNode.x + dx;
                    int newY = currentNode.y + dy;
                    if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1))
                    {
                        neighbours.Add(new Node(newX, newY));
                    }
                }
            }

            foreach (Node neighbour in neighbours) // проверяем каждого соседа
            {
                if (grid[neighbour.x, neighbour.y] == 1 || closedList.Contains(neighbour)) // пропускаем непроходимые ячейки или те, которые уже были обработаны
                {
                    continue;
                }

                int cost = currentNode.g + 1; // вычисляем временную стоимость пути
                if (!openList.Contains(neighbour) || cost < neighbour.g)
                {
                    neighbour.g = cost;
                    neighbour.h = Math.Abs(neighbour.x - end.x) + Math.Abs(neighbour.y - end.y); // вычисляем эвристическую оценку
                    neighbour.parent = currentNode;
                    neighbour.CalculateF();

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour); // добавляем соседа в openList
                    }
                }
            }
        }

        return null; // если openList пуст, путь не найден, возвращаем null
    }
}