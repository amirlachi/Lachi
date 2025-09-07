using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lachi.Migrations
{
    /// <inheritdoc />
    public partial class UserChannelWithoutBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_AspNetUsers_CreatedById",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_AspNetUsers_RemovedById",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_AspNetUsers_UpdatedById",
                table: "UserChannels");

            migrationBuilder.DropIndex(
                name: "IX_UserChannels_CreatedById",
                table: "UserChannels");

            migrationBuilder.DropIndex(
                name: "IX_UserChannels_RemovedById",
                table: "UserChannels");

            migrationBuilder.DropIndex(
                name: "IX_UserChannels_UpdatedById",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "UserChannels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "UserChannels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserChannels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserChannels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "UserChannels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RemovedById",
                table: "UserChannels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "UserChannels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "UserChannels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserChannels_CreatedById",
                table: "UserChannels",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserChannels_RemovedById",
                table: "UserChannels",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserChannels_UpdatedById",
                table: "UserChannels",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_AspNetUsers_CreatedById",
                table: "UserChannels",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_AspNetUsers_RemovedById",
                table: "UserChannels",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_AspNetUsers_UpdatedById",
                table: "UserChannels",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
