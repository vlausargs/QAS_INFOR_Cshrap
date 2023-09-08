//PROJECT NAME: Logistics
//CLASS NAME: VoucherCanEdi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherCanEdi : IVoucherCanEdi
	{
		readonly IApplicationDB appDB;
		
		public VoucherCanEdi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? VoucherCanEdiFn(
			string VendNum)
		{
			VendNumType _VendNum = VendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[VoucherCanEdi](@VendNum)";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
