namespace tetris
{
	public class Figure
	{
		public Vector2Int position;
		private Vector2Int[] elements;

		public char label;

		public Figure(char label)
		{
			this.label = label;
			this.position = new Vector2Int();
			this.elements = new Vector2Int[4];
		}

		public Figure(Figure figure)
		{

			this.label = figure.label;
			this.position = new Vector2Int(figure.position);
			this.elements = new Vector2Int[4];
			for (int i = 0; i < 4; i++)
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
	}
}