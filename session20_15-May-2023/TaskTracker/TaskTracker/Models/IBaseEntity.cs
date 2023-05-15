namespace TaskTracker.Models
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        bool IsDeleted { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
