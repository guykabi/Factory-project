using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Factoryfinal.Models
{
    public class userBL
    {
        private Factory2Entities db = new Factory2Entities();

        public string[] Get(string u1 , string u2) 
        {
            string[] full = new string[2];

            foreach (var item in db.User)
            {

                if (item.User_name==u1 && item.Password==u2)
                {
                    full[0] = item.Full_name;
                    full[1] = $"{item.ID}"; 
                    return full;
                    
                }
                else if(item.User_name != u1 | item.Password!=u2) 
                {
                    full[0] = "User does not exists"; 
                    full[1] = "";
                }

            }
            
            return full;  
        }


        public string update(int id)
        {
            var text = "";
            var res = db.User.Where(x => x.ID == id).First();
            if (res.Date == DateTime.Today && res.nums_actions <= 20)
            {
                res.nums_actions += 1;
                text = $"{res.nums_actions}/20"; 
                db.SaveChanges();
            } 
            else if(res.Date != DateTime.Today && res.nums_actions != 0)
            {
                res.Date = DateTime.Today;   
                res.nums_actions = 0;
                res.nums_actions += 1;
                text = $"{res.nums_actions}/20";
                db.SaveChanges();
            }

            else
            {
                res.Date = DateTime.Today;
                res.nums_actions = 0;
                text = "Run out of actions";  
                db.SaveChanges();
            }         
            return text; 
        }
    }
}