//PROJECT NAME: CSICustomer
//CLASS NAME: GetSalesmanAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetSalesmanAddress
	{
		int GetSalesmanAddressSp(string RefNum,
		                         byte? Outside,
		                         ref string SalesmanAddress,
		                         ref string Infobar,
                                 ref string UserName);
	}
	
	public class GetSalesmanAddress : IGetSalesmanAddress
	{
		readonly IApplicationDB appDB;
		
		public GetSalesmanAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetSalesmanAddressSp(string RefNum,
		                                byte? Outside,
		                                ref string SalesmanAddress,
		                                ref string Infobar,
                                        ref string UserName)
		{
			EmpVendNumType _RefNum = RefNum;
			ListYesNoType _Outside = Outside;
			LongAddress _SalesmanAddress = SalesmanAddress;
			Infobar _Infobar = Infobar;
            UsernameType _UserName = UserName;


            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSalesmanAddressSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Outside", _Outside, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesmanAddress", _SalesmanAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				SalesmanAddress = _SalesmanAddress;
				Infobar = _Infobar;
                UserName = _UserName;

                return Severity;
			}
		}
	}
}
