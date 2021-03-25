using System;
using System.Collections.Generic;

namespace tetris
{
	public class Game
	{
		public Grid Grid { get; set; }
		public string Title { get; set; }
		// private int score;

		private Figure currentFigure;
		private Figure nextFigure;
		private List<Figure> figures;

		private IInputHandler inputHandler;
		private IRender render;

		public Game(IInputHandler inputHandler, IRender render, int dimX = 13, int dimY = 13)
		{

			// this.score = 0;
			this.Title = "My Tetris";
			this.Grid = new Grid(new Vector2Int(dimX, dimY));
			this.figures = new List<Figure>();

			this.inputHandler = inputHandler;
			this.render = render;
			this.render.setup(this);
		}

		private void createFigure()
		{
			// update Figure
			// if (this.currentFigure == null)
			{
				this.currentFigure = new Figure(Letter.randomLetter());
				this.currentFigure.position.X = this.Grid.dimension.X / 2;
				this.currentFigure.position.Y = this.Grid.dimension.Y - 1;

				this.currentFigure.setElement(0, 0, -2);
				this.currentFigure.setElement(1, 0, -1);
				this.currentFigure.setElement(2, 0, 0);
				this.currentFigure.setElement(3, 0, 1);

				this.nextFigure = this.currentFigure;
			}
		}

		public void paint()
		{
			// to render currentFigure
			for (int i = 0; i < 4; i++)
			{
				this.Grid.setElement(this.currentFigure.getPosition(i), this.currentFigure.label);
			}

			// render ui
			this.render.renderUI();
			// rendering
			this.render.render();

			// remove currentFigure
			for (int i = 0; i < 4; i++)
			{
				this.Grid.setElement(this.currentFigure.getPosition(i), Letter.SpaceLetter);
			}
		}

		public void update()
		{
			// collision
			if (CollisionController.isCollision(this.Grid, this.nextFigure))
			{
				this.nextFigure = this.currentFigure;
			}

			this.currentFigure = this.nextFigure;

			this.nextFigure = FigureController.down(this.nextFigure);

			if (CollisionController.isCollision(this.Grid, this.nextFigure))
			{
				this.fixFigure(this.currentFigure);
				return;
			}

			this.currentFigure = this.nextFigure;

		}

		public void handlerEvent()
		{
			// input event
			switch (this.inputHandler.getInput())
			{
				case Action.Left:
					this.nextFigure = FigureController.left(this.currentFigure);
					break;
				case Action.Right:
					this.nextFigure = FigureController.rigth(this.currentFigure);
					break;
				case Action.RotateClockwise:
					this.nextFigure = FigureController.rotate(this.currentFigure);
					break;
				case Action.RotateCounterClockwise:
					this.nextFigure = FigureController.rotateInv(this.currentFigure);
					break;
				case Action.Save:
				// save game
				case Action.Exit:
					return;
				case Action.Reset:
					this.createFigure();
					break;
				default:
					// this.nextFigure = FigureController.down(this.currentFigure);
					this.nextFigure = this.currentFigure;
					break;
			}
		}

		public void run()
		{
			//load game
			this.createFigure();

			while (true)
			{
				this.paint();
				this.handlerEvent();
				this.update();
			}
		}

		public void fixFigure(Figure figure)
		{
			HashSet<int> indexLine = new HashSet<int>();

			for (int i = 0; i < 4; i++)
			{
				var p = figure.getPosition(i);

				indexLine.Add(p.Y);

				this.Grid.setElement(p, figure.label);
			}

			foreach (var index in indexLine)
			{
				if (this.Grid.verifyLine(index))
				{
					this.Grid.removeLine(index);
				}
			}
			this.createFigure();
		}

		public void verifyLine()
		{
		}
	}
}