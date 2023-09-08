//PROJECT NAME: CSICustomer
//CLASS NAME: ARPayPostUpdateTmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IARPayPostUpdateTmp
	{
		int? ARPayPostUpdateTmpSp(Guid? PSessionID,
		                          string PCustNum,
		                          string PBankCode,
		                          string PType,
		                          int? PCheckNum,
		                          int? PProcessSel,
		                          int? PUpdPrepaid,
		                          string CreditMemoNum = null);
	}
	
	public class ARPayPostUpdateTmp : IARPayPostUpdateTmp
	{
		readonly IApplicationDB appDB;
		
		public ARPayPostUpdateTmp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ARPayPostUpdateTmpSp(Guid? PSessionID,
		                                 string PCustNum,
		                                 string PBankCode,
		                                 string PType,
		                                 int? PCheckNum,
		                                 int? PProcessSel,
		                                 int? PUpdPrepaid,
		                                 string CreditMemoNum = null)
		{
			RowPointer _PSessionID = PSessionID;
			CustNumType _PCustNum = PCustNum;
			BankCodeType _PBankCode = PBankCode;
			ArpmtTypeType _PType = PType;
			ArCheckNumType _PCheckNum = PCheckNum;
			FlagNyType _PProcessSel = PProcessSel;
			FlagNyType _PUpdPrepaid = PUpdPrepaid;
			InvNumType _CreditMemoNum = CreditMemoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPayPostUpdateTmpSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessSel", _PProcessSel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUpdPrepaid", _PUpdPrepaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditMemoNum", _CreditMemoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
