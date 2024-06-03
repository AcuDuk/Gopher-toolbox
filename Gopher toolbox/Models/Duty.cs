using Microsoft.AspNetCore.Mvc;

namespace GopherToolboxNew.Models
{
    public class Duty
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DutyDate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
