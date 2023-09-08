//PROJECT NAME: Finance
//CLASS NAME: MXVATARTransfer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public interface IMXVATARTransfer
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) MXVATARTransferSp(DateTime? StartingReconDate = null,
		                                                                                  DateTime? EndingReconDate = null,
		                                                                                  string StartingBankCode = null,
		                                                                                  string EndingBankCode = null,
		                                                                                  string PrintOrCommit = "P",
		                                                                                  string Infobar = null);
	}
	
	public class MXVATARTransfer : IMXVATARTransfer
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MXVATARTransfer(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) MXVATARTransferSp(DateTime? StartingReconDate = null,
		                                                                                         DateTime? EndingReconDate = null,
		                                                                                         string StartingBankCode = null,
		                                                                                         string EndingBankCode = null,
		                                                                                         string PrintOrCommit = "P",
		                                                                                         string Infobar = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				DateType _StartingReconDate = StartingReconDate;
				DateType _EndingReconDate = EndingReconDate;
				BankCodeType _StartingBankCode = StartingBankCode;
				BankCodeType _EndingBankCode = EndingBankCode;
				StringType _PrintOrCommit = PrintOrCommit;
				Infobar _Infobar = Infobar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "MXVATARTransferSp";
					
					appDB.AddCommandParameter(cmd, "StartingReconDate", _StartingReconDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingReconDate", _EndingReconDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingBankCode", _StartingBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingBankCode", _EndingBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PrintOrCommit", _PrintOrCommit, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
