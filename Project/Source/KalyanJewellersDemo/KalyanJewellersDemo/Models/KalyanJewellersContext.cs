using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class KalyanJewellersContext : DbContext
    {
        public KalyanJewellersContext()
        {
        }

        public KalyanJewellersContext(DbContextOptions<KalyanJewellersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<DiamondDetail> DiamondDetails { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<JewelleryType> JewelleryTypes { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderAddress> OrderAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDesign> ProductDesigns { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<TblObject> TblObjects { get; set; }
        public virtual DbSet<TblType> TblTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-18JEBP4\\SQLEXPRESS;Database=KalyanJewellers;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Cart__UserID__14270015");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.ToTable("CartDetail");

                entity.Property(e => e.CartDetailId).HasColumnName("CartDetailID");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__CartDetai__CartI__17F790F9");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__CartDetai__Produ__18EBB532");
            });

            modelBuilder.Entity<DiamondDetail>(entity =>
            {
                entity.HasKey(e => e.DiamondDetailsId)
                    .HasName("PK__DiamondD__73F8596416EB3FD1");

                entity.Property(e => e.DiamondDetailsId).HasColumnName("DiamondDetailsID");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProductDetailsId).HasColumnName("ProductDetailsID");

                entity.Property(e => e.SettingType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Shape)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClarityNavigation)
                    .WithMany(p => p.DiamondDetails)
                    .HasForeignKey(d => d.Clarity)
                    .HasConstraintName("FK__DiamondDe__Clari__44CA3770");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProductDetailsId).HasColumnName("ProductDetailsID");

                entity.HasOne(d => d.ProductDetails)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.ProductDetailsId)
                    .HasConstraintName("FK_Discount_ProductDetails");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.ImagesId)
                    .HasName("PK__Images__0E2E80DF1121CBCD");

                entity.Property(e => e.ImagesId).HasColumnName("ImagesID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("ImageURL");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProductDetailsId).HasColumnName("ProductDetailsID");

                entity.HasOne(d => d.ProductDetails)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductDetailsId)
                    .HasConstraintName("FK_Images_ProductDetails");
            });

            modelBuilder.Entity<JewelleryType>(entity =>
            {
                entity.ToTable("JewelleryType");

                entity.Property(e => e.JewelleryTypeId).HasColumnName("JewelleryTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.JewelleryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.MaterialType)
                    .WithMany(p => p.JewelleryTypes)
                    .HasForeignKey(d => d.MaterialTypeId)
                    .HasConstraintName("FK__Jewellery__Mater__6B24EA82");
            });

            modelBuilder.Entity<MaterialType>(entity =>
            {
                entity.ToTable("MaterialType");

                entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.MaterialName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrdersId)
                    .HasName("PK__Orders__630B995694DD4532");

                entity.Property(e => e.OrdersId).HasColumnName("OrdersID");

                entity.Property(e => e.CartDetailId).HasColumnName("CartDetailID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.OrderAddressId).HasColumnName("OrderAddressID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CartDetail)
                    .WithMany(p => p.OrderCartDetails)
                    .HasForeignKey(d => d.CartDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__CartDeta__2180FB33");

                entity.HasOne(d => d.OrderAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__OrderAdd__22751F6C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserID__208CD6FA");
            });

            modelBuilder.Entity<OrderAddress>(entity =>
            {
                entity.ToTable("OrderAddress");

                entity.Property(e => e.OrderAddressId).HasColumnName("OrderAddressID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderAddr__UserI__1CBC4616");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SKU");
            });

            modelBuilder.Entity<ProductDesign>(entity =>
            {
                entity.ToTable("ProductDesign");

                entity.Property(e => e.ProductDesignId).HasColumnName("ProductDesignID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.DesignName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JewelleryTypeId).HasColumnName("JewelleryTypeID");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.JewelleryType)
                    .WithMany(p => p.ProductDesigns)
                    .HasForeignKey(d => d.JewelleryTypeId)
                    .HasConstraintName("FK__ProductDe__Jewel__6EF57B66");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasKey(e => e.ProductDetailsId)
                    .HasName("PK__ProductD__2991D8BF8FE2D985");

                entity.Property(e => e.ProductDetailsId).HasColumnName("ProductDetailsID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MetalWeight).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PcreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("PCreatedDate")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ProductDesignId).HasColumnName("ProductDesignID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Size)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.Property(e => e.StyleNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalWeight).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.MetalColorNavigation)
                    .WithMany(p => p.ProductDetailMetalColorNavigations)
                    .HasForeignKey(d => d.MetalColor)
                    .HasConstraintName("FK_ProductDetails_TblObject1");

                entity.HasOne(d => d.MetalpurityNavigation)
                    .WithMany(p => p.ProductDetailMetalpurityNavigations)
                    .HasForeignKey(d => d.Metalpurity)
                    .HasConstraintName("FK_ProductDetails_TblObject2");

                entity.HasOne(d => d.ProductDesign)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductDesignId)
                    .HasConstraintName("FK_ProductDetails_ProductDesign");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductDe__Produ__3A4CA8FD");

                entity.HasOne(d => d.ProductStatusNavigation)
                    .WithMany(p => p.ProductDetailProductStatusNavigations)
                    .HasForeignKey(d => d.ProductStatus)
                    .HasConstraintName("FK_ProductDetails_TblObject3");

                entity.HasOne(d => d.UserCategoryNavigation)
                    .WithMany(p => p.ProductDetailUserCategoryNavigations)
                    .HasForeignKey(d => d.UserCategory)
                    .HasConstraintName("FK_ProductDetails_TblObject");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.HasKey(e => e.SubscribersId)
                    .HasName("PK__Subscrib__D3B28E02885E1B5C");

                entity.Property(e => e.SubscribersId).HasColumnName("SubscribersID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<TblObject>(entity =>
            {
                entity.ToTable("TblObject");

                entity.Property(e => e.TblObjectId).HasColumnName("TblObjectID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ObjectValue)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TblTypeId).HasColumnName("TblTypeID");

                entity.HasOne(d => d.TblType)
                    .WithMany(p => p.TblObjects)
                    .HasForeignKey(d => d.TblTypeId)
                    .HasConstraintName("FK__TblObject__TblTy__367C1819");
            });

            modelBuilder.Entity<TblType>(entity =>
            {
                entity.ToTable("TblType");

                entity.Property(e => e.TblTypeId).HasColumnName("TblTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Users__A349B0425058E7D9");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.AlternateMobileNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AnniversaryDate).HasColumnType("date");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubscribersId).HasColumnName("SubscribersID");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('User')");

                entity.HasOne(d => d.Subscribers)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SubscribersId)
                    .HasConstraintName("FK__Users__Subscribe__4D94879B");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.Property(e => e.WishListId).HasColumnName("WishListID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__WishList__Produc__10566F31");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__WishList__UserID__0F624AF8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
