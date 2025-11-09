using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedPropertiesAndAddEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "YearLevel",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "FinalGrade",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Enrollments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Teachers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Teachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearLevel",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Courses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Courses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Enrollments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Enrollments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalGrade",
                table: "Enrollments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Enrollments",
                type: "TEXT",
                nullable: true);
        }
    }
}
