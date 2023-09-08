//PROJECT NAME: CSIMaterial
//CLASS NAME: EdiOutGPlnpo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEdiOutGPlnpo
    {
        int EdiOutGPlnpoSp(VendNumType BeginVendNum,
                           VendNumType EndVendNum,
                           ItemType BeginItem,
                           ItemType EndItem,
                           ref InfobarType Infobar);
    }

    public class EdiOutGPlnpo : IEdiOutGPlnpo
    {
        readonly IApplicationDB appDB;

        public EdiOutGPlnpo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EdiOutGPlnpoSp(VendNumType BeginVendNum,
                                  VendNumType EndVendNum,
                                  ItemType BeginItem,
                                  ItemType EndItem,
                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EdiOutGPlnpoSp";

                appDB.AddCommandParameter(cmd, "BeginVendNum", BeginVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndVendNum", EndVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BeginItem", BeginItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
