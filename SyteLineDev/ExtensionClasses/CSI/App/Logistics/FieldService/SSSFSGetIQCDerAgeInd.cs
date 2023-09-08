//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetIQCDerAgeInd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetIQCDerAgeInd : ISSSFSGetIQCDerAgeInd
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetIQCDerAgeInd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSGetIQCDerAgeIndFn(
			DateTime? AsOfDate,
			string IncNum)
		{
			DateTimeType _AsOfDate = AsOfDate;
			FSIncNumType _IncNum = IncNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetIQCDerAgeInd](@AsOfDate, @IncNum)";
				
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncNum", _IncNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
