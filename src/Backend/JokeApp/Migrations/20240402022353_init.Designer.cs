﻿// <auto-generated />
using JokeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JokeApp.Migrations
{
    [DbContext(typeof(JokeAppDbXontext))]
    [Migration("20240402022353_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JokeApp.Models.Joke", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Joke");
                });

            modelBuilder.Entity("JokeApp.Models.Vote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JokeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Liked")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("JokeId");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("JokeApp.Models.Vote", b =>
                {
                    b.HasOne("JokeApp.Models.Joke", "Joke")
                        .WithMany("Votes")
                        .HasForeignKey("JokeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Joke");
                });

            modelBuilder.Entity("JokeApp.Models.Joke", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
