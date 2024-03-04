using ToDoAppNTier.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ToDoAppNTier.Dtos.WorkDtos
{
    // db Update process work design in program
    public class WorkUpdateDto : IDto
    {
        // Id in 1 to integers max value
        [Range(1,int.MaxValue)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tanım zorunludur!")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
