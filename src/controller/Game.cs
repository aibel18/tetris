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

		public Game(IInputHandler inputHandler, IRender render, int dimX = 10, int dimY = 10)
		{

			// this.score = 0;
			this.Title = "My Tetris";
			this.Grid = new Grid(new Vector2Int(dimX, dimY));
			this.figures = new List<Figure>();

			this.inputHandler = inputHandler;
			this.render = render;
			this.render.setup(this);
		}

		private void reset()
		{
			// update Figure
			// if (this.currentFigure == null)
			{
				this.currentFigure = new Figure('A');
				this.currentFigure.position.X = this.Grid.dimension.X / 2;
				this.currentFigure.position.Y = this.Grid.dimension.Y - 2;

				this.currentFigure.setElement(0, 0, -1);
				this.currentFigure.setElement(1, 0, 0);
				this.currentFigure.setElement(2, 0, 1);
				this.currentFigure.setElement(3, 0, 2);

				for (int i = 0; i < 4; i++)
				{
					this.Grid.setElement(this.currentFigure.getPosition(i), this.currentFigure.label);
				}

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
				this.Grid.setElement(this.currentFigure.getPosition(i), ' ');
			}
		}

		public void update()
		{
			// collision
			if (CollisionController.isCollision(this.Grid, this.nextFigure))
			{
				this.nextFigure = this.currentFigure;
				Console.WriteLine("entor collision");
			}

			this.currentFigure = this.nextFigure;

			this.nextFigure = FigureController.down(this.nextFigure);
			if (CollisionController.isCollision(this.Grid, this.nextFigure))
			{
				this.nextFigure = this.currentFigure;
				Console.WriteLine("entor collision2");
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
					this.reset();
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
			this.reset();

			while (true)
			{
				this.paint();
				this.handlerEvent();
				this.update();
			}
		}


	}
}