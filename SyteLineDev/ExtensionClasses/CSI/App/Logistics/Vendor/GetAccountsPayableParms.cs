//PROJECT NAME: CSIVendor
//CLASS NAME: GetAccountsPayableParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetAccountsPayableParms
	{
		int GetAccountsPayableParmsSp(ref string APCheckFormType);
	}
	
	public class GetAccountsPayableParms : IGetAccountsPayableParms
	{
		readonly IApplicationDB appDB;
		
		public GetAccountsPayableParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAccountsPayableParmsSp(ref string APCheckFormType)
		{
			ApCheckFormTypeType _APCheckFormType = APCheckFormType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAccountsPayableParmsSp";
				
				appDB.AddCommandParameter(cmd, "APCheckFormType", _APCheckFormType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				APCheckFormType = _APCheckFormType;
				
				return Severity;
			}
		}
	}
}
