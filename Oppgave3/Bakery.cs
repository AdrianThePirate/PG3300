using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;



namespace Oppgave3 {
    class Bakery {
        public String name { get; set; }
        private static List<String> bakeries = new List<String>();
        private Object thisLock = new Object();
        private Cookie cookie;


        public Bakery(string name) {
            this.name = name;
            
            }

        public static List<String> GetBakeries() {
            if (bakeries.Count()==0) {
                bakeries.Add("Barrack O bakery");
                bakeries.Add("Trump Tower cafe");
                
                }

            return bakeries;
            }
        //Factory.CreatCookie(Client.cookieOrders[i], Client.cookieOrders[i + 1])
        public void SellCookieTo(Customer customer) {
           lock (thisLock) {
                
                for (int i = 0; i < Client.cookieOrders.Count(); i += 2) {
                    cookie = Factory.CreatCookie("", "");
                    String temp = "";
                    temp = Client.cookieOrders[i];
                    //Console.Write(temp);
                    temp = Client.cookieOrders[i + 1];

                    //Console.WriteLine(temp);
                    customer.TakeCookie(cookie);
                    Thread.Sleep(445);
                    cookie = null;
                    }
                }
            }
        public  void MakeCookieOrders(List<String> list) {
            for (int i=0;i<5;i++) {
                for (int j = 0; j < bakeries.Count(); j++) {
                    for (int k=0;k< Cookie.GetCookieTypes().Count();k++) {

                        list.Add(list[j]);
                        list.Add(list[bakeries.Count() + k]);

                        }
                    }
                }
            for (int i =0; i < Cookie.GetCookieTypes().Count + bakeries.Count(); i++) {
                list.Remove(list[0]);
                }
            }

        }
}