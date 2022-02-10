using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoryfinal.Models
{
    public class shiftBL
    {
        private Factory2Entities db = new Factory2Entities();

        public List<shifttable> GetAll()
        {
            List<shifttable> list = new List<shifttable>();


            foreach (var item in db.Shift)
            {
                shifttable st = new shifttable();  
                st.ID = item.ID; 
                st.Date = item.Date;
                st.strat_time = item.strat_time;
                st.End_time = item.End_time;               
                st.employees = new List<Employee2>();

                var result = db.Employeeshift.Where(x => x.Shift_id == item.ID);

                foreach (var emp in result)
                {
                    var result2 = db.Employee2.Where(x => x.ID == emp.Employee_id);
                    foreach (var emp2 in result2)
                    { 
                        Employee2 emp3 = new Employee2();  
                        emp3.ID = emp2.ID;
                        emp3.First_name = emp2.First_name + " " + emp2.Last_name;
                        st.employees.Add(emp3);
                         

                    }


                }
                list.Add(st);
            }
            return list;
        }

        public Shift GetOneEmp(int id)
        {
            return db.Shift.Where(x => x.ID == id).First();

        }

        public void Add(Shift s)
        {
            db.Shift.Add(s);
            db.SaveChanges();
        }

        /*public void Update(int id, Shift s)
        {
            var shift = db.Shift.Where(x => x.ID == id).First();
            shift.Date = s.Date;
            shift.strat_time = s.strat_time;
            shift.End_time = s.End_time;    
             

            db.SaveChanges();

        } 

        public void Delete(int id)
        {
            var shift = db.Shift.Where(x => x.ID == id).First();
            db.Shift.Remove(shift);
            db.SaveChanges();
        } */
    }
}