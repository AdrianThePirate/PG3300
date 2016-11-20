using System;

namespace Snake {
	class InputHandler { 
		
		public static void TestInput() {
			var gameState = Factory.CreateGameState();
			var action = Factory.CreateAction();

			ConsoleKeyInfo cki = Console.ReadKey(true);
			if(cki.Key == ConsoleKey.Escape)
				gameState.SetDeath();
			else if(cki.Key == ConsoleKey.Spacebar)
				gameState.SetPause();
			//Directions values 0 = up, 1 = right, 2 = down, 3 = left
			else if(cki.Key == ConsoleKey.UpArrow)
				action.ChangeDirection(Action.direction.Up);
			else if(cki.Key == ConsoleKey.RightArrow)
				action.ChangeDirection(Action.direction.Right);
			else if(cki.Key == ConsoleKey.DownArrow)
				action.ChangeDirection(Action.direction.Down);
			else if(cki.Key == ConsoleKey.LeftArrow)
				action.ChangeDirection(Action.direction.Left);
		}
	}
}
