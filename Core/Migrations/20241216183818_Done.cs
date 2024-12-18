using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Done : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TermTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TestTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserDictionaryStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDictionaryStatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    term = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.id);
                    table.ForeignKey(
                        name: "FK_Terms_TermTypes_termTypeId",
                        column: x => x.termTypeId,
                        principalTable: "TermTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_UserStatuses_userStatusId",
                        column: x => x.userStatusId,
                        principalTable: "UserStatuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDictionarys",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    termId = table.Column<int>(type: "int", nullable: false),
                    lastTestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserDictionaryStatusid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDictionarys", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserDictionarys_Terms_termId",
                        column: x => x.termId,
                        principalTable: "Terms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDictionarys_UserDictionaryStatuses_UserDictionaryStatusid",
                        column: x => x.UserDictionaryStatusid,
                        principalTable: "UserDictionaryStatuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordList", x => x.id);
                    table.ForeignKey(
                        name: "FK_WordList_Users_createdBy",
                        column: x => x.createdBy,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    TestTypeid = table.Column<int>(type: "int", nullable: false),
                    WordListid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tests_TestTypes_TestTypeid",
                        column: x => x.TestTypeid,
                        principalTable: "TestTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tests_WordList_WordListid",
                        column: x => x.WordListid,
                        principalTable: "WordList",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDictionaryWordList",
                columns: table => new
                {
                    UserDictionaryid = table.Column<int>(type: "int", nullable: false),
                    WordListid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDictionaryWordList", x => new { x.UserDictionaryid, x.WordListid });
                    table.ForeignKey(
                        name: "FK_UserDictionaryWordList_UserDictionarys_UserDictionaryid",
                        column: x => x.UserDictionaryid,
                        principalTable: "UserDictionarys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDictionaryWordList_WordList_WordListid",
                        column: x => x.WordListid,
                        principalTable: "WordList",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testId = table.Column<int>(type: "int", nullable: false),
                    resultPercent = table.Column<double>(type: "float", nullable: false),
                    finishTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.id);
                    table.ForeignKey(
                        name: "FK_Results_Tests_testId",
                        column: x => x.testId,
                        principalTable: "Tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_testId",
                table: "Results",
                column: "testId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_termTypeId",
                table: "Terms",
                column: "termTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestTypeid",
                table: "Tests",
                column: "TestTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_WordListid",
                table: "Tests",
                column: "WordListid");

            migrationBuilder.CreateIndex(
                name: "IX_UserDictionarys_termId",
                table: "UserDictionarys",
                column: "termId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDictionarys_UserDictionaryStatusid",
                table: "UserDictionarys",
                column: "UserDictionaryStatusid");

            migrationBuilder.CreateIndex(
                name: "IX_UserDictionaryWordList_WordListid",
                table: "UserDictionaryWordList",
                column: "WordListid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userStatusId",
                table: "Users",
                column: "userStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WordList_createdBy",
                table: "WordList",
                column: "createdBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "UserDictionaryWordList");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "UserDictionarys");

            migrationBuilder.DropTable(
                name: "TestTypes");

            migrationBuilder.DropTable(
                name: "WordList");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "UserDictionaryStatuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TermTypes");

            migrationBuilder.DropTable(
                name: "UserStatuses");
        }
    }
}
