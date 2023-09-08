//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectPackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectPackingSlip : IRpt_ProjectPackingSlip
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectPackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectPackingSlipSp(string PckCall,
		int? MinPackNum = null,
		int? MaxPackNum = null,
		int? PrintProjNotes = 0,
		int? PrintResNotes = 0,
		int? ShowInternal = 0,
		int? ShowExternal = 0,
		int? DisplayHeader = 0,
		int? ActiveStatus = 1,
		int? InActiveStatus = 1,
		int? CompleteStatus = 1,
		int? IncludeSN = 0,
		string pSite = null)
		{
			StringType _PckCall = PckCall;
			PackNumType _MinPackNum = MinPackNum;
			PackNumType _MaxPackNum = MaxPackNum;
			FlagNyType _PrintProjNotes = PrintProjNotes;
			FlagNyType _PrintResNotes = PrintResNotes;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DisplayHeader = DisplayHeader;
			ListYesNoType _ActiveStatus = ActiveStatus;
			ListYesNoType _InActiveStatus = InActiveStatus;
			ListYesNoType _CompleteStatus = CompleteStatus;
			ListYesNoType _IncludeSN = IncludeSN;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectPackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "PckCall", _PckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MinPackNum", _MinPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxPackNum", _MaxPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProjNotes", _PrintProjNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintResNotes", _PrintResNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveStatus", _ActiveStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InActiveStatus", _InActiveStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompleteStatus", _CompleteStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSN", _IncludeSN, ParameterDirection.Input);
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
