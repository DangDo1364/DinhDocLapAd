using DinhDocLapAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MyDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public MyDBContext(DbContextOptions options) : base(options)
        {
                
        }
        #region Dbset
        public DbSet<Node> nodes { get; set; }
        public DbSet<Face> faces { get; set; }
        public DbSet<FaceNode> faceNodes { get; set; }
        public DbSet<Block> blocks { get; set; }
        public DbSet<BlockType> blockTypes { get; set; }
        public DbSet<FaceBlock> faceBlocks { get; set; }
        public DbSet<Building> buildings { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>(c =>
            {
                c.ToTable("Node");
                c.HasKey(n => n.IDN);
            });
            modelBuilder.Entity<Face>(c =>
            {
                c.ToTable("Face");
                c.HasKey(n => n.IDF);
            });
            modelBuilder.Entity<BlockType>(c =>
            {
                c.ToTable("BlockType");
                c.HasKey(b => b.IDBT);
            });

            modelBuilder.Entity<Building>(c =>
            {
                c.ToTable("Building");
                c.HasKey(b => b.IDBD);
            });
            modelBuilder.Entity<Block>(c =>
            {
                c.ToTable("Block");
                c.HasKey(n => n.IDB);
            });

            modelBuilder.Entity<FaceNode>(c =>
            {
                c.ToTable("FaceNode");
                c.HasKey(f => new { f.IDF, f.IDN });

                c.HasOne(f => f.node)
                .WithMany(f => f.faceNodes)
                .HasForeignKey(f => f.IDN)
                .HasConstraintName("FK_FaceNode_Node");

                c.HasOne(f => f.face)
               .WithMany(f => f.faceNodes)
               .HasForeignKey(f => f.IDF)
               .HasConstraintName("FK_FaceNode_Face");
            });
            modelBuilder.Entity<FaceBlock>(c =>
            {
                c.ToTable("FaceBlock");
                c.HasKey(f => new { f.IDF, f.IDB });

                c.HasOne(f => f.block)
                .WithMany(f => f.faceBlocks)
                .HasForeignKey(f => f.IDB)
                .HasConstraintName("FK_FaceBlock_Node");

                c.HasOne(f => f.face)
               .WithMany(f => f.faceBlocks)
               .HasForeignKey(f => f.IDF)
               .HasConstraintName("FK_FaceBlock_Face");
            });
          

         
        }
    }
}
