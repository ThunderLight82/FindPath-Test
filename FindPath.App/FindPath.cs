using System;
using System.Collections.Generic;
using System.Drawing;

namespace FindPath.App;

public class FindPath
{
    private static readonly (int, int)[] StrictDirections = { (0, 1), (1, 0), (0, -1), (0, 1) };
    private static readonly (int, int)[] DiagonalDirections = { (1, 1), (1, -1), (-1, 1), (-1, -1) };

    public static Point[] FindShortestPath(int[,] arr)
    {
        int n = arr.GetLength(0);

        // Check if the array is empty
        if (n == 0 || arr.GetLength(1) == 0)
            return Array.Empty<Point>();

        var queue = new Queue<Point>();
        var visitedPoints = new bool[n, n];
        var parentPoints = new Point?[n, n];

        queue.Enqueue( new Point(0, 0));
        visitedPoints[0, 0] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.X;
            int y = current.Y;

            if (x == n - 1 && y == n - 1)
                return ReconstructPath(parentPoints, n - 1, n - 1);

            foreach (var (dx, dy) in GetValidDirections(arr, x, y))
            {
                int newPointX = x + dx;
                int newPointY = y + dy;

                if (IsWithinBound(newPointX, newPointY, n) && !visitedPoints[newPointX, newPointY])
                {
                    visitedPoints[newPointX, newPointY] = true;
                    parentPoints[newPointX, newPointY] = new Point(x, y);
                    queue.Enqueue(new Point(newPointX, newPointY));
                }
            }
        }

        // Return empty array if no path is found
        return Array.Empty<Point>();
    }

    private static Point[] ReconstructPath(Point?[,] parentPoint, int x, int y)
    {
        var path = new List<Point>();

        while (parentPoint[x, y] != null)
        {
            path.Add(new Point(x, y));

            var previous = parentPoint[x, y].Value;
            x = previous.X;
            y = previous.Y;
        }

        if (path.Count == 0 || path[^1] != new Point(0, 0))
            path.Add(new Point(0, 0));

        path.Reverse();
     
        return path.ToArray();
    }

    private static bool IsWithinBound(int x, int y, int size)
    {
        return x >= 0 && x < size && y >= 0 && y < size;
    }

    private static IEnumerable<(int, int)> GetValidDirections(int[,] arr, int x, int y)
    {
        foreach (var direction in StrictDirections)
        {
            yield return direction;
        }

        if (arr[x, y] != 0)
        {
            foreach (var diagonal in DiagonalDirections)
            {
                yield return diagonal;
            }
        }
    }
}