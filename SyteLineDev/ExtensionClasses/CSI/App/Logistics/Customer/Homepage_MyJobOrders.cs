//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MyJobOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_MyJobOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_MyJobOrdersSp(DateTime? Date,
		string DateType = "D",
		string TakenBy = null,
		string Salesperson = null,
		byte? OnlyCo = (byte)0,
		string ProjMgr = null,
		byte? OnlyProj = (byte)0);
	}
	
	public class Homepage_MyJobOrders : IHomepage_MyJobOrders
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Homepage_MyJobOrders(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_MyJobOrdersSp(DateTime? Date,
		string DateType = "D",
		string TakenBy = null,
		string Salesperson = null,
		byte? OnlyCo = (byte)0,
		string ProjMgr = null,
		byte? OnlyProj = (byte)0)
		{
			DateType _Date = Date;
			StringType _DateType = DateType;
			TakenByType _TakenBy = TakenBy;
			SlsmanType _Salesperson = Salesperson;
			ListYesNoType _OnlyCo = OnlyCo;
			NameType _ProjMgr = ProjMgr;
			ListYesNoType _OnlyProj = OnlyProj;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Homepage_MyJobOrdersSp";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateType", _DateType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TakenBy", _TakenBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Salesperson", _Salesperson, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OnlyCo", _OnlyCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjMgr", _ProjMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OnlyProj", _OnlyProj, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
