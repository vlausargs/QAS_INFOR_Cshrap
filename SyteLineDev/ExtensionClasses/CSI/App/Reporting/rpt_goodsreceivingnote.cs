//PROJECT NAME: Reporting
//CLASS NAME: rpt_goodsreceivingnote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface Irpt_goodsreceivingnote
	{
		(ICollectionLoadResponse Data, int? ReturnCode) rpt_goodsreceivingnotesp(string GRNStatus = null,
		byte? PageBreakByGRN = (byte)0,
		string StartingGRN = null,
		string EndingGRN = null,
		string StartingVendor = null,
		string EndingVendor = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null,
		byte? PrintItemOverview = null);
	}
	
	public class rpt_goodsreceivingnote : Irpt_goodsreceivingnote
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public rpt_goodsreceivingnote(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) rpt_goodsreceivingnotesp(string GRNStatus = null,
		byte? PageBreakByGRN = (byte)0,
		string StartingGRN = null,
		string EndingGRN = null,
		string StartingVendor = null,
		string EndingVendor = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null,
		byte? PrintItemOverview = null)
		{
			StringType _GRNStatus = GRNStatus;
			ListYesNoType _PageBreakByGRN = PageBreakByGRN;
			GrnNumType _StartingGRN = StartingGRN;
			GrnNumType _EndingGRN = EndingGRN;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "rpt_goodsreceivingnotesp";
				
				appDB.AddCommandParameter(cmd, "GRNStatus", _GRNStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBreakByGRN", _PageBreakByGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingGRN", _StartingGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingGRN", _EndingGRN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
