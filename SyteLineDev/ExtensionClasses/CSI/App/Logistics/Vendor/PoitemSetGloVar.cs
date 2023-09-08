//PROJECT NAME: Logistics
//CLASS NAME: PoitemSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoitemSetGloVar : IPoitemSetGloVar
	{
		readonly IApplicationDB appDB;
		
		
		public PoitemSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PoitemSetGloVarSp(int? ItemVendAdd,
		int? ItemVendUpdate,
		int? PoChangeIup,
		int? AddProjMatl,
		string CostCode,
		int? UpdateJobMatlUnitCost)
		{
			ListYesNoType _ItemVendAdd = ItemVendAdd;
			ListYesNoType _ItemVendUpdate = ItemVendUpdate;
			ListYesNoType _PoChangeIup = PoChangeIup;
			ListYesNoType _AddProjMatl = AddProjMatl;
			CostCodeType _CostCode = CostCode;
			ListYesNoType _UpdateJobMatlUnitCost = UpdateJobMatlUnitCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoitemSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "ItemVendAdd", _ItemVendAdd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemVendUpdate", _ItemVendUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChangeIup", _PoChangeIup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddProjMatl", _AddProjMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateJobMatlUnitCost", _UpdateJobMatlUnitCost, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
