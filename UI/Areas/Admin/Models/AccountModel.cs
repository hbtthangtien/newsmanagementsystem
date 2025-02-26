using Persistences.Enum;

namespace UI.Areas.Admin.Models
{
    public class AccountModel
    {
        public short AccountId { get; set; }

        public string? AccountName { get; set; }

        public string? AccountEmail { get; set; }

        public UserRole? AccountRole { get; set; }

        public string? AccountPassword { get; set; }
        public SystemStatus? AccountStatus { get; set; } = SystemStatus.Inactive;
    }
}
