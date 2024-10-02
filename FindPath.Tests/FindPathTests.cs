using NUnit.Framework;
using System;
using System.Drawing;

namespace FindPath.Tests;

public class FindPathTests
{
    [Test]
    public void FindShortestPath_EmptyArray_ReturnsDirectPath()
    {
        //Arrange
        int[,] arr = new int[4, 4]
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        };

        var expectedResult = new[]
        {
            new Point(0,0),
            new Point(0,1),
            new Point(0,2),
            new Point(0,3),
            new Point(1,3),
            new Point(2,3),
            new Point(3,3)
        };

        //Act
        var actualResult = App.FindPath.FindShortestPath(arr);

        //Assert
        Assert.IsNotNull(actualResult);
        Assert.That(actualResult.Length, Is.EqualTo(expectedResult.Length));

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.That(actualResult[i], Is.EqualTo(expectedResult[i]));
        }
    }

    [Test]
    public void FindShortestPath_UniformArray_ReturnsDirectPath()
    {
        //Arrange
        int[,] arr = new int[4, 4]
        {
            {1,1,1,1},
            {1,1,1,1},
            {1,1,1,1},
            {1,1,1,1}
        };

        var expectedResult = new[]
        {
            new Point(0,0),
            new Point(1,1),
            new Point(2,2),
            new Point(3,3)
        };

        //Act
        var actualResult = App.FindPath.FindShortestPath(arr);

        //Assert
        Assert.IsNotNull(actualResult);
        Assert.That(actualResult.Length, Is.EqualTo(expectedResult.Length));

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.That(actualResult[i], Is.EqualTo(expectedResult[i]));
        }
    }

    [Test]
    public void FindShortestPath_MixedArray_ReturnsShortestPath()
    {
        //Arrange
        int[,] arr = new int[4, 4]
        {
            {0,1,0,1},
            {1,1,0,1},
            {0,0,5,1},
            {1,1,1,0}
        };

        var expectedResult = new[]
        {
            new Point(0,0),
            new Point(0,1),
            new Point(1,1),
            new Point(2,2), 
            new Point(3,3)
        };

        //Act
        var actualResult = App.FindPath.FindShortestPath(arr);

        //Assert
        Assert.IsNotNull(actualResult);
        Assert.That(actualResult.Length, Is.EqualTo(expectedResult.Length));

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.That(actualResult[i], Is.EqualTo(expectedResult[i]));
        }
    }

    [Test]
    public void FindShortestPath_EmptyArray_ReturnsEmptyPath()
    {
        // Arrange
        int[,] arr = new int[0, 0]; 

        // Act
        var result = App.FindPath.FindShortestPath(arr);

        // Assert
        Assert.AreEqual(Array.Empty<Point>(), result);
    }
}