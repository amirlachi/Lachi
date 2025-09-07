using Lachi.Data.Entities.UserStuff;

namespace Lachi.Data.Entities
{
    public interface IBaseEntity
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid? CreatedById { get; set; }
        public User? CreatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }
        public Guid? RemovedById { get; set; }
        public User? RemovedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public Guid? CreatedById { get; set; }
        public User? CreatedBy { get; set; } = null!;
        public Guid? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }
        public Guid? RemovedById { get; set; }
        public User? RemovedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsRemoved { get; set; } = false;
    }
}
