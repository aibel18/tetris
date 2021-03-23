using System;
using System.Collections.Generic;

namespace tetris
{
	class Game
	{
		private int score;
		private Grid grid;
		private List<Figure> figures;

		public Game(int dimX = 10, int dimY = 20)
		{
			this.score = 0;
			this.grid = new Grid(new Vector2Int(dimX, dimY));
			this.figures = new List<Figure>();
		}

		public void run()
		{
			foreach (var item in grid.matrix)
			{
					Console.WriteLine(item);
			}
			// var date = DateTime.Now;
			// Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {date:d} at {date:t}!");
		}
	}
}