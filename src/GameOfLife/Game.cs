using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class Game
    {
        public Game(int rows, int columns, List<Point> initialLiveCellPositions)
        {
            Rows = rows;
            Columns = columns;
            CurrentState = new List<Cell>();
            InitCells(initialLiveCellPositions);
        }

        private void InitCells(List<Point> initialLiveCellPositions)
        {
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Columns; j++) 
                {
                    var location = new Point(j, i);
                    var isAlive = initialLiveCellPositions.Contains(location);
                    CurrentState.Add(new Cell(location, isAlive));
                }
            }
        }

        public int Rows { get; }

        public void SetInitialState(List<Point> initSate)
        {
            
        }

        public int Columns { get; }
        public List<Cell> CurrentState { get; private set; }
        public int Generation { get; private set; }

        public void MoveToNextGeneration()
        {
            var nextState = new List<Cell>();
            foreach (var cell in CurrentState) 
            {
                int liveNeighbours = GetLiveNeighoursCount(cell);
                bool isAlive = cell.IsAlive?((liveNeighbours==2||liveNeighbours==3)||!(liveNeighbours>3)) : liveNeighbours==3;
                nextState.Add(new Cell(cell.CellLocation, isAlive));
                
            }
            CurrentState = nextState;
            Generation++;
        }

        private int GetLiveNeighoursCount(Cell cell)
        {
            var neighbours = CurrentState
                .Where(c=>c.CellLocation.X >= cell.CellLocation.X-1 
                && c.CellLocation.X <= cell.CellLocation.X + 1
                && c.CellLocation.Y>= cell.CellLocation.Y-1
                && c.CellLocation.Y<= cell.CellLocation.Y+1
                && c.CellLocation!=cell.CellLocation
                && c.IsAlive);

            return neighbours.Count();
        }
    }
}
