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
    
    public partial class Letter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Letter()
        {
            this.AttachFiles = new HashSet<AttachFile>();
            this.SentLetters = new HashSet<SentLetter>();
            this.ReferenceLetters = new HashSet<ReferenceLetter>();
        }
    
        public int LetterId { get; set; }
        public string subject { get; set; }
        public string matn { get; set; }
        public string letterNo { get; set; }
        public string createDate { get; set; }
        public int userID { get; set; }
        public byte SecurityType { get; set; }
        public byte ForceType { get; set; }
        public byte BayganiType { get; set; }
        public byte PeygiryType { get; set; }
        public byte AttachmentType { get; set; }
        public byte LetterType { get; set; }
        public byte DraftType { get; set; }
        public string abstrct { get; set; }
        public byte answerType { get; set; }
        public string answerDeadline { get; set; }
        public string Reffrence { get; set; }
        public Nullable<int> replyLetterId { get; set; }
        public string sentLetterDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttachFile> AttachFiles { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SentLetter> SentLetters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReferenceLetter> ReferenceLetters { get; set; }
    }
}
