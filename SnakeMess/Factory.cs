using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
	class Factory {

		private static Position position;
		private static Snake snake;

		public static Position CreatePosition(int xCord = 0, int yCord = 0, Position location = null) {
			if(location != null) {
				position = new Position(location);
			} else {
				position = new Position(xCord,yCord);
			}
			return position;	
		}

		public static Snake CreateSnake() {
			snake = new Snake();
			return snake;
		}
	}
}
