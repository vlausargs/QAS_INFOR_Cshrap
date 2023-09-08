//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_SalespersonOppsClosed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_SalespersonOppsClosed
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_SalespersonOppsClosedSp(string Salesperson = null,
		byte? IncludeDirectReports = (byte)1,
		string DateType = "D");
	}
	
	public class Homepage_SalespersonOppsClosed : IHomepage_SalespersonOppsClosed
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Homepage_SalespersonOppsClosed(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_SalespersonOppsClosedSp(string Salesperson = null,
		byte? IncludeDirectReports = (byte)1,
		string DateType = "D")
		{
			SlsmanType _Salesperson = Salesperson;
			ListYesNoType _IncludeDirectReports = IncludeDirectReports;
			LoadTypeType _DateType = DateType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Homepage_SalespersonOppsClosedSp";
				
				appDB.AddCommandParameter(cmd, "Salesperson", _Salesperson, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeDirectReports", _IncludeDirectReports, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateType", _DateType, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
