//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetBATPRODORD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetBATPRODORD
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetBATPRODORDSp(int? AltNo,
		int? BatProd = null,
		string Filter = null);
	}

	public class CLM_ApsGetBATPRODORD : ICLM_ApsGetBATPRODORD
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

		public CLM_ApsGetBATPRODORD(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetBATPRODORDSp(int? AltNo,
		int? BatProd = null,
		string Filter = null)
		{
			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{
				ApsAltNoType _AltNo = AltNo;
				ApsBatchNumberType _BatProd = BatProd;
				LongListType _Filter = Filter;

				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();

					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsGetBATPRODORDSp";

					appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BatProd", _BatProd, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);

					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

					dtReturn = appDB.ExecuteQuery(cmd);

					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}
	}
}
