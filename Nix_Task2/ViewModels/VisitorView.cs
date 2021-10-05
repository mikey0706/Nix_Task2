using System;
using System.Collections.Generic;
using System.Text;

namespace Nix_Task2.ViewModels
{
    public class VisitorView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Passport { get; set; }

        public string DateOfBirth { get; set; }

        public int MyRoomId { get; set; }

        public VisitorView() 
        {
            Name = "Undefined";
            Passport ="NoPassport";
            DateOfBirth = DateTime.MinValue.ToShortDateString();
            MyRoomId = 0;
        }
    }
}
