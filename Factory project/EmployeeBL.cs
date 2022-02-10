using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoryfinal.Models
{
    public class EmployeeBL
    {
        private Factory2Entities db = new Factory2Entities();

        public List<Employeetable> GetAll(string dep , string fname , string lname)
        {
            List<Employeetable> emptable = new List<Employeetable>(); 

            if (dep == "" && fname== "" && lname == "")
            {

                foreach (var item in db.Employee2)
                {
                    var res = db.Department2.Where(x => x.ID == item.Department_ID).First();

                    Employeetable emp = new Employeetable();
                    emp.ID = item.ID;
                    emp.First_name = item.First_name;
                    emp.Last_name = item.Last_name;
                    emp.Start_year = item.Start_year;
                    emp.Department = res.Name;
                    emp.shifts = new List<string>(); 

                    var result = db.Employeeshift.Where(x => x.Employee_id == item.ID); 

                    foreach (var s in result)
                    {
                        var result2 = db.Shift.Where(x => x.ID == s.Shift_id);
                        foreach (var s2 in result2)
                        {
                            emp.shifts.Add(s2.Date + "-" + s2.strat_time);

                        }

                    }


                    emptable.Add(emp);
                }

                return emptable;
            }   
            
                
            if(dep != null && fname == "null" && lname == "null")
            {
                var r = db.Department2.Where(x => x.Name == dep).First(); 
                var res = db.Employee2.Where(x => x.Department_ID == r.ID).ToList();
                foreach (var item in res)
                {
                    Employeetable emp = new Employeetable();
                    emp.ID = item.ID;  
                    emp.First_name = item.First_name;
                    emp.Last_name = item.Last_name;
                    emp.Start_year = item.Start_year;
                    emp.Department =r.Name;
                    emp.shifts = new List<string>();

                    var result = db.Employeeshift.Where(x => x.Employee_id == item.ID);

                    foreach (var s in result)
                    {
                        var result2 = db.Shift.Where(x => x.ID == s.Shift_id);
                        foreach (var s2 in result2)
                        {
                            emp.shifts.Add(s2.Date + " - " + s2.strat_time);

                        }

                    }


                    emptable.Add(emp);
                }

                return emptable;
            }  

            if(dep== "null" && fname== "null" && lname != null)
            {
                var res = db.Employee2.Where(x => x.Last_name == lname).ToList();
                foreach (var item in res)
                {
                    var r = db.Department2.Where(x => x.ID == item.Department_ID).First();

                    Employeetable emp = new Employeetable();
                    emp.ID = item.ID;
                    emp.First_name = item.First_name;
                    emp.Last_name = item.Last_name;
                    emp.Start_year = item.Start_year;
                    emp.Department = r.Name;
                    emp.shifts = new List<string>();

                    var result = db.Employeeshift.Where(x => x.Employee_id == item.ID);

                    foreach (var s in result)
                    {
                        var result2 = db.Shift.Where(x => x.ID == s.Shift_id);
                        foreach (var s2 in result2)
                        {
                            emp.shifts.Add(s2.Date + " - " + s2.strat_time);

                        }

                    }


                    emptable.Add(emp);
                }

                return emptable;


            }
            else
            {

                var res = db.Employee2.Where(x => x.First_name == fname).ToList();   
                   
                foreach (var item in res)
                {
                    var r = db.Department2.Where(x => x.ID == item.Department_ID).First();

                    Employeetable emp = new Employeetable();
                    emp.ID = item.ID;
                    emp.First_name = item.First_name;
                    emp.Last_name = item.Last_name;
                    emp.Start_year = item.Start_year;
                    emp.Department = r.Name;
                    emp.shifts = new List<string>();

                    var result = db.Employeeshift.Where(x => x.Employee_id == item.ID);

                    foreach (var s in result)
                    {
                        var result2 = db.Shift.Where(x => x.ID == s.Shift_id);
                        foreach (var s2 in result2)
                        {
                            emp.shifts.Add(s2.Date + " - " + s2.strat_time);

                        }

                    }


                    emptable.Add(emp);
                }

                return emptable;
            }
           
        }

        public Employeetable GetOneEmp(int id)
        {

            var res = db.Employee2.Where(x => x.ID == id).First(); 
            var r = db.Department2.Where(x => x.ID == res.Department_ID).First();

            Employeetable emp = new Employeetable(); 
            emp.ID = id;    
            emp.First_name = res.First_name;
            emp.Last_name = res.Last_name;
            emp.Start_year = res.Start_year;
            emp.Department = r.Name;
            emp.shifts = new List<string>();

            var result = db.Employeeshift.Where(x => x.Employee_id == res.ID);
            foreach (var s in result)
            {

                var result2 = db.Shift.Where(x => x.ID == s.Shift_id);
                foreach (var s2 in result2)
                {
                    emp.shifts.Add(s2.Date + "--" + s2.strat_time);

                }

            }
            return emp;
        }


        /*public void Add(Employee2 emp) //there is no need to on this project
        {
            db.Employee2.Add(emp);
            Employeeshift e = new Employeeshift();
            e.Employee_id = emp.ID;
            db.SaveChanges();

        }*/


        public void Update(int id, Employee2 emp)
        {
            var emplo = db.Employee2.Where(x => x.ID == id).First();
            emplo.First_name = emp.First_name;
            emplo.Last_name = emp.Last_name;
            emplo.Start_year = emp.Start_year;
            emplo.Department_ID = emp.Department_ID; 
            db.SaveChanges();

        }


        public void Delete(int id)
        {
            var emplo = db.Employee2.Where(x => x.ID == id).First();
            db.Employee2.Remove(emplo);
            var emplo2 = db.Employeeshift.Where(x => x.Employee_id == id);
            foreach (var item in emplo2)
            {
                db.Employeeshift.Remove(item);
            }
            db.SaveChanges();
        }
    } 








}