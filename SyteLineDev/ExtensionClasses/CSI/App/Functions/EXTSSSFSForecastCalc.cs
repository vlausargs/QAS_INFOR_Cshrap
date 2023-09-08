//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSForecastCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSForecastCalc : IEXTSSSFSForecastCalc
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSForecastCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSForecastCalcSp(
			string iItem,
			DateTime? iFcstDate,
			int? iTFcstAhd,
			int? iTFcstBhd)
		{
			ItemType _iItem = iItem;
			DateType _iFcstDate = iFcstDate;
			PlanFenceType _iTFcstAhd = iTFcstAhd;
			PlanFenceType _iTFcstBhd = iTFcstBhd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSForecastCalcSp";
				
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFcstDate", _iFcstDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTFcstAhd", _iTFcstAhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTFcstBhd", _iTFcstBhd, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
