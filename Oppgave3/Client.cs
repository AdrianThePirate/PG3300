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
            var cookieOrders = new List<String>();
            
                for (int j = 0; j < Bakery.GetBakeries().Count(); j++) {
                cookieOrders.Add(Bakery.GetBakeries()[j] + " ");
                    }
                for (int k = 0; k < Cookie.GetCookieTypes().Count(); k++) {
                cookieOrders.Add(Cookie.GetCookieTypes()[k] + " ");
                    }
                
            Bakery bakery = Factory.CreateBakery("");
            bakery.MakeCookieOrders(cookieOrders);

            foreach (String s in cookieOrders) {
                Console.WriteLine(s);
                }
            Console.ReadLine();
            }
        }
}
