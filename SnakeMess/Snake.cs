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
	class Snake{
		//Main
		public static void Main(string[] arguments)
		{
			//Set values
			bool gg = false, pause = false, inUse = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
			int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
			Random rng = new Random();
			Position app = new Position();
			//Creats list of point (posistions)
			List<Position> snake = new List<Position>();
			snake.Add(new Position(10, 10)); snake.Add(new Position(10, 10)); snake.Add(new Position(10, 10)); snake.Add(new Position(10, 10)); //add to list Snake
			//GUI fuck
			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(10, 10); Console.Write("@");

			//Creates food
			while (true) {
				app.XCord = rng.Next(0, boardW); app.YCord = rng.Next(0, boardH);
				bool spot = true;
				//Test if food loc is not loced on snake
				foreach (Position i in snake)
					if (i.XCord == app.XCord && i.YCord == app.YCord) {
						spot = false;
						break;
					}
				//Prints food, if not loced on snake
				if (spot) {
					Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.XCord, app.YCord); Console.Write("$");
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
					Position tail = new Position(snake.First());
					Position head = new Position(snake.Last());
					Position newH = new Position(head);

					//Cheack direction and moves newH accordingly. Directions values 0 = up, 1 = right, 2 = down, 3 = left
					switch(newDir) {
						case 0:
							newH.YCord -= 1;
							break;
						case 1:
							newH.XCord += 1;
							break;
						case 2:
							newH.YCord += 1;
							break;
						default:
							newH.XCord -= 1;
							break;
					}
					//Cheack if newH is located outside the game area
					if (newH.XCord < 0 || newH.XCord >= boardW)
						gg = true;
					else if (newH.YCord < 0 || newH.YCord >= boardH)
						gg = true;
					//Test is newH is on the food
					if (newH.XCord == app.XCord && newH.YCord == app.YCord) {
						//Cheacks if there is room for food
						if (snake.Count + 1 >= boardW * boardH)
							// No more room to place apples - game over.
							gg = true;
						else {
							//Creates new food
							while (true) {
								app.XCord = rng.Next(0, boardW); app.YCord = rng.Next(0, boardH);
								bool found = true;
								//Tests if food is on snake
								foreach (Position i in snake)
									if (i.XCord == app.XCord && i.YCord == app.YCord) {
										found = false;
										break;
									}
								//If new food is added stets inUse = true and breks teh creat food
								if (found) {
									inUse = true;
									break;
								}
							}
						}
					}

					//If new food is not added tests if self-cannibalism.
					if (!inUse) {
						//Removes the back of the snek
						snake.RemoveAt(0);
						foreach (Position x in snake)
							if (x.XCord == newH.XCord && x.YCord == newH.YCord) {
								// Death by accidental self-cannibalism.
								gg = true;
								break;
							}
					}

					//Updated GUI
					if (!gg) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						//Overides old head with body part
						Console.SetCursorPosition(head.XCord, head.YCord); Console.Write("0");
						//Test if not added new food
						if (!inUse) {
							//Remove the back of snek
							Console.SetCursorPosition(tail.XCord, tail.YCord); Console.Write(" ");
						} else {
							//Prints new food
							Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.XCord, app.YCord); Console.Write("$");
							inUse = false;
						}
						//adds newH to the snake list
						snake.Add(newH);
						//Prints new head
						Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newH.XCord, newH.YCord); Console.Write("@");
						//Sets last (controller for last usde direction command) to the newest used direction.
						last = newDir;
					}
				}
			}
		}
	}
}