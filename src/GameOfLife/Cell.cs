using System;
using System.Drawing;

namespace GameOfLife
{
    public class Cell
    {
        public Cell(Point cellLocation, bool isAlive)
        {
            CellLocation = cellLocation;
            IsAlive = isAlive;
        }

        
        public Point CellLocation { get; }
        public bool IsAlive { get; private set; }

        public void Kill()
        {
            this.IsAlive = false;
        }

        public void Resurrect()
        {
            this.IsAlive = true;
        }
        public override bool Equals(object obj)
        {
            var cell = obj as Cell;
            return cell.CellLocation == CellLocation; 
                
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
