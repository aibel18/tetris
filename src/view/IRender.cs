namespace tetris
{
	public interface IRender
	{
		void setup(Game game);
		void renderUI();
		void render();
	}
}