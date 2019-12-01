using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTests
    {
       
        [Fact]
        public void Should_CreateCellAtGivenPosition() {

            var cellLocation= new Point(3, 2);
            var isAlive = true;
            var cell = new Cell(cellLocation, isAlive);

            cell.IsAlive.Should().BeTrue();
            cell.CellLocation.Should().Be(cellLocation);
        }
        [Fact]
        public void Should_KillCell_WhenKillIsInvoked() 
        {
            
            var cellLocation = new Point(3,2);
            var isAlive = true;
            var cell = new Cell(cellLocation, isAlive);

            cell.Kill();

            cell.IsAlive.Should().BeFalse();
        }

        [Fact]
        public void Should_ResurrectCell_WhenResurrectIsInvoked() 
        {
            var cellLocation = new Point(3, 2);
            var isAlive = false;
            var cell = new Cell(cellLocation, isAlive);

            cell.Resurrect();

            cell.IsAlive.Should().BeTrue();
        }
        [Fact]
        public void Should_BeEqual_WhenAtSameCoordinates() 
        {
            var cellLocation = new Point(1, 1);
            var cell = new Cell(cellLocation, true);
            var cell1 = new Cell(cellLocation, false);

            cell.Should().Be(cell1);
        }

    }
}
