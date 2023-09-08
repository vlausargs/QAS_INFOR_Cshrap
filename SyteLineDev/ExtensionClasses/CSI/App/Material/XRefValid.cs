//PROJECT NAME: Material
//CLASS NAME: XRefValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class XRefValid : IXRefValid
	{
		readonly IApplicationDB appDB;
		
		
		public XRefValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) XRefValidSp(string Item,
		string FrmRefType,
		string FrmRefNum,
		int? FrmRefLineSuf,
		int? FrmRefRelease,
		string Infobar)
		{
			ItemType _Item = Item;
			RefTypeIJPRType _FrmRefType = FrmRefType;
			JobPoReqNumType _FrmRefNum = FrmRefNum;
			SuffixPoReqLineType _FrmRefLineSuf = FrmRefLineSuf;
			PoReleaseType _FrmRefRelease = FrmRefRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "XRefValidSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrmRefType", _FrmRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrmRefNum", _FrmRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrmRefLineSuf", _FrmRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrmRefRelease", _FrmRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
