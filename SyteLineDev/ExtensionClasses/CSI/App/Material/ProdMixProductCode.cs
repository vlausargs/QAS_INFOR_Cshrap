//PROJECT NAME: CSIMaterial
//CLASS NAME: ProdMixProductCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IProdMixProductCode
    {
        int ProdMixProductCodeSp(ItemType LeadItem,
                                 ItemType ChildItem,
                                 ref InfobarType Infobar);
    }

    public class ProdMixProductCode : IProdMixProductCode
    {
        readonly IApplicationDB appDB;

        public ProdMixProductCode(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ProdMixProductCodeSp(ItemType LeadItem,
                                        ItemType ChildItem,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProdMixProductCodeSp";

                appDB.AddCommandParameter(cmd, "LeadItem", LeadItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ChildItem", ChildItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
