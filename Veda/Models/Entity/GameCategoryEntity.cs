using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersList.Models.Entity
{
    [Table("game_category", Schema = "playerslist")]
    public class GameCategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        public int name { get; set; }

        [Column("about")]
        public int about { get; set; }

        [Column("information")]
        public int information { get; set; }

        [Column("system_requirement")]
        public int system_requirement { get; set; }

        [Column("url_picture")]
        public int url_picture { get; set; }

        [Column("url_video")]
        public int url_video { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("updated_at")]
        public DateTime updated_at { get; set; }
    }
}
