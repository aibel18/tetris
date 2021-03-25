using System;
using System.Collections.Generic;

namespace tetris
{
	public class Grid
	{
		public Vector2Int dimension;
		public Vector2Int Dimension { get; set; }

		public List<char[]> matrix { get; set; }

		public Grid(Vector2Int dimension)
		{
			this.dimension = dimension;
			this.matrix = new List<char[]>();

			this.init();
		}

		public void init()
		{
			// init matrix
			this.matrix.Clear();

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

		public void init(string[] lines)
		{

			this.dimension.X = int.Parse(lines[1]);
			this.dimension.Y = int.Parse(lines[2]);

			for (int j = 3; j < lines.Length; j++)
			{
				var line = lines[j];
				for (int i = 0; i < line.Length; i++)
				{
					this.matrix[j - 3][i] = line[i];
				}
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