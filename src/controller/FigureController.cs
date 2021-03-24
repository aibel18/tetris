namespace tetris
{
	class FigureController
	{
		public static Figure left(Figure figure)
		{
			Figure newFigure = new Figure(figure);
			newFigure.position.X -= 1;
			return newFigure;
		}
		public static Figure rigth(Figure figure)
		{

			Figure newFigure = new Figure(figure);
			newFigure.position.X += 1;
			return newFigure;
		}
		public static Figure up(Figure figure)
		{
			Figure newFigure = new Figure(figure);
			newFigure.position.Y += 1;
			return newFigure;
		}
		public static Figure down(Figure figure)
		{
			Figure newFigure = new Figure(figure);
			newFigure.position.Y -= 1;
			return newFigure;
		}
		public static Figure rotate(Figure figure)
		{
			Figure newFigure = new Figure(figure);
			for (int i = 0; i < 4; i++)
			{
				var p = newFigure.getElement(i);
				var newX = -p.Y;
				var newY = p.X;

				newFigure.setElement(i, newX, newY);
			}
			return newFigure;
		}
		public static Figure rotateInv(Figure figure)
		{
			Figure newFigure = new Figure(figure);
			for (int i = 0; i < 4; i++)
			{
				var p = newFigure.getElement(i);
				var newX = p.Y;
				var newY = -p.X;

				newFigure.setElement(i, newX, newY);
			}
			return newFigure;
		}
	}
}