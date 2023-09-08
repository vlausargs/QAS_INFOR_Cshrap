//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InboundVendorShipNotice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InboundVendorShipNotice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InboundVendorShipNoticeSp(string StartVendor = null,
		string EndVendor = null,
		string StartGrn = null,
		string EndGrn = null,
		DateTime? StartOrderDate = null,
		DateTime? EndOrderDate = null,
		string StartVendorOrder = null,
		string EndVendorOrder = null,
		string StartItem = null,
		string EndItem = null,
		byte? ShowDetail = null,
		byte? ShowErrorOnly = null,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null,
		byte? DisplayHeader = null,
		byte? IncludeSerialNumbers = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_InboundVendorShipNotice : IRpt_InboundVendorShipNotice
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InboundVendorShipNotice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InboundVendorShipNoticeSp(string StartVendor = null,
		string EndVendor = null,
		string StartGrn = null,
		string EndGrn = null,
		DateTime? StartOrderDate = null,
		DateTime? EndOrderDate = null,
		string StartVendorOrder = null,
		string EndVendorOrder = null,
		string StartItem = null,
		string EndItem = null,
		byte? ShowDetail = null,
		byte? ShowErrorOnly = null,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null,
		byte? DisplayHeader = null,
		byte? IncludeSerialNumbers = null,
		string pSite = null,
		string BGUser = null)
		{
			VendNumType _StartVendor = StartVendor;
			VendNumType _EndVendor = EndVendor;
			GrnNumType _StartGrn = StartGrn;
			GrnNumType _EndGrn = EndGrn;
			GenericDateType _StartOrderDate = StartOrderDate;
			GenericDateType _EndOrderDate = EndOrderDate;
			VendOrderType _StartVendorOrder = StartVendorOrder;
			VendOrderType _EndVendorOrder = EndVendorOrder;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			FlagNyType _ShowDetail = ShowDetail;
			FlagNyType _ShowErrorOnly = ShowErrorOnly;
			DateOffsetType _StartOrderDateOffset = StartOrderDateOffset;
			DateOffsetType _EndOrderDateOffset = EndOrderDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			FlagNyType _IncludeSerialNumbers = IncludeSerialNumbers;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InboundVendorShipNoticeSp";
				
				appDB.AddCommandParameter(cmd, "StartVendor", _StartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendor", _EndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartGrn", _StartGrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGrn", _EndGrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderDate", _StartOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderDate", _EndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendorOrder", _StartVendorOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendorOrder", _EndVendorOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowErrorOnly", _ShowErrorOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderDateOffset", _StartOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderDateOffset", _EndOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSerialNumbers", _IncludeSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
