using System.Numerics;

namespace tetris
{
	class Figure
	{
		public Vector2Int position { get; set; }
		public Vector2Int[] elements;

		public Figure()
		{
			this.position = new Vector2Int();
			this.elements = new Vector2Int[4];
		}
	}
}