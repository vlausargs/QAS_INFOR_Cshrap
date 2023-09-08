//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCalcEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCalcEndDate : ISSSFSConInvSubCalcEndDate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubCalcEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? SSSFSConInvSubCalcEndDateFn(
			string IUnitOfRate,
			DateTime? IStartDate,
			int? INumOfTimes)
		{
			FSContUnitOfRateType _IUnitOfRate = IUnitOfRate;
			DateType _IStartDate = IStartDate;
			GenericIntType _INumOfTimes = INumOfTimes;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSConInvSubCalcEndDate](@IUnitOfRate, @IStartDate, @INumOfTimes)";
				
				appDB.AddCommandParameter(cmd, "IUnitOfRate", _IUnitOfRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IStartDate", _IStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "INumOfTimes", _INumOfTimes, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
