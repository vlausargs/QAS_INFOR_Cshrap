//PROJECT NAME: Data
//CLASS NAME: GetItemSurchargeRule.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Functions
{
	public class GetItemSurchargeRule : IGetItemSurchargeRule
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public GetItemSurchargeRule(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse GetItemSurchargeRuleSp(
			string RefType = null,
			string RefNum = null,
			int? RefLine = 0,
			int? RefRelease = 0,
			string InvNum = null,
			DateTime? TransDate = null)
		{
			RefTypeCEIOPRVType _RefType = RefType;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
			CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
			InvNumType _InvNum = InvNum;
			DateTimeType _TransDate = TransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[GetItemSurchargeRuleSp](@RefType, @RefNum, @RefLine, @RefRelease, @InvNum, @TransDate)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetItemSurchargeRule";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
