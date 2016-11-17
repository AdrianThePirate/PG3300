using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
	class GameState {
		public bool pause { get; private set; }
		public bool death { get; private set; }

		public GameState() {
			pause = false;
			death = false;
		}

		public void SetPause() {
			pause = !pause;
		}

		public void SetDeath() {
			death = !death;
		}
	}
}
