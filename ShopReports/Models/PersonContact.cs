using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("person_contacts")]
    public class PersonContact
    {
        [Key]
        [Column("person_contact_id")]
        public int Id { get; set; }

        [ForeignKey("Person")]
        [Column("person_id")]
        public int PersonId { get; set; }

        [ForeignKey("Type")]
        [Column("contact_type_id")]
        public int ContactTypeId { get; set; }

        [Column("contact_value")]
        public string Value { get; set; }

        public virtual Person Person { get; set; }

        public virtual ContactType Type { get; set; }
    }
}
