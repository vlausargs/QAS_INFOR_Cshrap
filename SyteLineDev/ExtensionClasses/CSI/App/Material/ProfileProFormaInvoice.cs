//PROJECT NAME: CSIMaterial
//CLASS NAME: ProfileProFormaInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IProfileProFormaInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileProFormaInvoiceSp(int? pStartPackNum = null,
		int? pEndPackNum = null);
	}
	
	public class ProfileProFormaInvoice : IProfileProFormaInvoice
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileProFormaInvoice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileProFormaInvoiceSp(int? pStartPackNum = null,
		int? pEndPackNum = null)
		{
			PackNumType _pStartPackNum = pStartPackNum;
			PackNumType _pEndPackNum = pEndPackNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileProFormaInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "pStartPackNum", _pStartPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPackNum", _pEndPackNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
