//PROJECT NAME: Data
//CLASS NAME: GetEFTEventHandlerRecordDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetEFTEventHandlerRecordDate : IGetEFTEventHandlerRecordDate
	{
		readonly IApplicationDB appDB;
		
		public GetEFTEventHandlerRecordDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetEFTEventHandlerRecordDateFn(
			string MapId)
		{
			EFTMappingIdType _MapId = MapId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetEFTEventHandlerRecordDate](@MapId)";
				
				appDB.AddCommandParameter(cmd, "MapId", _MapId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
