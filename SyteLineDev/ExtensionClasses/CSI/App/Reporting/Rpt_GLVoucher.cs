//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GLVoucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_GLVoucher
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_GLVoucherSp(string GLVoucherStarting,
		string GLVoucherEnding,
		string JournalId,
		byte? Preview = (byte)0,
		string pSite = null);
	}
	
	public class Rpt_GLVoucher : IRpt_GLVoucher
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_GLVoucher(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_GLVoucherSp(string GLVoucherStarting,
		string GLVoucherEnding,
		string JournalId,
		byte? Preview = (byte)0,
		string pSite = null)
		{
			InvNumVoucherType _GLVoucherStarting = GLVoucherStarting;
			InvNumVoucherType _GLVoucherEnding = GLVoucherEnding;
			JournalIdType _JournalId = JournalId;
			ListYesNoType _Preview = Preview;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_GLVoucherSp";
				
				appDB.AddCommandParameter(cmd, "GLVoucherStarting", _GLVoucherStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GLVoucherEnding", _GLVoucherEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Preview", _Preview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
