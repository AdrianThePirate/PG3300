using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
	class Snake {
		private List<Position> snake;

		public Snake() {
			snake = new List<Position>();
			for(int i = 0; i < 4; i++) {
				snake.Add(Factory.CreatePosition(10,10));
			}
		}

		public Position First() {
			Position pos = snake.First();
			return pos;
		}

		public Position Last() {
			return snake.Last();
		}

		public int Size() {
			int size = snake.Count;
			return size;
		}

		public void Add(Position pos = null) {
			snake.Add(pos);
		}

		public void RemoveEnd() {
			snake.RemoveAt(0);
		}

		public bool CollisionCheck(int xCord = 0,int yCord = 0,Position position = null) {
			if(position != null){
				xCord = position.xCord;
				yCord = position.yCord;
			}
			bool result = false;
			foreach(Position location in snake) {
				if(location.xCord == xCord && location.yCord == yCord) {
					result = true;
					break;
				}
			}
			return result;
		}

		
	}
}
