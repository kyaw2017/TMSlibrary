using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace TMSLibrary.Class
{
    public class DebtorMap : EntityTypeConfiguration<Debtor>
    {
        public DebtorMap()
        {
            this.ToTable("Debtors");
            this.HasKey(Debtor => Debtor.user_id);
            this.Property(Debtor => Debtor.user_name);
            this.Property(Debtor => Debtor.user_password);
            this.Property(Debtor => Debtor.internet_access);
            this.Property(Debtor => Debtor.user_desc);
            this.Property(Debtor => Debtor.cur_list);
        }
    }
}
