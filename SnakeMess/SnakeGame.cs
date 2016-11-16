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
			Food food = Factory.CreateFood();
			GUI GUI = Factory.CreateGUI();
			//Creats list of point (posistions)
			Snake snake = Factory.CreateSnake();

			//Creates food
			while (true) {
				food.NewFood(GUI.boardW,GUI.boardH);
				bool spot = snake.CollisionCheck(food.GetLocation());

				//Prints food, if not loced on snake
				if (!spot) {
					GUI.WriteFood(food.GetLocation());
					break;
				}
			}


			//Creates and starts stopwatch
			Stopwatch time = Factory.CreateStopwatch();
			time.Start();

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
					if (time.ElapsedMilliseconds < 100)
						continue;

					// Restes stopwatch
					time.Restart();
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
					if (newH.yCord < 0 || newH.xCord >= GUI.boardW)
						gg = true;
					else if (newH.xCord < 0 || newH.yCord >= GUI.boardH)
						gg = true;
					//Test if newH is on the food
					if (newH.Equals(food.GetLocation())) { 
						//Cheacks if there is room for food
						if (snake.Size() + 1 >= GUI.Size())
							// No more room to place apples - game over.
							gg = true;
						else {
							//Creates new food
							while (true) {
								food.NewFood(GUI.boardW, GUI.boardH);
								bool found = snake.CollisionCheck(food.GetLocation());
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
						if(snake.CollisionCheck(newH)) {
							gg = true;
						}
					}

					//Updated GUI
					if (!gg) {
						//Test if not added new food
						if (!inUse) {
							//Remove the back of snek
							GUI.WriteRemove(tail);
						} else {
							//Prints new food
							GUI.WriteFood(food.GetLocation());
							inUse = false;
						}
						//adds newH to the snake list
						snake.Add(newH);
						//Prints new head
						GUI.WriteMove(head, newH);
						//Sets last (controller for last usde direction command) to the newest used direction.
						last = newDir;
					}
				}
			}
		}
	}
}