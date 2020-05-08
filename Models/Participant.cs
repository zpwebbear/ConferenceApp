using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Models
{
    public class Participant
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfArrival { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfDeparture { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50)]
        public string PositionInCompany { get; set; }
        [Required]
        public ParticipantRole Role { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Required]
        public Country Country { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }

    public class ParticipantRole : BaseReferenceModel
    {
        public string RoleName { get; set; }
    }
}
