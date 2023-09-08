//PROJECT NAME: Finance
//CLASS NAME: ExtFinAddBatchToBGQueue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinAddBatchToBGQueue : IExtFinAddBatchToBGQueue
	{
		readonly IApplicationDB appDB;
		
		
		public ExtFinAddBatchToBGQueue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ExtFinAddBatchToBGQueueSp(string object_name,
		decimal? batch_num,
		string Infobar,
		string ToSite)
		{
			ObjectNameType _object_name = object_name;
			BatchNumType _batch_num = batch_num;
			InfobarType _Infobar = Infobar;
			SiteType _ToSite = ToSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinAddBatchToBGQueueSp";
				
				appDB.AddCommandParameter(cmd, "object_name", _object_name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "batch_num", _batch_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
