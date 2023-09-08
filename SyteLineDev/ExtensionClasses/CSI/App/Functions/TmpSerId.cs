//PROJECT NAME: Data
//CLASS NAME: TmpSerId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TmpSerId : ITmpSerId
	{
		readonly IApplicationDB appDB;
		
		public TmpSerId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public Guid? TmpSerIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[TmpSerId]()";
				
				var Output = appDB.ExecuteScalar<Guid?>(cmd);
				
				return Output;
			}
		}
	}
}
