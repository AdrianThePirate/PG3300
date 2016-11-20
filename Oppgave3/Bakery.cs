using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Diagnostics;

namespace Oppgave3 {
	class Bakery {
		public String name { get; private set; }
		private static List<String> bakeries = new List<String>();
		private Cookie cookie;
		private Store store;
		public Stopwatch stopwatch;

		public Bakery(string name, Store shop) {
			this.name = name;
			store = shop;
			stopwatch = new Stopwatch();

		}
        //The cookies put up for sale is generated. Different types will be given based on which bakery has called the method
		public void BakeCockie() {
			string type;
			Random rng = new Random();
			int typ = rng.Next(0,Cookie.GetCookieTypes().Count()+1);
			if(typ == Cookie.GetCookieTypes().Count()) {
				if(name.Equals("Trump Tower Café")) {
					type = "The greatest cookie";
				}else {
					type = "Cookie care";
				}
			}else {
				type = Cookie.GetCookieTypes()[typ];
			}
			cookie = Factory.CreatCookie(name,type);
			store.AddToStore(cookie);
			Thread.Sleep(1250);
			stopwatch.Restart();
		}
	}
}