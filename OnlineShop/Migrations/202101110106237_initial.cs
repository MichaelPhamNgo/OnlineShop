namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertisementPage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdvertisementPosition",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PageId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Page", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Advertisement",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 250),
                        Image = c.String(maxLength: 250),
                        Url = c.String(maxLength: 250),
                        PostionId = c.Long(),
                        SortOrder = c.Int(),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvertisementPosition", t => t.PostionId)
                .Index(t => t.PostionId);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        Content = c.String(maxLength: 2000),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Announcement",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Content = c.String(maxLength: 250),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnnouncementUser",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AnnouncementId = c.Long(nullable: false),
                        UserId = c.Guid(nullable: false),
                        HasRead = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Announcement", t => t.AnnouncementId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.AnnouncementId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 256),
                        SecurityStamp = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(nullable: false, maxLength: 256),
                        LastName = c.String(nullable: false, maxLength: 256),
                        MiddleName = c.String(maxLength: 256),
                        Email = c.String(nullable: false),
                        EmailConfirm = c.Boolean(nullable: false),
                        Phone = c.String(maxLength: 50),
                        Birthday = c.DateTime(),
                        Address1 = c.String(maxLength: 256),
                        Address2 = c.String(maxLength: 256),
                        City = c.String(maxLength: 100),
                        ZipCode = c.String(maxLength: 10),
                        State = c.String(maxLength: 10),
                        Status = c.Int(),
                        RegisteredDate = c.DateTime(),
                        LockoutEnabled = c.Boolean(),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        Avatar = c.String(maxLength: 250),
                        AccessFailedCount = c.Int(),
                        UserGroupId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserGroup", t => t.UserGroupId, cascadeDelete: true)
                .Index(t => t.UserGroupId);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Credential",
                c => new
                    {
                        UserGroupId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserGroupId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserGroup", t => t.UserGroupId, cascadeDelete: true)
                .Index(t => t.UserGroupId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillDetail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BillId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ColorId = c.Long(nullable: false),
                        SizeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bill", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Color", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Size", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.BillId)
                .Index(t => t.ProductId)
                .Index(t => t.ColorId)
                .Index(t => t.SizeId);
            
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 256),
                        CustomerAddress = c.String(maxLength: 256),
                        CustomerMobile = c.String(nullable: false, maxLength: 50),
                        CustomerMessage = c.String(maxLength: 256),
                        PaymentMethod = c.Int(),
                        BillStatus = c.Int(),
                        CustomerId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 256),
                        LastName = c.String(nullable: false, maxLength: 256),
                        MiddleName = c.String(maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Address1 = c.String(maxLength: 256),
                        Address2 = c.String(maxLength: 256),
                        City = c.String(maxLength: 100),
                        ZipCode = c.String(maxLength: 10),
                        State = c.String(maxLength: 10),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Code = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductQuantity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        SizeId = c.Long(nullable: false),
                        ColorId = c.Long(nullable: false),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Color", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Size", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SizeId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 256),
                        ProductCategoryId = c.Long(nullable: false),
                        Content = c.String(unicode: false, storeType: "text"),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        Tags = c.String(maxLength: 2000),
                        Unit = c.String(maxLength: 256),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        Status = c.Int(),
                        SeoPageTitle = c.String(maxLength: 256),
                        SeoAlias = c.String(maxLength: 256),
                        SeoKeywords = c.String(maxLength: 256),
                        SeoDescription = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 2000),
                        Description = c.String(maxLength: 2000),
                        ParentId = c.Long(),
                        HomeOrder = c.Int(),
                        Image = c.String(maxLength: 2000),
                        SortOrder = c.Int(),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        Status = c.Int(),
                        SeoPageTitle = c.String(maxLength: 256),
                        SeoAlias = c.String(maxLength: 256),
                        SeoKeywords = c.String(maxLength: 256),
                        SeoDescription = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Path = c.String(maxLength: 256),
                        Caption = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        TagId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BlogId = c.Long(nullable: false),
                        TagId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.BlogId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Description = c.String(maxLength: 500),
                        Content = c.String(unicode: false, storeType: "text"),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        Tags = c.String(maxLength: 2000),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        Status = c.Int(),
                        SeoPageTitle = c.String(maxLength: 256),
                        SeoAlias = c.String(maxLength: 256),
                        SeoKeywords = c.String(maxLength: 256),
                        SeoDescription = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WholePrice",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        FromQuantity = c.Int(),
                        ToQuantity = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 256),
                        Website = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        Other = c.String(maxLength: 2000),
                        Lat = c.Double(),
                        Lng = c.Double(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 250),
                        Message = c.String(maxLength: 500),
                        DateCreated = c.DateTime(),
                        DateModified = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Function",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        URL = c.String(nullable: false, maxLength: 256),
                        ParentId = c.Long(),
                        IconCss = c.String(maxLength: 256),
                        SortOrder = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 128, unicode: false),
                        Name = c.String(nullable: false, maxLength: 128, unicode: false),
                        isDefault = c.Boolean(),
                        Resources = c.String(maxLength: 2000),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        SortOrder = c.Int(),
                        Status = c.Int(),
                        Content = c.String(unicode: false, storeType: "text"),
                        GroupAlias = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 255, unicode: false),
                        Name = c.String(maxLength: 128, unicode: false),
                        Value1 = c.String(unicode: false, storeType: "text"),
                        Value2 = c.Int(),
                        Value3 = c.Boolean(),
                        Value4 = c.DateTime(),
                        Value5 = c.Decimal(precision: 18, scale: 2),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillDetail", "SizeId", "dbo.Size");
            DropForeignKey("dbo.BillDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.BillDetail", "ColorId", "dbo.Color");
            DropForeignKey("dbo.ProductQuantity", "SizeId", "dbo.Size");
            DropForeignKey("dbo.ProductQuantity", "ProductId", "dbo.Product");
            DropForeignKey("dbo.WholePrice", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.BlogTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.BlogTag", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.ProductTag", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductImage", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductQuantity", "ColorId", "dbo.Color");
            DropForeignKey("dbo.BillDetail", "BillId", "dbo.Bill");
            DropForeignKey("dbo.Bill", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.AnnouncementUser", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "UserGroupId", "dbo.UserGroup");
            DropForeignKey("dbo.Credential", "UserGroupId", "dbo.UserGroup");
            DropForeignKey("dbo.Credential", "RoleId", "dbo.Role");
            DropForeignKey("dbo.AnnouncementUser", "AnnouncementId", "dbo.Announcement");
            DropForeignKey("dbo.AdvertisementPosition", "PageId", "dbo.Page");
            DropForeignKey("dbo.Advertisement", "PostionId", "dbo.AdvertisementPosition");
            DropIndex("dbo.WholePrice", new[] { "ProductId" });
            DropIndex("dbo.BlogTag", new[] { "TagId" });
            DropIndex("dbo.BlogTag", new[] { "BlogId" });
            DropIndex("dbo.ProductTag", new[] { "TagId" });
            DropIndex("dbo.ProductTag", new[] { "ProductId" });
            DropIndex("dbo.ProductImage", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            DropIndex("dbo.ProductQuantity", new[] { "ColorId" });
            DropIndex("dbo.ProductQuantity", new[] { "SizeId" });
            DropIndex("dbo.ProductQuantity", new[] { "ProductId" });
            DropIndex("dbo.Bill", new[] { "CustomerId" });
            DropIndex("dbo.BillDetail", new[] { "SizeId" });
            DropIndex("dbo.BillDetail", new[] { "ColorId" });
            DropIndex("dbo.BillDetail", new[] { "ProductId" });
            DropIndex("dbo.BillDetail", new[] { "BillId" });
            DropIndex("dbo.Credential", new[] { "RoleId" });
            DropIndex("dbo.Credential", new[] { "UserGroupId" });
            DropIndex("dbo.User", new[] { "UserGroupId" });
            DropIndex("dbo.AnnouncementUser", new[] { "UserId" });
            DropIndex("dbo.AnnouncementUser", new[] { "AnnouncementId" });
            DropIndex("dbo.Advertisement", new[] { "PostionId" });
            DropIndex("dbo.AdvertisementPosition", new[] { "PageId" });
            DropTable("dbo.SystemConfig");
            DropTable("dbo.Slide");
            DropTable("dbo.Language");
            DropTable("dbo.Function");
            DropTable("dbo.Footer");
            DropTable("dbo.Feedback");
            DropTable("dbo.Contact");
            DropTable("dbo.Size");
            DropTable("dbo.WholePrice");
            DropTable("dbo.Blog");
            DropTable("dbo.BlogTag");
            DropTable("dbo.Tag");
            DropTable("dbo.ProductTag");
            DropTable("dbo.ProductImage");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.ProductQuantity");
            DropTable("dbo.Color");
            DropTable("dbo.Customer");
            DropTable("dbo.Bill");
            DropTable("dbo.BillDetail");
            DropTable("dbo.Role");
            DropTable("dbo.Credential");
            DropTable("dbo.UserGroup");
            DropTable("dbo.User");
            DropTable("dbo.AnnouncementUser");
            DropTable("dbo.Announcement");
            DropTable("dbo.Page");
            DropTable("dbo.Advertisement");
            DropTable("dbo.AdvertisementPosition");
            DropTable("dbo.AdvertisementPage");
        }
    }
}
