using System;

namespace tetris
{
	class FigureController
	{

		public static Figure createFigure(int x, int y)
		{
			Figure newFigure = new Figure(Letter.randomLetter());
			newFigure.position.X = x;
			newFigure.position.Y = y;

			var type = FigureType.elements[new Random().Next(FigureType.elements.Length)];

			for (int i = 0; i < type.Length; i++)
			{
				newFigure.setElement(i, type[i].X, type[i].Y);
			}

			return newFigure;
		}

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
			for (int i = 0; i < Figure.Length; i++)
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
			for (int i = 0; i < Figure.Length; i++)
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