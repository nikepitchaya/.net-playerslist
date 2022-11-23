using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersList.Models.Entity
{
    [Table("players_types", Schema = "playerslist")]
    public class PlayerTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]

        [Column("id")]
        public long id { get; set; }

        [Column("type_of_players")]
        public string type_of_players { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("updated_at")]
        public DateTime updated_at { get; set; }
    }
}
