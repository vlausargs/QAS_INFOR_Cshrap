//PROJECT NAME: CSIMaterial
//CLASS NAME: CombineXferUMValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICombineXferUMValid
    {
        int CombineXferUMValidSp(UMType UM,
                                 TrnNumType TrnNum,
                                 TrnLineType TrnLine,
                                 ref UMConvFactorType UomConvFactor,
                                 ref QtyUnitType TQtyShipped,
                                 ref InfobarType Infobar);
    }

    public class CombineXferUMValid : ICombineXferUMValid
    {
        readonly IApplicationDB appDB;

        public CombineXferUMValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CombineXferUMValidSp(UMType UM,
                                        TrnNumType TrnNum,
                                        TrnLineType TrnLine,
                                        ref UMConvFactorType UomConvFactor,
                                        ref QtyUnitType TQtyShipped,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CombineXferUMValidSp";

                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TrnLine", TrnLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UomConvFactor", UomConvFactor, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TQtyShipped", TQtyShipped, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
