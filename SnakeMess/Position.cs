namespace Snake {
	/*
	 * Class Position geems is used as an object.
	 * 
	 * It keeps the cords on where on the game window it's located.
	 */
	class Position {
		//Defin cordinastion values (x-cordinants, y-cordinants)
		public int xCord, yCord;
		
		//Constructer of Position, uses in sent cordination info to create new object. If, no a cord is missing the value is automatlic 0
		public Position(int x = 0,int y = 0) {
			xCord = x;
			yCord = y;
		}

		//Constructer of Position by Position. Takes a posistion objects and creates a new posistion object.
		public Position(Position input) {
			xCord = input.xCord;
			yCord = input.yCord;
		}

		//Equals methoed to compare two posistions. Retunrs a true or false bool back.
		public bool Equals(Position subject) {
			bool result = true;

			if(xCord != subject.xCord || yCord != subject.yCord) {
				result = false;
			}

			return result;
		}
	}
}
