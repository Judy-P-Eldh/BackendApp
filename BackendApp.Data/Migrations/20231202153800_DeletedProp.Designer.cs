﻿// <auto-generated />
using System;
using BackendApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendApp.Data.Migrations
{
    [DbContext(typeof(BackenAppContext))]
    [Migration("20231202153800_DeletedProp")]
    partial class DeletedProp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("BackendApp.Core.Enteties.Account", b =>
                {
                    b.Property<Guid>("Account_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "account_id");

                    b.Property<int>("Balance")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "balance");

                    b.HasKey("Account_id");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("BackendApp.Core.Enteties.Transaction", b =>
                {
                    b.Property<Guid>("Transaction_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "transaction_id");

                    b.Property<Guid>("Account_id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "account_id");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "amount");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.HasKey("Transaction_id");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("BackendApp.Core.Enteties.TransactionRequest", b =>
                {
                    b.Property<Guid>("Request_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Account_id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "account_id");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "amount");

                    b.Property<Guid>("Transaction_id")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "transaction_id");

                    b.HasKey("Request_id");

                    b.ToTable("Requests", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
