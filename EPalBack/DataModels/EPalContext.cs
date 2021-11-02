using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class EPalContext : DbContext
    {
        public EPalContext()
        {
        }

        public EPalContext(DbContextOptions<EPalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chatlist> Chatlists { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentDetail> CommentDetails { get; set; }
        public virtual DbSet<Following> Followings { get; set; }
        public virtual DbSet<GameCategory> GameCategories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LineStatus> LineStatuses { get; set; }
        public virtual DbSet<LiveChat> LiveChats { get; set; }
        public virtual DbSet<MeetLike> MeetLikes { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPlan> ProductPlans { get; set; }
        public virtual DbSet<ProductPosition> ProductPositions { get; set; }
        public virtual DbSet<ProductServer> ProductServers { get; set; }
        public virtual DbSet<ProductStyle> ProductStyles { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<RecentVistor> RecentVistors { get; set; }
        public virtual DbSet<SatisfyTag> SatisfyTags { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Style> Styles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=bs-2021-tpe-summer.database.windows.net;Database=EPal;User ID=bs;Password=3U7hzk5f8Bzm;Trusted_Connection=True;Integrated Security=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chatlist>(entity =>
            {
                entity.ToTable("Chatlist");

                entity.Property(e => e.SendOrReceiveDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.MessageType)
                    .WithMany(p => p.Chatlists)
                    .HasForeignKey(d => d.MessageTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chatlist_MessageType");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.ChatlistReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK_Chatlist_ReceiverId");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.ChatlistSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chatlist_SenderId");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.HasOne(d => d.CommentDetail)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommentDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_CommentDetails");

                entity.HasOne(d => d.SatisfyTag)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.SatisfyTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_SatisfyTag");
            });

            modelBuilder.Entity<CommentDetail>(entity =>
            {
                entity.Property(e => e.CommentDate).HasColumnType("date");

                entity.Property(e => e.CommentUpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CommentDetails)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentDetails_Members");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CommentDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentDetails_Products");
            });

            modelBuilder.Entity<Following>(entity =>
            {
                entity.HasKey(e => e.FollowId);

                entity.HasOne(d => d.FollowingNavigation)
                    .WithMany(p => p.FollowingFollowingNavigations)
                    .HasForeignKey(d => d.FollowingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Followings_Following");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.FollowingMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Followings_Members");
            });

            modelBuilder.Entity<GameCategory>(entity =>
            {
                entity.Property(e => e.GameCoverImg).IsRequired();

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LineStatus>(entity =>
            {
                entity.ToTable("LineStatus");

                entity.Property(e => e.LineStatusName)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LiveChat>(entity =>
            {
                entity.ToTable("LiveChat");

                entity.Property(e => e.LiveMessageContent).IsRequired();

                entity.Property(e => e.LiveMessageDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.LiveMessageType)
                    .WithMany(p => p.LiveChats)
                    .HasForeignKey(d => d.LiveMessageTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LiveChat_MessageType");

                entity.HasOne(d => d.LiveReceiver)
                    .WithMany(p => p.LiveChatLiveReceivers)
                    .HasForeignKey(d => d.LiveReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LiveChat_LiveReceiverId");

                entity.HasOne(d => d.LiveSender)
                    .WithMany(p => p.LiveChatLiveSenders)
                    .HasForeignKey(d => d.LiveSenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LiveChat_LiveSenderId");
            });

            modelBuilder.Entity<MeetLike>(entity =>
            {
                entity.HasOne(d => d.Like)
                    .WithMany(p => p.MeetLikeLikes)
                    .HasForeignKey(d => d.LikeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetLikes_LikeId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MeetLikeMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetLikes_MemberId");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasComment("true表示已從epal網站註冊成為會員");

                entity.HasIndex(e => e.CityId, "IX_CityId");

                entity.HasIndex(e => e.LanguageId, "IX_LanguageId");

                entity.Property(e => e.AuthCode)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fbid).HasColumnName("FBId");

                entity.Property(e => e.MemberName).HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Members_Cities");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Members_Language");

                entity.HasOne(d => d.LineStatus)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.LineStatusId)
                    .HasConstraintName("FK_Members_LineStatus");
            });

            modelBuilder.Entity<MessageType>(entity =>
            {
                entity.ToTable("MessageType");

                entity.Property(e => e.MessageTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DesiredStartTime).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GameEndDateTime).HasColumnType("datetime");

                entity.Property(e => e.GameStartTime).HasColumnType("datetime");

                entity.Property(e => e.OrderConfirmation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Members");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.OrderOrderStatuses)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK_Orders_OrderStatus");

                entity.HasOne(d => d.OrderStatusIdCreatorNavigation)
                    .WithMany(p => p.OrderOrderStatusIdCreatorNavigations)
                    .HasForeignKey(d => d.OrderStatusIdCreator)
                    .HasConstraintName("FK_Orders_OrderStatus1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Products");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.OrderStatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.TransactionUid)
                    .IsRequired()
                    .HasColumnName("TransactionUID");

                entity.Property(e => e.TransationDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Orders1");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreatorImg).IsRequired();

                entity.Property(e => e.Introduction).IsRequired();

                entity.Property(e => e.ProductImg).IsRequired();

                entity.Property(e => e.RecommendationVoice).IsRequired();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Members");

                entity.HasOne(d => d.GameCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.GameCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_GameCategories");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_Products_Rank");
            });

            modelBuilder.Entity<ProductPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId);

                entity.Property(e => e.GameAvailableDay).HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPlans)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPlans_Products");
            });

            modelBuilder.Entity<ProductPosition>(entity =>
            {
                entity.ToTable("ProductPosition");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.ProductPositions)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPosition_Position");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPositions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPosition_Products");
            });

            modelBuilder.Entity<ProductServer>(entity =>
            {
                entity.ToTable("ProductServer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductServers)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductServer_Products1");

                entity.HasOne(d => d.Server)
                    .WithMany(p => p.ProductServers)
                    .HasForeignKey(d => d.ServerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductServer_Server");
            });

            modelBuilder.Entity<ProductStyle>(entity =>
            {
                entity.ToTable("ProductStyle");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductStyles)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductStyle_Products");

                entity.HasOne(d => d.Style)
                    .WithMany(p => p.ProductStyles)
                    .HasForeignKey(d => d.StyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductStyle_Style");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("Rank");

                entity.Property(e => e.RankName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RecentVistor>(entity =>
            {
                entity.HasKey(e => e.VistorId);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.RecentVistorMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecentVistors_MemberId");

                entity.HasOne(d => d.RecentVistorNavigation)
                    .WithMany(p => p.RecentVistorRecentVistorNavigations)
                    .HasForeignKey(d => d.RecentVistorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecentVistors_RecentVistor");
            });

            modelBuilder.Entity<SatisfyTag>(entity =>
            {
                entity.ToTable("SatisfyTag");

                entity.Property(e => e.SatisfyTagName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server");

                entity.Property(e => e.ServerName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("Style");

                entity.Property(e => e.StyleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
