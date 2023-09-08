//PROJECT NAME: Data
//CLASS NAME: PoitemProjMatlXrefCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoitemProjMatlXrefCreate : IPoitemProjMatlXrefCreate
	{
		readonly IApplicationDB appDB;
		
		public PoitemProjMatlXrefCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? RefRelease,
			string Infobar) PoitemProjMatlXrefCreateSp(
			string PoNum,
			int? PoLine,
			int? PoRelease,
			string Item,
			string CostCode,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Infobar = null)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			ItemType _Item = Item;
			CostCodeType _CostCode = CostCode;
			RefTypeIJKOTType _RefType = RefType;
			CoJobProjTrnNumType _RefNum = RefNum;
			CoLineSuffixProjTaskTrnLineType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumType _RefRelease = RefRelease;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoitemProjMatlXrefCreateSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefRelease = _RefRelease;
				Infobar = _Infobar;
				
				return (Severity, RefRelease, Infobar);
			}
		}
	}
}
