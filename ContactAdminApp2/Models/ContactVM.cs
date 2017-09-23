using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ContactAdminApp2.Models
{
    public class ContactVM
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        
        public string Phone { get; set; }
        [Required]
        public string BirthDate { get; set; }       
        public string ProfilePictureUrl { get; set; }
        public Boolean IsFamily { get; set; }
        public Boolean IsFriend { get; set; }
        public Boolean IsColleague { get; set; }
        public Boolean IsAssociate { get; set; }

      //  public string ListofGroup { get; set; }
        public string Comments{ get; set; }

    }

    public class ContactDBcontext : DbContext
    {
        public DbSet<ContactVM> Contacts { get; set; }
    }

}