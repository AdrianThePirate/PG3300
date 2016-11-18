using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave3 {
    class Factory {
        public static Bakery CreateBakery(String Name) {
            return new Bakery(Name);
            }

        public static Customer CreatePerson(String customerName) {
            return new Customer(customerName);
            }
        }
}
