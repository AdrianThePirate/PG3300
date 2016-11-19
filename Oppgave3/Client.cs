using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;





namespace Oppgave3 {
    class Client {
        Bakery bakery = new Bakery("");
        public static List<String> cookieOrders = new List<String>();
        Factory f = new Factory();
        Cookie yay = f.CreatCookie("Barrack o Bakery", "Chococalte Cookie");

        Customer fred = Factory.CreateCustomer("Fred");
        Customer greg = Factory.CreateCustomer("Greg");
        Customer ted = Factory.CreateCustomer("Ted");
   
        static void Main(string[] args) {

            Client client = new Client();

            client.run();



            }

        public Client() {


            }
        public void run() {

            Thread t = new Thread(thread);
            Thread fredd = new Thread(Fred);
            Thread gregg = new Thread(Greg);
            Thread tedg = new Thread(Ted);

            t.Start();
            gregg.Start();
            tedg.Start();
            fredd.Start();
            Console.ReadLine();

            }
        public void thread() {
            orders();
            SortOrders();
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
            bakery.SellCookieTo(fred);
            Thread.Sleep(1000);
            }
        public void Greg() {
            bakery.SellCookieTo(greg);
            Thread.Sleep(667);

            }
        public void Ted() {
            bakery.SellCookieTo(ted);
            Thread.Sleep(1300);

            }

        }
       
}

