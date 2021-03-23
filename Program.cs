namespace tetris
{
	class Program
	{
		static void Main(string[] args)
		{

			MyConsole.setupConsole();

			var game = new Game();
			game.run();

		}
	}
}
