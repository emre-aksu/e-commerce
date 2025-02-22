using Infrastructure.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Dtos
{
    public class EmployeeEditDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //public DateTime BirthDate { get; set; }
        //public DateTime HireDate { get; set; }
        //public string PhotoPath { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IFormFile Photo { get; set; }
    }
}
