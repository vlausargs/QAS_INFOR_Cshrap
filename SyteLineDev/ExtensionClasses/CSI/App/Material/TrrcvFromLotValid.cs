//PROJECT NAME: CSIMaterial
//CLASS NAME: TrrcvFromLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrrcvFromLotValid
    {
        int TrrcvFromLotValidSp(SiteType PSite,
                                WhseType PWhse,
                                ItemType PItem,
                                LocType PTrnLoc,
                                LotType PTrnLot,
                                TrnNumType PTrnNum,
                                TrnLineType PTrnLine,
                                FlagNyType PReturn,
                                UMConvFactorType PUomConvFactor,
                                ref LotType ToLot,
                                ref QtyUnitType PQty,
                                ref InfobarType Infobar);
    }

    public class TrrcvFromLotValid : ITrrcvFromLotValid
    {
        readonly IApplicationDB appDB;

        public TrrcvFromLotValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrrcvFromLotValidSp(SiteType PSite,
                                       WhseType PWhse,
                                       ItemType PItem,
                                       LocType PTrnLoc,
                                       LotType PTrnLot,
                                       TrnNumType PTrnNum,
                                       TrnLineType PTrnLine,
                                       FlagNyType PReturn,
                                       UMConvFactorType PUomConvFactor,
                                       ref LotType ToLot,
                                       ref QtyUnitType PQty,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrrcvFromLotValidSp";

                appDB.AddCommandParameter(cmd, "PSite", PSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnLoc", PTrnLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnLot", PTrnLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnLine", PTrnLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PReturn", PReturn, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PUomConvFactor", PUomConvFactor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToLot", ToLot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PQty", PQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
