using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
	class Position {
		//Defin cordinastion
		public int XCord, YCord;
		
		//Constructer of point (poistion)
		public Position(int x = 0,int y = 0) {
			XCord = x;
			YCord = y;
		}

		//Constructer of point by point
		public Position(Position input) {
			XCord = input.XCord;
			YCord = input.YCord;
		}
	}
}
