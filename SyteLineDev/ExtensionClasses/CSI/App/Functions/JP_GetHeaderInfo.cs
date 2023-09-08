//PROJECT NAME: Data
//CLASS NAME: JP_GetHeaderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JP_GetHeaderInfo : IJP_GetHeaderInfo
	{
		readonly IApplicationDB appDB;
		
		public JP_GetHeaderInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CustNum,
			int? CustSeq,
			string ConsumptionTaxHeaderLineMethod,
			string ConsumptionTaxRoundMethod) JP_GetHeaderInfoSp(
			string RefType = null,
			Guid? RowPointer = null,
			string CustNum = null,
			int? CustSeq = null,
			string ConsumptionTaxHeaderLineMethod = null,
			string ConsumptionTaxRoundMethod = null)
		{
			RefType _RefType = RefType;
			RowPointer _RowPointer = RowPointer;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			JP_ConsumptionTaxHeaderLineMethodType _ConsumptionTaxHeaderLineMethod = ConsumptionTaxHeaderLineMethod;
			JP_ConsumptionTaxRoundMethodType _ConsumptionTaxRoundMethod = ConsumptionTaxRoundMethod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JP_GetHeaderInfoSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConsumptionTaxHeaderLineMethod", _ConsumptionTaxHeaderLineMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConsumptionTaxRoundMethod", _ConsumptionTaxRoundMethod, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				ConsumptionTaxHeaderLineMethod = _ConsumptionTaxHeaderLineMethod;
				ConsumptionTaxRoundMethod = _ConsumptionTaxRoundMethod;
				
				return (Severity, CustNum, CustSeq, ConsumptionTaxHeaderLineMethod, ConsumptionTaxRoundMethod);
			}
		}
	}
}
