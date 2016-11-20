using System;
using System.Diagnostics;

namespace Snake {
	/*
	 * Factory class keeps track on objects that's there is only ment to be one of, and creates new objects.
	 */
	class Factory {

		//Set up local objects
		private static Position position;
		private static Snake snake;
		private static Food food;
		private static Random random;
		private static Stopwatch stopwatch;
		private static GUI GUI;
		private static GameState gameState;
		private static Action action;

		//Creates a new position, with the help of cord, or another posistion.
		public static Position CreatePosition(int xCord = 0, int yCord = 0, Position location = null) {
			if(location != null) {
				position = new Position(location);
			} else {
				position = new Position(xCord,yCord);
			}
			return position;	
		}

		//Creates a Snake object. If snake object already exists returns existing object.
		public static Snake CreateSnake() {
			if(snake == null) {
				snake = new Snake();
			}
			return snake;
		}

		//Creates food ($) object. If allready exists returns existing object.
		public static Food CreateFood() {
			if(food == null) {
				food = new Food();
			}
			return food;
		}

		//Creates object of random. If random allready exists returns exsisting object.
		public static Random CreateRandom() {
			if(random == null) {
				random = new Random();
			}
			return random;
		}

		//Creates object of stopwatch. If stopwatch allready existst returns exsisting object.
		public static Stopwatch CreateStopwatch() {
			if(stopwatch == null) {
				stopwatch = new Stopwatch();
			}
			return stopwatch;
		}
		
		//Creates object of GUI, if GUI allready exists, returns existing object.
		public static GUI CreateGUI() {
			if(GUI == null) {
				GUI = new GUI();
			}
			return GUI;
		}

		//Creates object of gamestate, if gamestat allready exists returns existing object.
		public static GameState CreateGameState() {
			if(gameState == null) {
				gameState = new GameState();
			}
			return gameState;
		}

		//Creates object of action, if action allready exists returns existing object.
		public static Action CreateAction() {
			if(action == null) {
				action = new Action();
			}
			return action;
		}
	}
}
