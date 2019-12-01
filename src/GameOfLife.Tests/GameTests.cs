using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        [Fact]
        public void Should_CreateGame_WithRowsXColumnsCells()
        {
            int rows = 10;
            int columns = 10;

            var game = new Game(rows, columns, new List<Point>());

            game.Columns.Should().Be(columns);
            game.Rows.Should().Be(rows);

            game.CurrentState.Count.Should().Be(rows*columns);

            game.Generation.Should().Be(0);

        }

        [Fact]
        public void Should_InitGame_WithGivenLiveCells() 
        {
            var initState = new List<Point>() 
            {
                new Point(1,1)
            };
            var game = new Game(3, 3, initState);       

           
            foreach (var item in initState) 
            {
                var cell = game.CurrentState
                    .FirstOrDefault(c=>c.CellLocation== item && c.IsAlive);
                cell.Should().NotBeNull();
                
            }
        }

        [Fact]
        public void Should_MoveToNextGeneration() 
        {
            var initState = new List<Point>()
            {
                new Point(1,1), new Point(1,2),new Point(2,2)
            };
            var game = new Game(3, 3, initState);

            var expectedLivePositions = new List<Point>()
            {
                new Point(1,1), new Point(1,2),new Point(2,1), new Point(2,2)
            };

            game.MoveToNextGeneration();

            game.Generation.Should().Be(1);

            var liveCells = game.CurrentState.Where(c => c.IsAlive);
            liveCells.Count().Should().Be(4);

            foreach (var cell in liveCells) 
            {
                expectedLivePositions.Should().Contain(cell.CellLocation);
            }



        }
    }
}
