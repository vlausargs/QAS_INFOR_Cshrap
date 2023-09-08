//PROJECT NAME: Data
//CLASS NAME: CoDConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Functions
{
	public class CoDConfig : ICoDConfig
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public CoDConfig(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse CoDConfigFn(
			string PCoitemCoNum,
			int? PCoitemCoLine,
			int? PCoitemCoRelease,
			string PCoitemItem,
			string PCoitemShipSite,
			DateTime? PCoOrderDate,
			string PCoitemFeatStr)
		{
			CoNumType _PCoitemCoNum = PCoitemCoNum;
			CoLineType _PCoitemCoLine = PCoitemCoLine;
			CoReleaseType _PCoitemCoRelease = PCoitemCoRelease;
			ItemType _PCoitemItem = PCoitemItem;
			SiteType _PCoitemShipSite = PCoitemShipSite;
			DateType _PCoOrderDate = PCoOrderDate;
			FeatStrType _PCoitemFeatStr = PCoitemFeatStr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[CoDConfig](@PCoitemCoNum, @PCoitemCoLine, @PCoitemCoRelease, @PCoitemItem, @PCoitemShipSite, @PCoOrderDate, @PCoitemFeatStr)";
				
				appDB.AddCommandParameter(cmd, "PCoitemCoNum", _PCoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoLine", _PCoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoRelease", _PCoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemItem", _PCoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemShipSite", _PCoitemShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoOrderDate", _PCoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemFeatStr", _PCoitemFeatStr, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_CoDConfig";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
