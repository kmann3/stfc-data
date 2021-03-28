using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STFC_Web.Data.migrations
{
    public partial class _000init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RankResourceCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActiveNanoprobes = table.Column<int>(type: "INTEGER", nullable: true),
                    IndependantCredits = table.Column<int>(type: "INTEGER", nullable: true),
                    FederationCredits = table.Column<int>(type: "INTEGER", nullable: true),
                    RomulanCredits = table.Column<int>(type: "INTEGER", nullable: true),
                    KlingonCredits = table.Column<int>(type: "INTEGER", nullable: true),
                    CommandBadges = table.Column<int>(type: "INTEGER", nullable: true),
                    EngineeringBadges = table.Column<int>(type: "INTEGER", nullable: true),
                    ScienceBadges = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankResourceCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rarities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClassId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FactionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    GroupId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RarityId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SynergyCommand = table.Column<int>(type: "INTEGER", nullable: true),
                    SynergyEngineering = table.Column<int>(type: "INTEGER", nullable: true),
                    SynergyScience = table.Column<int>(type: "INTEGER", nullable: true),
                    RankName_1_5 = table.Column<string>(type: "TEXT", nullable: true),
                    RankShardsReq_1_5 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankXP_1_5 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankResourceCost_1_5Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    RankName_6_10 = table.Column<string>(type: "TEXT", nullable: true),
                    RankShardsReq_6_10 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankXP_6_10 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankResourceCost_6_10Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    RankName_11_15 = table.Column<string>(type: "TEXT", nullable: true),
                    RankShardsReq_11_15 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankXP_11_15 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankResourceCost_11_15Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    RankName_16_20 = table.Column<string>(type: "TEXT", nullable: true),
                    RankShardsReq_16_20 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankXP_16_20 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankResourceCost_16_20Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    RankName_21_30 = table.Column<string>(type: "TEXT", nullable: true),
                    RankShardsReq_21_30 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankXP_21_30 = table.Column<int>(type: "INTEGER", nullable: true),
                    RankResourceCost_21_30Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    CaptainManeuverName = table.Column<string>(type: "TEXT", nullable: true),
                    CaptainManeuverDescription = table.Column<string>(type: "TEXT", nullable: true),
                    OfficerAbilityName = table.Column<string>(type: "TEXT", nullable: true),
                    OfficerAbilityDescription = table.Column<string>(type: "TEXT", nullable: true),
                    OfficerAbilityRank1Value = table.Column<int>(type: "INTEGER", nullable: true),
                    OfficerAbilityRank2Value = table.Column<int>(type: "INTEGER", nullable: true),
                    OfficerAbilityRank3Value = table.Column<int>(type: "INTEGER", nullable: true),
                    OfficerAbilityRank4Value = table.Column<int>(type: "INTEGER", nullable: true),
                    OfficerAbilityRank5Value = table.Column<int>(type: "INTEGER", nullable: true),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Officers_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_RankResourceCosts_RankResourceCost_1_5Id",
                        column: x => x.RankResourceCost_1_5Id,
                        principalTable: "RankResourceCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_RankResourceCosts_RankResourceCost_11_15Id",
                        column: x => x.RankResourceCost_11_15Id,
                        principalTable: "RankResourceCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_RankResourceCosts_RankResourceCost_16_20Id",
                        column: x => x.RankResourceCost_16_20Id,
                        principalTable: "RankResourceCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_RankResourceCosts_RankResourceCost_21_30Id",
                        column: x => x.RankResourceCost_21_30Id,
                        principalTable: "RankResourceCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_RankResourceCosts_RankResourceCost_6_10Id",
                        column: x => x.RankResourceCost_6_10Id,
                        principalTable: "RankResourceCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_Rarities_RarityId",
                        column: x => x.RarityId,
                        principalTable: "Rarities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Link_Officer_Tag",
                columns: table => new
                {
                    OfficersId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_Officer_Tag", x => new { x.OfficersId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_Link_Officer_Tag_Officers_OfficersId",
                        column: x => x.OfficersId,
                        principalTable: "Officers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_Officer_Tag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74ca91c4-7c0f-4ddd-8866-982d672b9f67", "a1889811-d030-4a18-b7a0-31d17638d54b", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Name",
                table: "Classes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factions_Name",
                table: "Factions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_Officer_Tag_TagsId",
                table: "Link_Officer_Tag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_ClassId",
                table: "Officers",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_FactionId",
                table: "Officers",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_GroupId",
                table: "Officers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_Name",
                table: "Officers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Officers_RankResourceCost_1_5Id",
                table: "Officers",
                column: "RankResourceCost_1_5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_RankResourceCost_11_15Id",
                table: "Officers",
                column: "RankResourceCost_11_15Id");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_RankResourceCost_16_20Id",
                table: "Officers",
                column: "RankResourceCost_16_20Id");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_RankResourceCost_21_30Id",
                table: "Officers",
                column: "RankResourceCost_21_30Id");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_RankResourceCost_6_10Id",
                table: "Officers",
                column: "RankResourceCost_6_10Id");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_RarityId",
                table: "Officers",
                column: "RarityId");

            migrationBuilder.CreateIndex(
                name: "IX_RankResourceCosts_Name",
                table: "RankResourceCosts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rarities_Name",
                table: "Rarities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "Link_Officer_Tag");

            migrationBuilder.DropTable(
                name: "Officers");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "RankResourceCosts");

            migrationBuilder.DropTable(
                name: "Rarities");
        }
    }
}
