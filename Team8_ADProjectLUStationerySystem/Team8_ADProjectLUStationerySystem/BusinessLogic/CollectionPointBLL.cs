using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class CollectionPointBLL
    {
        CollectionPointDAO CDAO = new CollectionPointDAO();

        public List<collectionPoint> getAllCollectionPoints()
        {
            return CDAO.getAllCollectionPoints();
        }

        public void changeCollectionPoint(string depCode, int collectionId)
        {
            CDAO.changeCollectionPoint(depCode, collectionId);
        }

        public List<employee> getAllEmployees()
        {
            return CDAO.getAllEmployees();
        }

        public List<department> getAllDepartment()
        {
            return CDAO.getAllDepartment();
        }

        public List<string> getAllDepartments()
        {
            return CDAO.getAllDepartments();
        }

        public void assignRepresentative(string depCode, int repID)
        {
            CDAO.assignRepresentative(depCode, repID);
        }

        public int getCurrentPointID(string depCode)
        {
            return CDAO.getCurrentPointID(depCode);
        }

        public string getCurrentRepName(string depCode)
        {
            return CDAO.getCurrentRepName(depCode);
        }

        public department getOne()
        {
            return CDAO.getOne();
        }
        public string getCurrentPointName(string depCode)
        {
            return CDAO.getCurrentPointName(depCode);
        }
        public List<employee> getAllEmployeesByDepartmentCode(string depCode)
        {
            return CDAO.getAllEmployeesByDepartmentCode(depCode);
        }
        public int getCollectionPointIdbyCollectionPointName(string name)
        {
            return CDAO.getCollectionPointIdbyCollectionPointName(name);
        }
        public void changeRepUserRoleId(int eid, int roleId)
        {
            CDAO.changeRepUserRoleId(eid, roleId);
        }
        public employee getEmployeeByName(string name){
             return CDAO.getEmployeeByName(name); 
        }

        public int getCurrentRepID(string depCode)
        {
            return CDAO.getCurrentRepID(depCode);
        }

        public collectionPoint getCollectionid(int cid)
        {
            return CDAO.getCollectionid(cid);
        }

        public collectionPoint getCollection(string deptcode)
        {
            return CDAO.getCollection(deptcode);
        }
    }
}