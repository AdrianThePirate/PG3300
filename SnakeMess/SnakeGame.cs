using System;
using System.Diagnostics;

namespace Snake{

	/*
	 * Snake Game is the main class of the game. It boots up the game and activates action with eatch game tick (100ms).
	 * 
	 * It also startes TestInput when needed.
	 */
	class SnakeGame{
		//Main, fist class to start last to close
		public static void Main(string[] arguments) {
			//Set values
			GameState gameSate = Factory.CreateGameState();
			Action action = Factory.CreateAction();

			//Creates and starts stopwatch
			Stopwatch time = Factory.CreateStopwatch();
			time.Start();

			// ----The game startes here-----
			while (!gameSate.death) {
				//Looks of key input (if any)
				if (Console.KeyAvailable) {
					InputHandler.TestInput();
				}
				//Test if not pasued
				if (!gameSate.pause) {
					// If not passed 100ms (1 tick) return to start of game, esle run one action.
					if (time.ElapsedMilliseconds >= 100) {
						action.Move();
						time.Restart();
					}
				}
			}
		}
	}
}