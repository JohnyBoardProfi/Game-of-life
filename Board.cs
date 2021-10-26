using System;
using System.Collections.Generic;

namespace GameOfLife
{

    public class Board
    {
        protected HashSet<Cell> _currentState = new HashSet<Cell>(), _tmpCheckedCell = new HashSet<Cell>();
        private Queue<Cell> _nextStateGiveLife = new Queue<Cell>(), _nextStateKillLife = new Queue<Cell>();
        private Cell tmpCell = new Cell();
        private int _counterMethod_GiveLifeToNeighboursIfPossible = 0;

        public int CounterMethod_GiveLifeToNeighboursIfPossible
        {
            get => _counterMethod_GiveLifeToNeighboursIfPossible;
            private set => _counterMethod_GiveLifeToNeighboursIfPossible = value;
        }

        public void AddCell(int x, int y)
        {
            tmpCell.X = x;
            tmpCell.Y = y; 
            _currentState.Add(tmpCell);
        }

        public void RemoveCell(int x, int y)
        {
            tmpCell.X = x;
            tmpCell.Y = y;
            _currentState.Remove(tmpCell);
        }

        public bool IsCellExist(int x, int y) => _currentState.Contains(new Cell() { X = x, Y = y });

        public int CountCells() => _currentState.Count;

        public void NextState()
        {
            CounterMethod_GiveLifeToNeighboursIfPossible = 0;
            int tmpNeighbours = 0;
            foreach (Cell cell in _currentState)
            {
                tmpNeighbours = CountNeighbours(cell.X, cell.Y);
                if (tmpNeighbours < 2 || tmpNeighbours > 3)
                {
                    AddCellToNextStateKillLife(cell);
                }
                GiveLifeToNeighboursIfPossible(cell.X, cell.Y);
                _tmpCheckedCell.Clear();
            }
            while (_nextStateKillLife.Count > 0)
            {
                tmpCell = _nextStateKillLife.Dequeue();
                RemoveCell(tmpCell.X, tmpCell.Y);
            }          
            while (_nextStateGiveLife.Count > 0)
            {
                tmpCell = _nextStateGiveLife.Dequeue();
                AddCell(tmpCell.X, tmpCell.Y);
            }
        }

        private void GiveLifeToNeighboursIfPossible(int x, int y)
        {
            CounterMethod_GiveLifeToNeighboursIfPossible++;         
            int tmpX = 0, tmpY = 0;            
            for (int i = 0; i < 8; i++)
            {                
                switch(i)
                {
                    case 0:
                        tmpX = x - 1;
                        tmpY = y - 1;
                        break;
                    case 1:
                        tmpX = x;
                        tmpY = y - 1;
                        break;
                    case 2:
                        tmpX = x + 1;
                        tmpY = y - 1;
                        break;
                    case 3:
                        tmpX = x - 1;
                        tmpY = y;
                        break;
                    case 4:
                        tmpX = x + 1;
                        tmpY = y;
                        break;
                    case 5:
                        tmpX = x - 1;
                        tmpY = y + 1;
                        break;
                    case 6:
                        tmpX = x;
                        tmpY = y + 1;
                        break;
                    case 7:
                        tmpX = x + 1;
                        tmpY = y + 1;
                        break;
                    default:
                        throw new Exception("Wrong variable i.");                        
                }
                if (!_tmpCheckedCell.Contains(new Cell() { X = tmpX, Y = tmpY }) && !IsCellExist(tmpX, tmpY) && CountNeighbours(tmpX, tmpY) == 3)
                { 
                    AddCellToNextStateGiveLife(new Cell() { X = tmpX, Y = tmpY });
                }
                _tmpCheckedCell.Add(new Cell() { X = tmpX, Y = tmpY });
            }
        }

        public int CountNeighbours(int x, int y)
        {
            int neighbours = 0;
            neighbours += Convert.ToInt32(IsCellExist(x - 1, y - 1));
            neighbours += Convert.ToInt32(IsCellExist(x, y - 1));
            neighbours += Convert.ToInt32(IsCellExist(x + 1, y - 1));
            neighbours += Convert.ToInt32(IsCellExist(x - 1, y));
            neighbours += Convert.ToInt32(IsCellExist(x + 1, y));
            neighbours += Convert.ToInt32(IsCellExist(x - 1, y + 1));
            neighbours += Convert.ToInt32(IsCellExist(x - 1, y + 1));
            neighbours += Convert.ToInt32(IsCellExist(x, y + 1));
            neighbours += Convert.ToInt32(IsCellExist(x + 1, y + 1));
            return neighbours;
        }
        
        private void AddCellToNextStateKillLife(Cell cell)
        {
            if (!_nextStateKillLife.Contains(new Cell() { X = cell.X, Y = cell.Y }))
            {
                _nextStateKillLife.Enqueue(cell);
            }
        }
        
        private void AddCellToNextStateGiveLife(Cell cell)
        {
            if (!_nextStateGiveLife.Contains(new Cell() { X = cell.X, Y = cell.Y }))
            {
                _nextStateGiveLife.Enqueue(cell);
            }
        }
    }
}