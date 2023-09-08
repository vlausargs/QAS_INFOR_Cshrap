//PROJECT NAME: Data
//CLASS NAME: EurVendEurVBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EurVendEurVBal : IEurVendEurVBal
	{
		readonly IApplicationDB appDB;
		
		public EurVendEurVBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? pNetDue) EurVendEurVBalSp(
			string pVendNum,
			int? pVoucher,
			decimal? pNetDue)
		{
			VendNumType _pVendNum = pVendNum;
			VoucherType _pVoucher = pVoucher;
			DecimalType _pNetDue = pNetDue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EurVendEurVBalSp";
				
				appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVoucher", _pVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNetDue", _pNetDue, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pNetDue = _pNetDue;
				
				return (Severity, pNetDue);
			}
		}
	}
}
