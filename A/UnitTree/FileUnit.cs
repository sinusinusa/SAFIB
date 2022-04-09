

namespace A.UnitTree
{
    public class FileUnit
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public FileUnit(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
