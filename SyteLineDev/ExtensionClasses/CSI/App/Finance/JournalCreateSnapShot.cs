//PROJECT NAME: Finance
//CLASS NAME: JournalCreateSnapShot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalCreateSnapShot : IJournalCreateSnapShot
	{
		readonly IApplicationDB appDB;
		
		
		public JournalCreateSnapShot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		int? MaxSeq) JournalCreateSnapShotSp(Guid? PSessionID,
		string CurId,
		DateTime? CompressDate,
		string Infobar,
		int? MaxSeq)
		{
			RowPointer _PSessionID = PSessionID;
			JournalIdType _CurId = CurId;
			DateType _CompressDate = CompressDate;
			Infobar _Infobar = Infobar;
			JournalSeqType _MaxSeq = MaxSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalCreateSnapShotSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurId", _CurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompressDate", _CompressDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MaxSeq", _MaxSeq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				MaxSeq = _MaxSeq;
				
				return (Severity, Infobar, MaxSeq);
			}
		}
	}
}
