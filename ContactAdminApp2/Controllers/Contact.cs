namespace ContactAdminApp2.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthDate { get; set; }

        [StringLength(200)]
        public string profilePictureUrl { get; set; }
        public bool isFamily { get; set; }
        public bool isFriend { get; set; }
        public bool isColleague { get; set; }
        public bool isAssociate { get; set; }


       // [StringLength(200)]
      //  public string listofGroup { get; set; }

        public string comments { get; set; }
    }
}
