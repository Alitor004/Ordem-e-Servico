using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Dto;
using OsDsII.api.Dto.Builder;

namespace OsDsII.api.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("customer")]

    public class Customer 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set;}
        
        [Required]
        [StringLength(60)]
        [Column("name")]
        [NotNull]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        [NotNull]
        public string Email { get; set; }

        [Column("phone")]
        [StringLength(20)]
        [Required]
        public string Phone { get; set; }

        public CustomerDto ToCustomer()
        {
            CustomerDto customerDto = new CustomerDtoBuilder()
                .WithName(Name)
                .WithEmail(Email)
                .WithPhone(Phone)
                .Build();
            return customerDto;
        }
    }
}