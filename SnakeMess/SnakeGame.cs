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
			bool gg = false, pause = false, inUse = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
			int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
			Random rng = new Random();
			Position app = Factory.CreatePosition();
			//Creats list of point (posistions)
			Snake snake = Factory.CreateSnake();
			//GUI fuck
			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(10, 10); Console.Write("@");

			//Creates food
			while (true) {
				app.xCord = rng.Next(0, boardW); app.yCord = rng.Next(0, boardH);
				bool spot = snake.CollisionCheck(app.xCord,app.yCord);

				//Prints food, if not loced on snake
				if (!spot) {
					Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.xCord, app.yCord); Console.Write("$");
					break;
				}
			}


			//Creates and starts stopwatch
			Stopwatch t = new Stopwatch();
			t.Start();

			// ----The game startes here-----
			while (!gg) {
				//Looks of key input (if any)
				if (Console.KeyAvailable) {
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						gg = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						pause = !pause;
					//Directions values 0 = up, 1 = right, 2 = down, 3 = left
					else if (cki.Key == ConsoleKey.UpArrow && last != 2)
						newDir = 0;
					else if (cki.Key == ConsoleKey.RightArrow && last != 3)
						newDir = 1;
					else if (cki.Key == ConsoleKey.DownArrow && last != 0)
						newDir = 2;
					else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
						newDir = 3;
				}

				//Does the action
				if (!pause) {
					// If not passed 100ms return to start of game
					if (t.ElapsedMilliseconds < 100)
						continue;

					// Restes stopwatch
					t.Restart();
					//Creates objects of point (posistion) basde in snakes posstiosn
					Position tail = Factory.CreatePosition(location: snake.First());
					Position head = Factory.CreatePosition(location: snake.Last());
					Position newH = Factory.CreatePosition(location: head);

					//Cheack direction and moves newH accordingly. Directions values 0 = up, 1 = right, 2 = down, 3 = left
					switch(newDir) {
						case 0:
							newH.yCord -= 1;
							break;
						case 1:
							newH.xCord += 1;
							break;
						case 2:
							newH.yCord += 1;
							break;
						default:
							newH.xCord -= 1;
							break;
					}
					//Cheack if newH is located outside the game area
					if (newH.yCord < 0 || newH.xCord >= boardW)
						gg = true;
					else if (newH.xCord < 0 || newH.yCord >= boardH)
						gg = true;
					//Test is newH is on the food
					if (newH.xCord == app.xCord && newH.yCord == app.yCord) {
						//Cheacks if there is room for food
						if (snake.Size() + 1 >= boardW * boardH)
							// No more room to place apples - game over.
							gg = true;
						else {
							//Creates new food
							while (true) {
								app.xCord = rng.Next(0, boardW); app.yCord = rng.Next(0, boardH);
								bool found = snake.CollisionCheck(app.xCord, app.yCord);
								//If new food is added stets inUse = true and breks teh creat food
								if (!found) {
									inUse = true;
									break;
								}
							}
						}
					}

					//If new food is not added tests if self-cannibalism.
					if (!inUse) {
						//Removes the back of the snek
						snake.RemoveEnd();
						if(snake.CollisionCheck(newH.xCord, newH.yCord)) {
							gg = true;
						}
					}

					//Updated GUI
					if (!gg) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						//Overides old head with body part
						Console.SetCursorPosition(head.xCord, head.yCord); Console.Write("0");
						//Test if not added new food
						if (!inUse) {
							//Remove the back of snek
							Console.SetCursorPosition(tail.xCord, tail.yCord); Console.Write(" ");
						} else {
							//Prints new food
							Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.xCord, app.yCord); Console.Write("$");
							inUse = false;
						}
						//adds newH to the snake list
						snake.Add(newH);
						//Prints new head
						Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newH.xCord, newH.yCord); Console.Write("@");
						//Sets last (controller for last usde direction command) to the newest used direction.
						last = newDir;
					}
				}
			}
		}
	}
}