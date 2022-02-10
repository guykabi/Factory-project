using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoryfinal.Models
{
    public class EmployeeshiftBL
    {
        private Factory2Entities db = new Factory2Entities();

        public List<Employeeshift> GetAll()
        {
            return db.Employeeshift.ToList();
        }

        public Employeeshift GetOne(int id)
        {
            return db.Employeeshift.Where(x => x.ID == id).First();

        }

        public void Add(Employeeshift e)
        {
            db.Employeeshift.Add(e);
            db.SaveChanges();
        }

        public void Update(int id, Employeeshift e) //optional
        {
            var result = db.Employeeshift.Where(x => x.ID == id).First();
            result.Employee_id = e.Employee_id;
            result.Shift_id = e.Shift_id;

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var result = db.Employeeshift.Where(x => x.Employee_id == id);
            foreach (var e in result)
            {
                db.Employeeshift.Remove(e);
            }
            db.SaveChanges();

        }
    }
}