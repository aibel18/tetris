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

		public Game(IInputHandler inputHandler, IRender render, int dimX = 15, int dimY = 15)
		{

			// this.score = 0;
			this.Title = "My Tetris";
			this.Grid = new Grid(new Vector2Int(dimX, dimY));
			this.figures = new List<Figure>();

			this.inputHandler = inputHandler;
			this.render = render;
			this.render.setup(this);
		}

		private void load()
		{
			if (this.currentFigure == null)
				this.currentFigure = FigureController.createFigure(this.Grid.dimension.X / 2, this.Grid.dimension.Y - 1);
		}

		public void paint()
		{
			// to render currentFigure
			for (int i = 0; i < Figure.Length; i++)
			{
				this.Grid.setElement(this.currentFigure.getPosition(i), this.currentFigure.label);
			}

			// rendering
			this.render.render();

			// clean currentFigure
			for (int i = 0; i < Figure.Length; i++)
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
					this.nextFigure = FigureController.rotateInv(this.currentFigure);
					break;
				case Action.RotateCounterClockwise:
					this.nextFigure = FigureController.rotate(this.currentFigure);
					break;
				case Action.Save:
				// save game
				case Action.Exit:
					return;
				case Action.Reset:
					this.load();
					break;
				default:
					this.nextFigure = this.currentFigure;
					break;
			}
		}

		public void run()
		{
			//load game
			this.load();

			while (true)
			{
				this.paint();
				this.handlerEvent();
				this.update();
			}
		}

		public void fixFigure(Figure figure)
		{
			HashSet<int> indexRow = new HashSet<int>();

			for (int i = 0; i < Figure.Length; i++)
			{
				var p = figure.getPosition(i);

				indexRow.Add(p.Y);

				this.Grid.setElement(p, figure.label);
			}

			SortedSet<int> deleteIndexRow = new SortedSet<int>();

			// only verify specify row of the figure
			foreach (var index in indexRow)
			{
				if (this.Grid.verifyRow(index))
				{
					deleteIndexRow.Add(index);
				}
			}

			for (int i = deleteIndexRow.Count - 1; i >= 0; i--)
			{
				Grid.removeLine(i);
			}

			this.currentFigure = FigureController.createFigure(this.Grid.dimension.X / 2, this.Grid.dimension.Y - 1);
		}
	}
}