using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobShop.Models
{
    /*
    public partial class Jobs
    {
        public Jobs()
        {
            this.JobRequirements = new HashSet<JobRequirements>();
            this.JobSkills = new HashSet<JobSkills>();
        }

        public int IdJob { get; set; }
        public Nullable<int> IdWho { get; set; }
        public string User { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
        public string ImageSRC { get; set; }
        public string Titlu { get; set; }
        public string WhereWhat { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Solicitare { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string Orar { get; set; }
        public string Address { get; set; }
        public Nullable<double> Latitudine { get; set; }
        public Nullable<double> Longitudine { get; set; }
        public string ZIP { get; set; }
        public string Localitate { get; set; }
        public string Region { get; set; }
        public string ImagePath { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<JobRequirements> JobRequirements { get; set; }
        public virtual ICollection<JobSkills> JobSkills { get; set; }
    }
    public partial class Candidates
    {
        public Candidates()
        {
            this.CandidateEducation = new HashSet<CandidateEducation>();
            this.CandidateExperience = new HashSet<CandidateExperience>();
            this.CandidateSkills = new HashSet<CandidateSkills>();
            this.CandidateReq = new HashSet<CandidateReq>();
        }

        public int IdCV { get; set; }
        public string User { get; set; }
        public string Experienta { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
        public string ImageSRC { get; set; }
        public string Titlu { get; set; }
        public string WhereWhat { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Solicitare { get; set; }
        public string Orar { get; set; }
        public Nullable<double> MinSal { get; set; }
        public Nullable<double> MaxSal { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public Nullable<double> Latitudine { get; set; }
        public Nullable<double> Longitudine { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string Localitate { get; set; }
        public string Region { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<CandidateEducation> CandidateEducation { get; set; }
        public virtual ICollection<CandidateExperience> CandidateExperience { get; set; }
        public virtual ICollection<CandidateSkills> CandidateSkills { get; set; }
        public virtual ICollection<CandidateReq> CandidateReq { get; set; }
    }
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            this.AspNetUserClaims = new HashSet<AspNetUserClaims>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogins>();
            this.Jobs = new HashSet<Jobs>();
            this.AspNetRoles = new HashSet<AspNetRoles>();
            this.Candidates = new HashSet<Candidates>();
            this.AspNetUserDetails = new HashSet<AspNetUserDetails>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> Country { get; set; }
        public string Website { get; set; }
        public string ThumbURL { get; set; }
        public byte[] ThumbImg { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePlus { get; set; }
        public string Dribble { get; set; }
        public string Pinterest { get; set; }
        public string LinkedIn { get; set; }
        public Nullable<bool> Favorited { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<Jobs> Jobs { get; set; }
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
        public virtual ICollection<Candidates> Candidates { get; set; }
        public virtual ICollection<AspNetUserDetails> AspNetUserDetails { get; set; }
    }
    */
    
    public class ViewModel
    {
        //public AspNetUsers Model3 { get; set; } 
        //As List
        public List<Jobs> listJobs { get; set; }
        public List<Candidates> listCandidates { get; set; }
        public List<AspNetUsers> listUsers { get; set; }
        //As IEnumerable
        public IEnumerable<Jobs> enumJobs { get; set; }
        public IEnumerable<Candidates> enumCandidates { get; set; }
        public IEnumerable<AspNetUsers> enumAspNetUsers { get; set; }
    }
}
