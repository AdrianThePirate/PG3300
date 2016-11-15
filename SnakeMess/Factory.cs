using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
	class Factory {

		private static Position position;

		public static Position CreatePosition(int xCord = 0, int yCord = 0) {
			position = new Position(xCord, yCord);
			return position;	
		}
	}
}
