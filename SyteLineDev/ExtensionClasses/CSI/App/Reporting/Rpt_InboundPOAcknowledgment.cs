//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InboundPOAcknowledgment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InboundPOAcknowledgment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InboundPOAcknowledgmentSp(string StartVendor = null,
		string EndVendor = null,
		string StartPO = null,
		string EndPO = null,
		string StartVendorOrder = null,
		string EndVendorOrder = null,
		string Posted = null,
		byte? ShowDetail = null,
		byte? ShowErrorOnly = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? PoAckNotes = null,
		byte? PoAckBlnNotes = null,
		byte? PoAckItemNotes = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_InboundPOAcknowledgment : IRpt_InboundPOAcknowledgment
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InboundPOAcknowledgment(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InboundPOAcknowledgmentSp(string StartVendor = null,
		string EndVendor = null,
		string StartPO = null,
		string EndPO = null,
		string StartVendorOrder = null,
		string EndVendorOrder = null,
		string Posted = null,
		byte? ShowDetail = null,
		byte? ShowErrorOnly = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? PoAckNotes = null,
		byte? PoAckBlnNotes = null,
		byte? PoAckItemNotes = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			VendNumType _StartVendor = StartVendor;
			VendNumType _EndVendor = EndVendor;
			PoNumType _StartPO = StartPO;
			PoNumType _EndPO = EndPO;
			VendOrderType _StartVendorOrder = StartVendorOrder;
			VendOrderType _EndVendorOrder = EndVendorOrder;
			InfobarType _Posted = Posted;
			FlagNyType _ShowDetail = ShowDetail;
			FlagNyType _ShowErrorOnly = ShowErrorOnly;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _PoAckNotes = PoAckNotes;
			ListYesNoType _PoAckBlnNotes = PoAckBlnNotes;
			ListYesNoType _PoAckItemNotes = PoAckItemNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InboundPOAcknowledgmentSp";
				
				appDB.AddCommandParameter(cmd, "StartVendor", _StartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendor", _EndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPO", _StartPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPO", _EndPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendorOrder", _StartVendorOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendorOrder", _EndVendorOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Posted", _Posted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowErrorOnly", _ShowErrorOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoAckNotes", _PoAckNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoAckBlnNotes", _PoAckBlnNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoAckItemNotes", _PoAckItemNotes, ParameterDirection.Input);
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
