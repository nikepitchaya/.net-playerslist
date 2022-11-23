using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersList.Models.Entity
{
    [Table("players", Schema = "playerslist")]
    public class PlayerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]

        [Column("id")]
        public long id { get; set; }

        [Column("user_game_category_id")]
        public long user_game_category_id { get; set; }

        [Column("type_id")]
        public int type_id { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("about")]
        public string about { get; set; }

        [Column("action")]
        public string action { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("updated_at")]
        public DateTime updated_at { get; set; }


    }
}
