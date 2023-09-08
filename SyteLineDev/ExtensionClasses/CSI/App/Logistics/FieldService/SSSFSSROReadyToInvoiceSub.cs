//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROReadyToInvoiceSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROReadyToInvoiceSub : ISSSFSSROReadyToInvoiceSub
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROReadyToInvoiceSub(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSROReadyToInvoiceSubFn(
			int? InclBillHold,
			string OperationStatus = "I",
			string SRONum = null,
			string CustNum = null,
			int? StartSROLine = null,
			int? EndSROLine = null,
			int? StartSROOper = null,
			int? EndSROOper = null,
			DateTime? StartTransDate = null,
			DateTime? EndTransDate = null,
			string PInvCred = null,
			int? PInclCalculated = null,
			int? PInclProject = null)
		{
			ListYesNoType _InclBillHold = InclBillHold;
			StringType _OperationStatus = OperationStatus;
			FSSRONumType _SRONum = SRONum;
			CustNumType _CustNum = CustNum;
			FSSROLineType _StartSROLine = StartSROLine;
			FSSROLineType _EndSROLine = EndSROLine;
			FSSROOperType _StartSROOper = StartSROOper;
			FSSROOperType _EndSROOper = EndSROOper;
			DateType _StartTransDate = StartTransDate;
			DateType _EndTransDate = EndTransDate;
			StringType _PInvCred = PInvCred;
			ListYesNoType _PInclCalculated = PInclCalculated;
			ListYesNoType _PInclProject = PInclProject;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSROReadyToInvoiceSub](@InclBillHold, @OperationStatus, @SRONum, @CustNum, @StartSROLine, @EndSROLine, @StartSROOper, @EndSROOper, @StartTransDate, @EndTransDate, @PInvCred, @PInclCalculated, @PInclProject)";
				
				appDB.AddCommandParameter(cmd, "InclBillHold", _InclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationStatus", _OperationStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROLine", _StartSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROLine", _EndSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROOper", _StartSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROOper", _EndSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransDate", _StartTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvCred", _PInvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclCalculated", _PInclCalculated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclProject", _PInclProject, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
