using System;
using System.Diagnostics;

namespace Snake{

	//Main Class
	class SnakeGame{
		//Main
		public static void Main(string[] arguments) {
			//Set values
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
			Food food = Factory.CreateFood();
			GUI GUI = Factory.CreateGUI();
			GameState gameSate = Factory.CreateGameState();
			Action action = Factory.CreateAction();
			//Creats list of point (posistions)
			Snake snake = Factory.CreateSnake();


			//Creates and starts stopwatch
			Stopwatch time = Factory.CreateStopwatch();
			time.Start();

			// ----The game startes here-----
			while (!gameSate.death) {
				//Looks of key input (if any)
				if (Console.KeyAvailable) {
					InputHandler.TestInput();
				}
				//Does the action
				if (!gameSate.pause) {
					// If not passed 100ms return to start of game
					if (time.ElapsedMilliseconds >= 100) {
						action.Move();
						time.Restart();
					}
				}
			}
		}
	}
}