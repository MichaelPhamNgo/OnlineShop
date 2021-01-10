namespace DBGeneration.Migrations
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
                        Name = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Page", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Advertisement",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        Description = c.String(maxLength: 250, storeType: "nvarchar"),
                        Image = c.String(maxLength: 250, storeType: "nvarchar"),
                        Url = c.String(maxLength: 250, storeType: "nvarchar"),
                        PostionId = c.Long(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvertisementPosition", t => t.PostionId, cascadeDelete: true)
                .Index(t => t.PostionId);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Alias = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Content = c.String(maxLength: 2000, storeType: "nvarchar"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Announcement",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        Content = c.String(maxLength: 250, storeType: "nvarchar"),
                        UserId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AnnouncementUser",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AnnouncementId = c.Long(nullable: false),
                        UserId = c.Guid(nullable: false),
                        HasRead = c.Boolean(nullable: false),
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
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        PasswordHash = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        SecurityStamp = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        FirstName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        LastName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        MiddleName = c.String(maxLength: 256, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        EmailConfirm = c.Boolean(nullable: false),
                        Phone = c.String(maxLength: 50, storeType: "nvarchar"),
                        Birthday = c.DateTime(precision: 0),
                        Address1 = c.String(maxLength: 256, storeType: "nvarchar"),
                        Address2 = c.String(maxLength: 256, storeType: "nvarchar"),
                        City = c.String(maxLength: 100, storeType: "nvarchar"),
                        ZipCode = c.String(maxLength: 10, storeType: "nvarchar"),
                        State = c.String(maxLength: 10, storeType: "nvarchar"),
                        LastLogin = c.DateTime(nullable: false, precision: 0),
                        LoginAttempt = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
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
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        CustomerName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        CustomerAddress = c.String(maxLength: 256, storeType: "nvarchar"),
                        CustomerMobile = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        CustomerMessage = c.String(maxLength: 256, storeType: "nvarchar"),
                        PaymentMethod = c.Int(nullable: false),
                        BillStatus = c.Int(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        LastName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        MiddleName = c.String(maxLength: 256, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        Phone = c.String(maxLength: 50, storeType: "nvarchar"),
                        Address1 = c.String(maxLength: 256, storeType: "nvarchar"),
                        Address2 = c.String(maxLength: 256, storeType: "nvarchar"),
                        City = c.String(maxLength: 100, storeType: "nvarchar"),
                        ZipCode = c.String(maxLength: 10, storeType: "nvarchar"),
                        State = c.String(maxLength: 10, storeType: "nvarchar"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Code = c.String(maxLength: 256, storeType: "nvarchar"),
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
                        Quantity = c.Int(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Image = c.String(maxLength: 256, storeType: "nvarchar"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 256, storeType: "nvarchar"),
                        ProductCategoryId = c.Long(nullable: false),
                        Content = c.String(unicode: false, storeType: "text"),
                        HomeFlag = c.Boolean(nullable: false),
                        HotFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Tags = c.String(maxLength: 2000, storeType: "nvarchar"),
                        Unit = c.String(maxLength: 256, storeType: "nvarchar"),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                        SeoPageTitle = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoAlias = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoKeywords = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoDescription = c.String(maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 2000, storeType: "nvarchar"),
                        Description = c.String(maxLength: 2000, storeType: "nvarchar"),
                        ParentId = c.Long(),
                        HomeOrder = c.Int(nullable: false),
                        Image = c.String(maxLength: 2000, storeType: "nvarchar"),
                        SortOrder = c.Int(),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                        SeoPageTitle = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoAlias = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoKeywords = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoDescription = c.String(maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Path = c.String(maxLength: 256, storeType: "nvarchar"),
                        Caption = c.String(maxLength: 256, storeType: "nvarchar"),
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
                        Name = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Type = c.String(maxLength: 50, storeType: "nvarchar"),
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
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Image = c.String(maxLength: 256, storeType: "nvarchar"),
                        Description = c.String(maxLength: 500, storeType: "nvarchar"),
                        Content = c.String(unicode: false, storeType: "text"),
                        HomeFlag = c.Boolean(nullable: false),
                        HotFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Tags = c.String(maxLength: 2000, storeType: "nvarchar"),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                        SeoPageTitle = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoAlias = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoKeywords = c.String(maxLength: 256, storeType: "nvarchar"),
                        SeoDescription = c.String(maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WholePrice",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        FromQuantity = c.Int(nullable: false),
                        ToQuantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Phone = c.String(maxLength: 50, storeType: "nvarchar"),
                        Website = c.String(maxLength: 256, storeType: "nvarchar"),
                        Address = c.String(maxLength: 256, storeType: "nvarchar"),
                        Other = c.String(maxLength: 2000, storeType: "nvarchar"),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        Phone = c.String(maxLength: 50, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        Message = c.String(maxLength: 500, storeType: "nvarchar"),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        DateModified = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Content = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Function",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        URL = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        ParentId = c.Long(),
                        IconCss = c.String(maxLength: 256, storeType: "nvarchar"),
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
                        isDefault = c.Boolean(nullable: false),
                        Resources = c.String(maxLength: 2000, storeType: "nvarchar"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Description = c.String(maxLength: 256, storeType: "nvarchar"),
                        Image = c.String(maxLength: 256, storeType: "nvarchar"),
                        Url = c.String(maxLength: 256, storeType: "nvarchar"),
                        SortOrder = c.Int(),
                        Status = c.Int(nullable: false),
                        Content = c.String(unicode: false, storeType: "text"),
                        GroupAlias = c.String(maxLength: 25, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 255, unicode: false),
                        Name = c.String(maxLength: 128, unicode: false),
                        Value1 = c.String(unicode: false, storeType: "text"),
                        Value2 = c.Int(nullable: false),
                        Value3 = c.Boolean(nullable: false),
                        Value4 = c.DateTime(nullable: false, precision: 0),
                        Value5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
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
            DropForeignKey("dbo.Announcement", "UserId", "dbo.User");
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
            DropIndex("dbo.Announcement", new[] { "UserId" });
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
