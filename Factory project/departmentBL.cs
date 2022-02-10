using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoryfinal.Models
{
    public class departmentBL
    {
        private Factory2Entities db = new Factory2Entities();

        public List<Departable> GetAll()
        {
            List<Departable> list = new List<Departable>();

            foreach (var item in db.Department2)
            {
                var manager = db.Employee2.Where(x => x.ID == item.Manager_ID).First();

                Departable dep = new Departable();
                dep.ID = item.ID;
                dep.Name = item.Name;
                dep.Manager_ID = manager.First_name;

                list.Add(dep);
            }
            return list;

        }

        public Department2 GetOneDep(int id)
        {
            return db.Department2.Where(x => x.ID == id).First();

        }

        public void Add(Departable d)
        {
            var result = db.Employee2.Where(x => x.First_name == d.Manager_ID).First();

            Department2 dep = new Department2();
            dep.Name = d.Name;
            dep.Manager_ID = result.ID;

            db.Department2.Add(dep);

            db.SaveChanges();
        }

        public void Update(int id, Departable d)
        {
            var res = db.Employee2.Where(x => x.First_name == d.Manager_ID).First();
            var dep = db.Department2.Where(x => x.ID == id).First();
            dep.Name = d.Name;
            dep.Manager_ID = res.ID;
            
            db.SaveChanges();

        }

        public int Delete(int id) 
        {
            var total = 0;
            var dep = db.Department2.Where(x => x.ID == id).First(); 

            foreach(var item in db.Employee2)
            {
                if(item.Department_ID==dep.ID)
                {
                    total++;
                }
            }  
            if(total==0)
            {
                db.Department2.Remove(dep);
                db.SaveChanges();
            }
           
            return total;
           
        }
    }
}