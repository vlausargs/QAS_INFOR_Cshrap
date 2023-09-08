//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSRODurationHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSRODurationHrs : ISSSFSSRODurationHrs
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSRODurationHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSFSSRODurationHrsFn(
			string iSRONum,
			int? iSROLine = null,
			int? iSROOper = null,
			int? iCalcFrom = 0)
		{
			FSSRONumType _iSRONum = iSRONum;
			FSSROLineType _iSROLine = iSROLine;
			FSSROOperType _iSROOper = iSROOper;
			IntType _iCalcFrom = iCalcFrom;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSRODurationHrs](@iSRONum, @iSROLine, @iSROOper, @iCalcFrom)";
				
				appDB.AddCommandParameter(cmd, "iSRONum", _iSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSROLine", _iSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSROOper", _iSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCalcFrom", _iCalcFrom, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
