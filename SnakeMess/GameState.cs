namespace Snake {
	/*
	 * Class GameState keeps track on death and pause.
	 * 
	 */

	class GameState {
		//Set up bool for pause and death. Public get, private read.
		public bool pause { get; private set; }
		public bool death { get; private set; }

		//Constructor for GameSate. Sets up defualt values.
		public GameState() {
			pause = false;
			death = false;
		}

		//SetPause, makes pause the opposit of what it currently is.
		public void SetPause() {
			pause = !pause;
		}

		//SteDeath, makes death the opposit of what it currently is.
		public void SetDeath() {
			death = !death;
		}
	}
}
