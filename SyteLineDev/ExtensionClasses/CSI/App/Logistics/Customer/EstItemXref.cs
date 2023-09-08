//PROJECT NAME: Logistics
//CLASS NAME: EstItemXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstItemXref : IEstItemXref
	{
		readonly IApplicationDB appDB;
		
		
		public EstItemXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CurRefNum,
		int? CurRefLineSuf,
		int? CurRefRelease,
		string Infobar) EstItemXrefSp(string EstNum,
		int? EstLine,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		decimal? QtyOrdered,
		DateTime? DueDate,
		string Whse,
		int? MpwxrefDelete = 0,
		int? CreateProj = 0,
		int? CreateProjtask = 0,
		string CurRefNum = null,
		int? CurRefLineSuf = null,
		int? CurRefRelease = null,
		string Infobar = null)
		{
			CoNumType _EstNum = EstNum;
			CoLineType _EstLine = EstLine;
			RefTypeIJKPRTType _RefType = RefType;
			JobPoProjReqTrnNumType _RefNum = RefNum;
			SuffixPoLineProjTaskReqTrnLineType _RefLineSuf = RefLineSuf;
			OperNumPoReleaseType _RefRelease = RefRelease;
			ItemType _Item = Item;
			QtyUnitType _QtyOrdered = QtyOrdered;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			FlagNyType _MpwxrefDelete = MpwxrefDelete;
			FlagNyType _CreateProj = CreateProj;
			FlagNyType _CreateProjtask = CreateProjtask;
			JobPoReqNumType _CurRefNum = CurRefNum;
			SuffixPoReqLineType _CurRefLineSuf = CurRefLineSuf;
			PoReleaseType _CurRefRelease = CurRefRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstItemXrefSp";
				
				appDB.AddCommandParameter(cmd, "EstNum", _EstNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstLine", _EstLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MpwxrefDelete", _MpwxrefDelete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateProj", _CreateProj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateProjtask", _CreateProjtask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurRefNum", _CurRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurRefLineSuf", _CurRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurRefRelease", _CurRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurRefNum = _CurRefNum;
				CurRefLineSuf = _CurRefLineSuf;
				CurRefRelease = _CurRefRelease;
				Infobar = _Infobar;
				
				return (Severity, CurRefNum, CurRefLineSuf, CurRefRelease, Infobar);
			}
		}
	}
}
