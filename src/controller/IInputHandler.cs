namespace tetris
{
	public interface IInputHandler
	{
		Action getInput();

		bool confirmationInput();
	}
}