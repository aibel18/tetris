namespace tetris
{
	public class FigureType
	{

		public static Vector2Int[][] elements = new Vector2Int[7][]{

			new Vector2Int[]{
				new Vector2Int(0, 2),		//			(0, 2)
				new Vector2Int(0, 1),		//			(0, 1)
				new Vector2Int(0, 0),		//			(0, 0)
				new Vector2Int(0,-1)			//		(0,-1)
			},

			new Vector2Int[]{
				new Vector2Int(1,1),		//			(0, 1) (1, 1)
				new Vector2Int(0,1),		//			(0, 0)
				new Vector2Int(0,0),		//			(0,-1)
				new Vector2Int(0,-1)		//
			},
			new Vector2Int[]{
				new Vector2Int(-1,1),		//			(-1, 1) (1, 1)
				new Vector2Int(0,1),		//							(0, 0)
				new Vector2Int(0,0),		//							(0,-1)
				new Vector2Int(0,-1)		//
			},
			new Vector2Int[]{
				new Vector2Int(1,1),		//							(1, 1)
				new Vector2Int(1,0),		//			(0, 0)	(1, 0) 
				new Vector2Int(0,0),		//			(0,-1)
				new Vector2Int(0,-1)		//
			},
			new Vector2Int[]{
				new Vector2Int(-1,1),		//			(-1, 1) 
				new Vector2Int(-1,0),		//			(-1, 0)	(0, 0)
				new Vector2Int(0,0),		//							(0,-1)
				new Vector2Int(0,-1)		//
			},
			new Vector2Int[]{
				new Vector2Int(0,1),		//			(0, 1)
				new Vector2Int(1,0),		//			(0, 0) (1, 0)
				new Vector2Int(0,0),		//			(0,-1)
				new Vector2Int(0,-1)		//
			},
			new Vector2Int[]{
				new Vector2Int(1,1),		//			(0, 1) (1, 1)
				new Vector2Int(0,1),		//			(0, 0) (1, 0)
				new Vector2Int(1,0),		//			
				new Vector2Int(0,0)			//
			}
		};
	}
}