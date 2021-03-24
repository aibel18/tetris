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
			this.width = this.TetrisGame.Grid.matrix.GetLength(0);
			this.height = this.TetrisGame.Grid.matrix.GetLength(1);

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				Console.SetWindowSize(this.width, this.height);
				Console.SetBufferSize(this.width, this.height);

				Console.CursorVisible = false;
			}
			Console.Title = this.TetrisGame.Title;
		}

		public void renderUI()
		{
			Console.WriteLine("===" + this.TetrisGame.Title + "===");
		}
		public void render()
		{

			for (int j = this.height - 1; j >= 0; j--)
			{
				String lineRender = "";
				for (int i = 0; i < this.width; i++)
				{
					lineRender += this.TetrisGame.Grid.matrix[i, j];
				}
				Console.WriteLine(lineRender);
			}
			Console.WriteLine("==========");
		}
	}
}