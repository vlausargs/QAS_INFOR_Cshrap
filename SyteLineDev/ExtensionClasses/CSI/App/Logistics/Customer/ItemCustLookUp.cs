//PROJECT NAME: CSICustomer
//CLASS NAME: ItemCustLookUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IItemCustLookUp
	{
		(int? ReturnCode, string CustItem, string UM, short? DuePeriod, int? Rank, string EndUser, string Infobar) ItemCustLookUpSp(string CustNum,
		string Item,
		string CustItem,
		string UM,
		short? DuePeriod,
		int? Rank,
		string EndUser,
		string Infobar = null);
	}
	
	public class ItemCustLookUp : IItemCustLookUp
	{
		readonly IApplicationDB appDB;
		
		public ItemCustLookUp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CustItem, string UM, short? DuePeriod, int? Rank, string EndUser, string Infobar) ItemCustLookUpSp(string CustNum,
		string Item,
		string CustItem,
		string UM,
		short? DuePeriod,
		int? Rank,
		string EndUser,
		string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			CustItemType _CustItem = CustItem;
			UMType _UM = UM;
			DuePeriodType _DuePeriod = DuePeriod;
			CustItemRankType _Rank = Rank;
			NameType _EndUser = EndUser;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemCustLookUpSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DuePeriod", _DuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Rank", _Rank, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndUser", _EndUser, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustItem = _CustItem;
				UM = _UM;
				DuePeriod = _DuePeriod;
				Rank = _Rank;
				EndUser = _EndUser;
				Infobar = _Infobar;
				
				return (Severity, CustItem, UM, DuePeriod, Rank, EndUser, Infobar);
			}
		}
	}
}
