//PROJECT NAME: Data
//CLASS NAME: PoItemcost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoItemcost : IPoItemcost
	{
		readonly IApplicationDB appDB;
		
		public PoItemcost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PPlanCost,
			string Infobar) PoItemcostSp(
			string PItem,
			decimal? PQtyOrdered,
			string PCurrCode,
			string PVendNum,
			DateTime? EffectiveDate,
			decimal? PPlanCost,
			string Infobar)
		{
			ItemType _PItem = PItem;
			QtyUnitNoNegType _PQtyOrdered = PQtyOrdered;
			CurrCodeType _PCurrCode = PCurrCode;
			VendNumType _PVendNum = PVendNum;
			DateType _EffectiveDate = EffectiveDate;
			CostPrcType _PPlanCost = PPlanCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoItemcostSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlanCost", _PPlanCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPlanCost = _PPlanCost;
				Infobar = _Infobar;
				
				return (Severity, PPlanCost, Infobar);
			}
		}
	}
}
