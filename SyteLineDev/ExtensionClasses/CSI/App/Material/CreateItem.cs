//PROJECT NAME: CSIMaterial
//CLASS NAME: CreateItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICreateItem
    {
        int CreateItemSp(ItemType Item,
                         DescriptionType Description,
                         RevisionType Revision,
                         UMType UM,
                         ProductCodeType ProductCode,
                         ref JobType Job,
                         ref SuffixType Suffix,
                         ref JobTypeType JobType,
                         ref InfobarType Infobar);
    }

    public class CreateItem : ICreateItem
    {
        readonly IApplicationDB appDB;

        public CreateItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CreateItemSp(ItemType Item,
                                DescriptionType Description,
                                RevisionType Revision,
                                UMType UM,
                                ProductCodeType ProductCode,
                                ref JobType Job,
                                ref SuffixType Suffix,
                                ref JobTypeType JobType,
                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateItemSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Description", Description, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Revision", Revision, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProductCode", ProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobType", JobType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
