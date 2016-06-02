using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DeadlockSample.SqlServer;

namespace DeadlockSample.Migrations
{
    [DbContext(typeof(SampleContext))]
    [Migration("20160602045944_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeadlockSample.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonId");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DeadlockSample.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressOneId");

                    b.Property<int?>("AddressTwoId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AddressOneId");

                    b.HasIndex("AddressTwoId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DeadlockSample.Model.Address", b =>
                {
                    b.HasOne("DeadlockSample.Model.Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("DeadlockSample.Model.Person", b =>
                {
                    b.HasOne("DeadlockSample.Model.Address")
                        .WithMany()
                        .HasForeignKey("AddressOneId");

                    b.HasOne("DeadlockSample.Model.Address")
                        .WithMany()
                        .HasForeignKey("AddressTwoId");
                });
        }
    }
}
