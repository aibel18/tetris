using System;

namespace tetris
{
	class CollisionController
	{
		public static bool isCollision(Grid grid, Figure figure)
		{

			// verify collitions
			for (int i = 0; i < 4; i++)
			{
				// with horizontal wall
				var p = figure.getPosition(i);
				if (p.X < 0 || p.X >= grid.dimension.X)
				{
					return true;
				}
				// with floor
				if (p.Y < 0)
				{
					return true;
				}
				// with matrix's elements
				if (grid.getElement(p) != ' ')
				{
					return true;
				}
			}

			return false;
		}
	}
}