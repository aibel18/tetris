namespace tetris
{
	class FigureController
	{
		public static Figure left(Figure figure)
		{
			figure.position.X -= 1;
			return figure;
		}
		public static Figure rigth(Figure figure)
		{
			figure.position.X += 1;
			return figure;
		}
		public static Figure up(Figure figure)
		{
			figure.position.Y -= 1;
			return figure;
		}
		public static Figure down(Figure figure)
		{
			figure.position.Y += 1;
			return figure;
		}
		public static Figure rotate(Figure figure)
		{
			for (int i = 0; i < figure.elements.Length; i++)
			{
				var newX = -figure.elements[i].Y;
				var newY = figure.elements[i].X;

				figure.elements[i].X = newX;
				figure.elements[i].Y = newY;
			}
			return figure;
		}
		public static Figure rotateInv(Figure figure)
		{
			for (int i = 0; i < figure.elements.Length; i++)
			{
				var newX = figure.elements[i].Y;
				var newY = -figure.elements[i].X;

				figure.elements[i].X = newX;
				figure.elements[i].Y = newY;
			}
			return figure;
		}
	}
}