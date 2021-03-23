namespace tetris
{
	public struct Vector2Int
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Vector2Int(int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}

	}
}