namespace DBGeneration.Migrations
{
    using DBGeneration.Entities;
    using DBGeneration.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DBGeneration.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DBGeneration.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Functions.AddOrUpdate(x => x.Id,
                new Function() { Id = 1, FunctionName = "System", ParentId = null, DisplayOrder = 1, Status = Status.Active, URL = "/", IconCss = "fa-desktop" },
                new Function() { Id = 2, FunctionName = "Role", ParentId = 1, DisplayOrder = 1, Status = Status.Active, URL = "/admin/role/index", IconCss = "fa-home" },
                new Function() { Id = 3, FunctionName = "Function", ParentId = 1, DisplayOrder = 2, Status = Status.Active, URL = "/admin/function/index", IconCss = "fa-home" },
                new Function() { Id = 4, FunctionName = "User", ParentId = 1, DisplayOrder = 3, Status = Status.Active, URL = "/admin/user/index", IconCss = "fa-home" },
                new Function() { Id = 5, FunctionName = "Activity", ParentId = 1, DisplayOrder = 4, Status = Status.Active, URL = "/admin/activity/index", IconCss = "fa-home" },
                new Function() { Id = 6, FunctionName = "Error", ParentId = 1, DisplayOrder = 5, Status = Status.Active, URL = "/admin/error/index", IconCss = "fa-home" },
                new Function() { Id = 7, FunctionName = "Configuration", ParentId = 1, DisplayOrder = 6, Status = Status.Active, URL = "/admin/setting/index", IconCss = "fa-home" },
                new Function() { Id = 8, FunctionName = "Product Management", ParentId = null, DisplayOrder = 2, Status = Status.Active, URL = "/", IconCss = "fa-chevron-down" },
                new Function() { Id = 9, FunctionName = "Category", ParentId = 8, DisplayOrder = 1, Status = Status.Active, URL = "/admin/productcategory/index", IconCss = "fa-chevron-down" },
                new Function() { Id = 10, FunctionName = "Product", ParentId = 8, DisplayOrder = 2, Status = Status.Active, URL = "/admin/product/index", IconCss = "fa-chevron-down" },
                new Function() { Id = 11, FunctionName = "Bill", ParentId = 8, DisplayOrder = 3, Status = Status.Active, URL = "/admin/bill/index", IconCss = "fa-chevron-down" },
                new Function() { Id = 12, FunctionName = "Content", ParentId = null, DisplayOrder = 3, Status = Status.Active, URL = "/", IconCss = "fa-table" },
                new Function() { Id = 13, FunctionName = "Blog", ParentId = 12, DisplayOrder = 1, Status = Status.Active, URL = "/admin/blog/index", IconCss = "fa-table" },
                new Function() { Id = 14, FunctionName = "Utilities", ParentId = null, DisplayOrder = 4, Status = Status.Active, URL = "/", IconCss = "fa-clone" },
                new Function() { Id = 15, FunctionName = "Footer", ParentId = 14, DisplayOrder = 1, Status = Status.Active, URL = "/admin/footer/index", IconCss = "fa-clone" },
                new Function() { Id = 16, FunctionName = "Feedback", ParentId = 14, DisplayOrder = 2, Status = Status.Active, URL = "/admin/feedback/index", IconCss = "fa-clone" },
                new Function() { Id = 17, FunctionName = "Announcement", ParentId = 14, DisplayOrder = 3, Status = Status.Active, URL = "/admin/announcement/index", IconCss = "fa-clone" },
                new Function() { Id = 18, FunctionName = "Contact", ParentId = 14, DisplayOrder = 4, Status = Status.Active, URL = "/admin/contact/index", IconCss = "fa-clone" },
                new Function() { Id = 19, FunctionName = "Slide", ParentId = 14, DisplayOrder = 5, Status = Status.Active, URL = "/admin/slide/index", IconCss = "fa-clone" },
                new Function() { Id = 20, FunctionName = "Advertisment", ParentId = 14, DisplayOrder = 6, Status = Status.Active, URL = "/admin/Advertisement/index", IconCss = "fa-clone" },
                new Function() { Id = 21, FunctionName = "Report", ParentId = null, DisplayOrder = 5, Status = Status.Active, URL = "/", IconCss = "fa-bar-chart-o" },
                new Function() { Id = 22, FunctionName = "Revenue report", ParentId = 21, DisplayOrder = 1, Status = Status.Active, URL = "/admin/report/revenues", IconCss = "fa-bar-chart-o" },
                new Function() { Id = 23, FunctionName = "Visitor Report", ParentId = 21, DisplayOrder = 2, Status = Status.Active, URL = "/admin/report/visitor", IconCss = "fa-bar-chart-o" },
                new Function() { Id = 24, FunctionName = "Reader Report", ParentId = 21, DisplayOrder = 3, Status = Status.Active, URL = "/admin/report/reader", IconCss = "fa-bar-chart-o" }
                );
        }
    }
}
