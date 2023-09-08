//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefCreateM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefCreateM : ISSSFSXrefCreateM
	{
		readonly IApplicationDB appDB;
		
		public SSSFSXrefCreateM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string NewRmaNum,
			int? NewRmaLine,
			string Infobar) SSSFSXrefCreateMSp(
			string FromRefType,
			string FromRefNum,
			int? FromRefLineSuf,
			int? FromRefRelease,
			string ToRefNum,
			int? ToRefLine,
			string Item,
			string Whse,
			decimal? Qty,
			string CustNum,
			DateTime? OrderDate,
			string UM,
			string Desc,
			string NewRmaNum,
			int? NewRmaLine,
			string Infobar)
		{
			RefTypeIJKPRTType _FromRefType = FromRefType;
			CoNumType _FromRefNum = FromRefNum;
			CoLineType _FromRefLineSuf = FromRefLineSuf;
			CoReleaseType _FromRefRelease = FromRefRelease;
			JobPoReqNumType _ToRefNum = ToRefNum;
			SuffixPoReqLineType _ToRefLine = ToRefLine;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			QtyUnitType _Qty = Qty;
			CustNumType _CustNum = CustNum;
			DateType _OrderDate = OrderDate;
			UMType _UM = UM;
			DescriptionType _Desc = Desc;
			RmaNumType _NewRmaNum = NewRmaNum;
			RmaLineType _NewRmaLine = NewRmaLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefCreateMSp";
				
				appDB.AddCommandParameter(cmd, "FromRefType", _FromRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefNum", _FromRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefLineSuf", _FromRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefRelease", _FromRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRefNum", _ToRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRefLine", _ToRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Desc", _Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRmaNum", _NewRmaNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewRmaLine", _NewRmaLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewRmaNum = _NewRmaNum;
				NewRmaLine = _NewRmaLine;
				Infobar = _Infobar;
				
				return (Severity, NewRmaNum, NewRmaLine, Infobar);
			}
		}
	}
}
