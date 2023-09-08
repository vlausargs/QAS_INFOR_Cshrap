//PROJECT NAME: Finance
//CLASS NAME: EXTCHSPreJourReseqVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSPreJourReseqVal : IEXTCHSPreJourReseqVal
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSPreJourReseqVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTCHSPreJourReseqValSp(
			string JournalId,
			string Infobar)
		{
			JournalIdType _JournalId = JournalId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSPreJourReseqValSp";
				
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
