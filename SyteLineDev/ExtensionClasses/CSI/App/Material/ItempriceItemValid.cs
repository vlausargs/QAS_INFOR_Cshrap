//PROJECT NAME: CSIMaterial
//CLASS NAME: ItempriceItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IItempriceItemValid
	{
		int ItempriceItemValidSp(ref string PItem,
		                         byte? PReprice,
		                         ref string PItemDescription,
		                         ref decimal? PUnitPrice1,
		                         ref string PUM,
		                         ref string PCurCode,
		                         ref decimal? PQtyOnhand,
		                         ref decimal? PUnitCost,
		                         ref decimal? PCurUnitCost,
		                         ref string PPriceCode,
		                         ref string PPricecodeDesc,
		                         ref string PProdcode,
		                         ref string Infobar);
	}
	
	public class ItempriceItemValid : IItempriceItemValid
	{
		readonly IApplicationDB appDB;
		
		public ItempriceItemValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ItempriceItemValidSp(ref string PItem,
		                                byte? PReprice,
		                                ref string PItemDescription,
		                                ref decimal? PUnitPrice1,
		                                ref string PUM,
		                                ref string PCurCode,
		                                ref decimal? PQtyOnhand,
		                                ref decimal? PUnitCost,
		                                ref decimal? PCurUnitCost,
		                                ref string PPriceCode,
		                                ref string PPricecodeDesc,
		                                ref string PProdcode,
		                                ref string Infobar)
		{
			ItemType _PItem = PItem;
			ListYesNoType _PReprice = PReprice;
			DescriptionType _PItemDescription = PItemDescription;
			CostPrcType _PUnitPrice1 = PUnitPrice1;
			UMType _PUM = PUM;
			CurrCodeType _PCurCode = PCurCode;
			QtyUnitType _PQtyOnhand = PQtyOnhand;
			CostPrcType _PUnitCost = PUnitCost;
			CostPrcType _PCurUnitCost = PCurUnitCost;
			PriceCodeType _PPriceCode = PPriceCode;
			DescriptionType _PPricecodeDesc = PPricecodeDesc;
			ProductCodeType _PProdcode = PProdcode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItempriceItemValidSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PReprice", _PReprice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemDescription", _PItemDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitPrice1", _PUnitPrice1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurCode", _PCurCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyOnhand", _PQtyOnhand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitCost", _PUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurUnitCost", _PCurUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPriceCode", _PPriceCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPricecodeDesc", _PPricecodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProdcode", _PProdcode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PItem = _PItem;
				PItemDescription = _PItemDescription;
				PUnitPrice1 = _PUnitPrice1;
				PUM = _PUM;
				PCurCode = _PCurCode;
				PQtyOnhand = _PQtyOnhand;
				PUnitCost = _PUnitCost;
				PCurUnitCost = _PCurUnitCost;
				PPriceCode = _PPriceCode;
				PPricecodeDesc = _PPricecodeDesc;
				PProdcode = _PProdcode;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
