//PROJECT NAME: Data
//CLASS NAME: GetFiscalYearByDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetFiscalYearByDate : IGetFiscalYearByDate
	{
		readonly IApplicationDB appDB;
		
		public GetFiscalYearByDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetFiscalYearByDateFn(
			DateTime? DateToStartDepr)
		{
			DateType _DateToStartDepr = DateToStartDepr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetFiscalYearByDate](@DateToStartDepr)";
				
				appDB.AddCommandParameter(cmd, "DateToStartDepr", _DateToStartDepr, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
