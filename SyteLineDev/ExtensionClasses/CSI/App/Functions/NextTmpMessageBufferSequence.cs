//PROJECT NAME: Data
//CLASS NAME: NextTmpMessageBufferSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextTmpMessageBufferSequence : INextTmpMessageBufferSequence
	{
		readonly IApplicationDB appDB;
		
		public NextTmpMessageBufferSequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? NextTmpMessageBufferSequenceFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[NextTmpMessageBufferSequence]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
