//PROJECT NAME: CSIVendor
//CLASS NAME: GetMasterBuyAgreement.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetMasterBuyAgreement
	{
		int GetMasterBuyAgreementSp(string Item,
		                            string VendNum,
		                            ref byte? MasterBuyAgreement);
	}
	
	public class GetMasterBuyAgreement : IGetMasterBuyAgreement
	{
		readonly IApplicationDB appDB;
		
		public GetMasterBuyAgreement(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetMasterBuyAgreementSp(string Item,
		                                   string VendNum,
		                                   ref byte? MasterBuyAgreement)
		{
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			ListYesNoType _MasterBuyAgreement = MasterBuyAgreement;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMasterBuyAgreementSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MasterBuyAgreement", _MasterBuyAgreement, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MasterBuyAgreement = _MasterBuyAgreement;
				
				return Severity;
			}
		}
	}
}
