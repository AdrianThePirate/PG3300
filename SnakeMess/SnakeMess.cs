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
namespace SnakeMess
{
	// Class point, keeps two posistion values.
	class Point
	{
		//Does nothing...
		public const string Ok = "Ok";

		//Defin values
		public int X; public int Y;
		
		//Constructer of point (poistion)
		public Point(int x = 0, int y = 0) { X = x; Y = y; }

		//Constructer of point by point
		public Point(Point input) { X = input.X; Y = input.Y; }
	}

	//Main Class
	class SnakeMess
	{
		//Main
		public static void Main(string[] arguments)
		{
			//Set values
			bool gg = false, pause = false, inUse = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
			int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
			Random rng = new Random();
			Point app = new Point();
			//Creats list of point (posistions)
			List<Point> snake = new List<Point>();
			snake.Add(new Point(10, 10)); snake.Add(new Point(10, 10)); snake.Add(new Point(10, 10)); snake.Add(new Point(10, 10)); //add to list Snake
			//GUI fuck
			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(10, 10); Console.Write("@");

			//Creates food
			while (true) {
				app.X = rng.Next(0, boardW); app.Y = rng.Next(0, boardH);
				bool spot = true;
				//Test if food loc is not loced on snake
				foreach (Point i in snake)
					if (i.X == app.X && i.Y == app.Y) {
						spot = false;
						break;
					}
				//Prints food, if not loced on snake
				if (spot) {
					Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.X, app.Y); Console.Write("$");
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
					Point tail = new Point(snake.First());
					Point head = new Point(snake.Last());
					Point newH = new Point(head);

					//Cheack direction and moves newH accordingly. Directions values 0 = up, 1 = right, 2 = down, 3 = left
					switch(newDir) {
						case 0:
							newH.Y -= 1;
							break;
						case 1:
							newH.X += 1;
							break;
						case 2:
							newH.Y += 1;
							break;
						default:
							newH.X -= 1;
							break;
					}
					//Cheack if newH is located outside the game area
					if (newH.X < 0 || newH.X >= boardW)
						gg = true;
					else if (newH.Y < 0 || newH.Y >= boardH)
						gg = true;
					//Test is newH is on the food
					if (newH.X == app.X && newH.Y == app.Y) {
						//Cheacks if there is room for food
						if (snake.Count + 1 >= boardW * boardH)
							// No more room to place apples - game over.
							gg = true;
						else {
							//Creates new food
							while (true) {
								app.X = rng.Next(0, boardW); app.Y = rng.Next(0, boardH);
								bool found = true;
								//Tests if food is on snake
								foreach (Point i in snake)
									if (i.X == app.X && i.Y == app.Y) {
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
						foreach (Point x in snake)
							if (x.X == newH.X && x.Y == newH.Y) {
								// Death by accidental self-cannibalism.
								gg = true;
								break;
							}
					}

					//Updated GUI
					if (!gg) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						//Overides old head with body part
						Console.SetCursorPosition(head.X, head.Y); Console.Write("0");
						//Test if not added new food
						if (!inUse) {
							//Remove the back of snek
							Console.SetCursorPosition(tail.X, tail.Y); Console.Write(" ");
						} else {
							//Prints new food
							Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(app.X, app.Y); Console.Write("$");
							inUse = false;
						}
						//adds newH to the snake list
						snake.Add(newH);
						//Prints new head
						Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newH.X, newH.Y); Console.Write("@");
						//Sets last (controller for last usde direction command) to the newest used direction.
						last = newDir;
					}
				}
			}
		}
	}
}