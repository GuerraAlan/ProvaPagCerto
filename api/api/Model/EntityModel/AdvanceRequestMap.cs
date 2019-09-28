using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Model.EntityModel
{
    public static class AdvanceRequestMap
    {
        public static void Map(this EntityTypeBuilder<AdvanceRequest> entity)
        {
            entity.ToTable(nameof(AdvanceRequest));

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.InitialDate).HasColumnType("Data_Solicitação").IsRequired();

            entity.HasOne(p => p.Transaction)
                .WithMany(p => p.AdvanceRequests)
                .HasForeignKey(p => p.TransactionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.Property(p => p.Status).HasColumnName("Status").IsRequired();

            entity.Property(p => p.InitialAnalysisDate).HasColumnType("Data_Inicial_Analise");

            entity.Property(p => p.DoneAnalysisDate).HasColumnType("Data_Conclusao_Analise");

            entity.Property(p => p.InstallmentsAmount).HasColumnName("Numero_Parcelas").IsRequired();

            entity.Property(p => p.AnalysisResult).HasColumnType("Resultado_Analise");
        }
    }
}
