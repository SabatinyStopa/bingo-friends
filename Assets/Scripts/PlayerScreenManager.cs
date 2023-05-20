using System.Collections.Generic;
using UnityEngine;

namespace BingoFriends
{
    public class PlayerScreenManager : MonoBehaviour
    {
        [System.Serializable]
        private struct ColumnCells
        {
            public Cell[] Cells;
        }

        [SerializeField] private ColumnCells[] allColumnCells;

        private int[,] constRanges = new int[,] { { 1, 15 }, { 16, 30 }, { 31, 45 }, { 46, 60 }, { 61, 75 } };
        private const int EspcialColumnIndex = 2;

        private void Start()
        {
            foreach (ColumnCells columnCell in allColumnCells)
            {
                foreach (Cell cell in columnCell.Cells)
                {
                    cell.Reset();
                }
            }
        }

        public void GenerateNumbers()
        {
            for (int i = 0; i < 5; i++)
            {
                GenerateColumn(i);
            }
        }

        private void GenerateColumn(int columnIndex)
        {
            SetCells(columnIndex, GenerateNumbers(columnIndex));
        }

        private List<int> GenerateNumbers(int columnIndex)
        {
            var numbers = new List<int>();
            var numbersToGenerate = columnIndex == EspcialColumnIndex ? 4 : 5;

            for (int i = 0; i < numbersToGenerate; i++)
            {
                var randomNumber = Random.Range(constRanges[columnIndex, 0], constRanges[columnIndex, 1] + 1);

                while (numbers.Contains(randomNumber))
                {
                    randomNumber = Random.Range(constRanges[columnIndex, 0], constRanges[columnIndex, 1] + 1);
                }

                numbers.Add(randomNumber);
            }

            return numbers;
        }

        private void SetCells(int columnIndex, List<int> numbers)
        {
            for (int i = 0; i < allColumnCells[columnIndex].Cells.Length; i++)
            {
                var cell = allColumnCells[columnIndex].Cells[i];

                cell.Reset();
                cell.SetText(numbers[i].ToString());
            }
        }
    }
}
