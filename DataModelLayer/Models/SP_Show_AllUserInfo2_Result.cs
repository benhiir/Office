//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModelLayer.Models
{
    using System;
    
    public partial class SP_Show_AllUserInfo2_Result
    {
        public int userId { get; set; }
        public string UserFirstName { get; set; }
        public string UserFamily { get; set; }
        public string Username { get; set; }
        public string PersonalCode { get; set; }
        public string Email { get; set; }
        public string farsiGender { get; set; }
        public string farsiActivity { get; set; }
        public string UserTel { get; set; }
        public string BirthDayDate { get; set; }
        public byte[] UserImage { get; set; }
        public string CreateDate { get; set; }
        public byte[] Signatures { get; set; }
        public byte Gender { get; set; }
        public byte Activity { get; set; }
        public string jobsName { get; set; }
        public Nullable<int> DetermineJobsLevel { get; set; }
        public int JobId { get; set; }
    }
}
