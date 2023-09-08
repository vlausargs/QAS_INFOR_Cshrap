//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCalcHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCalcHrs : ISSSFSConInvSubCalcHrs
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubCalcHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConInvSubCalcHrsFn(
			DateTime? StartDateTime,
			DateTime? EndDateTime,
			decimal? ContMaxHrs)
		{
			GenericDate _StartDateTime = StartDateTime;
			GenericDate _EndDateTime = EndDateTime;
			GenericDecimalType _ContMaxHrs = ContMaxHrs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSConInvSubCalcHrs](@StartDateTime, @EndDateTime, @ContMaxHrs)";
				
				appDB.AddCommandParameter(cmd, "StartDateTime", _StartDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateTime", _EndDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContMaxHrs", _ContMaxHrs, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
