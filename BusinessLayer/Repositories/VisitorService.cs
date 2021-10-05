using AutoMapper;
using BusinessLayer.DTO;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repositories
{
    class VisitorService : IVisitor
    {
        private readonly Context _context;

        private IMapper mapper = new Mapper(AutomapperConfig.Config);

        public VisitorService(Context context) 
        {
            _context = context;
        }
        public List<VisitorDTO> AllVisitors()
        {
            return mapper.Map<List<Visitor>, List<VisitorDTO>>(_context.Visitors.Data);
        }

        public string EditVisitor(VisitorDTO visitor) 
        {
            var v = AllVisitors().Find(v=>v.Id==visitor.Id);
            if (v != null)
            {
                string[] info = {
                visitor.Id.ToString(),
                visitor.Name,
                visitor.Passport,
                visitor.DateOfBirth,
                visitor.MyRoomId.ToString()
            };

                _context.Visitors.EditNode(info);

                return "Данные успешно изменены!";
            }
            return "Пользователь не найден!";
        }

        public string DeleteUser(int id) 
        {
            var v = AllVisitors().Find(v => v.Id == id);
            if (v!=null) 
            {
                _context.Visitors.Remove(id);
                return $"Пользователь {v.Name} был удалён.";
            }
            return "Пользователь либо удалён, либо не существует.";
        }

        public void AddUser(VisitorDTO visitor) 
        {
            _context.Visitors.Add(mapper.Map<Visitor>(visitor));
        }
    }
}
