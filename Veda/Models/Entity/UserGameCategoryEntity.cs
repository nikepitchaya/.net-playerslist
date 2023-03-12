using MyTask.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersList.Models.Entity
{
    [Table("users_game_category", Schema = "playerslist")]
    public class UserGameCategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]
        [Column("id")]
        public long id { get; set; }

        [Column("user_id")]
        public long user_id { get; set; }

        [Column("game_category_id")]
        public int game_category_id { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("updated_at")]
        public DateTime updated_at { get; set; }

    }
}
