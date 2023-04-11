using Shared.Models;

namespace FileData;

public class DataContainer
{
    public List<User> Users { get; set; }
    public ICollection<Forum> Forums { get; set; }
}