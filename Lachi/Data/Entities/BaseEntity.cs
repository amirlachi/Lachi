using Lachi.Data.Entities.UserStuff;

namespace Lachi.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;
        public Guid? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }
        public int? RemovedById { get; set; }
        public User? RemovedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsRemoved { get; set; } = false;
    }
}
