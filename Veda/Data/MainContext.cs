using Microsoft.EntityFrameworkCore;
using MyTask.Models.Entity;
using PlayersList.Models.Entity;

namespace PlayersList.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }
        // เวลาสร้าง model Entity ใหม่ มาใส่ในนี้ด้วย
        public DbSet<HealthCheckEntity> healthCheckEntity { get; set; }
        public DbSet<TaskEntity> taskEntity { get; set; }
        public DbSet<TodolistEntity> todoEntity { get; set; }
        public DbSet<ColorsEntity> colorsEntity { get; set; }
        public DbSet<PlayerEntity> playerEntity { get; set; }
        public DbSet<PlayerTypeEntity> playerTypeEntity { get; set; }
        public DbSet<UserEntity> userEntity { get; set; }
        public DbSet<UserGameCategoryEntity> userGameCategoryEntity { get; set; }
        public DbSet<GameCategoryEntity> gameCategoryEntity { get; set; }
    }
}
