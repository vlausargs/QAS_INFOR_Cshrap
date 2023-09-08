//PROJECT NAME: CSIProduct
//CLASS NAME: GetProdMix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IGetProdMix
	{
		int GetProdMixSp(string Item,
		                 ref string ProdMix,
		                 ref short? Qty,
		                 ref string Description);
	}
	
	public class GetProdMix : IGetProdMix
	{
		readonly IApplicationDB appDB;
		
		public GetProdMix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetProdMixSp(string Item,
		                        ref string ProdMix,
		                        ref short? Qty,
		                        ref string Description)
		{
			ItemType _Item = Item;
			ProdMixType _ProdMix = ProdMix;
			TotalProdMixQuantityType _Qty = Qty;
			DescriptionType _Description = Description;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetProdMixSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdMix", _ProdMix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProdMix = _ProdMix;
				Qty = _Qty;
				Description = _Description;
				
				return Severity;
			}
		}
	}
}
