using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebProject_API.Models
{
    public class ApplicationUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string UserName { get;  set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Email { get;  set; }
        [Column(TypeName = "nvarchar(150)")]
        public object Id { get;  set; }
    }
}
