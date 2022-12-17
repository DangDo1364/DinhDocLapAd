using Microsoft.EntityFrameworkCore.Migrations;

namespace DinhDocLapAdmin.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockType",
                columns: table => new
                {
                    IDBT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colorEdge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockType", x => x.IDBT);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    IDBD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buildingDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.IDBD);
                });

            migrationBuilder.CreateTable(
                name: "Face",
                columns: table => new
                {
                    IDF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Face", x => x.IDF);
                });

            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    IDN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    x = table.Column<double>(type: "float", nullable: false),
                    y = table.Column<double>(type: "float", nullable: false),
                    z = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.IDN);
                });

            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    IDB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDBT = table.Column<int>(type: "int", nullable: false),
                    blockDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDBD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.IDB);
                    table.ForeignKey(
                        name: "FK_Block_BlockType_IDBT",
                        column: x => x.IDBT,
                        principalTable: "BlockType",
                        principalColumn: "IDBT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Block_Building_IDBD",
                        column: x => x.IDBD,
                        principalTable: "Building",
                        principalColumn: "IDBD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaceNode",
                columns: table => new
                {
                    IDF = table.Column<int>(type: "int", nullable: false),
                    IDN = table.Column<int>(type: "int", nullable: false),
                    seq = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceNode", x => new { x.IDF, x.IDN });
                    table.ForeignKey(
                        name: "FK_FaceNode_Face",
                        column: x => x.IDF,
                        principalTable: "Face",
                        principalColumn: "IDF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaceNode_Node",
                        column: x => x.IDN,
                        principalTable: "Node",
                        principalColumn: "IDN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaceBlock",
                columns: table => new
                {
                    IDF = table.Column<int>(type: "int", nullable: false),
                    IDB = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceBlock", x => new { x.IDF, x.IDB });
                    table.ForeignKey(
                        name: "FK_FaceBlock_Face",
                        column: x => x.IDF,
                        principalTable: "Face",
                        principalColumn: "IDF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaceBlock_Node",
                        column: x => x.IDB,
                        principalTable: "Block",
                        principalColumn: "IDB",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Block_IDBD",
                table: "Block",
                column: "IDBD");

            migrationBuilder.CreateIndex(
                name: "IX_Block_IDBT",
                table: "Block",
                column: "IDBT");

            migrationBuilder.CreateIndex(
                name: "IX_FaceBlock_IDB",
                table: "FaceBlock",
                column: "IDB");

            migrationBuilder.CreateIndex(
                name: "IX_FaceNode_IDN",
                table: "FaceNode",
                column: "IDN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaceBlock");

            migrationBuilder.DropTable(
                name: "FaceNode");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Face");

            migrationBuilder.DropTable(
                name: "Node");

            migrationBuilder.DropTable(
                name: "BlockType");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
