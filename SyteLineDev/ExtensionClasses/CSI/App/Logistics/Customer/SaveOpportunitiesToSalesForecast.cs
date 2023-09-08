//PROJECT NAME: Logistics
//CLASS NAME: SaveOpportunitiesToSalesForecast.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SaveOpportunitiesToSalesForecast : ISaveOpportunitiesToSalesForecast
	{
		readonly IApplicationDB appDB;
		
		
		public SaveOpportunitiesToSalesForecast(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SaveOpportunitiesToSalesForecastSp(string OppList,
		string ForecastId,
		string Infobar)
		{
			StringType _OppList = OppList;
			SalesForecastIdType _ForecastId = ForecastId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SaveOpportunitiesToSalesForecastSp";
				
				appDB.AddCommandParameter(cmd, "OppList", _OppList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForecastId", _ForecastId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
