namespace tetris
{
	public struct Vector2Int
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Vector2Int(int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}
		public Vector2Int(Vector2Int vector2Int)
		{
			this.X = vector2Int.X;
			this.Y = vector2Int.Y;
		}

		public static Vector2Int sum(Vector2Int v1, Vector2Int v2)
		{
			return new Vector2Int(v1.X + v2.X, v1.Y + v2.Y);
		}

	}
}