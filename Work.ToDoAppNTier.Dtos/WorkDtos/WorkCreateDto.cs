using System.ComponentModel.DataAnnotations;
using ToDoAppNTier.Dtos.Interfaces;

namespace ToDoAppNTier.Dtos.WorkDtos
{
    // Work Create Data Transfer Options. implements IDto interface
    public class WorkCreateDto : IDto
    {
        // definition is must given property
        [Required]
        public string Definition { get; set; }

        // is work completed?
        public bool IsCompleted { get; set; }
    }
}
