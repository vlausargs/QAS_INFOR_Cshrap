//PROJECT NAME: Data
//CLASS NAME: GetBaseQuantity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetBaseQuantity : IGetBaseQuantity
	{
		readonly IApplicationDB appDB;
		
		public GetBaseQuantity(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? QtyInBase,
			string Infobar) GetBaseQuantitySp(
			string UM,
			string Item,
			string CustNum,
			decimal? QtyConv,
			decimal? QtyInBase,
			string Infobar,
			string Site = null)
		{
			UMType _UM = UM;
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			QtyUnitType _QtyConv = QtyConv;
			QtyUnitType _QtyInBase = QtyInBase;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetBaseQuantitySp";
				
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyInBase", _QtyInBase, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyInBase = _QtyInBase;
				Infobar = _Infobar;
				
				return (Severity, QtyInBase, Infobar);
			}
		}
	}
}
