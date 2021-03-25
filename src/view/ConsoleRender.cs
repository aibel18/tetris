using System;
using System.Runtime.InteropServices;

namespace tetris
{
	class ConsoleRender : IRender
	{

		private Game TetrisGame;
		private int width;
		private int height;

		public ConsoleRender()
		{
		}

		public void setup(Game game)
		{
			this.TetrisGame = game;

			Console.Clear();
			this.height = this.TetrisGame.Grid.matrix.Count;
			this.width = this.TetrisGame.Grid.matrix[0].Length;

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				Console.SetWindowSize(this.width, this.height);
				Console.SetBufferSize(this.width, this.height);

				Console.CursorVisible = false;
			}
			Console.Title = this.TetrisGame.Title;
		}

		public void render()
		{
			Console.WriteLine("+++" + this.TetrisGame.Title + "+++");

			for (int j = this.height - 1; j >= 0; j--)
			{
				String lineRender = "+";
				for (int i = 0; i < this.width; i++)
				{
					lineRender += this.TetrisGame.Grid.matrix[j][i];
				}
				lineRender += "+";
				Console.WriteLine(lineRender);
			}
			Console.WriteLine(Letter.lineLetter('+', this.width + 2));
		}
	}
}