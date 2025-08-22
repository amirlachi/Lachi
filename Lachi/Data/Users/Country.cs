namespace Lachi.Data.Users
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Image {  get; set; }
        public List<GameStudio> GameStudios { get; set; }
    }
}
