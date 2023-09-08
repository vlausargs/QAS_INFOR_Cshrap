//PROJECT NAME: Data
//CLASS NAME: MpwxrefdDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MpwxrefdDelete : IMpwxrefdDelete
	{
		readonly IApplicationDB appDB;
		
		public MpwxrefdDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MpwxrefdDeleteSp(
			string PReference,
			string PRefType,
			string PItem,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			int? PRefSeq,
			string Infobar)
		{
			RefTypeIJKPRTType _PReference = PReference;
			RefTypeIJKMNOTType _PRefType = PRefType;
			ItemType _PItem = PItem;
			UnknownRefNumLastTranType _PRefNum = PRefNum;
			UnknownRefLineType _PRefLineSuf = PRefLineSuf;
			UnknownRefReleaseType _PRefRelease = PRefRelease;
			JobmatlProjmatlSeqType _PRefSeq = PRefSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MpwxrefdDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PReference", _PReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefSeq", _PRefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
