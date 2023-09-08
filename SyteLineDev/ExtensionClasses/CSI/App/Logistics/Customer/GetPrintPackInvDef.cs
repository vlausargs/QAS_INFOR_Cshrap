//PROJECT NAME: CSICustomer
//CLASS NAME: GetPrintPackInvDef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetPrintPackInvDef
	{
		int GetPrintPackInvDefSp(ref byte? PrintPackInv);
	}
	
	public class GetPrintPackInvDef : IGetPrintPackInvDef
	{
		readonly IApplicationDB appDB;
		
		public GetPrintPackInvDef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetPrintPackInvDefSp(ref byte? PrintPackInv)
		{
			ListYesNoType _PrintPackInv = PrintPackInv;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPrintPackInvDefSp";
				
				appDB.AddCommandParameter(cmd, "PrintPackInv", _PrintPackInv, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrintPackInv = _PrintPackInv;
				
				return Severity;
			}
		}
	}
}
