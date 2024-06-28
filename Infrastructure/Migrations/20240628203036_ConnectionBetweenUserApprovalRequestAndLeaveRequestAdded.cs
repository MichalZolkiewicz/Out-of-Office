using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionBetweenUserApprovalRequestAndLeaveRequestAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequests_AspNetUsers_UserId",
                table: "ApprovalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequests_Employees_ApproverId",
                table: "ApprovalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequests_ApproverId",
                table: "ApprovalRequests");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "LeaveRequests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ApprovalRequests",
                newName: "ApproverId1");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalRequests_UserId",
                table: "ApprovalRequests",
                newName: "IX_ApprovalRequests_ApproverId1");

            migrationBuilder.AddColumn<string>(
                name: "ProjectManagerId1",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "LeaveRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId1",
                table: "Projects",
                column: "ProjectManagerId1");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_UserId1",
                table: "LeaveRequests",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequests_AspNetUsers_ApproverId1",
                table: "ApprovalRequests",
                column: "ApproverId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_UserId1",
                table: "LeaveRequests",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectManagerId1",
                table: "Projects",
                column: "ProjectManagerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequests_AspNetUsers_ApproverId1",
                table: "ApprovalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_UserId1",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectManagerId1",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectManagerId1",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequests_UserId1",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "ProjectManagerId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "LeaveRequests");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LeaveRequests",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "ApproverId1",
                table: "ApprovalRequests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalRequests_ApproverId1",
                table: "ApprovalRequests",
                newName: "IX_ApprovalRequests_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_ApproverId",
                table: "ApprovalRequests",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequests_AspNetUsers_UserId",
                table: "ApprovalRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequests_Employees_ApproverId",
                table: "ApprovalRequests",
                column: "ApproverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
