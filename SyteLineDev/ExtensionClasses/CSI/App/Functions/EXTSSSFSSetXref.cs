//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSSetXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSSetXref : IEXTSSSFSSetXref
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSSetXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTSSSFSSetXrefSp(
			string PRefType,
			string PRefNum,
			int? PRefLine,
			int? PRefRel,
			string PParType,
			string PParNum,
			int? PParLine,
			int? PParRel,
			string POldParType,
			string POldParNum,
			int? POldParLine,
			int? POldParRel,
			string PItem,
			string ParmsSite,
			string Infobar)
		{
			RefTypeIJKOTType _PRefType = PRefType;
			CoJobProjTrnNumType _PRefNum = PRefNum;
			CoLineSuffixProjTaskTrnLineType _PRefLine = PRefLine;
			CoReleaseOperNumType _PRefRel = PRefRel;
			RefTypeIJKOTType _PParType = PParType;
			CoJobProjTrnNumType _PParNum = PParNum;
			CoLineSuffixProjTaskTrnLineType _PParLine = PParLine;
			CoReleaseOperNumType _PParRel = PParRel;
			RefTypeIJKOTType _POldParType = POldParType;
			CoJobProjTrnNumType _POldParNum = POldParNum;
			CoLineSuffixProjTaskTrnLineType _POldParLine = POldParLine;
			CoReleaseOperNumType _POldParRel = POldParRel;
			ItemType _PItem = PItem;
			SiteType _ParmsSite = ParmsSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSSetXrefSp";
				
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLine", _PRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRel", _PRefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParType", _PParType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParNum", _PParNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParLine", _PParLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParRel", _PParRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldParType", _POldParType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldParNum", _POldParNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldParLine", _POldParLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldParRel", _POldParRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
