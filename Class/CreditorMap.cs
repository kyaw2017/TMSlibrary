using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace TMSLibrary.Class
{
    public class CreditorMap : EntityTypeConfiguration<Creditor>
    {
        public CreditorMap()
        {
            this.ToTable("Creditors");
            this.HasKey(Creditor => Creditor.user_id);
            this.Property(Creditor => Creditor.user_name);
            this.Property(Creditor => Creditor.user_password);
            this.Property(Creditor => Creditor.internet_access);
            this.Property(Creditor => Creditor.user_desc);
            this.Property(Creditor => Creditor.cur_list);
            this.Property(Creditor => Creditor.sup_pick_up_status);
            this.Property(Creditor => Creditor.sup_overwrite_policy_status);
            this.Property(Creditor => Creditor.sup_cross_season_rate);
            this.Property(Creditor => Creditor.Service_Point_List);
            this.Property(Creditor => Creditor.Amenities_List);
            this.Property(Creditor => Creditor.Sup_Room_Policy_List);
            this.Property(Creditor => Creditor.Sup_Age_Policy_List);
            this.Property(Creditor => Creditor.Sup_Stay_Start_On_List);
            this.Property(Creditor => Creditor.Sup_Stay_Must_Include_List);
        }
    }
}
