//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefCreateJ.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefCreateJ : ISSSFSXrefCreateJ
	{
		readonly IApplicationDB appDB;
		
		public SSSFSXrefCreateJ(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CurJob,
			int? CurSuffix,
			string Infobar) SSSFSXrefCreateJSp(
			string FromRefType,
			string FromRefNum,
			int? FromRefLineSuf,
			int? FromRefRelease,
			string ToRefNum,
			int? ToRefLineSuf,
			string CustNum,
			string Item,
			string ItemDescription,
			decimal? QtyOrdered,
			DateTime? DueDate,
			string Whse,
			string CurJob,
			int? CurSuffix,
			string Infobar)
		{
			RefTypeIJKPRTType _FromRefType = FromRefType;
			CoNumType _FromRefNum = FromRefNum;
			CoLineType _FromRefLineSuf = FromRefLineSuf;
			CoReleaseType _FromRefRelease = FromRefRelease;
			JobPoReqNumType _ToRefNum = ToRefNum;
			SuffixPoReqLineType _ToRefLineSuf = ToRefLineSuf;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			QtyUnitType _QtyOrdered = QtyOrdered;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			JobType _CurJob = CurJob;
			SuffixType _CurSuffix = CurSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefCreateJSp";
				
				appDB.AddCommandParameter(cmd, "FromRefType", _FromRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefNum", _FromRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefLineSuf", _FromRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefRelease", _FromRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRefNum", _ToRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRefLineSuf", _ToRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurJob", _CurJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurSuffix", _CurSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurJob = _CurJob;
				CurSuffix = _CurSuffix;
				Infobar = _Infobar;
				
				return (Severity, CurJob, CurSuffix, Infobar);
			}
		}
	}
}
