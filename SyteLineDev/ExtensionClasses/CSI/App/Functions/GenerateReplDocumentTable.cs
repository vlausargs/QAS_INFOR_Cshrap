//PROJECT NAME: Data
//CLASS NAME: GenerateReplDocumentTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Functions
{
	public class GenerateReplDocumentTable : IGenerateReplDocumentTable
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public GenerateReplDocumentTable(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse GenerateReplDocumentTableFn(
			string BODNoun,
			string BODVerb)
		{
			MarkupDocumentNameType _BODNoun = BODNoun;
			MarkupDocumentNameType _BODVerb = BODVerb;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[GenerateReplDocumentTable](@BODNoun, @BODVerb)";
				
				appDB.AddCommandParameter(cmd, "BODNoun", _BODNoun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODVerb", _BODVerb, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GenerateReplDocumentTable";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
