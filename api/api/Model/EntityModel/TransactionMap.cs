using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.EntityModel
{
    public static class TransactionMap
    {
        public static void Map(this EntityTypeBuilder<Transaction> entity)
        {
            entity.ToTable(nameof(Transaction));

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.InitialDate).HasColumnType("Data_Efetuada").IsRequired();

            entity.Property(p => p.TransferDate).HasColumnType("Data_Repasse");

            entity.Property(p => p.AcquirerConfirmation).HasColumnName("Confirmacao_Adquirente");

            entity.Property(p => p.TransactionValue).HasColumnName("Valor_Transacao").IsRequired();

            entity.Property(p => p.InstallmentsAmount).HasColumnName("Numero_Parcelas").IsRequired();

            entity.Property(p => p.CardLastDigits).HasColumnName("Digitos_Cartao").IsRequired();

            entity.Property(p => p.TransferAmount).HasColumnName("Valor_Pago").IsRequired();

            entity.HasMany(p => p.AdvanceRequests)
                .WithOne(p => p.Transaction);
           
        }
    }
}
