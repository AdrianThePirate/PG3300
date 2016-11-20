using System;

namespace Snake {
	class Food {

		private Position posistion;

		public Food() {
			posistion = Factory.CreatePosition();
		}

		public void NewFood(int maxX, int maxY) {
			Random rnd = Factory.CreateRandom();
			posistion.xCord = rnd.Next(0,maxX);
			posistion.yCord = rnd.Next(0,maxY);
		}

		public Position GetLocation() {
			return posistion;
		}
	}
}
