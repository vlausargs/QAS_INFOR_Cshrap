//PROJECT NAME: CSIReport
//CLASS NAME: MO_Rpt_CoProduct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IMO_Rpt_CoProduct
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MO_Rpt_CoProductSp(string JobNum = null,
		short? JobSuffix = null,
		byte? CoProduct = (byte)0,
		string pSite = null);
	}
	
	public class MO_Rpt_CoProduct : IMO_Rpt_CoProduct
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MO_Rpt_CoProduct(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) MO_Rpt_CoProductSp(string JobNum = null,
		short? JobSuffix = null,
		byte? CoProduct = (byte)0,
		string pSite = null)
		{
			JobType _JobNum = JobNum;
			SuffixType _JobSuffix = JobSuffix;
			CoProductMixType _CoProduct = CoProduct;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_Rpt_CoProductSp";
				
				appDB.AddCommandParameter(cmd, "JobNum", _JobNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoProduct", _CoProduct, ParameterDirection.Input);
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
