//PROJECT NAME: Production
//CLASS NAME: DeleteJobtranitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class DeleteJobtranitem : IDeleteJobtranitem
	{
		readonly IApplicationDB appDB;
		
		
		public DeleteJobtranitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteJobtranitemSp(decimal? TransNum)
		{
			HugeTransNumType _TransNum = TransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteJobtranitemSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
