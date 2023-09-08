//PROJECT NAME: Data
//CLASS NAME: GetEFTMappingRecordDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetEFTMappingRecordDate : IGetEFTMappingRecordDate
	{
		readonly IApplicationDB appDB;
		
		public GetEFTMappingRecordDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetEFTMappingRecordDateFn(
			string MapId)
		{
			EFTMappingIdType _MapId = MapId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetEFTMappingRecordDate](@MapId)";
				
				appDB.AddCommandParameter(cmd, "MapId", _MapId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
