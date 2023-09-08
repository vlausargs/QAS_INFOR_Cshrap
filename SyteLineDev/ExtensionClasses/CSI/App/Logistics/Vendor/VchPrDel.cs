//PROJECT NAME: Logistics
//CLASS NAME: VchPrDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VchPrDel : IVchPrDel
	{
		readonly IApplicationDB appDB;
		
		
		public VchPrDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VchPrDelSp(int? BegPreRegister,
		int? EndPreRegister,
		string BegVendNum,
		string EndVendNum,
		DateTime? BegVchDate,
		DateTime? EndVchDate,
		int? DateNulChk,
		string Infobar,
		int? StartingVoucherDateOffset = null,
		int? EndingVoucherDateOffset = null)
		{
			PreRegisterType _BegPreRegister = BegPreRegister;
			PreRegisterType _EndPreRegister = EndPreRegister;
			VendNumType _BegVendNum = BegVendNum;
			VendNumType _EndVendNum = EndVendNum;
			DateType _BegVchDate = BegVchDate;
			DateType _EndVchDate = EndVchDate;
			IntType _DateNulChk = DateNulChk;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingVoucherDateOffset = StartingVoucherDateOffset;
			DateOffsetType _EndingVoucherDateOffset = EndingVoucherDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VchPrDelSp";
				
				appDB.AddCommandParameter(cmd, "BegPreRegister", _BegPreRegister, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPreRegister", _EndPreRegister, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVendNum", _BegVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVchDate", _BegVchDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVchDate", _EndVchDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateNulChk", _DateNulChk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingVoucherDateOffset", _StartingVoucherDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVoucherDateOffset", _EndingVoucherDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
