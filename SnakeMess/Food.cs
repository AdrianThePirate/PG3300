using System;

namespace Snake {
	/*
	 * Class food, used as object for keep location of food. And creats new locations.
	 */
	class Food {

		private Position posistion;

		//constructor of food. Creats a position.
		public Food() {
			posistion = Factory.CreatePosition();
		}

		//NewFood creates a new random location for the food.
		public void NewFood(int maxX, int maxY) {
			Random rnd = Factory.CreateRandom();
			posistion.xCord = rnd.Next(0,maxX);
			posistion.yCord = rnd.Next(0,maxY);
		}
		//Fet location returns location of food.
		public Position GetLocation() {
			return posistion;
		}
	}
}
