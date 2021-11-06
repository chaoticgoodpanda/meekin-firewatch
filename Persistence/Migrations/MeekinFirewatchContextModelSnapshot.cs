﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(MeekinFirewatchContext))]
    partial class MeekinFirewatchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Domain.Facebook.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Handle")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

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

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Domain.Facebook.Actual", b =>
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

            modelBuilder.Entity("Domain.Facebook.ExpandedLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Expanded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Original")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PostGuidId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostGuidId");

                    b.ToTable("ExpandedLink");
                });

            modelBuilder.Entity("Domain.Facebook.Expected", b =>
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

            modelBuilder.Entity("Domain.Facebook.Medium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Full")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("PostGuidId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostGuidId");

                    b.ToTable("Medium");
                });

            modelBuilder.Entity("Domain.Facebook.Post", b =>
                {
                    b.Property<Guid>("GuidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("TEXT");

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

                    b.HasKey("GuidId");

                    b.HasIndex("AccountId");

                    b.HasIndex("StatisticsId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Facebook.Statistics", b =>
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

            modelBuilder.Entity("Domain.Facebook.ExpandedLink", b =>
                {
                    b.HasOne("Domain.Facebook.Post", null)
                        .WithMany("ExpandedLinks")
                        .HasForeignKey("PostGuidId");
                });

            modelBuilder.Entity("Domain.Facebook.Medium", b =>
                {
                    b.HasOne("Domain.Facebook.Post", null)
                        .WithMany("Media")
                        .HasForeignKey("PostGuidId");
                });

            modelBuilder.Entity("Domain.Facebook.Post", b =>
                {
                    b.HasOne("Domain.Facebook.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("Domain.Facebook.Statistics", "Statistics")
                        .WithMany()
                        .HasForeignKey("StatisticsId");

                    b.Navigation("Account");

                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("Domain.Facebook.Statistics", b =>
                {
                    b.HasOne("Domain.Facebook.Actual", "Actual")
                        .WithMany()
                        .HasForeignKey("ActualId");

                    b.HasOne("Domain.Facebook.Expected", "Expected")
                        .WithMany()
                        .HasForeignKey("ExpectedId");

                    b.Navigation("Actual");

                    b.Navigation("Expected");
                });

            modelBuilder.Entity("Domain.Facebook.Post", b =>
                {
                    b.Navigation("ExpandedLinks");

                    b.Navigation("Media");
                });
#pragma warning restore 612, 618
        }
    }
}
