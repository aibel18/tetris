using System;
using System.Collections.Generic;

namespace tetris
{
	public class Game
	{
		public Grid Grid { get; set; }
		public string Title { get; set; }
		private int score;
		private bool on = true;
		private string nameFile = "tetris";

		private Figure currentFigure;
		private Figure nextFigure;
		private List<Figure> figures;

		private IInputHandler inputHandler;
		private IRender render;

		public Game(IInputHandler inputHandler, IRender render, int dimX = 15, int dimY = 17)
		{
			this.score = 0;
			this.Title = "My Tetris";
			this.Grid = new Grid(new Vector2Int(dimX, dimY));
			this.figures = new List<Figure>();

			this.inputHandler = inputHandler;
			this.render = render;
			this.render.setup(this);
		}

		private void load()
		{
			try
			{
				string[] lines = File.read(nameFile);

				this.render.render("load the game? (y/n)");
				if (this.inputHandler.confirmationInput())
				{
					this.score = int.Parse(lines[0]);
					this.Grid.init(lines);
				}
			}
			catch (System.Exception)
			{
				this.render.render("no load file");
			}

			this.currentFigure = FigureController.createFigure(this.Grid.dimension.X / 2, this.Grid.dimension.Y - 2);

			this.nextFigure = currentFigure;
		}
		private void reset()
		{
			this.score = 0;
			this.Grid.init();
			this.currentFigure = FigureController.createFigure(this.Grid.dimension.X / 2, this.Grid.dimension.Y - 2);

			this.nextFigure = currentFigure;
		}

		private void save()
		{
			string[] lines = new string[3 + this.Grid.dimension.Y];
			lines[0] = this.score.ToString();
			lines[1] = this.Grid.dimension.X.ToString();
			lines[2] = this.Grid.dimension.Y.ToString();

			for (int j = 0; j < this.Grid.dimension.Y; j++)
			{
				string line = "";
				for (int i = 0; i < this.Grid.dimension.X; i++)
				{
					line += this.Grid.matrix[j][i];
				}
				lines[j + 3] = line;
			}

			File.save(nameFile, lines);

			this.render.render("game saved!!");
		}

		public void paint()
		{
			// to render currentFigure
			for (int i = 0; i < Figure.Length; i++)
			{
				this.Grid.setElement(this.currentFigure.getPosition(i), this.currentFigure.label);
			}

			// rendering
			Console.WriteLine("==== " + this.Title + " score: " + this.score + " ====");
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
					this.save();
					this.on = false;
					return;
				case Action.Exit:
					this.on = false;
					return;
				case Action.Reset:
					this.reset();
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

			while (this.on)
			{
				this.update();
				this.paint();
				this.handlerEvent();

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

			foreach (var index in deleteIndexRow.Reverse())
			{
				Grid.removeLine(index);
				this.score++;
			}

			this.currentFigure = FigureController.createFigure(this.Grid.dimension.X / 2, this.Grid.dimension.Y - 2);
		}
	}
}