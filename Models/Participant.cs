using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Models
{
    public class Participant
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DateOfArrival { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DateOfDeparture { get; set; }
        public string CompanyName { get; set; }
        public string PositionInCompany { get; set; }
        public ParticipantRole Role { get; set; }
        public Gender Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
        public Country Country { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue("getutcdate()")]
        public DateTime Inserted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime LastUpdated { get; set; }
    }

    public class ParticipantRole : BaseReferenceModel
    {
        public string RoleName { get; set; }
    }
}
