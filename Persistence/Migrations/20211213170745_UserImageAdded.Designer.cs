// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(MeekinFirewatchContext))]
    [Migration("20211213170745_UserImageAdded")]
    partial class UserImageAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
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

            modelBuilder.Entity("Domain.Facebook.PostFollower", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPoster")
                        .HasColumnType("boolean");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostFollowers");
                });

            modelBuilder.Entity("Domain.Facebook.ReportReporter", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsAuthor")
                        .HasColumnType("boolean");

                    b.HasKey("UserId", "ReportId");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportReporters");
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

                    b.Property<string>("OriginalPostUrl")
                        .HasColumnType("text");

                    b.Property<double>("RabatLikelihoodHarm")
                        .HasColumnType("double precision");

                    b.Property<string>("Speaker")
                        .HasColumnType("text");

                    b.Property<string>("SpeechContent")
                        .HasColumnType("text");

                    b.Property<string>("SummaryAnalysis")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("platformId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PostLabelings");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Organization")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "600ef89e-3c66-4490-b084-a9abefe1f902",
                            ConcurrencyStamp = "ba5a697e-ed9a-4cbb-b974-ce796f267ef2",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        },
                        new
                        {
                            Id = "258d46d9-36ec-4744-a32c-51662d1165c4",
                            ConcurrencyStamp = "6145c4f2-f7c5-4a00-926b-8aa39cf3e7ee",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
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

            modelBuilder.Entity("Domain.Facebook.PostFollower", b =>
                {
                    b.HasOne("Domain.Facebook.Post", "Post")
                        .WithMany("PostFollowers")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Facebook.ReportReporter", b =>
                {
                    b.HasOne("Domain.PostLabeling", "Report")
                        .WithMany("Reporters")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");

                    b.Navigation("User");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Facebook.Post", b =>
                {
                    b.Navigation("ExpandedLinks");

                    b.Navigation("Media");

                    b.Navigation("PostFollowers");
                });

            modelBuilder.Entity("Domain.Facebook.Result", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Domain.PostLabeling", b =>
                {
                    b.Navigation("Reporters");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
