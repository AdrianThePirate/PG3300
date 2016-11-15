using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
	class Snake {
		private List<Position> snake;

		public Snake() {
			List<Position> snake = new List<Position>();
			for(int i = 0; i > 4; i++) {
				snake.Add(Factory.CreatePosition(10,10));
			}
		}

		public CollisionCheck(int xCord, int yCord) {

		}
	}
}
