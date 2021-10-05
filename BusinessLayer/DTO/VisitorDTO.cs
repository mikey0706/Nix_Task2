using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DTO
{
    public class VisitorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Passport { get; set; }

        public string DateOfBirth { get; set; }

        public int MyRoomId { get; set; }

    }
}
