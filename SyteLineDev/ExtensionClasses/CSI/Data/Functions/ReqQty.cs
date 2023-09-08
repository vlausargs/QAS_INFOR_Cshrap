//PROJECT NAME: Data
//CLASS NAME: ReqQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ReqQty : IReqQty
    {
        readonly IApplicationDB appDB;

        public ReqQty(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public decimal? ReqQtyFn(
            decimal? QtyReleased,
            string Units,
            decimal? MatlQty,
            int? Scrap,
            decimal? ScrapFact)
        {
            QtyUnitType _QtyReleased = QtyReleased;
            JobmatlUnitsType _Units = Units;
            QtyUnitType _MatlQty = MatlQty;
            ListYesNoType _Scrap = Scrap;
            ScrapFactorType _ScrapFact = ScrapFact;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ReqQty](@QtyReleased, @Units, @MatlQty, @Scrap, @ScrapFact)";

                appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MatlQty", _MatlQty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Scrap", _Scrap, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ScrapFact", _ScrapFact, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<decimal?>(cmd);

                return Output;
            }
        }
    }
}
