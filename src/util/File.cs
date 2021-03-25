using System.IO;

namespace tetris
{
	public class File
	{
		public static void save(string fileName, string[] lines)
		{
			using (TextWriter tw = new StreamWriter(fileName))
			{
				for (int j = 0; j < lines.Length; j++)
				{
					tw.WriteLine(lines[j]);
				}
			}
		}

		public static string[] read(string fileName)
		{
			string[] lines = System.IO.File.ReadAllLines(fileName);

			return lines;
		}
	}
}