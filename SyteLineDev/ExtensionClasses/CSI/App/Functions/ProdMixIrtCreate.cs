//PROJECT NAME: Data
//CLASS NAME: ProdMixIrtCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProdMixIrtCreate : IProdMixIrtCreate
	{
		readonly IApplicationDB appDB;
		
		public ProdMixIrtCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProdMixIrtCreateSp(
			string Item,
			string ProdMix,
			string ChildItem,
			string Infobar)
		{
			ItemType _Item = Item;
			ProdMixType _ProdMix = ProdMix;
			ItemType _ChildItem = ChildItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProdMixIrtCreateSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdMix", _ProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChildItem", _ChildItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
