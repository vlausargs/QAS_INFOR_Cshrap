//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentDistGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARPaymentDistGen : IARPaymentDistGen
	{
		readonly IApplicationDB appDB;
		
		
		public ARPaymentDistGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CallVar,
		string ParmsSite,
		string Infobar) ARPaymentDistGenSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		int? PReapplication,
		string POpenType,
		string CallVar,
		string ParmsSite,
		string Infobar,
		string CreditMemoNum = null)
		{
			BankCodeType _PBankCode = PBankCode;
			CustNumType _PCustNum = PCustNum;
			ArpmtTypeType _PType = PType;
			ArCheckNumType _PCheckNum = PCheckNum;
			ListYesNoType _PReapplication = PReapplication;
			LongListType _POpenType = POpenType;
			LongListType _CallVar = CallVar;
			SiteType _ParmsSite = ParmsSite;
			InfobarType _Infobar = Infobar;
			InvNumType _CreditMemoNum = CreditMemoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPaymentDistGenSp";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReapplication", _PReapplication, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenType", _POpenType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallVar", _CallVar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreditMemoNum", _CreditMemoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CallVar = _CallVar;
				ParmsSite = _ParmsSite;
				Infobar = _Infobar;
				
				return (Severity, CallVar, ParmsSite, Infobar);
			}
		}
	}
}
