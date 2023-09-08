//PROJECT NAME: CSICustomer
//CLASS NAME: AddOpportunitiesToSalesForecast.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IAddOpportunitiesToSalesForecast
    {
        int AddOpportunitiesToSalesForecastSp(string ForecastId,
                                              string OpportunityId,
                                              ref string Infobar);
    }

    public class AddOpportunitiesToSalesForecast : IAddOpportunitiesToSalesForecast
    {
        readonly IApplicationDB appDB;

        public AddOpportunitiesToSalesForecast(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AddOpportunitiesToSalesForecastSp(string ForecastId,
                                                     string OpportunityId,
                                                     ref string Infobar)
        {
            SalesForecastIdType _ForecastId = ForecastId;
            OpportunityIDType _OpportunityId = OpportunityId;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddOpportunitiesToSalesForecastSp";

                appDB.AddCommandParameter(cmd, "ForecastId", _ForecastId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OpportunityId", _OpportunityId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
