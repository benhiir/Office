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
    using System.Collections.Generic;
    
    public partial class Vw_recieveReference
    {
        public int LetterId { get; set; }
        public int UserID_sender { get; set; }
        public int UserID_Reciever { get; set; }
        public string ReferenceDate { get; set; }
        public Nullable<int> ReadType { get; set; }
        public string Description { get; set; }
        public Nullable<int> LevelNo { get; set; }
        public int ReferenceLetterID { get; set; }
        public string farsiReadType { get; set; }
        public string Fullname_reciever { get; set; }
        public string fullname_sender { get; set; }
        public string subject { get; set; }
        public string matn { get; set; }
        public string letterNo { get; set; }
        public string createDate { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<byte> SecurityType { get; set; }
        public Nullable<byte> ForceType { get; set; }
        public Nullable<byte> BayganiType { get; set; }
        public Nullable<byte> PeygiryType { get; set; }
        public Nullable<byte> AttachmentType { get; set; }
        public Nullable<byte> LetterType { get; set; }
        public Nullable<byte> DraftType { get; set; }
        public string abstrct { get; set; }
        public Nullable<byte> answerType { get; set; }
        public string answerDeadline { get; set; }
        public string Reffrence { get; set; }
        public Nullable<int> replyLetterId { get; set; }
        public string FarsiSecurityType { get; set; }
        public string FarsiForceType { get; set; }
        public string FarsiBayganiType { get; set; }
        public string FarsiPeygiriType { get; set; }
        public string FarsiAttachmentType { get; set; }
        public string FarsiLetterType { get; set; }
        public string FarsiDraftType { get; set; }
        public string FarsiAnswerType { get; set; }
        public string UserFirstName { get; set; }
        public string UserFamily { get; set; }
        public string sentLetterDate { get; set; }
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public Nullable<int> FileSize { get; set; }
        public Nullable<int> Expr2 { get; set; }
        public string Fullname { get; set; }
        public Nullable<byte> IsMessage { get; set; }
    }
}
