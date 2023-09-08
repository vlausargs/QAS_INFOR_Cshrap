//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_GetSearchItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ICLM_GetSearchItems
	{
		DataTable CLM_GetSearchItemsSp(string Criteria,
		                               string CriterionTypes,
		                               int? LocaleID,
		                               string CustNum,
		                               string ResellerCustNum,
		                               string OrderBySel);
	}
	
	public class CLM_GetSearchItems : ICLM_GetSearchItems
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_GetSearchItems(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_GetSearchItemsSp(string Criteria,
		                                      string CriterionTypes,
		                                      int? LocaleID,
		                                      string CustNum,
		                                      string ResellerCustNum,
		                                      string OrderBySel)
		{
			StringType _Criteria = Criteria;
			StringType _CriterionTypes = CriterionTypes;
			GenericIntType _LocaleID = LocaleID;
			CustNumType _CustNum = CustNum;
			CustNumType _ResellerCustNum = ResellerCustNum;
			StringType _OrderBySel = OrderBySel;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetSearchItemsSp";
				
				appDB.AddCommandParameter(cmd, "Criteria", _Criteria, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CriterionTypes", _CriterionTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocaleID", _LocaleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerCustNum", _ResellerCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderBySel", _OrderBySel, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
