using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave3 {
	class Store {
		private Object thisLock = new Object();
		private List<Cookie> sale;
		private int stockNr;
		public Stopwatch stopwatch = new Stopwatch();
		public Store() {
			sale = new List<Cookie>();
			stockNr = 0;
		}
        //Cookies are put out ready for sale
		public void AddToStore(Cookie cookie) {
			lock(thisLock) {
				cookie.number = stockNr;
				sale.Add(cookie);
				Console.WriteLine(cookie.bakery + " have made " + cookie.type + " [" + cookie.number + "]");
				++stockNr;
			}
		}
        //Returns the amount of cookies currently avaiable for sale
		public int GetStockSize() {
			return sale.Count();
		}
        //Cookies are "sold" to whatever thread gains access first
		public void SellCookieTo(string customer) {
			lock(thisLock) {
				if(sale.Count != 0) {
					Cookie cookie = sale[0];
					String txt = customer + " takes " + cookie.bakery + "'s " + cookie.type + " [" + cookie.number + "]";
					Console.CursorLeft = Console.BufferWidth - txt.Length - 1;
					Console.WriteLine(txt);
					Thread.Sleep(445);
					stopwatch.Restart();
					sale.RemoveAt(0);
				}
			}
		}
	}
}
