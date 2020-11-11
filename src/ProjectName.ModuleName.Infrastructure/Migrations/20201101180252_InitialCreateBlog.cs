using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectName.ModuleName.Infrastructure.Migrations
{
    public partial class InitialCreateBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BlogSample");

            migrationBuilder.CreateTable(
                name: "Blog",
                schema: "BlogSample",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostStatus",
                schema: "BlogSample",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "BlogSample",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "BlogSample",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    BlogId1 = table.Column<Guid>(nullable: true),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Blog_BlogId1",
                        column: x => x.BlogId1,
                        principalSchema: "BlogSample",
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_PostStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "BlogSample",
                        principalTable: "PostStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                schema: "BlogSample",
                columns: table => new
                {
                    PostId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTag_Tag_PostId",
                        column: x => x.PostId,
                        principalSchema: "BlogSample",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Post_TagId",
                        column: x => x.TagId,
                        principalSchema: "BlogSample",
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_BlogId1",
                schema: "BlogSample",
                table: "Post",
                column: "BlogId1");

            migrationBuilder.CreateIndex(
                name: "IX_Post_StatusId",
                schema: "BlogSample",
                table: "Post",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagId",
                schema: "BlogSample",
                table: "PostTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTag",
                schema: "BlogSample");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "BlogSample");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "BlogSample");

            migrationBuilder.DropTable(
                name: "Blog",
                schema: "BlogSample");

            migrationBuilder.DropTable(
                name: "PostStatus",
                schema: "BlogSample");
        }
    }
}
