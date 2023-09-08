//PROJECT NAME: Finance
//CLASS NAME: EXTCHSUpdateCHJournalSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSUpdateCHJournalSeq : IEXTCHSUpdateCHJournalSeq
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSUpdateCHJournalSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTCHSUpdateCHJournalSeqSp(
			Guid? pRowPointer,
			decimal? pNewTransNum,
			string Infobar)
		{
			RowPointerType _pRowPointer = pRowPointer;
			MatlTransNumType _pNewTransNum = pNewTransNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSUpdateCHJournalSeqSp";
				
				appDB.AddCommandParameter(cmd, "pRowPointer", _pRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewTransNum", _pNewTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
