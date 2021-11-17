﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
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
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Domain.Facebook.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccountType")
                        .HasColumnType("text");

                    b.Property<string>("Handle")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PageAdminTopCountry")
                        .HasColumnType("text");

                    b.Property<string>("PageCategory")
                        .HasColumnType("text");

                    b.Property<string>("PageCreatedDate")
                        .HasColumnType("text");

                    b.Property<string>("PageDescription")
                        .HasColumnType("text");

                    b.Property<string>("Platform")
                        .HasColumnType("text");

                    b.Property<string>("PlatformId")
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.Property<int>("SubscriberCount")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<bool>("Verified")
                        .HasColumnType("boolean");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Domain.Facebook.Actual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AngryCount")
                        .HasColumnType("integer");

                    b.Property<int>("CareCount")
                        .HasColumnType("integer");

                    b.Property<int>("CommentCount")
                        .HasColumnType("integer");

                    b.Property<int>("HahaCount")
                        .HasColumnType("integer");

                    b.Property<int>("LikeCount")
                        .HasColumnType("integer");

                    b.Property<int>("LoveCount")
                        .HasColumnType("integer");

                    b.Property<int>("SadCount")
                        .HasColumnType("integer");

                    b.Property<int>("ShareCount")
                        .HasColumnType("integer");

                    b.Property<int>("ThankfulCount")
                        .HasColumnType("integer");

                    b.Property<int>("WowCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Actual");
                });

            modelBuilder.Entity("Domain.Facebook.ExpandedLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Expanded")
                        .HasColumnType("text");

                    b.Property<string>("Original")
                        .HasColumnType("text");

                    b.Property<Guid?>("PostGuidId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PostGuidId");

                    b.ToTable("ExpandedLink");
                });

            modelBuilder.Entity("Domain.Facebook.Expected", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AngryCount")
                        .HasColumnType("integer");

                    b.Property<int>("CareCount")
                        .HasColumnType("integer");

                    b.Property<int>("CommentCount")
                        .HasColumnType("integer");

                    b.Property<int>("HahaCount")
                        .HasColumnType("integer");

                    b.Property<int>("LikeCount")
                        .HasColumnType("integer");

                    b.Property<int>("LoveCount")
                        .HasColumnType("integer");

                    b.Property<int>("SadCount")
                        .HasColumnType("integer");

                    b.Property<int>("ShareCount")
                        .HasColumnType("integer");

                    b.Property<int>("ThankfulCount")
                        .HasColumnType("integer");

                    b.Property<int>("WowCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Expected");
                });

            modelBuilder.Entity("Domain.Facebook.Medium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Full")
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<Guid?>("PostGuidId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostGuidId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Domain.Facebook.Pagination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("NextPage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pagination");
                });

            modelBuilder.Entity("Domain.Facebook.Post", b =>
                {
                    b.Property<Guid>("GuidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<string>("Caption")
                        .HasColumnType("text");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("text");

                    b.Property<int?>("LegacyId")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("Platform")
                        .HasColumnType("text");

                    b.Property<string>("PlatformId")
                        .HasColumnType("text");

                    b.Property<string>("PostUrl")
                        .HasColumnType("text");

                    b.Property<int?>("ResultId")
                        .HasColumnType("integer");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<int?>("StatisticsId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriberCount")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("Updated")
                        .HasColumnType("text");

                    b.Property<int?>("VideoLengthMS")
                        .HasColumnType("integer");

                    b.HasKey("GuidId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ResultId");

                    b.HasIndex("StatisticsId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Facebook.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PaginationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PaginationId");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("Domain.Facebook.Root", b =>
                {
                    b.Property<Guid>("RootId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("ResultId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("RootId");

                    b.HasIndex("ResultId");

                    b.ToTable("Roots");
                });

            modelBuilder.Entity("Domain.Facebook.Statistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ActualId")
                        .HasColumnType("integer");

                    b.Property<int?>("ExpectedId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActualId");

                    b.HasIndex("ExpectedId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("Domain.PostLabeling", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnalysisDate")
                        .HasColumnType("text");

                    b.Property<string>("AnalysisReport")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("text");

                    b.Property<string>("DecisionDate")
                        .HasColumnType("text");

                    b.Property<string>("FacebookDecision")
                        .HasColumnType("text");

                    b.Property<Guid>("FacebookGuid")
                        .HasColumnType("uuid");

                    b.Property<bool>("HumanTarget")
                        .HasColumnType("boolean");

                    b.Property<int?>("Intent")
                        .HasColumnType("integer");

                    b.Property<string[]>("Justifications")
                        .HasColumnType("text[]");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("OrganizationId")
                        .HasColumnType("text");

                    b.Property<double>("RabatLikelihoodHarm")
                        .HasColumnType("double precision");

                    b.Property<string>("Speaker")
                        .HasColumnType("text");

                    b.Property<string>("SpeechContent")
                        .HasColumnType("text");

                    b.Property<string>("SummaryAnalysis")
                        .HasColumnType("text");

                    b.Property<string>("TranslatedSpeechContent")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("platformId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PostLabelings");
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

                    b.HasOne("Domain.Facebook.Result", null)
                        .WithMany("Posts")
                        .HasForeignKey("ResultId");

                    b.HasOne("Domain.Facebook.Statistics", "Statistics")
                        .WithMany()
                        .HasForeignKey("StatisticsId");

                    b.Navigation("Account");

                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("Domain.Facebook.Result", b =>
                {
                    b.HasOne("Domain.Facebook.Pagination", "Pagination")
                        .WithMany()
                        .HasForeignKey("PaginationId");

                    b.Navigation("Pagination");
                });

            modelBuilder.Entity("Domain.Facebook.Root", b =>
                {
                    b.HasOne("Domain.Facebook.Result", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId");

                    b.Navigation("Result");
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

            modelBuilder.Entity("Domain.Facebook.Result", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
