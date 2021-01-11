namespace OnlineShop.Migrations
{
    using global::Models;
    using global::Models.Entities;
    using global::Models.Enums;
    using OnlineShop.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDbContext context)
        {
            context.Colors.AddOrUpdate(x => x.Id,
                new Color() { Name = "Black", Code = "#000000" },
                new Color() { Name = "White", Code = "#FFFFFF" },
                new Color() { Name = "Red", Code = "#ff0000" },
                new Color() { Name = "Blue", Code = "#1000ff" }
            );

            context.Sizes.AddOrUpdate(x => x.Id,
                new Size() { Name = "XXL" },
                new Size() { Name = "XL" },
                new Size() { Name = "L" },
                new Size() { Name = "M" },
                new Size() { Name = "S" },
                new Size() { Name = "XS" }
            );

            context.Functions.AddOrUpdate(x => x.Id,
                new Function() { Id = 1, Name = "System", ParentId = null, SortOrder = 1, Status = Status.Active, URL = "/", IconCss = "fa-desktop" },
                new Function() { Id = 2, Name = "Role", ParentId = 1, SortOrder = 1, Status = Status.Active, URL = "/admin/role/index", IconCss = "fa-home" },
                new Function() { Id = 3, Name = "Function", ParentId = 1, SortOrder = 2, Status = Status.Active, URL = "/admin/function/index", IconCss = "fa-home" },
                new Function() { Id = 4, Name = "User", ParentId = 1, SortOrder = 3, Status = Status.Active, URL = "/admin/user/index", IconCss = "fa-home" },
                new Function() { Id = 5, Name = "Activity", ParentId = 1, SortOrder = 4, Status = Status.Active, URL = "/admin/activity/index", IconCss = "fa-home" },
                new Function() { Id = 6, Name = "Error", ParentId = 1, SortOrder = 5, Status = Status.Active, URL = "/admin/error/index", IconCss = "fa-home" },
                new Function() { Id = 7, Name = "Configuration", ParentId = 1, SortOrder = 6, Status = Status.Active, URL = "/admin/setting/index", IconCss = "fa-home" },
                new Function() { Id = 8, Name = "Product Management", ParentId = null, SortOrder = 2, Status = Status.Active, URL = "/", IconCss = "fa-chevron-down" },
                new Function() { Id = 9, Name = "Category", ParentId = 8, SortOrder = 1, Status = Status.Active, URL = "/admin/productcategory/index", IconCss = "fa-chevron-down" },
                new Function() { Id = 10, Name = "Product", ParentId = 8, SortOrder = 2, Status = Status.Active, URL = "/admin/product/index", IconCss = "fa-chevron-down" },
                new Function() { Id = 11, Name = "Bill", ParentId = 8, SortOrder = 3, Status = Status.Active, URL = "/admin/bill/index", IconCss = "fa-chevron-down" },
                new Function() { Id = 12, Name = "Content", ParentId = null, SortOrder = 3, Status = Status.Active, URL = "/", IconCss = "fa-table" },
                new Function() { Id = 13, Name = "Blog", ParentId = 12, SortOrder = 1, Status = Status.Active, URL = "/admin/blog/index", IconCss = "fa-table" },
                new Function() { Id = 14, Name = "Utilities", ParentId = null, SortOrder = 4, Status = Status.Active, URL = "/", IconCss = "fa-clone" },
                new Function() { Id = 15, Name = "Footer", ParentId = 14, SortOrder = 1, Status = Status.Active, URL = "/admin/footer/index", IconCss = "fa-clone" },
                new Function() { Id = 16, Name = "Feedback", ParentId = 14, SortOrder = 2, Status = Status.Active, URL = "/admin/feedback/index", IconCss = "fa-clone" },
                new Function() { Id = 17, Name = "Announcement", ParentId = 14, SortOrder = 3, Status = Status.Active, URL = "/admin/announcement/index", IconCss = "fa-clone" },
                new Function() { Id = 18, Name = "Contact", ParentId = 14, SortOrder = 4, Status = Status.Active, URL = "/admin/contact/index", IconCss = "fa-clone" },
                new Function() { Id = 19, Name = "Slide", ParentId = 14, SortOrder = 5, Status = Status.Active, URL = "/admin/slide/index", IconCss = "fa-clone" },
                new Function() { Id = 20, Name = "Advertisment", ParentId = 14, SortOrder = 6, Status = Status.Active, URL = "/admin/Advertisement/index", IconCss = "fa-clone" },
                new Function() { Id = 21, Name = "Report", ParentId = null, SortOrder = 5, Status = Status.Active, URL = "/", IconCss = "fa-bar-chart-o" },
                new Function() { Id = 22, Name = "Revenue report", ParentId = 21, SortOrder = 1, Status = Status.Active, URL = "/admin/report/revenues", IconCss = "fa-bar-chart-o" },
                new Function() { Id = 23, Name = "Visitor Report", ParentId = 21, SortOrder = 2, Status = Status.Active, URL = "/admin/report/visitor", IconCss = "fa-bar-chart-o" },
                new Function() { Id = 24, Name = "Reader Report", ParentId = 21, SortOrder = 3, Status = Status.Active, URL = "/admin/report/reader", IconCss = "fa-bar-chart-o" }
            );

            context.Contacts.AddOrUpdate(x => x.Id,
               new Contact()
               {
                   Id = 1,
                   Address = "7823 Pacific Ave",
                   Email = "michaelphamn@gmail.com",
                   Name = "Phone Shop",
                   Phone = "253 226 0523",
                   Status = Status.Active,
                   Website = "http://localhost",
                   Lat = 21.0435009,
                   Lng = 105.7894758
               }
            );

            context.Slides.AddOrUpdate(x => x.Id,
                new Slide() { Name = "Slide 1", Image = "/client-side/images/slider/slide-1.jpg", Url = "#", SortOrder = 0, GroupAlias = "top", Status = Status.Active },
                new Slide() { Name = "Slide 2", Image = "/client-side/images/slider/slide-2.jpg", Url = "#", SortOrder = 1, GroupAlias = "top", Status = Status.Active },
                new Slide() { Name = "Slide 3", Image = "/client-side/images/slider/slide-3.jpg", Url = "#", SortOrder = 2, GroupAlias = "top", Status = Status.Active },
                new Slide() { Name = "Slide 1", Image = "/client-side/images/brand1.png", Url = "#", SortOrder = 1, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 2", Image = "/client-side/images/brand2.png", Url = "#", SortOrder = 2, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 3", Image = "/client-side/images/brand3.png", Url = "#", SortOrder = 3, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 4", Image = "/client-side/images/brand4.png", Url = "#", SortOrder = 4, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 5", Image = "/client-side/images/brand5.png", Url = "#", SortOrder = 5, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 6", Image = "/client-side/images/brand6.png", Url = "#", SortOrder = 6, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 7", Image = "/client-side/images/brand7.png", Url = "#", SortOrder = 7, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 8", Image = "/client-side/images/brand8.png", Url = "#", SortOrder = 8, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 9", Image = "/client-side/images/brand9.png", Url = "#", SortOrder = 9, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 10", Image = "/client-side/images/brand10.png", Url = "#", SortOrder = 10, GroupAlias = "brand", Status = Status.Active },
                new Slide() { Name = "Slide 11", Image = "/client-side/images/brand11.png", Url = "#", SortOrder = 11, GroupAlias = "brand", Status = Status.Active }
            );


            context.ProductCategories.AddOrUpdate(x => x.Id,
                new ProductCategory()
                {
                    Name = "Men shirt",
                    SeoAlias = "men-shirt",
                    ParentId = null,
                    Status = Status.Active,
                    SortOrder = 1,
                    Products = new List<Product>()
                    {
                        new Product(){Name = "Product 1",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-1",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 2",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-2",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 3",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-3",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 4",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-4",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 5",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-5",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                    }
                }
                ,
                new ProductCategory()
                {
                    Name = "Women shirt",
                    SeoAlias = "women-shirt",
                    ParentId = null,
                    Status = Status.Active,
                    SortOrder = 2,
                    Products = new List<Product>()
                    {
                        new Product(){Name = "Product 6",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-6",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 7",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-7",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 8",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-8",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 9",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-9",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 10",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-10",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                    }
                },
                new ProductCategory()
                {
                    Name = "Men shoes",
                    SeoAlias = "men-shoes",
                    ParentId = null,
                    Status = Status.Active,
                    SortOrder = 3,
                    Products = new List<Product>()
                    {
                        new Product(){Name = "Product 11",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-11",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 12",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-12",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 13",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-13",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 14",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-14",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 15",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-15",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                    }
                },
                new ProductCategory()
                {
                    Name = "Woment shoes",
                    SeoAlias = "women-shoes",
                    ParentId = null,
                    Status = Status.Active,
                    SortOrder = 4,
                    Products = new List<Product>()
                    {
                        new Product(){Name = "Product 16",DateCreated=DateTime.Now, Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-16",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 17",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-17",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 18",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-18",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 19",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-19",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        new Product(){Name = "Product 20",DateCreated=DateTime.Now,Image="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-20",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                    }
                }
            );

            context.Roles.AddOrUpdate(x => x.Id,
                new Role()
                {
                    Id = 1,
                    Name = "VIEW_USER",
                    Description = "View User List",
                },
                new Role()
                {
                    Id = 2,
                    Name = "EDIT_USER",
                    Description = "Edit User",
                },
                new Role()
                {
                    Id = 3,
                    Name = "DELETE_USER",
                    Description = "Delete User",
                },
                new Role()
                {
                    Id = 4,
                    Name = "ADD_USER",
                    Description = "Add User",
                },
                new Role()
                {
                    Id = 5,
                    Name = "VIEW_USER_GROUP",
                    Description = "View Group List",
                },
                new Role()
                {
                    Id = 6,
                    Name = "EDIT_USER_GROUP",
                    Description = "Edit Group",
                },
                new Role()
                {
                    Id = 7,
                    Name = "DELETE_USER_GROUP",
                    Description = "Delete Group",
                },
                new Role()
                {
                    Id = 8,
                    Name = "ADD_USER_GROUP",
                    Description = "Add Group",
                },
                new Role()
                {
                    Id = 9,
                    Name = "VIEW_TAG",
                    Description = "View Tag List",
                },
                new Role()
                {
                    Id = 10,
                    Name = "EDIT_TAG",
                    Description = "Edit Tag",
                },
                new Role()
                {
                    Id = 11,
                    Name = "DELETE_TAG",
                    Description = "Delete Tag",
                },
                new Role()
                {
                    Id = 12,
                    Name = "ADD_TAG",
                    Description = "Add Tag",
                },
                new Role()
                {
                    Id = 13,
                    Name = "VIEW_PRODUCT",
                    Description = "View Product List",
                },
                new Role()
                {
                    Id = 14,
                    Name = "EDIT_PRODUCT",
                    Description = "Edit Product",
                },
                new Role()
                {
                    Id = 15,
                    Name = "DELETE_PRODUCT",
                    Description = "Delete Product",
                },
                new Role()
                {
                    Id = 16,
                    Name = "ADD_PRODUCT",
                    Description = "Add Product",
                },
                new Role()
                {
                    Id = 17,
                    Name = "VIEW_CATEGORY",
                    Description = "View Category List",
                },
                new Role()
                {
                    Id = 18,
                    Name = "EDIT_CATEGORY",
                    Description = "Edit Category",
                },
                new Role()
                {
                    Id = 19,
                    Name = "DELETE_CATEGORY",
                    Description = "Delete Category",
                },
                new Role()
                {
                    Id = 20,
                    Name = "ADD_CATEGORY",
                    Description = "Add Category",
                }

            );

            context.UserGroups.AddOrUpdate(x => x.Id,
                new UserGroup()
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Top manager",
                },
                new UserGroup()
                {
                    Id = 2,
                    Name = "Staff",
                    Description = "Staff",
                },
                new UserGroup()
                {
                    Id = 3,
                    Name = "Customer",
                    Description = "Customer",
                }
            );            

            string stamp = Guid.NewGuid().ToString();
            context.Users.AddOrUpdate(x => x.Id,
                new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    Password = Helper.EncodePassword("123654$", stamp),
                    SecurityStamp = stamp,
                    FirstName = "Michael",
                    LastName = "Pham",
                    Email = "michaelphamn@gmail.com",
                    EmailConfirm = true,
                    RegisteredDate = DateTime.Now,
                    Status = Status.Active,
                    UserGroupId = 1
                }
            );

            context.SystemConfigs.AddOrUpdate(x => x.Id,
                new SystemConfig()
                {
                    Id = "HomeTitle",
                    Name = "Home's title",
                    Value1 = "Tedu Shop home",
                    Status = Status.Active
                },
                new SystemConfig()
                {
                    Id = "HomeMetaKeyword",
                    Name = "Home Keyword",
                    Value1 = "shopping, sales",
                    Status = Status.Active
                },
                new SystemConfig()
                {
                    Id = "HomeMetaDescription",
                    Name = "Home Description",
                    Value1 = "Home tedu",
                    Status = Status.Active
                }
            );
        }
    }
}
