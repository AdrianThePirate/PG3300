using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave3 {
	class Store {
		List<Cookie> Sale;
		public static void AddToStore(Cookie cookie) {
			Sale.Add(cookie);
		}
	}
}
