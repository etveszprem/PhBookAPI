using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InsOrUpdUsr.Models
{
    //TODO XML leírokat még létre kell hozni, de a lényeg már kész.
    public class PhoneUsrContext : DbContext
    {
        public PhoneUsrContext(DbContextOptions<PhoneUsrContext> options)
            : base(options)
        {
        }

        public DbSet<PhoneEntity> PhoneUsr { get; set; }
    }

    public class PhoneEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string TrzsSzam { get; set; }
        public string FhNev { get; set; }
        public string Nev { get; set; }
        public string MhNev { get; set; }
        public string FTrzsSzam { get; set; }

        public string MPhoneNum { get; set; }
        public string VPhoneNum { get; set; }

        public string Email { get; set; }
        public bool IsDeleted { get; set; }

    }
}
