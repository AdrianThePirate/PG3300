using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;





namespace Oppgave3 {
    class Client {
        static void Main(string[] args) {
            Client c = new Client();
            c.orders();


            }

        public Client() {


            }
        
        public void orders() {
            var orders = new List<String>();
            
                for (int j = 0; j < Bakery.GetBakeries().Count(); j++) {
                    orders.Add(Bakery.GetBakeries()[j] + " ");
                    }
                for (int k = 0; k < Cookie.GetCookieTypes().Count(); k++) {
                    orders.Add(Cookie.GetCookieTypes()[k] + " ");
                    }
                
            Bakery nigger = Factory.CreateBakery("");
            nigger.MakeCookies(orders);

            foreach (String s in orders) {
                Console.WriteLine(s);
                }
            Console.ReadLine();
            }
        }
}
