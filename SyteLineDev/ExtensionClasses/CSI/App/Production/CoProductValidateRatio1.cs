//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductValidateRatio1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICoProductValidateRatio1
    {
        int CoProductValidateRatio1Sp(QtyUnitType PQtyReleased,
                                      TotalProdMixQuantityType PRatio1,
                                      JobType PJob,
                                      SuffixType PSuffix,
                                      ItemType PItem,
                                      ref TotalProdMixQuantityType PRatio2,
                                      ref InfobarType Infobar);
    }

    public class CoProductValidateRatio1 : ICoProductValidateRatio1
    {
        readonly IApplicationDB appDB;

        public CoProductValidateRatio1(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoProductValidateRatio1Sp(QtyUnitType PQtyReleased,
                                             TotalProdMixQuantityType PRatio1,
                                             JobType PJob,
                                             SuffixType PSuffix,
                                             ItemType PItem,
                                             ref TotalProdMixQuantityType PRatio2,
                                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoProductValidateRatio1Sp";

                appDB.AddCommandParameter(cmd, "PQtyReleased", PQtyReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRatio1", PRatio1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRatio2", PRatio2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
