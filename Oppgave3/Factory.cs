using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave3 {
	class Factory {
		private static Store store;

		public static Bakery CreateBakery(String Name, Store store) {
			return new Bakery(Name, store);
		}

		public static Cookie CreatCookie(String bakery,String type) {
			return new Cookie(bakery,type);
		}

		public static Store CreateStore() {
			if(store == null){
				store = new Store();
			}
			return store;
		}
	}
}
