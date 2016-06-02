using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeadlockSample.Migrations
{
    public partial class RemovedNullableAddressesIdFromPersonEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressOneId1",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressTwoId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AddressOneId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AddressTwoId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AddressOneId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AddressTwoId1",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressOneId",
                table: "Persons",
                column: "AddressOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressTwoId",
                table: "Persons",
                column: "AddressTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressOneId",
                table: "Persons",
                column: "AddressOneId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressTwoId",
                table: "Persons",
                column: "AddressTwoId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressOneId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressTwoId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AddressOneId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AddressTwoId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "AddressOneId1",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressTwoId1",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressOneId1",
                table: "Persons",
                column: "AddressOneId1");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressTwoId1",
                table: "Persons",
                column: "AddressTwoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressOneId1",
                table: "Persons",
                column: "AddressOneId1",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressTwoId1",
                table: "Persons",
                column: "AddressTwoId1",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
