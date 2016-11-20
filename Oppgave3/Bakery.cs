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
		public String name { get; set; }
		private static List<String> bakeries = new List<String>();
		private Object thisLock = new Object();
		private Cookie cookie;
		public Stopwatch stopwatch;
		int i = 0;

		public Bakery(string name) {
			this.name = name;
			stopwatch = new Stopwatch();

		}

		//Factory.CreatCookie(Client.cookieOrders[i], Client.cookieOrders[i + 1])
		public void SellCookieTo(Customer customer) {
			lock(thisLock) {

				if(i == 0) {
					cookie = Factory.CreatCookie(i.ToString(),"");

					//Console.WriteLine(temp);
					customer.TakeCookie(cookie);
					Thread.Sleep(445);
					stopwatch.Restart();
					i++;
				} else if(i == 2) {
					i = 0;
				} else {
					i++;
				}

			}
		}
		public void BakeCockie() {
			string type;
			Random rng = new Random();
			int typ = rng.Next(0,Cookie.GetCookieTypes().Count()+1);
			if(typ == Cookie.GetCookieTypes().Count() + 1) {
				if(name.Equals("Trump Tower Café")) {
					type = "The greatest cookie";
				}else {
					type = "Cookie care";
				}
			}else {
				type = Cookie.GetCookieTypes()[i];
			}
			cookie = Factory.CreatCookie(name,type);
			Store.AddToStore(cookie);
		}
	}
}