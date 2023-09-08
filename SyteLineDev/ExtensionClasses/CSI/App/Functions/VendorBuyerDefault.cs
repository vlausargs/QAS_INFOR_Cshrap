//PROJECT NAME: Data
//CLASS NAME: VendorBuyerDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VendorBuyerDefault : IVendorBuyerDefault
	{
		readonly IApplicationDB appDB;
		
		public VendorBuyerDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Buyer,
			string Infobar) VendorBuyerDefaultSp(
			string PVendNum,
			string Buyer,
			string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			UsernameType _Buyer = Buyer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendorBuyerDefaultSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Buyer = _Buyer;
				Infobar = _Infobar;
				
				return (Severity, Buyer, Infobar);
			}
		}
	}
}
