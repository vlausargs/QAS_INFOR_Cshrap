//PROJECT NAME: Logistics
//CLASS NAME: PoBlnSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoBlnSetGloVar : IPoBlnSetGloVar
	{
		readonly IApplicationDB appDB;
		
		
		public PoBlnSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PoBlnSetGloVarSp(int? ItemVendAdd,
		int? ItemVendUpdate,
		int? PoChangeIup)
		{
			ListYesNoType _ItemVendAdd = ItemVendAdd;
			ListYesNoType _ItemVendUpdate = ItemVendUpdate;
			ListYesNoType _PoChangeIup = PoChangeIup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoBlnSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "ItemVendAdd", _ItemVendAdd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemVendUpdate", _ItemVendUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChangeIup", _PoChangeIup, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
