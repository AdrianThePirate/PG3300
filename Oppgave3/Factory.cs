using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave3 {
    class Factory {
		static Store store;
        public static Bakery CreateBakery(String Name) {
            return new Bakery(Name);
            }

        public static Customer CreateCustomer(String customerName) {
            return new Customer(customerName);
            }
        public static Cookie CreatCookie(String bakery,String type) {
            return new Cookie(bakery,type);
            }
		public static Store CreateStore {
			if(store == null){
				store = new Store;
			}
			return store;
		}
        }
}
