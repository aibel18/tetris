using System;
using System.Collections.Generic;

namespace tetris
{
	public class Grid
	{
		public Vector2Int dimension { get; set; }

		public List<char[]> matrix { get; set; }

		public Grid(Vector2Int dimension)
		{
			this.dimension = dimension;
			this.matrix = new List<char[]>();

			// init matrix
			for (int j = 0; j < this.dimension.Y; j++)
			{
				char[] row = new char[this.dimension.X];

				for (int i = 0; i < this.dimension.X; i++)
				{
					row[i] = Letter.SpaceLetter;
				}
				this.matrix.Add(row);
			}
		}

		public void setElement(Vector2Int position, char label)
		{
			if (position.X >= 0 && position.X < this.dimension.X && position.Y >= 0 && position.Y < this.dimension.Y)
			{
				this.matrix[position.Y][position.X] = label;
			}
		}

		public char getElement(Vector2Int position)
		{
			if (position.X >= 0 && position.X < this.dimension.X && position.Y >= 0 && position.Y < this.dimension.Y)
			{
				return this.matrix[position.Y][position.X];
			}
			return Letter.SpaceLetter;
		}

		public bool verifyRow(int index)
		{
			var row = this.matrix[index];

			for (int i = 0; i < this.dimension.X; i++)
			{
				if (row[i] == Letter.SpaceLetter)
					return false;
			}
			return true;
		}

		public void removeLine(int index)
		{
			char[] row = new char[this.dimension.X];
			for (int i = 0; i < this.dimension.X; i++)
			{
				row[i] = Letter.SpaceLetter;
			}
			this.matrix.RemoveAt(index);
			this.matrix.Add(row);
		}

	}
}