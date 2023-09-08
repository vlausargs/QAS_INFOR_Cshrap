//PROJECT NAME: Data
//CLASS NAME: MsDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MsDate : IMsDate
	{
		readonly IApplicationDB appDB;
		
		public MsDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? ODate) MsDateSp(
			string IProjNum,
			string IMsNum,
			DateTime? ODate)
		{
			ProjNumType _IProjNum = IProjNum;
			ProjMsNumType _IMsNum = IMsNum;
			CurrentDateType _ODate = ODate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MsDateSp";
				
				appDB.AddCommandParameter(cmd, "IProjNum", _IProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IMsNum", _IMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ODate", _ODate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ODate = _ODate;
				
				return (Severity, ODate);
			}
		}
	}
}
