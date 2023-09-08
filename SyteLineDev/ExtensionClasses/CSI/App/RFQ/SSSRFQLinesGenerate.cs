//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQLinesGenerate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQLinesGenerate : ISSSRFQLinesGenerate
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQLinesGenerate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSRFQLinesGenerateSp(
			string Method,
			int? FromGenUtils,
			string LastRFQNum,
			int? LastRFQLine,
			int? Seq = 1,
			string Item = null,
			string UM = null,
			string RefType = null,
			string RefNum = null,
			int? RefLineSuf = null,
			int? RefRelease = null,
			DateTime? DueDate = null,
			decimal? SelectedQty = null,
			decimal? BrkQtyConv1 = null,
			decimal? BrkQtyConv2 = null,
			decimal? BrkQtyConv3 = null,
			decimal? BrkQtyConv4 = null,
			decimal? BrkQtyConv5 = null,
			decimal? BrkQtyConv6 = null,
			decimal? BrkQtyConv7 = null,
			decimal? BrkQtyConv8 = null,
			decimal? BrkQtyConv9 = null,
			decimal? BrkQtyConv10 = null,
			string PSessionId = null,
			string Infobar = null,
			string Description = null,
			string Buyer = null)
		{
			StringType _Method = Method;
			ListYesNoType _FromGenUtils = FromGenUtils;
			RFQNumType _LastRFQNum = LastRFQNum;
			RFQLineType _LastRFQLine = LastRFQLine;
			IntType _Seq = Seq;
			ItemType _Item = Item;
			UMType _UM = UM;
			RFQRefTypeIJKRType _RefType = RefType;
			RFQRefNumType _RefNum = RefNum;
			RFQRefLineSufType _RefLineSuf = RefLineSuf;
			RFQRefReleaseType _RefRelease = RefRelease;
			DateTimeType _DueDate = DueDate;
			QtyUnitType _SelectedQty = SelectedQty;
			QtyUnitType _BrkQtyConv1 = BrkQtyConv1;
			QtyUnitType _BrkQtyConv2 = BrkQtyConv2;
			QtyUnitType _BrkQtyConv3 = BrkQtyConv3;
			QtyUnitType _BrkQtyConv4 = BrkQtyConv4;
			QtyUnitType _BrkQtyConv5 = BrkQtyConv5;
			QtyUnitType _BrkQtyConv6 = BrkQtyConv6;
			QtyUnitType _BrkQtyConv7 = BrkQtyConv7;
			QtyUnitType _BrkQtyConv8 = BrkQtyConv8;
			QtyUnitType _BrkQtyConv9 = BrkQtyConv9;
			QtyUnitType _BrkQtyConv10 = BrkQtyConv10;
			StringType _PSessionId = PSessionId;
			Infobar _Infobar = Infobar;
			DescriptionType _Description = Description;
			UsernameType _Buyer = Buyer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQLinesGenerateSp";
				
				appDB.AddCommandParameter(cmd, "Method", _Method, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromGenUtils", _FromGenUtils, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastRFQNum", _LastRFQNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastRFQLine", _LastRFQLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectedQty", _SelectedQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv1", _BrkQtyConv1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv2", _BrkQtyConv2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv3", _BrkQtyConv3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv4", _BrkQtyConv4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv5", _BrkQtyConv5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv6", _BrkQtyConv6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv7", _BrkQtyConv7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv8", _BrkQtyConv8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv9", _BrkQtyConv9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv10", _BrkQtyConv10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
