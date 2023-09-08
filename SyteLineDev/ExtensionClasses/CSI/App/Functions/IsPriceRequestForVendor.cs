//PROJECT NAME: Data
//CLASS NAME: IsPriceRequestForVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsPriceRequestForVendor : IIsPriceRequestForVendor
	{
		readonly IApplicationDB appDB;
		
		public IsPriceRequestForVendor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsPriceRequestForVendorFn(
			string VendNum,
			string IprId)
		{
			VendNumType _VendNum = VendNum;
			ItemPriceRequestIdType _IprId = IprId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsPriceRequestForVendor](@VendNum, @IprId)";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IprId", _IprId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
