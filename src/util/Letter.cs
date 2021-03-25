using System;

namespace tetris
{
	public class Letter
	{
		public const char SpaceLetter = ' ';
		public static char randomLetter()
		{
			return (char)((int)'A' + (new Random().Next(24)));
		}
		public static string lineLetter(char label, int size)
		{
			string line = "";
			for (int i = 0; i < size; i++)
				line += label;

			return line;
		}
	}
}