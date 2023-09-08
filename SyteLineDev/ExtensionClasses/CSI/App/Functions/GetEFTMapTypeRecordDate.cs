//PROJECT NAME: Data
//CLASS NAME: GetEFTMapTypeRecordDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetEFTMapTypeRecordDate : IGetEFTMapTypeRecordDate
	{
		readonly IApplicationDB appDB;
		
		public GetEFTMapTypeRecordDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetEFTMapTypeRecordDateFn(
			string EFTType)
		{
			EFTTypeType _EFTType = EFTType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetEFTMapTypeRecordDate](@EFTType)";
				
				appDB.AddCommandParameter(cmd, "EFTType", _EFTType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
