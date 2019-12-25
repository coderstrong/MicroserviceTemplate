using Microsoft.EntityFrameworkCore.Migrations;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Infrastructure.Migrations
{
    public partial class RunBlogSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("PostStatus", new string[] { "Id", "Name" }, new string[] { "1", "draft" }, BlogContext.DefaultSchema);
            migrationBuilder.InsertData("PostStatus", new string[] { "Id", "Name" }, new string[] { "2", "published" }, BlogContext.DefaultSchema);
            migrationBuilder.InsertData("PostStatus", new string[] { "Id", "Name" }, new string[] { "3", "deleted" }, BlogContext.DefaultSchema);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
