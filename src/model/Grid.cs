using System.Numerics;

namespace tetris
{
	class Grid
	{
		public Vector2Int dimension { get; set; }

		public bool[,] matrix { get; set; }

		public Grid(Vector2Int dimension)
		{
			this.dimension = dimension;
			this.matrix = new bool[dimension.X, dimension.Y];
		}

	}
}