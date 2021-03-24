namespace tetris
{
	class Program
	{
		static void Main(string[] args)
		{
			var game = new Game(new ConsoleInputHandler(), new ConsoleRender());
			game.run();
		}
	}
}
