using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table(Name = "TUsers")]
    public class TUsers
    {
        [PrimaryKey,Identity]
        [Column(Name = "ID")]
        public int ID { get; set; }
        [Column(Name = "NID")]
        public string NID { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        [Column(Name = "LastName")]
        public string LastName { get; set; }
        [Column(Name = "Email")]
        public string Email { get; set; }
        [Column(Name = "Password")]
        public string Password { get; set; }
        [Column(Name = "Users")]
        public string Users { get; set; }
        [Column(Name = "Telephone")]
        public string Telephone { get; set; }
        [Column(Name = "Role")]
        public string Role { get; set; }
        [Column(Name = "Date")]
        public string Date { get; set; }
        //Column(Name = "Images")]
        public byte[] Images { get; set; }
        
    }
}
