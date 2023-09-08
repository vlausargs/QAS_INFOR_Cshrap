//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROInspection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROInspection : ISSSFSRpt_SROInspection
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROInspection(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROInspectionSp(string StartSroNum = null,
		string EndSroNum = null,
		int? StartSroLine = null,
		int? EndSroLine = null,
		string StartInspectType = null,
		string EndInspectType = null,
		string StartLineSerNum = null,
		string EndLineSerNum = null,
		string StartLineItem = null,
		string EndLineItem = null,
		string StartSerNum = null,
		string EndSerNum = null,
		string StartItem = null,
		string EndItem = null,
		string StartPartner = null,
		string EndPartner = null,
		DateTime? StartInspDate = null,
		DateTime? EndInspDate = null,
		int? PrintSRONotes = 0,
		int? PrintSROLineNotes = 0,
		int? PrintInspNotes = 0,
		int? PrintInternalNotes = 0,
		int? PrintExternalNotes = 0,
		int? DisplayHeader = 0,
		string pSite = null)
		{
			FSSRONumType _StartSroNum = StartSroNum;
			FSSRONumType _EndSroNum = EndSroNum;
			FSSROLineType _StartSroLine = StartSroLine;
			FSSROLineType _EndSroLine = EndSroLine;
			FSInspectTypeType _StartInspectType = StartInspectType;
			FSInspectTypeType _EndInspectType = EndInspectType;
			SerNumType _StartLineSerNum = StartLineSerNum;
			SerNumType _EndLineSerNum = EndLineSerNum;
			ItemType _StartLineItem = StartLineItem;
			ItemType _EndLineItem = EndLineItem;
			SerNumType _StartSerNum = StartSerNum;
			SerNumType _EndSerNum = EndSerNum;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			FSPartnerType _StartPartner = StartPartner;
			FSPartnerType _EndPartner = EndPartner;
			DateType _StartInspDate = StartInspDate;
			DateType _EndInspDate = EndInspDate;
			ListYesNoType _PrintSRONotes = PrintSRONotes;
			ListYesNoType _PrintSROLineNotes = PrintSROLineNotes;
			ListYesNoType _PrintInspNotes = PrintInspNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROInspectionSp";
				
				appDB.AddCommandParameter(cmd, "StartSroNum", _StartSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroNum", _EndSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSroLine", _StartSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroLine", _EndSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInspectType", _StartInspectType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInspectType", _EndInspectType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineSerNum", _StartLineSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLineSerNum", _EndLineSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineItem", _StartLineItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLineItem", _EndLineItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSerNum", _StartSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSerNum", _EndSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPartner", _StartPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPartner", _EndPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInspDate", _StartInspDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInspDate", _EndInspDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSRONotes", _PrintSRONotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROLineNotes", _PrintSROLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInspNotes", _PrintInspNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
