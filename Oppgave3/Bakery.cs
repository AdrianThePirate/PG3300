using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Oppgave3 {
    class Bakery {
        public String name { get; set; }
        private static List<String> bakeries = new List<String>();
       
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

        public static void SellCookieTo(Customer customer) {
                
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