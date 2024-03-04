namespace ToDoAppNTier.Entities.Concrete
{
    // BaseEntity allows to reach id value of current work
    // base a tiny work class
    public class Work : BaseEntity
    {
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
