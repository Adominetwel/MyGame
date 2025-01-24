using System;
using System.Collections.Generic;

public class Node
{
    public int x, y;
    public int g; // ��������� ���� �� ���������� ���� �� �������� ����
    public int h; // ������������� ������ ��������� ���� �� �������� ���� �� ��������� ����
    public int f; // ����� ��������� ���� (f = g + h)
    public Node parent;
    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void CalculateF()
    {
        f = g + h; //���������� ����� ��������� ����
    }
}



public class AStar
{
    public static List<Node> FindPath(int[,] grid, Node start, Node end)
    {
        List<Node> openList = new List<Node>(); // ������ �������� �����
        List<Node> closedList = new List<Node>(); // ������ �������� �����


        openList.Add(start); // �������� ��������� ���� � openList

        while (openList.Count > 0) // �������� ���� ������ ����
        {
            Node currentNode = openList[0];
            for (int i = 1; i < openList.Count; i++) // ������� ���� � ���������� ����� ���������� f
            {
                if (openList[i].f < currentNode.f || (openList[i].f == currentNode.f && openList[i].h < currentNode.h))
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode); // ��������� ������� ���� �� openList � closedList
            closedList.Add(currentNode);

            if (currentNode.x == end.x && currentNode.y == end.y) // ���������, �������� �� ������� ���� ��������
            {
                List<Node> path = new List<Node>();
                while (currentNode != null) // ���� ��, ���������� ������ �����, �������������� ���� �� ���������� �� ��������� ����
                {
                    path.Add(currentNode);
                    currentNode = currentNode.parent;
                }
                path.Reverse(); // ���� �����������������, ������� � ��������� ����
                return path; // ���������� ��������� ����
            }

            // ��������� ������ �������� �����
            List<Node> neighbours = new List<Node>();
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue; // ���������� ������� ����
                    int newX = currentNode.x + dx;
                    int newY = currentNode.y + dy;
                    if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1))
                    {
                        neighbours.Add(new Node(newX, newY));
                    }
                }
            }

            foreach (Node neighbour in neighbours) // ��������� ������� ������
            {
                if (grid[neighbour.x, neighbour.y] == 1 || closedList.Contains(neighbour)) // ���������� ������������ ������ ��� ��, ������� ��� ���� ����������
                {
                    continue;
                }

                int cost = currentNode.g + 1; // ��������� ��������� ��������� ����
                if (!openList.Contains(neighbour) || cost < neighbour.g)
                {
                    neighbour.g = cost;
                    neighbour.h = Math.Abs(neighbour.x - end.x) + Math.Abs(neighbour.y - end.y); // ��������� ������������� ������
                    neighbour.parent = currentNode;
                    neighbour.CalculateF();

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour); // ��������� ������ � openList
                    }
                }
            }
        }

        return null; // ���� openList ����, ���� �� ������, ���������� null
    }
}