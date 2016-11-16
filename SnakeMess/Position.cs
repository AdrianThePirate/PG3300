using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
	class Position {
		//Defin cordinastion
		public int xCord, yCord;
		
		//Constructer of point (poistion)
		public Position(int x = 0,int y = 0) {
			xCord = x;
			yCord = y;
		}

		//Constructer of point by point
		public Position(Position input) {
			xCord = input.xCord;
			yCord = input.yCord;
		}

		public bool Equals(Position subject) {
			bool result = true;

			if(xCord != subject.xCord || yCord != subject.yCord) {
				result = false;
			}

			return result;
		}
	}
}
