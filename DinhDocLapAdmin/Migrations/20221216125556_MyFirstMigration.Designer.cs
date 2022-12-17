﻿// <auto-generated />
using DinhDocLapAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DinhDocLapAdmin.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20221216125556_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DinhDocLapAdmin.Models.Block", b =>
                {
                    b.Property<int>("IDB")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDBD")
                        .HasColumnType("int");

                    b.Property<int>("IDBT")
                        .HasColumnType("int");

                    b.Property<string>("blockDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDB");

                    b.HasIndex("IDBD");

                    b.HasIndex("IDBT");

                    b.ToTable("Block");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.BlockType", b =>
                {
                    b.Property<int>("IDBT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("blockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("colorEdge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("height")
                        .HasColumnType("float");

                    b.HasKey("IDBT");

                    b.ToTable("BlockType");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.Building", b =>
                {
                    b.Property<int>("IDBD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buildingDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buildingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDBD");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.Face", b =>
                {
                    b.Property<int>("IDF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("faceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDF");

                    b.ToTable("Face");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.FaceBlock", b =>
                {
                    b.Property<int>("IDF")
                        .HasColumnType("int");

                    b.Property<int>("IDB")
                        .HasColumnType("int");

                    b.HasKey("IDF", "IDB");

                    b.HasIndex("IDB");

                    b.ToTable("FaceBlock");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.FaceNode", b =>
                {
                    b.Property<int>("IDF")
                        .HasColumnType("int");

                    b.Property<int>("IDN")
                        .HasColumnType("int");

                    b.Property<int>("seq")
                        .HasColumnType("int");

                    b.HasKey("IDF", "IDN");

                    b.HasIndex("IDN");

                    b.ToTable("FaceNode");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.Node", b =>
                {
                    b.Property<int>("IDN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("x")
                        .HasColumnType("float");

                    b.Property<double>("y")
                        .HasColumnType("float");

                    b.Property<double>("z")
                        .HasColumnType("float");

                    b.HasKey("IDN");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.Block", b =>
                {
                    b.HasOne("DinhDocLapAdmin.Models.Building", "building")
                        .WithMany("blocks")
                        .HasForeignKey("IDBD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DinhDocLapAdmin.Models.BlockType", "blockType")
                        .WithMany("blocks")
                        .HasForeignKey("IDBT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("blockType");

                    b.Navigation("building");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.FaceBlock", b =>
                {
                    b.HasOne("DinhDocLapAdmin.Models.Block", "block")
                        .WithMany("faceBlocks")
                        .HasForeignKey("IDB")
                        .HasConstraintName("FK_FaceBlock_Node")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DinhDocLapAdmin.Models.Face", "face")
                        .WithMany("faceBlocks")
                        .HasForeignKey("IDF")
                        .HasConstraintName("FK_FaceBlock_Face")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("block");

                    b.Navigation("face");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.FaceNode", b =>
                {
                    b.HasOne("DinhDocLapAdmin.Models.Face", "face")
                        .WithMany("faceNodes")
                        .HasForeignKey("IDF")
                        .HasConstraintName("FK_FaceNode_Face")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DinhDocLapAdmin.Models.Node", "node")
                        .WithMany("faceNodes")
                        .HasForeignKey("IDN")
                        .HasConstraintName("FK_FaceNode_Node")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("face");

                    b.Navigation("node");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.Block", b =>
                {
                    b.Navigation("faceBlocks");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.BlockType", b =>
                {
                    b.Navigation("blocks");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.Building", b =>
                {
                    b.Navigation("blocks");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.Face", b =>
                {
                    b.Navigation("faceBlocks");

                    b.Navigation("faceNodes");
                });

            modelBuilder.Entity("DinhDocLapAdmin.Models.Node", b =>
                {
                    b.Navigation("faceNodes");
                });
#pragma warning restore 612, 618
        }
    }
}