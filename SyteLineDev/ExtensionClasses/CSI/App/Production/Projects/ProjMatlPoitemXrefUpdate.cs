//PROJECT NAME: Production
//CLASS NAME: ProjMatlPoitemXrefUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjMatlPoitemXrefUpdate : IProjMatlPoitemXrefUpdate
	{
		readonly IApplicationDB appDB;
		
		public ProjMatlPoitemXrefUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProjMatlPoitemXrefUpdateSp(
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string ProjmatlProjNum,
			int? ProjmatlTaskNum,
			int? ProjmatlSeq,
			string Item,
			string Infobar)
		{
			RefTypeIJPRType _RefType = RefType;
			JobPoReqNumType _RefNum = RefNum;
			SuffixPoReqLineType _RefLineSuf = RefLineSuf;
			OperNumPoReleaseType _RefRelease = RefRelease;
			ProjNumType _ProjmatlProjNum = ProjmatlProjNum;
			TaskNumType _ProjmatlTaskNum = ProjmatlTaskNum;
			ProjmatlSeqType _ProjmatlSeq = ProjmatlSeq;
			ItemType _Item = Item;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjMatlPoitemXrefUpdateSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjmatlProjNum", _ProjmatlProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjmatlTaskNum", _ProjmatlTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjmatlSeq", _ProjmatlSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
