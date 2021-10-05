using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repositories
{
    public interface IVisitor
    {
        public List<VisitorDTO> AllVisitors();
        public string EditVisitor(VisitorDTO visitor);
        public string DeleteUser(int id);
        public void AddUser(VisitorDTO visitor);
    }
}
