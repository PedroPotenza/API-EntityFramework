// <auto-generated />
using System;
using API_EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_EntityFramework.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211104123358_Fix_v2")]
    partial class Fix_v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_EntityFramework.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("client");
                });

            modelBuilder.Entity("API_EntityFramework.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.HasKey("ContractId");

                    b.HasIndex("PlanId");

                    b.ToTable("contract");
                });

            modelBuilder.Entity("API_EntityFramework.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("genre");
                });

            modelBuilder.Entity("API_EntityFramework.Models.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.HasKey("HistoryId");

                    b.HasIndex("ContractId")
                        .IsUnique();

                    b.ToTable("history");
                });

            modelBuilder.Entity("API_EntityFramework.Models.HistoryRegister", b =>
                {
                    b.Property<int>("HistoryRegisterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HistoryId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StopTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("WatchDate")
                        .HasColumnType("datetime2");

                    b.HasKey("HistoryRegisterId");

                    b.HasIndex("HistoryId");

                    b.HasIndex("MovieId");

                    b.ToTable("historyRegister");
                });

            modelBuilder.Entity("API_EntityFramework.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("movie");
                });

            modelBuilder.Entity("API_EntityFramework.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Download")
                        .HasColumnType("bit");

                    b.Property<double>("LoyaltyFine")
                        .HasColumnType("float");

                    b.Property<int>("LoyaltyFineTime")
                        .HasColumnType("int");

                    b.Property<int>("MaxMovies")
                        .HasColumnType("int");

                    b.Property<string>("MaxQuality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxSimultaneousDevices")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("PlanId");

                    b.ToTable("plan");
                });

            modelBuilder.Entity("API_EntityFramework.Models.Contract", b =>
                {
                    b.HasOne("API_EntityFramework.Models.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("API_EntityFramework.Models.Genre", b =>
                {
                    b.HasOne("API_EntityFramework.Models.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("API_EntityFramework.Models.History", b =>
                {
                    b.HasOne("API_EntityFramework.Models.Contract", "Contract")
                        .WithOne("History")
                        .HasForeignKey("API_EntityFramework.Models.History", "ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("API_EntityFramework.Models.HistoryRegister", b =>
                {
                    b.HasOne("API_EntityFramework.Models.History", "History")
                        .WithMany()
                        .HasForeignKey("HistoryId");

                    b.HasOne("API_EntityFramework.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.Navigation("History");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("API_EntityFramework.Models.Contract", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("API_EntityFramework.Models.Movie", b =>
                {
                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
