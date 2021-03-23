using System;
using System.Runtime.InteropServices;

namespace tetris
{
	class MyConsole
	{

		private static int WIDTH = 300;
		private static int HEIGHT = 300;

		public static void setupConsole()
		{
			Console.Clear();
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				Console.SetWindowSize(300, WIDTH + 1);
				Console.SetBufferSize(300, HEIGHT + 1);

				Console.CursorVisible = false;
			}
			Console.Title = "Tetris";
			// Console.ReadKey(true);
		}
	}
}