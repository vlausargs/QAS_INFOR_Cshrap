//PROJECT NAME: CSICustomer
//CLASS NAME: GetCustItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetCustItemInfo
	{
		(int? ReturnCode, int? CustItemSeq, string EndUser, int? Rank, short? DuePeriod, string CustItemUM, string Infobar, string ItmDescription, string ItmUM, decimal? ItmUnitCost) GetCustItemInfoSp(string CustNum,
		string Item,
		string CustItem,
		int? CustItemSeq = null,
		string EndUser = null,
		int? Rank = null,
		short? DuePeriod = null,
		string CustItemUM = null,
		string Infobar = null,
		string ItmDescription = null,
		string ItmUM = null,
		decimal? ItmUnitCost = null);
	}
	
	public class GetCustItemInfo : IGetCustItemInfo
	{
		readonly IApplicationDB appDB;
		
		public GetCustItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CustItemSeq, string EndUser, int? Rank, short? DuePeriod, string CustItemUM, string Infobar, string ItmDescription, string ItmUM, decimal? ItmUnitCost) GetCustItemInfoSp(string CustNum,
		string Item,
		string CustItem,
		int? CustItemSeq = null,
		string EndUser = null,
		int? Rank = null,
		short? DuePeriod = null,
		string CustItemUM = null,
		string Infobar = null,
		string ItmDescription = null,
		string ItmUM = null,
		decimal? ItmUnitCost = null)
		{
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			CustItemType _CustItem = CustItem;
			CustItemSeqType _CustItemSeq = CustItemSeq;
			NameType _EndUser = EndUser;
			CustItemRankType _Rank = Rank;
			DuePeriodType _DuePeriod = DuePeriod;
			UMType _CustItemUM = CustItemUM;
			InfobarType _Infobar = Infobar;
			DescriptionType _ItmDescription = ItmDescription;
			UMType _ItmUM = ItmUM;
			CostPrcType _ItmUnitCost = ItmUnitCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCustItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItemSeq", _CustItemSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndUser", _EndUser, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Rank", _Rank, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DuePeriod", _DuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItemUM", _CustItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmDescription", _ItmDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmUM", _ItmUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmUnitCost", _ItmUnitCost, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustItemSeq = _CustItemSeq;
				EndUser = _EndUser;
				Rank = _Rank;
				DuePeriod = _DuePeriod;
				CustItemUM = _CustItemUM;
				Infobar = _Infobar;
				ItmDescription = _ItmDescription;
				ItmUM = _ItmUM;
				ItmUnitCost = _ItmUnitCost;
				
				return (Severity, CustItemSeq, EndUser, Rank, DuePeriod, CustItemUM, Infobar, ItmDescription, ItmUM, ItmUnitCost);
			}
		}
	}
}
