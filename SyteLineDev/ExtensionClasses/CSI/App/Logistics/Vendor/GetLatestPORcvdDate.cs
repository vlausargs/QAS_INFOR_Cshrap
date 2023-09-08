//PROJECT NAME: Logistics
//CLASS NAME: GetLatestPORcvdDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetLatestPORcvdDate : IGetLatestPORcvdDate
	{
		readonly IApplicationDB appDB;
		
		
		public GetLatestPORcvdDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? PoitemRcvdDate) GetLatestPORcvdDateSp(string PoNum,
		DateTime? PoitemRcvdDate)
		{
			PoNumType _PoNum = PoNum;
			DateTimeType _PoitemRcvdDate = PoitemRcvdDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetLatestPORcvdDateSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoitemRcvdDate", _PoitemRcvdDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoitemRcvdDate = _PoitemRcvdDate;
				
				return (Severity, PoitemRcvdDate);
			}
		}
	}
}
