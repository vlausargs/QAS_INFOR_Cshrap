//PROJECT NAME: Logistics
//CLASS NAME: PreqitemValidateVendNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PreqitemValidateVendNum : IPreqitemValidateVendNum
	{
		readonly IApplicationDB appDB;
		
		
		public PreqitemValidateVendNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PPlanCostConv,
		string PVendCurrCode,
		string Infobar) PreqitemValidateVendNumSp(string PVendNum,
		string POldVendNum,
		string PItem,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PPlanCostConv,
		string PVendCurrCode,
		string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			VendNumType _POldVendNum = POldVendNum;
			ItemType _PItem = PItem;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			CostPrcType _PPlanCostConv = PPlanCostConv;
			CurrCodeType _PVendCurrCode = PVendCurrCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreqitemValidateVendNumSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldVendNum", _POldVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPlanCostConv", _PPlanCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVendCurrCode", _PVendCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAcct = _PAcct;
				PAcctUnit1 = _PAcctUnit1;
				PAcctUnit2 = _PAcctUnit2;
				PAcctUnit3 = _PAcctUnit3;
				PAcctUnit4 = _PAcctUnit4;
				PPlanCostConv = _PPlanCostConv;
				PVendCurrCode = _PVendCurrCode;
				Infobar = _Infobar;
				
				return (Severity, PAcct, PAcctUnit1, PAcctUnit2, PAcctUnit3, PAcctUnit4, PPlanCostConv, PVendCurrCode, Infobar);
			}
		}
	}
}
