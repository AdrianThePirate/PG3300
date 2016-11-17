using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code though! And I can now (proudly?) say that this is the uggliest short piece of code I've ever worked with! :-)
//          (And yes, it could have been a lot ugglier! But the idea wasn't to make it fuggly-uggly, just funny-uggly, sweet-uggly, or whatever you want to call it.)
//
//          -Tomas
//
namespace Snake{

	//Main Class
	class SnakeGame{
		//Main
		public static void Main(string[] arguments) {
			//Set values
			bool inUse = false;
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
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if(cki.Key == ConsoleKey.Escape)
						gameSate.SetDeath();
					else if(cki.Key == ConsoleKey.Spacebar)
						gameSate.SetPause();
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
				//Does the action
				if (!gameSate.pause) {
					// If not passed 100ms return to start of game
					if (time.ElapsedMilliseconds < 100)
						continue;
					action.Move();
					// Restes stopwatch
					time.Restart();
					
				}
			}
		}
	}
}