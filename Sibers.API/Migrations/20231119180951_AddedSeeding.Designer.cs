﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sibers.WebAPI.IdentityData;

#nullable disable

namespace Sibers.WebAPI.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20231119180951_AddedSeeding")]
    partial class AddedSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            RoleId = 3L
                        },
                        new
                        {
                            UserId = 2L,
                            RoleId = 2L
                        },
                        new
                        {
                            UserId = 3L,
                            RoleId = 2L
                        },
                        new
                        {
                            UserId = 4L,
                            RoleId = 1L
                        },
                        new
                        {
                            UserId = 5L,
                            RoleId = 1L
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Sibers.WebAPI.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConcurrencyStamp = "2ad76e65-7c86-4f99-a114-71f31273b7c4",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = 2L,
                            ConcurrencyStamp = "081dcfd8-12d8-4388-b7b4-daaf5976354e",
                            Name = "ProjectManager",
                            NormalizedName = "PROJECTMANAGER"
                        },
                        new
                        {
                            Id = 3L,
                            ConcurrencyStamp = "08f5de56-c928-439d-8104-3f59dae51200",
                            Name = "Leader",
                            NormalizedName = "LEADER"
                        });
                });

            modelBuilder.Entity("Sibers.WebAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ac381681-2ee4-474f-ba5c-f359da39bd92",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            EmployeeId = 1L,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEC+H9NDVp77SJd7LdAx11rIlinqohK78JwFVNJpOBSRLUxJZzI5pWvAfzVZd02VL4g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "977e39d0-b9fb-4705-b16d-b0aae24f2d85",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "89ca9276-7d66-4367-b455-cd67f3cd6d46",
                            Email = "ProjectManager@gmail.com",
                            EmailConfirmed = false,
                            EmployeeId = 2L,
                            LockoutEnabled = false,
                            NormalizedUserName = "PROJECTMANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEAtnhnUQP2l5RApCFK1mAyfnTEqUdtnPSCRVzHOJeQKWPWXiStM25S00O5/ivQXvtg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "afa67302-7b0e-4381-bbce-10e573cdb7b4",
                            TwoFactorEnabled = false,
                            UserName = "ProjectManager"
                        },
                        new
                        {
                            Id = 3L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "693eab96-10fc-4c92-96a8-ff06bfa51924",
                            Email = "FreeProjectManager@gmail.com",
                            EmailConfirmed = false,
                            EmployeeId = 3L,
                            LockoutEnabled = false,
                            NormalizedUserName = "FREEPROJECTMANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEL7VxFq3oT7w8JdQo5VoC4S9RzWLpuQjK2Al6WAwGTf9K82yqU2aSMTswtJsHOtxgw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2b417e84-0612-4be0-b70f-dc37540d9ff6",
                            TwoFactorEnabled = false,
                            UserName = "FreeProjectManager"
                        },
                        new
                        {
                            Id = 4L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b9b1e3f1-b1bd-423f-bafd-f1f0f3e7a828",
                            Email = "Employee@gmail.com",
                            EmailConfirmed = false,
                            EmployeeId = 4L,
                            LockoutEnabled = false,
                            NormalizedUserName = "EMPLOYEE",
                            PasswordHash = "AQAAAAEAACcQAAAAEOAYi8sYYsW5IkCzGGxNhILuQf3+seM53uxfG58e69X+N/ZEtowdEm8+Hjttmip4pQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "abf6738e-80c8-43f0-af13-e735268bf3a8",
                            TwoFactorEnabled = false,
                            UserName = "Employee"
                        },
                        new
                        {
                            Id = 5L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a8c7c87a-ddec-492a-a5d4-e3d5f6dc5d36",
                            Email = "FreeEmployee@gmail.com",
                            EmailConfirmed = false,
                            EmployeeId = 5L,
                            LockoutEnabled = false,
                            NormalizedUserName = "FREEEMPLOYEE",
                            PasswordHash = "AQAAAAEAACcQAAAAENUqp7TB7pSJZ8dXOxd4aceB2TN9mjAydTaaXZkRIp+oofPs0YvQgWvbeY+mpiakBA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cf645e9f-36d6-4cbc-b239-e19405a09f0a",
                            TwoFactorEnabled = false,
                            UserName = "FreeEmployee"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Sibers.WebAPI.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("Sibers.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("Sibers.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Sibers.WebAPI.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sibers.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("Sibers.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
