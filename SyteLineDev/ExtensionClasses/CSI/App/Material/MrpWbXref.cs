//PROJECT NAME: Material
//CLASS NAME: MrpWbXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbXref : IMrpWbXref
	{
		readonly IApplicationDB appDB;
		
		public MrpWbXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MrpWbXrefSp(
			string OrdType,
			string OrdNum,
			int? OrdLineSuf,
			int? OrdRelease,
			int? OrdSeq,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Infobar)
		{
			RefTypeIJKMNOTType _OrdType = OrdType;
			UnknownRefNumLastTranType _OrdNum = OrdNum;
			UnknownRefLineType _OrdLineSuf = OrdLineSuf;
			UnknownRefReleaseType _OrdRelease = OrdRelease;
			JobmatlProjmatlSeqType _OrdSeq = OrdSeq;
			RefTypeIJKMNOTType _RefType = RefType;
			UnknownRefNumLastTranType _RefNum = RefNum;
			UnknownRefLineType _RefLineSuf = RefLineSuf;
			UnknownRefReleaseType _RefRelease = RefRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpWbXrefSp";
				
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNum", _OrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdLineSuf", _OrdLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdRelease", _OrdRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdSeq", _OrdSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
