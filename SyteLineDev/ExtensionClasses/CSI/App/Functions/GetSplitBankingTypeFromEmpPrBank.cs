using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Functions
{
    public class GetSplitBankingTypeFromEmpPrBank : IGetSplitBankingTypeFromEmpPrBank
    {
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public GetSplitBankingTypeFromEmpPrBank(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

        public ICollectionLoadResponse GetSplitBankingTypeFromEmpPrBankSp(string EmpNum)
        {
			EmpNumType _EmpNum = EmpNum;
			using (IDbCommand cmd = appDB.CreateCommand())
            {
				cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.[GetSplitBankingTypeFromEmpPrBankSp](@EmpNum)";

				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);

				DataTable dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetSplitBankingTypeFromEmpPrBank";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
    }
}
