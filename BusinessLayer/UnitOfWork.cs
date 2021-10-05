using BusinessLayer.Repositories;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class UnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork() 
        {
            _context = new Context();
        }

        public IVisitor VisitorData() 
        {
            return new VisitorService(_context);
        }

        public IRooms RoomsData() 
        {
            return new RoomService(_context);
        }

    }
}
