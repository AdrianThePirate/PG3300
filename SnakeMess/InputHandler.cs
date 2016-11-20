using System;

namespace Snake {
	/*
	 * InputHandler cheacks the input, and updated relevent object.
	 */ 
	class InputHandler { 
		
		//Test input and do needed action.
		public static void TestInput() {
			//Aks for needed objects
			var gameState = Factory.CreateGameState();
			var action = Factory.CreateAction();

			//gets and test input and makes a desicion based on it.
			ConsoleKeyInfo cki = Console.ReadKey(true);
			if(cki.Key == ConsoleKey.Escape)
				gameState.SetDeath();
			else if(cki.Key == ConsoleKey.Spacebar)
				gameState.SetPause();
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
