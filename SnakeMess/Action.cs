namespace Snake {
	/*
	 * Action class, keep track on the action in the game, and updateds other objects.
	 */
	class Action {
		//Declears needed objects
		private Snake snake;
		private Food food;
		private GameState gameState;
		private GUI window;
		private bool newFood;
		private Position head;
		private Position newHead;
		//Public enum for easleyer handle diretions.
		public enum direction {
			Up,
			Right,
			Down,
			Left,
		};
		private direction dir;
		private direction lastDir;
		
		//Constructor for Action. Askes for needed objects, and sets defaults.
		public Action() {
			snake = Factory.CreateSnake();
			food = Factory.CreateFood();
			gameState = Factory.CreateGameState();
			window = Factory.CreateGUI();
			dir = (direction)direction.Down;
			lastDir = dir;
			newFood = false;
			NewFood();
		}

		//Tests new diraction and sets new direction if it's sensabile
		public void ChangeDirection(direction newDir) {
			if(lastDir == direction.Up) {
				if(newDir != direction.Down) { dir = newDir; }
			}
			if(lastDir == direction.Down) {
				if(newDir != direction.Up) { dir = newDir; }
			}
			if(lastDir == direction.Left) {
				if(newDir != direction.Right) { dir = newDir; }
			}
			if(lastDir == direction.Right) {
				if(newDir != direction.Left) { dir = newDir; }
			}

		}

		//Makes a move with the snake.
		public void Move() {
			//Creates objects of point (posistion) basde in snakes posstiosn
			head = Factory.CreatePosition(location: snake.Last());
			newHead = Factory.CreatePosition(location: head);
			//Moveing the snake
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
			lastDir = dir;
			//Test if newH is on the food, if succsessfull starts process of new food
			if(newHead.Equals(food.GetLocation())) {
				NewFood();
			}
			DeathCheack(newHead,newFood);
			UpdatedGUI();
		}
		
		//priavte, cheacks if the snake has done someting deadly
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

		//Creates new food, makes sure it's not on the snake.
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
			//Tests if there are room to place the apple, if not - game over
			if(snake.Size() + 1 >= window.Size()) {
				gameState.SetDeath();
			} else {
				newFood = true;
			}
		}

		//Updateds the GUI, and snake
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
				//adds new head to the snake list
				snake.Add(newHead);
				//Prints new head
				window.WriteMove(head,newHead);
			}
		}
	}
}
