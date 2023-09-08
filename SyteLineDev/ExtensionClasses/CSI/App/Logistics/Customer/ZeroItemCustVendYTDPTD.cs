//PROJECT NAME: Logistics
//CLASS NAME: ZeroItemCustVendYTDPTD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ZeroItemCustVendYTDPTD : IZeroItemCustVendYTDPTD
	{
		readonly IApplicationDB appDB;
		
		
		public ZeroItemCustVendYTDPTD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ItemvendCount,
		int? ItemcustCount) ZeroItemCustVendYTDPTDSp(int? ZeroItemvendYTD,
		int? ZeroItemcustPTD,
		int? ZeroItemcustYTD,
		string BegItem,
		string EndItem,
		int? ItemvendCount,
		int? ItemcustCount)
		{
			ByteType _ZeroItemvendYTD = ZeroItemvendYTD;
			ByteType _ZeroItemcustPTD = ZeroItemcustPTD;
			ByteType _ZeroItemcustYTD = ZeroItemcustYTD;
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			IntType _ItemvendCount = ItemvendCount;
			IntType _ItemcustCount = ItemcustCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ZeroItemCustVendYTDPTDSp";
				
				appDB.AddCommandParameter(cmd, "ZeroItemvendYTD", _ZeroItemvendYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ZeroItemcustPTD", _ZeroItemcustPTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ZeroItemcustYTD", _ZeroItemcustYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemvendCount", _ItemvendCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemcustCount", _ItemcustCount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemvendCount = _ItemvendCount;
				ItemcustCount = _ItemcustCount;
				
				return (Severity, ItemvendCount, ItemcustCount);
			}
		}
	}
}
