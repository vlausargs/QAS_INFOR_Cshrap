//PROJECT NAME: Logistics
//CLASS NAME: CoBlnSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICoBlnSetGloVar
	{
		int? CoBlnSetGloVarSp(byte? ItemCustAdd = (byte)0,
		byte? ItemCustUpdate = (byte)0);
	}
	
	public class CoBlnSetGloVar : ICoBlnSetGloVar
	{
		readonly IApplicationDB appDB;
		
		public CoBlnSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CoBlnSetGloVarSp(byte? ItemCustAdd = (byte)0,
		byte? ItemCustUpdate = (byte)0)
		{
			ListYesNoType _ItemCustAdd = ItemCustAdd;
			ListYesNoType _ItemCustUpdate = ItemCustUpdate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoBlnSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "ItemCustAdd", _ItemCustAdd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCustUpdate", _ItemCustUpdate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
