//PROJECT NAME: Logistics
//CLASS NAME: InvPostingCreateTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvPostingCreateTT : IInvPostingCreateTT
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public InvPostingCreateTT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) InvPostingCreateTTSp(string PStartingCustNum,
		string PEndingCustNum,
		string PStartingInvNum,
		string PEndingInvNum,
		DateTime? PStartingInvDate,
		DateTime? PEndingInvDate,
		DateTime? PStartingDueDate,
		DateTime? PEndingDueDate,
		string PInvoice,
		string PDebitMemo,
		string PCreditMemo,
		Guid? PSessionID,
		string StartBuilderInvNum = null,
		string EndBuilderInvNum = null,
		string ToSite = null,
		int? CalledFromBackground = 0,
		int? SkipResultSet = 0)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CustNumType _PStartingCustNum = PStartingCustNum;
				CustNumType _PEndingCustNum = PEndingCustNum;
				InvNumType _PStartingInvNum = PStartingInvNum;
				InvNumType _PEndingInvNum = PEndingInvNum;
				DateTimeType _PStartingInvDate = PStartingInvDate;
				DateTimeType _PEndingInvDate = PEndingInvDate;
				DateTimeType _PStartingDueDate = PStartingDueDate;
				DateTimeType _PEndingDueDate = PEndingDueDate;
				StringType _PInvoice = PInvoice;
				StringType _PDebitMemo = PDebitMemo;
				StringType _PCreditMemo = PCreditMemo;
				RowPointer _PSessionID = PSessionID;
				BuilderInvNumType _StartBuilderInvNum = StartBuilderInvNum;
				BuilderInvNumType _EndBuilderInvNum = EndBuilderInvNum;
				SiteType _ToSite = ToSite;
				ListYesNoType _CalledFromBackground = CalledFromBackground;
				ListYesNoType _SkipResultSet = SkipResultSet;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "InvPostingCreateTTSp";
					
					appDB.AddCommandParameter(cmd, "PStartingCustNum", _PStartingCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingCustNum", _PEndingCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingInvNum", _PStartingInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingInvNum", _PEndingInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingInvDate", _PStartingInvDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingInvDate", _PEndingInvDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingDueDate", _PStartingDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingDueDate", _PEndingDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PInvoice", _PInvoice, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PDebitMemo", _PDebitMemo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCreditMemo", _PCreditMemo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartBuilderInvNum", _StartBuilderInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndBuilderInvNum", _EndBuilderInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CalledFromBackground", _CalledFromBackground, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SkipResultSet", _SkipResultSet, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
