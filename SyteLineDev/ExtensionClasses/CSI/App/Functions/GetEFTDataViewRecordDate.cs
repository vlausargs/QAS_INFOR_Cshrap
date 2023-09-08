//PROJECT NAME: Data
//CLASS NAME: GetEFTDataViewRecordDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetEFTDataViewRecordDate : IGetEFTDataViewRecordDate
	{
		readonly IApplicationDB appDB;
		
		public GetEFTDataViewRecordDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetEFTDataViewRecordDateFn(
			string ViewName)
		{
			NameType _ViewName = ViewName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetEFTDataViewRecordDate](@ViewName)";
				
				appDB.AddCommandParameter(cmd, "ViewName", _ViewName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
