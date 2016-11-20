using System;

namespace Snake {
	/* 
	 * GUI class handels the consol window.
	 * 
	 * Writes to the window, define the game size.
	 */
	class GUI {
		//Set up values needed from GUI. Public read, private write. 
		public int boardW { get; private set; }
		public int boardH { get; private set; }

		//Constructor for GUI. Sets up console window with titel and start location for snake. And  saves size of Console.
		public GUI() {
			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(10,10);
			Console.Write("@");
			boardW = Console.WindowWidth;
			boardH = Console.WindowHeight;
		}

		//Get Size/areal of the GUI window.
		public int Size() {
			int size = boardW * boardH;
			return size;
		}

		//Writes inn the food ($) in the window
		public void WriteFood(Position location) {
			WriteGreen(location);
			Console.Write("$");
		}

		//Writes inn the move (new head, and overwritght prev head with body) of the snake.
		public void WriteMove(Position Location, Position newLocation) {
			WriteYellow(Location);
			Console.Write("0");
			WriteGreen(newLocation);
			Console.Write("@");
		}

		//Writes over the location with nothing/space.
		public void WriteRemove(Position location) {
			WriteGreen(location);
			Console.Write(" ");
		}

		//Private class for setting green text colour and cursoer/writing posisiton
		private void WriteGreen(Position location) {
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(location.xCord,location.yCord);
		}

		//Piravte class for setting yellow text colour, and cursoer/writing position
		private void WriteYellow(Position location) {
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(location.xCord,location.yCord);
		}

	}
}
