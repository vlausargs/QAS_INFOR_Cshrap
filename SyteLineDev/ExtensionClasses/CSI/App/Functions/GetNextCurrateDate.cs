//PROJECT NAME: Data
//CLASS NAME: GetNextCurrateDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetNextCurrateDate : IGetNextCurrateDate
	{
		readonly IApplicationDB appDB;
		
		public GetNextCurrateDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetNextCurrateDateFn(
			DateTime? TransDate = null,
			string ForCurrCode = null,
			string DomCurrCode = null)
		{
			GenericDate _TransDate = TransDate;
			CurrCodeType _ForCurrCode = ForCurrCode;
			CurrCodeType _DomCurrCode = DomCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetNextCurrateDate](@TransDate, @ForCurrCode, @DomCurrCode)";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForCurrCode", _ForCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
