//PROJECT NAME: Logistics
//CLASS NAME: CoitemSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemSetGloVar : ICoitemSetGloVar
	{
		readonly IApplicationDB appDB;
		
		
		public CoitemSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CoitemSetGloVarSp(int? ItemCustAdd = 0,
		int? ItemCustUpdate = 0,
		int? AllowOverCreditLimit = 0)
		{
			ListYesNoType _ItemCustAdd = ItemCustAdd;
			ListYesNoType _ItemCustUpdate = ItemCustUpdate;
			ListYesNoType _AllowOverCreditLimit = AllowOverCreditLimit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "ItemCustAdd", _ItemCustAdd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCustUpdate", _ItemCustUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowOverCreditLimit", _AllowOverCreditLimit, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
