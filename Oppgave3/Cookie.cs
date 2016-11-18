using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;



namespace Oppgave3 {
     class Cookie {
        private static Cookie cookie = new Cookie("","");
       static List<String> cookieTypes = new List<String>();

        public String bakery { get; set; }
        public String type { get; set; }

        public Cookie(String bakery, String type) {
            this.bakery = bakery;
            this.type = type;
            
            }

        public static Cookie GetCookie(String bakery,String type) {
            cookie.bakery = bakery;
            cookie.type = type;

            return cookie;
            }
      
              
        public static List<String> GetCookieTypes() {
            if (cookieTypes.Count() == 0) {
                cookieTypes.Add("Chocolate");
                cookieTypes.Add("Vanilla");
                cookieTypes.Add("apple");
                cookieTypes.Add("dirt");

                }
          
            return cookieTypes;
            }
        }
    }