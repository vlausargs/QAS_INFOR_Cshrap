//PROJECT NAME: Data
//CLASS NAME: IntraSiteTransferDetailRefresh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IntraSiteTransferDetailRefresh : IIntraSiteTransferDetailRefresh
	{
		readonly IApplicationDB appDB;
		
		public IntraSiteTransferDetailRefresh(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IntraSiteTransferDetailRefreshSp(
			int? RowCount,
			string PCFilter = null,
			int? PageCount = 1)
		{
			IntType _RowCount = RowCount;
			LongListType _PCFilter = PCFilter;
			IntType _PageCount = PageCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IntraSiteTransferDetailRefreshSp";
				
				appDB.AddCommandParameter(cmd, "RowCount", _RowCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCFilter", _PCFilter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageCount", _PageCount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
