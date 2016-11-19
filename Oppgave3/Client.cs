using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;





namespace Oppgave3 {
    class Client {
        private static List<String> cookieOrders = new List<String>();
        Cookie yay = Factory.CreatCookie("Barrack o Bakery", "Chococalte Cookie");
        Customer fred = Factory.CreateCustomer("Fred");
        Customer greg = Factory.CreateCustomer("Greg");
        Customer ted = Factory.CreateCustomer("Ted");
   
        static void Main(string[] args) {
            Client c = new Client();
            c.Test();
            c.BakeNShit();





            }

        public Client() {

            Thread fredd = new Thread(Fred);
            Thread gregg = new Thread(Greg);
            Thread tedg = new Thread(Ted);

            fredd.Start();
            gregg.Start();
                
            }

        public void orders() {
            
                for (int j = 0; j < Bakery.GetBakeries().Count(); j++) {
                cookieOrders.Add(Bakery.GetBakeries()[j] + " ");
                    }
                for (int k = 0; k < Cookie.GetCookieTypes().Count(); k++) {
                cookieOrders.Add(Cookie.GetCookieTypes()[k] + " ");
                    }
            Bakery bakery = Factory.CreateBakery("");
            bakery.MakeCookieOrders(cookieOrders);

            }
        public void SortOrders() {
       

            foreach (String s in cookieOrders) {
                Console.WriteLine(s);
                }
            Console.ReadLine();
            }
        public void Fred() {
            fred.TakeCookie(yay);
            }
        public void Greg() {
            greg.TakeCookie(yay);

            }
        public void Ted() {
            ted.TakeCookie(yay);


            }
        public void BakeNShit() {
            orders();
            //SortOrders();
            for (int i = 0; i < 4; i++) {
                String temp = ""; 
                temp= cookieOrders[i];
                Console.WriteLine(temp);
                    
                Console.ReadLine();
                }
            }
        public void Test() {
         Customer hitler=  Factory.CreateCustomer("hitler");
            hitler.TakeCookie(yay);
            
            }
        }
}
