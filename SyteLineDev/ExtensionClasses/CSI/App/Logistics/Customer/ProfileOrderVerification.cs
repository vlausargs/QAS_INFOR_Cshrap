//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileOrderVerification.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IProfileOrderVerification
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileOrderVerificationSp(byte? CoTypeRegular = null,
		byte? CoTypeBlanket = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string SalespersonStarting = null,
		string SalespersonEnding = null,
		string Sortby = null,
        string CoStatus = null);
	}
	
	public class ProfileOrderVerification : IProfileOrderVerification
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileOrderVerification(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileOrderVerificationSp(byte? CoTypeRegular = null,
		byte? CoTypeBlanket = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string SalespersonStarting = null,
		string SalespersonEnding = null,
		string Sortby = null,
        string CoStatus = null)
		{
			ListYesNoType _CoTypeRegular = CoTypeRegular;
			ListYesNoType _CoTypeBlanket = CoTypeBlanket;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			SlsmanType _SalespersonStarting = SalespersonStarting;
			SlsmanType _SalespersonEnding = SalespersonEnding;
			StringType _Sortby = Sortby;
            StringType _CoStatus = CoStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileOrderVerificationSp";
				
				appDB.AddCommandParameter(cmd, "CoTypeRegular", _CoTypeRegular, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoTypeBlanket", _CoTypeBlanket, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalespersonStarting", _SalespersonStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalespersonEnding", _SalespersonEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sortby", _Sortby, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoStatus", _CoStatus, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
