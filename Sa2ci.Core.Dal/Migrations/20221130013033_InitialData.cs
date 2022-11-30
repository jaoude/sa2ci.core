using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sa2ci.Core.Dal.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"
                INSERT INTO ROLE (ID, [Name]) VALUES('76e45f8d-2d21-4695-867a-a83f12e3622d', 'Owner')
                GO
                INSERT INTO ROLE (ID, [Name]) VALUES('f483253a-39f0-4503-ad07-42e0e7a86577', 'Editor')
                GO
                INSERT INTO ROLE (ID, [Name]) VALUES('af1dd184-5396-4363-b1c6-0a14a60ae5d4', 'Viewer')
                GO
                INSERT INTO [USER] (ID, [Name], Email, Password) VALUES('a9d30c96-ec0a-4a5e-86b1-0ada26c7724b', 'Sassine Jaoude', 'sassine.jaoude@hotmail.com', 'BCB15F821479B4D5772BD0CA866C00AD5F926E3580720659CC80D39C9D09802A') -- 111111 
                GO
                INSERT INTO USERROLE (USERID, ROLEID) VALUES('a9d30c96-ec0a-4a5e-86b1-0ada26c7724b', '76e45f8d-2d21-4695-867a-a83f12e3622d')
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
           @"
                DELETE FROM USERROLE
                GO
                DELETE FROM ROLE
                GO
                DELETE FROM [USER]
            ");
        }
    }
}
