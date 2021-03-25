namespace tetris
{
	public class Figure
	{
		public const int Length = 4;

		public char label;
		public Vector2Int position;
		private Vector2Int[] elements;		

		public Figure(char label)
		{
			this.label = label;
			this.position = new Vector2Int();
			this.elements = new Vector2Int[Figure.Length];
		}

		public Figure(Figure figure)
		{

			this.label = figure.label;
			this.position = new Vector2Int(figure.position);
			this.elements = new Vector2Int[Figure.Length];
			for (int i = 0; i < Figure.Length; i++)
			{
				var p = figure.getElement(i);
				this.setElement(i, p.X, p.Y);
			}
		}

		public Vector2Int getPosition(int index)
		{
			return Vector2Int.sum(this.position, this.elements[index]);
		}

		public Vector2Int getElement(int index)
		{
			return elements[index];
		}

		public void setElement(int index, int X, int Y)
		{
			this.elements[index].X = X;
			this.elements[index].Y = Y;
		}

		public void setElement(int index, Vector2Int position)
		{
			this.elements[index].X = position.X;
			this.elements[index].Y = position.Y;
		}
	}
}