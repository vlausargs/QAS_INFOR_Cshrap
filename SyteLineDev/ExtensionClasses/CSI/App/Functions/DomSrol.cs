//PROJECT NAME: Data
//CLASS NAME: DomSrol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DomSrol : IDomSrol
	{
		readonly IApplicationDB appDB;
		
		public DomSrol(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DomSrolSp(
			Guid? InRecid)
		{
			RowPointerType _InRecid = InRecid;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DomSrolSp";
				
				appDB.AddCommandParameter(cmd, "InRecid", _InRecid, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
