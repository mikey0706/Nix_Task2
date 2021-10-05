using AutoMapper;
using BusinessLayer;
using BusinessLayer.DTO;
using Nix_Task2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nix_Task2.Controllers
{
    public class VisitorController
    {
        private readonly UnitOfWork _unit;
        private readonly List<VisitorView> visitors;
        private IMapper mapper = new Mapper(AutomapperConfig.Config);

        public VisitorController() 
        {
            _unit = new UnitOfWork();
            var v = _unit.VisitorData().AllVisitors();
            visitors = mapper.Map<List<VisitorDTO>, List<VisitorView>>(v);
        }

        public List<VisitorView> VisitorsInfo 
        {
            get { return visitors; }
        }

        public VisitorView FindVisitor(string name) 
        {
            var vis = visitors.FirstOrDefault(v=>v.Name.Equals(name));
            if (vis == null) 
            {
                Console.WriteLine("Такой пользователь не найден.");
            }
            return vis;
        }

        public void AddVisitor(VisitorView visitor) 
        {
            visitor.Id = ++visitors.Last().Id;
            _unit.VisitorData().AddUser(mapper.Map<VisitorDTO>(visitor));
        }

        public string EditVisitor(VisitorView visitor) 
        {
            return _unit.VisitorData().EditVisitor(mapper.Map<VisitorDTO>(visitor));
        }

        public string DeleteVisitor(int id) 
        {
            return _unit.VisitorData().DeleteUser(id);
        }
    }
}
