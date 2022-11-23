using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersList.Models.Entity
{
    [Table("users", Schema = "playerslist")]
    public class UserEntity
    {
        [Key]
        // ใช้คุณสมบัติ LINQ กับ SQL IsDbGenerated บนแอตทริบิวต์ เพื่อกำหนดฟิลด์หรือคุณสมบัติให้เป็นตัวแทนของคอลัมน์ที่สร้างฐานข้อมูล
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]
        [Column("id")]
        public int id { get; set; }
        [Column("username")]
        public string username { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("password")]
        public string password { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("updated_at")]
        public DateTime updated_at { get; set; }
        
    }
}
