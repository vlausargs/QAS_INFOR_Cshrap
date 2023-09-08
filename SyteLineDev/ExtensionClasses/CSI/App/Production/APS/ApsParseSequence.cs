//PROJECT NAME: Production
//CLASS NAME: ApsParseSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsParseSequence : IApsParseSequence
	{
		readonly IApplicationDB appDB;
		
		public ApsParseSequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsParseSequenceFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsParseSequence]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
