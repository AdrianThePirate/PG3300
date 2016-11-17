using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
	class Action {
		private Snake snake;
		private Food food;
		private GameState gameState;
		private GUI window;
		private bool newFood;
		private Position head;
		private Position newHead;
		public enum direction {
			Up,
			Right,
			Down,
			Left,
		};
		private direction dir;
		

		public Action() {
			snake = Factory.CreateSnake();
			food = Factory.CreateFood();
			gameState = Factory.CreateGameState();
			window = Factory.CreateGUI();
			dir = (direction)direction.Down;
			newFood = false;
			NewFood();
		}

		public void ChangeDirection(direction newDir) {
			if(dir == direction.Up) {
				if(newDir != direction.Down) { dir = newDir; }
			}
			if(dir == direction.Down) {
				if(newDir != direction.Up) { dir = newDir; }
			}
			if(dir == direction.Left) {
				if(newDir != direction.Right) { dir = newDir; }
			}
			if(dir == direction.Right) {
				if(newDir != direction.Left) { dir = newDir; }
			}

		}

		public void Move() {
			//Creates objects of point (posistion) basde in snakes posstiosn
			head = Factory.CreatePosition(location: snake.Last());
			newHead = Factory.CreatePosition(location: head);
			switch(dir) {
				case direction.Up:
				newHead.yCord -= 1;
				break;
				case direction.Right:
				newHead.xCord += 1;
				break;
				case direction.Down:
				newHead.yCord += 1;
				break;
				default:
				newHead.xCord -= 1;
				break;
			}
			//Test if newH is on the food
			if(newHead.Equals(food.GetLocation())) {
				NewFood();
			}
			DeathCheack(newHead,newFood);
			UpdatedGUI();
		}
		
		private void DeathCheack(Position newH, bool newFood) {
			//Cheack if newH is located outside the game area
			if(newH.yCord < 0 || newH.xCord >= window.boardW) {
				gameState.SetDeath();
			} else if(newH.xCord < 0 || newH.yCord >= window.boardH) {
				gameState.SetDeath();
			}
			//If new food is not added tests if self-cannibalism.
			if(!newFood) {
				//Removes the back of the snek
				snake.RemoveEnd();
				if(snake.CollisionCheck(newH)) {
					gameState.SetDeath();
				}
			}
		}

		private void NewFood() {
			while(true) {
				food.NewFood(window.boardW,window.boardH);
				bool overlap = snake.CollisionCheck(food.GetLocation());

				//Prints food, if not loced on snake
				if(!overlap) {
					window.WriteFood(food.GetLocation());
					break;
				}
			}
			if(snake.Size() + 1 >= window.Size()) {
				// No more room to place apples - game over.
				gameState.SetDeath();
			} else {
				newFood = true;
			}
		}

		private void UpdatedGUI() {
			var tail = Factory.CreatePosition(location: snake.First());

			if(!gameState.death) {
				//Test if not added new food
				if(!newFood) {
					//Remove the back of snek
					window.WriteRemove(tail);
				} else {
					//Prints new food
					window.WriteFood(food.GetLocation());
					newFood = false;
				}
				//adds newH to the snake list
				snake.Add(newHead);
				//Prints new head
				window.WriteMove(head,newHead);
				//Sets last (controller for last usde direction command) to the newest used direction
			}
		}
	}
}
