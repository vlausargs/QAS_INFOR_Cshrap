//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtdSetGloVar : IArpmtdSetGloVar
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtdSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ArpmtdSetGloVarSp(int? TransferCash)
		{
			ListYesNoType _TransferCash = TransferCash;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "TransferCash", _TransferCash, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
