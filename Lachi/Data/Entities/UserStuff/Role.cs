using Microsoft.AspNetCore.Identity;

namespace Lachi.Data.Entities.UserStuff
{
    public class Role:IdentityRole<Guid>, IBaseEntity
    {
        public string? Description { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;
        public Guid? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }
        public Guid? RemovedById { get; set; }
        public User? RemovedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsRemoved { get; set; } = false;
    }
}
