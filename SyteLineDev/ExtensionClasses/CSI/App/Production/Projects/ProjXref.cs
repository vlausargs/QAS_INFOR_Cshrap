//PROJECT NAME: Production
//CLASS NAME: ProjXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjXref : IProjXref
	{
		readonly IApplicationDB appDB;
		
		public ProjXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ProjNum,
			int? TaskNum,
			string Infobar) ProjXrefSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string RefNum,
			int? RefLine,
			int? RefRelease,
			string Item,
			string ItemDescription,
			int? CreateProj,
			int? CreateProjtask,
			string ProjNum,
			int? TaskNum,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			JobPoProjReqTrnNumType _RefNum = RefNum;
			SuffixPoLineProjTaskReqTrnLineType _RefLine = RefLine;
			OperNumPoReleaseType _RefRelease = RefRelease;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			FlagNyType _CreateProj = CreateProj;
			FlagNyType _CreateProjtask = CreateProjtask;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjXrefSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateProj", _CreateProj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateProjtask", _CreateProjtask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProjNum = _ProjNum;
				TaskNum = _TaskNum;
				Infobar = _Infobar;
				
				return (Severity, ProjNum, TaskNum, Infobar);
			}
		}
	}
}
