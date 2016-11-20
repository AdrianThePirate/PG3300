using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Diagnostics;






namespace Oppgave3 {
	class Client {
		public static List<String> cookieOrders = new List<String>();

		static Store store;

		static void Main(string[] args) {

			Client client = new Client();
			client.Run();



		}

		public Client() {
			store = Factory.CreateStore();

		}
        //Everything is initializied 
        public void Run() {

			store.stopwatch.Start();

			//Thread t = new Thread(thread);
			Thread fredd = new Thread(Fred);
			Thread gregg = new Thread(Greg);
			Thread tedg = new Thread(Ted);
			var barrack = new Thread(Barrack);
			var trump = new Thread(Trump);
			tedg.Start();
			fredd.Start();
			gregg.Start();
			barrack.Start();
			trump.Start();

			Console.ReadLine();

		}
			
        //The methods where Fred Greg and Ted tries to to grab the cookie//
        public void Fred() {
			while(true) {
				if(store.stopwatch.ElapsedMilliseconds >= 450) {
					if(store.GetStockSize() > 0) {
						store.SellCookieTo("Fred");
						Thread.Sleep(100);
					} else { store.stopwatch.Restart(); }
				}
			}
		}
		public void Greg() {
			while(true) {
				if(store.stopwatch.ElapsedMilliseconds >= 450) {
					if(store.GetStockSize() > 0) {
						store.SellCookieTo("Greg");
						Thread.Sleep(100);
					} else { store.stopwatch.Restart(); }

				}
			}
		}
		public void Ted() {
			while(true) {
				if(store.stopwatch.ElapsedMilliseconds >= 450) {
					if(store.GetStockSize() > 0) {
						store.SellCookieTo("Ted");
						Thread.Sleep(100);
					} else { store.stopwatch.Restart(); }
				}
			}
		}
        //The methods for for each bakery where they make the cookies
        public void Barrack() {
			Bakery bakery = Factory.CreateBakery("Barrack O bakery", store);
			bakery.stopwatch.Start();
			for(int i = 0;i <= 20;) {
				if(bakery.stopwatch.ElapsedMilliseconds == 1000) {
					bakery.BakeCockie();
					i++;
				}
			}
		}

		public void Trump() {
			Bakery bakery = Factory.CreateBakery("Trump Tower Café", store);
			bakery.stopwatch.Start();
			for(int i = 0;i <= 12;) {
				if(bakery.stopwatch.ElapsedMilliseconds == 2500) {
					bakery.BakeCockie();
					i++;
				}
			}

		}
	}
}

