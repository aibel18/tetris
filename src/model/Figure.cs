namespace tetris
{
	public class Figure
	{
		public Vector2Int position;
		public Vector2Int[] elements;
		public char label;

		public Figure(char label)
		{
			this.label = label;
			this.position = new Vector2Int();
			this.elements = new Vector2Int[4];
		}
	}
}