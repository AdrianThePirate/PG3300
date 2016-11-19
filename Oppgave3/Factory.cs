using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave3 {
    class Factory {
        private static Cookie cookie;
        public static Bakery CreateBakery(String Name) {
            return new Bakery(Name);
            }

        public static Customer CreateCustomer(String customerName) {
            return new Customer(customerName);
            }
        public static Cookie CreatCookie(String bakery,String type) {
            if (cookie == null) {
                cookie = new Cookie(bakery, type);
                }
            return cookie;
            }
        }
}
