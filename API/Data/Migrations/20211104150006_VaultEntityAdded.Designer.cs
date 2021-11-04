﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(MeekinFirewatchContext))]
    [Migration("20211104150006_VaultEntityAdded")]
    partial class VaultEntityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("API.Facebook.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Handle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PageAdminTopCountry")
                        .HasColumnType("TEXT");

                    b.Property<string>("PageCategory")
                        .HasColumnType("TEXT");

                    b.Property<string>("PageCreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PageDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("Platform")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlatformId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubscriberCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Verified")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("API.Facebook.Actual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AngryCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CareCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommentCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HahaCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LikeCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LoveCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SadCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShareCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ThankfulCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WowCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Actual");
                });

            modelBuilder.Entity("API.Facebook.ExpandedLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Expanded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Original")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PostPrimaryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostPrimaryId");

                    b.ToTable("ExpandedLink");
                });

            modelBuilder.Entity("API.Facebook.Expected", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AngryCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CareCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommentCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HahaCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LikeCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LoveCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SadCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShareCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ThankfulCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WowCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Expected");
                });

            modelBuilder.Entity("API.Facebook.Medium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Full")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PostPrimaryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostPrimaryId");

                    b.ToTable("Medium");
                });

            modelBuilder.Entity("API.Facebook.Post", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Caption")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LegacyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<string>("Platform")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlatformId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostUrl")
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<int?>("StatisticsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubscriberCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VideoLengthMS")
                        .HasColumnType("INTEGER");

                    b.HasKey("PrimaryId");

                    b.HasIndex("AccountId");

                    b.HasIndex("StatisticsId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("API.Facebook.Statistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ActualId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExpectedId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ActualId");

                    b.HasIndex("ExpectedId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("API.Vault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vaults");
                });

            modelBuilder.Entity("API.VaultItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PostPrimaryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VaultId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostPrimaryId");

                    b.HasIndex("VaultId");

                    b.ToTable("VaultItems");
                });

            modelBuilder.Entity("API.Facebook.ExpandedLink", b =>
                {
                    b.HasOne("API.Facebook.Post", null)
                        .WithMany("ExpandedLinks")
                        .HasForeignKey("PostPrimaryId");
                });

            modelBuilder.Entity("API.Facebook.Medium", b =>
                {
                    b.HasOne("API.Facebook.Post", null)
                        .WithMany("Media")
                        .HasForeignKey("PostPrimaryId");
                });

            modelBuilder.Entity("API.Facebook.Post", b =>
                {
                    b.HasOne("API.Facebook.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("API.Facebook.Statistics", "Statistics")
                        .WithMany()
                        .HasForeignKey("StatisticsId");

                    b.Navigation("Account");

                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("API.Facebook.Statistics", b =>
                {
                    b.HasOne("API.Facebook.Actual", "Actual")
                        .WithMany()
                        .HasForeignKey("ActualId");

                    b.HasOne("API.Facebook.Expected", "Expected")
                        .WithMany()
                        .HasForeignKey("ExpectedId");

                    b.Navigation("Actual");

                    b.Navigation("Expected");
                });

            modelBuilder.Entity("API.VaultItem", b =>
                {
                    b.HasOne("API.Facebook.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostPrimaryId");

                    b.HasOne("API.Vault", "Vault")
                        .WithMany("Items")
                        .HasForeignKey("VaultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Vault");
                });

            modelBuilder.Entity("API.Facebook.Post", b =>
                {
                    b.Navigation("ExpandedLinks");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("API.Vault", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}