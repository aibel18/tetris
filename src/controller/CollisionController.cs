namespace tetris
{
	class CollisionController
	{
		public static bool isCollision(Grid grid, Figure figure)
		{
			var positions = new Vector2Int[4];

			// update positions
			for (int i = 0; i < figure.elements.Length; i++)
			{
				positions[i].X = figure.elements[i].X + figure.position.X;
				positions[i].Y = figure.elements[i].Y + figure.position.Y;
			}

			// verify collitions
			for (int i = 0; i < positions.Length; i++)
			{
				// with horizontal wall
				if (positions[i].X < 0 || positions[i].X > grid.dimension.X)
				{
					return true;
				}
				// with floor
				if (positions[i].Y < 0)
				{
					return true;
				}
				// with matrix's elements
				if (grid.matrix[positions[i].X, positions[i].Y])
				{
					return true;
				}
			}

			return false;
		}
	}
}