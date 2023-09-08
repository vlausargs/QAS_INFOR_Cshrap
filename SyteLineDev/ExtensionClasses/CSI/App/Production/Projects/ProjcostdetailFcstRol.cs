//PROJECT NAME: Production
//CLASS NAME: ProjcostdetailFcstRol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjcostdetailFcstRol : IProjcostdetailFcstRol
	{
		readonly IApplicationDB appDB;
		
		public ProjcostdetailFcstRol(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProjcostdetailFcstRolSp(
			string PProjNum,
			int? PTaskNum,
			int? PMatlSeq,
			string PCostCode,
			string PIUDFlag,
			decimal? CostChange,
			DateTime? PDueDate,
			string PCostCodeType,
			string Infobar)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PMatlSeq = PMatlSeq;
			CostCodeType _PCostCode = PCostCode;
			StringType _PIUDFlag = PIUDFlag;
			AmountType _CostChange = CostChange;
			DateType _PDueDate = PDueDate;
			CostCodeTypeType _PCostCodeType = PCostCodeType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjcostdetailFcstRolSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatlSeq", _PMatlSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostCode", _PCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIUDFlag", _PIUDFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostChange", _CostChange, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostCodeType", _PCostCodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
