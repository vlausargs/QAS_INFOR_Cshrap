//PROJECT NAME: Data
//CLASS NAME: PopulateFSSignatureSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PopulateFSSignatureSeq : IPopulateFSSignatureSeq
	{
		readonly IApplicationDB appDB;
		
		public PopulateFSSignatureSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PopulateFSSignatureSeqSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PopulateFSSignatureSeqSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
