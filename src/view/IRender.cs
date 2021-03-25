namespace tetris
{
	public interface IRender
	{
		void setup(Game game);
		void render(string line);
		void render();
	}
}