//PROJECT NAME: Data
//CLASS NAME: FormatVendorAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class FormatVendorAddress : IFormatVendorAddress
	{
		readonly IApplicationDB appDB;

		public FormatVendorAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string VendorAddress,
			string Infobar) FormatVendorAddressSp(
			string VendNum,
			string VendorAddress,
			string Infobar)
		{
			VendNumType _VendNum = VendNum;
			LongAddress _VendorAddress = VendorAddress;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormatVendorAddressSp";

				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorAddress", _VendorAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				VendorAddress = _VendorAddress;
				Infobar = _Infobar;

				return (Severity, VendorAddress, Infobar);
			}
		}

		public string FormatVendorAddressFn(
			string VendNum)
		{
			VendNumType _VendNum = VendNum;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatVendorAddress](@VendNum)";

				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
