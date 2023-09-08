//PROJECT NAME: Data
//CLASS NAME: GetMaxRecordDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetMaxRecordDate : IGetMaxRecordDate
	{
		readonly IApplicationDB appDB;
		
		public GetMaxRecordDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetMaxRecordDateFn(
			DateTime? RecordDate1,
			DateTime? RecordDate2 = null,
			DateTime? RecordDate3 = null,
			DateTime? RecordDate4 = null,
			DateTime? RecordDate5 = null,
			DateTime? RecordDate6 = null,
			DateTime? RecordDate7 = null,
			DateTime? RecordDate8 = null,
			DateTime? RecordDate9 = null,
			DateTime? RecordDate10 = null)
		{
			CurrentDateType _RecordDate1 = RecordDate1;
			CurrentDateType _RecordDate2 = RecordDate2;
			CurrentDateType _RecordDate3 = RecordDate3;
			CurrentDateType _RecordDate4 = RecordDate4;
			CurrentDateType _RecordDate5 = RecordDate5;
			CurrentDateType _RecordDate6 = RecordDate6;
			CurrentDateType _RecordDate7 = RecordDate7;
			CurrentDateType _RecordDate8 = RecordDate8;
			CurrentDateType _RecordDate9 = RecordDate9;
			CurrentDateType _RecordDate10 = RecordDate10;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetMaxRecordDate](@RecordDate1, @RecordDate2, @RecordDate3, @RecordDate4, @RecordDate5, @RecordDate6, @RecordDate7, @RecordDate8, @RecordDate9, @RecordDate10)";
				
				appDB.AddCommandParameter(cmd, "RecordDate1", _RecordDate1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate2", _RecordDate2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate3", _RecordDate3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate4", _RecordDate4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate5", _RecordDate5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate6", _RecordDate6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate7", _RecordDate7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate8", _RecordDate8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate9", _RecordDate9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate10", _RecordDate10, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
