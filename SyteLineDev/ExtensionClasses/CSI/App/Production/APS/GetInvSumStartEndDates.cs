//PROJECT NAME: CSIAPS
//CLASS NAME: GetInvSumStartEndDat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IGetInvSumStartEndDat
	{
		int GetInvSumStartEndDates(ref DateTime? PStartDate,
		                           ref DateTime? PEndDate);
	}
	
	public class GetInvSumStartEndDat : IGetInvSumStartEndDat
	{
		readonly IApplicationDB appDB;
		
		public GetInvSumStartEndDat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetInvSumStartEndDates(ref DateTime? PStartDate,
		                                  ref DateTime? PEndDate)
		{
			DateType _PStartDate = PStartDate;
			DateType _PEndDate = PEndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetInvSumStartEndDates";
				
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PStartDate = _PStartDate;
				PEndDate = _PEndDate;
				
				return Severity;
			}
		}
	}
}
