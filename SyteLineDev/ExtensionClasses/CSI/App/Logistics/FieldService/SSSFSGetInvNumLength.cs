//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetInvNumLength.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetInvNumLength : ISSSFSGetInvNumLength
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetInvNumLength(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSGetInvNumLengthFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetInvNumLength]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
