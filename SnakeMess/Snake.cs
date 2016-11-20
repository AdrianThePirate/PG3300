using System.Collections.Generic;
using System.Linq;

namespace Snake {
	/*
	 * Snake class used as object. Keeps track of location and size of snake.
	 * 
	 * It also cheacks if something colides with it.
	 */
	class Snake {
		//Creates litst
		private List<Position> snake;

		//Constructor of snake, prepear snake of size of 4 posistions.
		public Snake() {
			snake = new List<Position>();
			for(int i = 0; i < 4; i++) {
				snake.Add(Factory.CreatePosition(10,10));
			}
		}

		//Get the first point of the snake (head)
		public Position First() {
			Position pos = snake.First();
			return pos;
		}

		//Get the last pint of the snake (tail)
		public Position Last() {
			return snake.Last();
		}

		//Returns size of the snake
		public int Size() {
			int size = snake.Count;
			return size;
		}

		//Adds position to snake
		public void Add(Position pos = null) {
			snake.Add(pos);
		}

		//Removes the end(tail) of the snake
		public void RemoveEnd() {
			snake.RemoveAt(0);
		}

		//Cheacks if position (subject) has collided with the snake
		public bool CollisionCheck(Position subject) {
			bool result = false;
			foreach(Position location in snake) {
				if(location.Equals(subject)) {
					result = true;
					break;
				}
			}
			return result;
		}

		
	}
}
