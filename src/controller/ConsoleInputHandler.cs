using System;

namespace tetris
{
	public class ConsoleInputHandler : IInputHandler
	{
		public Action getInput()
		{
			var key = Console.ReadKey().Key;

			switch (key)
			{
				case ConsoleKey.Escape:
					return Action.Exit;
				case ConsoleKey.S:
					return Action.Save;
				case ConsoleKey.LeftArrow:
					return Action.Left;
				case ConsoleKey.RightArrow:
					return Action.Right;
				case ConsoleKey.DownArrow:
					return Action.RotateClockwise;
				case ConsoleKey.UpArrow:
					return Action.RotateCounterClockwise;
				default:
					return Action.NoAction;
			}
		}
	}
}