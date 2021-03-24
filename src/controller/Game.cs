using System;
using System.Collections.Generic;

namespace tetris
{
	public class Game
	{
		private int score;
		private Grid grid;
		private Figure currentFigure;
		private List<Figure> figures;

		private IInputHandler inputHandler;
		private IRender render;

		public Game(IInputHandler inputHandler, IRender render, int dimX = 10, int dimY = 20)
		{
			this.score = 0;
			this.grid = new Grid(new Vector2Int(dimX, dimY));
			this.figures = new List<Figure>();

			this.inputHandler = inputHandler;
			this.render = render;
		}

		public void run()
		{

			//load game

			Figure nextFigure = this.currentFigure;

			while (true)
			{
				// input event
				switch (this.inputHandler.getInput())
				{
					case Action.Left:
						nextFigure = FigureController.left(this.currentFigure);
						break;
					case Action.Right:
						nextFigure = FigureController.rigth(this.currentFigure);
						break;
					case Action.RotateClockwise:
						nextFigure = FigureController.rotate(this.currentFigure);
						break;
					case Action.RotateCounterClockwise:
						nextFigure = FigureController.rotateInv(this.currentFigure);
						break;
					case Action.Save:
						break;
					case Action.NoSave:
						break;
					default:
						nextFigure = FigureController.down(this.currentFigure);
						break;
				}

				// collision
				CollisionController.isCollision(this.grid, nextFigure);

				// update

				// rendering


			}
		}
	}
}