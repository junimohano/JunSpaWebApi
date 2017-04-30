using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JunSpaWebApi.Data;

namespace JunSpaWebApi.Migrations
{
    [DbContext(typeof(JunSpaContext))]
    [Migration("20170430201159_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JunSpaWebApi.Models.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.HasKey("BoardId");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("JunSpaWebApi.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardId");

                    b.Property<string>("Content");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("BoardId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("JunSpaWebApi.Models.Comment", b =>
                {
                    b.HasOne("JunSpaWebApi.Models.Board", "Board")
                        .WithMany("Comments")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
