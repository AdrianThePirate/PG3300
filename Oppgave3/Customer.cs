﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Oppgave3 {
    class Customer {
        public String customerName { get; set; }
        public static List<String> customers = new List<String>();
        public Customer(String customerName) {
            this.customerName = customerName;
            }

        public static List<String> GetCustomers() {
            if (customers.Count() == 0) {
                customers.Add("Ted");
                customers.Add("Fred");
                customers.Add("Greg");

                }
            return customers;
            }
        

        public  void TakeCookie(Cookie cookie) {
            Console.WriteLine(this.customerName +" has captured "+ cookie.bakery+"'s "+cookie.type);
            Console.ReadLine();
            }

        }
    

}
   