//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROCostPriceMargin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROCostPriceMargin : ISSSFSSROCostPriceMargin
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROCostPriceMargin(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSROCostPriceMarginSP(
			string ParentForm = null,
			string SRONum = null,
			int? SROLine = null,
			int? SROOper = null,
			string PartnerId = null,
			string Type = "P",
			DateTime? BEGTransDate = null,
			DateTime? ENDTransDate = null,
			int? IncludePosted = 1,
			int? IncludeUnposted = 1,
			string BillHold = null,
			string CustNum = null,
			int? CustSeq = null,
			string Whse = null,
			string BillCode = null,
			string InvNum = null,
			string Dept = null,
			DateTime? BEGPostDate = null,
			DateTime? ENDPostDate = null,
			string MatlItem = null,
			string MatlTransType = null,
			string LabrWorkCode = null,
			string MiscMiscCode = null,
			string MiscFSPayType = null)
		{
			StringType _ParentForm = ParentForm;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			FSPartnerType _PartnerId = PartnerId;
			FSSROTransTypeType _Type = Type;
			DateType _BEGTransDate = BEGTransDate;
			DateType _ENDTransDate = ENDTransDate;
			ListYesNoType _IncludePosted = IncludePosted;
			ListYesNoType _IncludeUnposted = IncludeUnposted;
			StringType _BillHold = BillHold;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			WhseType _Whse = Whse;
			FSSROBillCodeType _BillCode = BillCode;
			InvNumType _InvNum = InvNum;
			DeptType _Dept = Dept;
			DateType _BEGPostDate = BEGPostDate;
			DateType _ENDPostDate = ENDPostDate;
			ItemType _MatlItem = MatlItem;
			FSSROTransTypeType _MatlTransType = MatlTransType;
			FSWorkCodeType _LabrWorkCode = LabrWorkCode;
			FSMiscCodeType _MiscMiscCode = MiscMiscCode;
			FSPayTypeType _MiscFSPayType = MiscFSPayType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROCostPriceMarginSP";
				
				appDB.AddCommandParameter(cmd, "ParentForm", _ParentForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BEGTransDate", _BEGTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDTransDate", _ENDTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludePosted", _IncludePosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeUnposted", _IncludeUnposted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillHold", _BillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BEGPostDate", _BEGPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDPostDate", _ENDPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlItem", _MatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlTransType", _MatlTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LabrWorkCode", _LabrWorkCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscMiscCode", _MiscMiscCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscFSPayType", _MiscFSPayType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
