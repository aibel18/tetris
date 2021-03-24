namespace tetris
{
	class Program
	{
		static void Main(string[] args)
		{

			ConsoleRender.setupConsole();

			var game = new Game();
			game.run();

		}
	}
}
