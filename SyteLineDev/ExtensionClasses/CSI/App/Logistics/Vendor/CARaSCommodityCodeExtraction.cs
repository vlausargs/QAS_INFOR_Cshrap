//PROJECT NAME: CSIVendor
//CLASS NAME: CARaSCommodityCodeExtraction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICARaSCommodityCodeExtraction
	{
		DataTable CARaSCommodityCodeExtractionSp(string StartCommCode,
		                                         string EndCommCode);
	}
	
	public class CARaSCommodityCodeExtraction : ICARaSCommodityCodeExtraction
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CARaSCommodityCodeExtraction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CARaSCommodityCodeExtractionSp(string StartCommCode,
		                                                string EndCommCode)
		{
			CommodityCodeType _StartCommCode = StartCommCode;
			CommodityCodeType _EndCommCode = EndCommCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CARaSCommodityCodeExtractionSp";
				
				appDB.AddCommandParameter(cmd, "StartCommCode", _StartCommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCommCode", _EndCommCode, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
