//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubSetStartDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubSetStartDay : ISSSFSConInvSubSetStartDay
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubSetStartDay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? OStartDay) SSSFSConInvSubSetStartDaySp(
			DateTime? IStartDate,
			DateTime? IBilledThru,
			int? IProrate,
			DateTime? IRenewalDate,
			string IUnitOfRate,
			int? OStartDay)
		{
			DateTimeType _IStartDate = IStartDate;
			DateTimeType _IBilledThru = IBilledThru;
			ListYesNoType _IProrate = IProrate;
			DateTimeType _IRenewalDate = IRenewalDate;
			FSContUnitOfRateType _IUnitOfRate = IUnitOfRate;
			IntType _OStartDay = OStartDay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubSetStartDaySp";
				
				appDB.AddCommandParameter(cmd, "IStartDate", _IStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IBilledThru", _IBilledThru, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IProrate", _IProrate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IRenewalDate", _IRenewalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IUnitOfRate", _IUnitOfRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OStartDay", _OStartDay, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OStartDay = _OStartDay;
				
				return (Severity, OStartDay);
			}
		}
	}
}
