using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersList.Models.Entity
{
    [Table("game_category", Schema = "playerslist")]
    public class GameCategoryEntity
    {
        internal string action;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("about")]
        public string about { get; set; }

        [Column("information")]
        public string information { get; set; }

        [Column("system_requirement")]
        public string system_requirement { get; set; }

        [Column("url_picture")]
        public string url_picture { get; set; }

        [Column("url_video")]
        public string url_video { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("updated_at")]
        public DateTime updated_at { get; set; }
    }
}
