//PROJECT NAME: Reporting
//CLASS NAME: SSSRMXRpt_ItemAtVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ISSSRMXRpt_ItemAtVendor
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRMXRpt_ItemAtVendorSp(int? inc_ord_type,
		string beg_vend_num,
		string end_vend_num,
		string beg_item,
		string end_item,
		string beg_ref_num,
		string end_ref_num,
		byte? page_per_vendor,
		string pSite = null,
		byte? PrintItemOverview = null);
	}
	
	public class SSSRMXRpt_ItemAtVendor : ISSSRMXRpt_ItemAtVendor
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRMXRpt_ItemAtVendor(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRMXRpt_ItemAtVendorSp(int? inc_ord_type,
		string beg_vend_num,
		string end_vend_num,
		string beg_item,
		string end_item,
		string beg_ref_num,
		string end_ref_num,
		byte? page_per_vendor,
		string pSite = null,
		byte? PrintItemOverview = null)
		{
			GenericIntType _inc_ord_type = inc_ord_type;
			VendNumType _beg_vend_num = beg_vend_num;
			VendNumType _end_vend_num = end_vend_num;
			ItemType _beg_item = beg_item;
			ItemType _end_item = end_item;
			FSRefNumType _beg_ref_num = beg_ref_num;
			FSRefNumType _end_ref_num = end_ref_num;
			ListYesNoType _page_per_vendor = page_per_vendor;
			SiteType _pSite = pSite;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXRpt_ItemAtVendorSp";
				
				appDB.AddCommandParameter(cmd, "inc_ord_type", _inc_ord_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_vend_num", _beg_vend_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_vend_num", _end_vend_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_item", _beg_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_item", _end_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_ref_num", _beg_ref_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_ref_num", _end_ref_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "page_per_vendor", _page_per_vendor, ParameterDirection.Input);
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
