using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasKey(o =>o.Id);

            //ö��ת��
            builder.Property(o => o.Status)
                   .HasColumnName("Status")
                   .HasConversion<string>()
                   .HasMaxLength(16);

            //ȱʡ����
            builder.Property(o => o.CreatedOnUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            // Configure OrderId as FK 
            builder.HasOne(o => o.DetailedOrder)
                   .WithOne()
                   .HasForeignKey<DetailedOrder>(od => od.Id);//�������������

            //DetailedOrder���в�����ǣ�Order������в������,�ɴ���һ��Ӱ��״̬
            builder.Property<byte[]>("Version")
                   .IsRowVersion()
                   .HasColumnName("Version");
        }
    }
}
