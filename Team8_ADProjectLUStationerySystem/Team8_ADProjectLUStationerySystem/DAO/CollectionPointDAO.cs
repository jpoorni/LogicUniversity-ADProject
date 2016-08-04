using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace  Team8_ADProjectLUStationerySystem.DAO
{
    public class CollectionPointDAO
    {
        logicUniversityEntities context = new logicUniversityEntities();

        public List<collectionPoint> getAllCollectionPoints()
        {
            var query = from col in context.collectionPoints select col;
            return query.ToList();
        }


        public void changeCollectionPoint(string depCode, int collectionId)
        {
            department d = context.departments.Where(x => x.departmentCode == depCode).FirstOrDefault();
            d.collectionPointId = collectionId;
            context.SaveChanges();
        }

        public List<department> getAllDepartment()
        {
            var query = from emp in context.departments select emp;
            return query.ToList();
        }

        public List<string> getAllDepartments()
        {
            var query = from emp in context.departments select emp.departmentName;
            return query.ToList();
        }
        public List<employee> getAllEmployees()
        {
            var query = from emp in context.employees select emp;
            return query.ToList();
        }
        public List<employee> getAllEmployeesByDepartmentCode(string depCode)
        {
            return context.employees.Where(e => e.departmentCode == depCode).ToList();
        }

        public void assignRepresentative(string depCode, int repID)
        {
            department d = context.departments.Where(x => x.departmentCode == depCode).First();
            d.RepresentativeID = repID;
            context.SaveChanges();
            
        }


        public int getCurrentPointID(string depCode)
        {
            //department d = luentity.departments.Where(x => x.departmentCode == depCode).FirstOrDefault();
            int collectionPointID = (int)context.departments.Where(r => r.departmentCode == depCode).FirstOrDefault().collectionPointId;
            return collectionPointID;
        }

        public string getCurrentPointName(string depCode)
        {

            var collectionPoint = (from d in context.departments
                                  join c in context.collectionPoints
                                  on d.collectionPointId equals c.collectionPointId
                                  select c.collectionPointName).First();
            return collectionPoint;
        }


        public string getCurrentRepName(string depCode)
        {
            //department d = luentity.departments.Where(x => x.departmentCode == depCode).FirstOrDefault();
            int repID = (int)context.departments.Where(r => r.departmentCode == depCode).FirstOrDefault().RepresentativeID;
            var repName = from x in context.employees
                          where x.employeeId == repID
                          select x.employeeName;
            string name = null;
            foreach(var x in repName)
            {
                name = x;
            }
            return name;
        }

        public department getOne()
        {
            var q = from emp in context.departments select emp;
            return q.FirstOrDefault();
        }
        public int getCollectionPointIdbyCollectionPointName(string name)
        {
           return  context.collectionPoints.Where(c => c.collectionPointName == name).First().collectionPointId;
        }

        public void changeRepUserRoleId(int eid, int roleId)
        {
            context.userDetails.Where(u => u.userId == eid).First().roleId = roleId;
            context.SaveChanges();
        }
       
        public employee getEmployeeByName(string name)
        {
             return context.employees.Where(e => e.employeeName == name).First();

        }

        public int getCurrentRepID(string depCode)
        {
            //department d = luentity.departments.Where(x => x.departmentCode == depCode).FirstOrDefault();
            int repID = (int)context.departments.Where(r => r.departmentCode == depCode).FirstOrDefault().RepresentativeID;
            return repID;
        }

        public collectionPoint getCollectionid(int deptcode)
        {
            var list = from c in context.collectionPoints

                       where c.collectionPointId == deptcode

                       select c;


            return list.FirstOrDefault();
        }

        public collectionPoint getCollection(string deptcode)
        {
            var list = from c in context.collectionPoints
                       from d in context.departments
                       where c.collectionPointId == d.collectionPointId
                       where d.departmentCode == deptcode
                       select c;


            return list.FirstOrDefault();
        }

    }
}