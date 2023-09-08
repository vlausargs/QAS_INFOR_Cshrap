//PROJECT NAME: CSIVendor
//CLASS NAME: GetDropShipToAddrWithPhone.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetDropShipToAddrWithPhone
	{
		int GetDropShipToAddrWithPhoneSp(string ShipTo,
		                                 string DropShipNo,
		                                 int? DropSeqNo,
		                                 string SiteRef,
		                                 ref string ShipToAddress);
	}
	
	public class GetDropShipToAddrWithPhone : IGetDropShipToAddrWithPhone
	{
		readonly IApplicationDB appDB;
		
		public GetDropShipToAddrWithPhone(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetDropShipToAddrWithPhoneSp(string ShipTo,
		                                        string DropShipNo,
		                                        int? DropSeqNo,
		                                        string SiteRef,
		                                        ref string ShipToAddress)
		{
			StringType _ShipTo = ShipTo;
			DropShipNoType _DropShipNo = DropShipNo;
			DropSeqType _DropSeqNo = DropSeqNo;
			SiteType _SiteRef = SiteRef;
			LongAddress _ShipToAddress = ShipToAddress;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDropShipToAddrWithPhoneSp";
				
				appDB.AddCommandParameter(cmd, "ShipTo", _ShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropShipNo", _DropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropSeqNo", _DropSeqNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ShipToAddress = _ShipToAddress;
				
				return Severity;
			}
		}
	}
}
