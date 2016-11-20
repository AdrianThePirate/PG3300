using System;

namespace Snake {
	class GUI {
		public int boardW { get; private set; }
		public int boardH { get; private set; }

		public GUI() {
			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(10,10);
			Console.Write("@");
			boardW = Console.WindowWidth;
			boardH = Console.WindowHeight;
		}

		public int Size() {
			int size = boardW * boardH;
			return size;
		}

		public void WriteFood(Position location) {
			WriteGreen(location);
			Console.Write("$");
		}

		public void WriteMove(Position Location, Position newLocation) {
			WriteYellow(Location);
			Console.Write("0");
			WriteGreen(newLocation);
			Console.Write("@");
		}

		public void WriteRemove(Position location) {
			WriteGreen(location);
			Console.Write(" ");
		}

		private void WriteGreen(Position location) {
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(location.xCord,location.yCord);
		}

		private void WriteYellow(Position location) {
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(location.xCord,location.yCord);
		}

	}
}
