using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;



namespace Oppgave3 {
     class Cookie {

        static List<String> cookieTypes = new List<String>();
        public String bakery { get; set; }
        public String type { get; set; }

         public Cookie(string bakery, String type) {
            this.bakery = bakery;
            this.type = type;
            
            }
  
        public static List<String> GetCookieTypes() {
            if (cookieTypes.Count() == 0) {
                cookieTypes.Add("Chocolate");
                cookieTypes.Add("Vanilla");
                    }
          
            return cookieTypes;
            }
        }
    }