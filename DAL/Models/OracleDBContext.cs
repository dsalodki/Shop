using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class OracleDBContext : DbContext
    {
        public OracleDBContext()
        {
        }

        public OracleDBContext(DbContextOptions<OracleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<DecommLog> DecommLogs { get; set; }
        public virtual DbSet<Dimension> Dimensions { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<GoodsCat> GoodsCats { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersList> OrdersLists { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("DATA SOURCE=localhost:1521;PASSWORD=aboba;USER ID=ABOBA");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ABOBA");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENTS");

                entity.HasIndex(e => e.Name, "I_CLIENTS_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Deleting)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DELETING")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<DecommLog>(entity =>
            {
                entity.ToTable("DECOMM_LOG");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.GoodsId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GOODS_ID");

                entity.Property(e => e.LogDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOG_DATE")
                    .HasDefaultValueSql("sysdate ");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("PRICE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Val)
                    .HasColumnType("NUMBER")
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("VAL")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.DecommLogs)
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DECOMM_LOG_FK_GOODS");
            });

            modelBuilder.Entity<Dimension>(entity =>
            {
                entity.ToTable("DIMENSION");

                entity.HasIndex(e => e.Name, "I_DIMENSION_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("GOODS");

                entity.HasIndex(e => e.DimensionId, "I_GOODS_DIMENSION");

                entity.HasIndex(e => e.GoodsCatId, "I_GOODS_GOODS_CAT");

                entity.HasIndex(e => e.ProviderId, "I_GOODS_PROVIDER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Decommissioned)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DECOMMISSIONED")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Delivery)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DELIVERY")
                    .HasDefaultValueSql("sysdate ");

                entity.Property(e => e.DimensionId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DIMENSION_ID");

                entity.Property(e => e.GoodsCatId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GOODS_CAT_ID");

                entity.Property(e => e.Idx)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDX");

                entity.Property(e => e.ImpPeriod)
                    .HasColumnType("NUMBER(38)")
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("IMP_PERIOD")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImpTime)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMP_TIME");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("PRICE")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProviderId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROVIDER_ID");

                entity.Property(e => e.Sale)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SALE")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Val)
                    .HasColumnType("NUMBER")
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("VAL")
                    .ValueGeneratedNever();

                entity.Property(e => e.ValDelivered)
                    .HasColumnType("NUMBER")
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("VAL_DELIVERED")
                    .ValueGeneratedNever();

                entity.Property(e => e.Weight)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEIGHT");

                entity.HasOne(d => d.Dimension)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.DimensionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GOODS_FK_DIMENSION");

                entity.HasOne(d => d.GoodsCat)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.GoodsCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GOODS_FK_GOODS_CAT");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("GOODS_FK_PROVIDER");
            });

            modelBuilder.Entity<GoodsCat>(entity =>
            {
                entity.ToTable("GOODS_CAT");

                entity.HasIndex(e => e.Name, "I_GOODS_CAT_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.ToTable("OPERATOR");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PWD");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ClientsId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CLIENTS_ID");

                entity.Property(e => e.Complete)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COMPLETE")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.OrdDate)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORD_DATE")
                    .HasDefaultValueSql("sysdate ");

                entity.HasOne(d => d.Clients)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ORDERS_FK_CLIENTS");
            });

            modelBuilder.Entity<OrdersList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ORDERS_LIST");

                entity.HasIndex(e => e.OrdersId, "I_ORDERS_LIST_1");

                entity.HasIndex(e => e.GoodsId, "I_ORDERS_LIST_2");

                entity.Property(e => e.GoodsId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GOODS_ID");

                entity.Property(e => e.OrdersId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDERS_ID");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("PRICE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Val)
                    .HasColumnType("NUMBER")
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("VAL")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Goods)
                    .WithMany()
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ORDERS_LIST_FK_GOODS");

                entity.HasOne(d => d.Orders)
                    .WithMany()
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ORDERS_LIST_FK_ORDERS");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("PROVIDER");

                entity.HasIndex(e => e.Name, "I_PROVIDER_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Deleting)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DELETING")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PHONE");
            });

            modelBuilder.HasSequence("OPERATOR_SEQ");

            modelBuilder.HasSequence("SEQ_CLIENTS");

            modelBuilder.HasSequence("SEQ_DECOMM_LOG");

            modelBuilder.HasSequence("SEQ_DIMENSION");

            modelBuilder.HasSequence("SEQ_GOODS");

            modelBuilder.HasSequence("SEQ_GOODS_CAT");

            modelBuilder.HasSequence("SEQ_ORDERS");

            modelBuilder.HasSequence("SEQ_PROVIDER");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
