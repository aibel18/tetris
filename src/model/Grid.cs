using System;
using System.Numerics;

namespace tetris
{
	public class Grid
	{
		public Vector2Int dimension { get; set; }

		public char[,] matrix { get; set; }

		public Grid(Vector2Int dimension)
		{
			this.dimension = dimension;
			this.matrix = new char[dimension.X, dimension.Y];

			// init matrix
			for (int i = 0; i < this.dimension.X; i++)
			{
				for (int j = 0; j < this.dimension.Y; j++)
				{
					this.matrix[i, j] = Letter.SpaceLetter;
				}
			}
		}

		public void setElement(Vector2Int position, char label)
		{
			if (position.X >= 0 && position.X < this.dimension.X && position.Y >= 0 && position.Y < this.dimension.Y)
			{
				this.matrix[position.X, position.Y] = label;
			}
		}

		public char getElement(Vector2Int position)
		{
			if (position.X >= 0 && position.X < this.dimension.X && position.Y >= 0 && position.Y < this.dimension.Y)
			{
				return this.matrix[position.X, position.Y];
			}
			return Letter.SpaceLetter;
		}

		public bool verifyLine(int index)
		{
			for (int i = 0; i < this.dimension.X; i++)
			{
				if (this.matrix[i, index] == Letter.SpaceLetter)
					return false;
			}
			return true;
		}

		public void removeLine(int index)
		{
			for (int i = 0; i < this.dimension.X; i++)
			{
				this.matrix[i, index] = Letter.SpaceLetter;
			}

			//for (int j = index + 1; j < this.dimension.Y; j++)
			// {
			// 	for (int i = 0; i < this.dimension.X; i++)
			// 	{
			// 		this.matrix[i, j - 1] = this.matrix[i, j];
			// 	}
			// }
		}

	}
}