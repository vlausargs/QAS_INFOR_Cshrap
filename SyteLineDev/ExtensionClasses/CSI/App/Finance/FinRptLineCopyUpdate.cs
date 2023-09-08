//PROJECT NAME: CSIFinance
//CLASS NAME: FinRptLineCopyUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IFinRptLineCopyUpdate
	{
		DataTable FinRptLineCopyUpdateSp(string Operation,
		                                 string FromReportId,
		                                 int? StartSeq,
		                                 int? EndSeq,
		                                 string ToSite,
		                                 string ToReportId,
		                                 int? AfterLine,
		                                 byte? AddToRatio,
		                                 byte? CompToRatio,
		                                 string PrintLine,
		                                 byte? PrintDollar,
		                                 byte? RunMode);
	}
	
	public class FinRptLineCopyUpdate : IFinRptLineCopyUpdate
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public FinRptLineCopyUpdate(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable FinRptLineCopyUpdateSp(string Operation,
		                                        string FromReportId,
		                                        int? StartSeq,
		                                        int? EndSeq,
		                                        string ToSite,
		                                        string ToReportId,
		                                        int? AfterLine,
		                                        byte? AddToRatio,
		                                        byte? CompToRatio,
		                                        string PrintLine,
		                                        byte? PrintDollar,
		                                        byte? RunMode)
		{
			StringType _Operation = Operation;
			RptIdType _FromReportId = FromReportId;
			FinStmtSeqType _StartSeq = StartSeq;
			FinStmtSeqType _EndSeq = EndSeq;
			SiteType _ToSite = ToSite;
			RptIdType _ToReportId = ToReportId;
			GenericIntType _AfterLine = AfterLine;
			FinStmtColType _AddToRatio = AddToRatio;
			FinStmtColType _CompToRatio = CompToRatio;
			StringType _PrintLine = PrintLine;
			ListYesNoType _PrintDollar = PrintDollar;
			ListYesNoType _RunMode = RunMode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptLineCopyUpdateSp";
				
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromReportId", _FromReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSeq", _StartSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSeq", _EndSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToReportId", _ToReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AfterLine", _AfterLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddToRatio", _AddToRatio, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompToRatio", _CompToRatio, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLine", _PrintLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDollar", _PrintDollar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunMode", _RunMode, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
