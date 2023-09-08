//PROJECT NAME: Logistics
//CLASS NAME: TaxDistDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxDistDelete : ITaxDistDelete
	{
		readonly IApplicationDB appDB;
		
		
		public TaxDistDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TaxDistDeleteSp(Guid? PRowPointer,
		string PCoNum,
		int? PSeq,
		string Infobar)
		{
			RowPointerType _PRowPointer = PRowPointer;
			CoNumType _PCoNum = PCoNum;
			ArDistSeqType _PSeq = PSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxDistDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
