namespace Lachi.Data.Users
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
    }
}
