//PROJECT NAME: CSIVendor
//CLASS NAME: GenApValInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGenApValInvNum
	{
		(int? ReturnCode, string PromptMsg, string PromptButtons) GenApValInvNumSp(string PoInvNum,
		string PoVendNum,
		string Voucher,
		string SiteRef = null,
		Guid? ProcessID = null,
		string CalledFrom = null,
		string PromptMsg = null,
		string PromptButtons = null);
	}
	
	public class GenApValInvNum : IGenApValInvNum
	{
		readonly IApplicationDB appDB;
		
		public GenApValInvNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg, string PromptButtons) GenApValInvNumSp(string PoInvNum,
		string PoVendNum,
		string Voucher,
		string SiteRef = null,
		Guid? ProcessID = null,
		string CalledFrom = null,
		string PromptMsg = null,
		string PromptButtons = null)
		{
			VendInvNumType _PoInvNum = PoInvNum;
			VendNumType _PoVendNum = PoVendNum;
			TTVoucherType _Voucher = Voucher;
			SiteType _SiteRef = SiteRef;
			RowPointerType _ProcessID = ProcessID;
			StringType _CalledFrom = CalledFrom;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenApValInvNumSp";
				
				appDB.AddCommandParameter(cmd, "PoInvNum", _PoInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVendNum", _PoVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PromptMsg, PromptButtons);
			}
		}
	}
}
