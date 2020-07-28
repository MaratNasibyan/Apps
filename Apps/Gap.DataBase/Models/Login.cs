using System;
using System.Collections.Generic;

namespace Gap.DataBase.Models
{
    public partial class Login
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool? IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        public string Password { get; set; }
        public int PasswordFormat { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? FailedPasswordAnswerAttemptWindowStart { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public DateTime? FailedPasswordAttemptWindowStart { get; set; }
        public int FailedPasswordAnswerAttemptCount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastVisitDate { get; set; }
        public DateTime? LastVisiteDate { get; set; }
        public bool? MustChangePassword { get; set; }
        public DateTime? TermsAgreedDate { get; set; }
        public string LogixContactId { get; set; }
        public string Source { get; set; }
        public long UsrId { get; set; }
    }
}
