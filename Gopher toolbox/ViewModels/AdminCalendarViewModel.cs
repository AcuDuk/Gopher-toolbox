using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GopherToolboxNew.Models;

namespace GopherToolboxNew.ViewModels
{
    public class AdminCalendarViewModel
    {
        public List<Department> Departments { get; set; }
        public List<Duty> Duties { get; set; }
        public int SelectedDepartmentId { get; set; }
        public Duty NewDuty { get; set; }
    }
}
