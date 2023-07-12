using Microsoft.EntityFrameworkCore;

namespace TestForCourses.Data.Models
{
    [Keyless]
    public class Path
    {
        public int AncestorId { get; set; }
        public int DescendantId { get; set; }
        public ushort Depth { get; set; }
    }
}
