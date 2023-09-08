//PROJECT NAME: Data
//CLASS NAME: InValidPrtrxStagingRecords.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InValidPrtrxStagingRecords : IInValidPrtrxStagingRecords
	{
		readonly IApplicationDB appDB;
		
		public InValidPrtrxStagingRecords(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InValidPrtrxStagingRecordsFn(
			Guid? pProcessId,
			Guid? pRowPointer,
			string pStartDept,
			string pEndDept,
			string pStartEmpNum,
			string pEndEmpNum,
			int? pPrintZeroChecks,
			string pEmpType,
			string PStartEmpCate,
			string PEndEmpCate)
		{
			GuidType _pProcessId = pProcessId;
			RowPointerType _pRowPointer = pRowPointer;
			DeptType _pStartDept = pStartDept;
			DeptType _pEndDept = pEndDept;
			EmpNumType _pStartEmpNum = pStartEmpNum;
			EmpNumType _pEndEmpNum = pEndEmpNum;
			FlagNyType _pPrintZeroChecks = pPrintZeroChecks;
			StringType _pEmpType = pEmpType;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[InValidPrtrxStagingRecords](@pProcessId, @pRowPointer, @pStartDept, @pEndDept, @pStartEmpNum, @pEndEmpNum, @pPrintZeroChecks, @pEmpType, @PStartEmpCate, @PEndEmpCate)";
				
				appDB.AddCommandParameter(cmd, "pProcessId", _pProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRowPointer", _pRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDept", _pStartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDept", _pEndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartEmpNum", _pStartEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndEmpNum", _pEndEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintZeroChecks", _pPrintZeroChecks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpType", _pEmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
