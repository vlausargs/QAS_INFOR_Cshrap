//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_BookingsByTime.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_BookingsByTime
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Homepage_BookingsByTimeSp(string Salesperson = null,
		byte? IncludeDirectReports = (byte)1,
		string DateType = "D",
		string CustNum = null,
		string Infobar = null);
	}
	
	public class Homepage_BookingsByTime : IHomepage_BookingsByTime
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Homepage_BookingsByTime(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Homepage_BookingsByTimeSp(string Salesperson = null,
		byte? IncludeDirectReports = (byte)1,
		string DateType = "D",
		string CustNum = null,
		string Infobar = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				SlsmanType _Salesperson = Salesperson;
				ListYesNoType _IncludeDirectReports = IncludeDirectReports;
				StringType _DateType = DateType;
				CustNumType _CustNum = CustNum;
				InfobarType _Infobar = Infobar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "Homepage_BookingsByTimeSp";
					
					appDB.AddCommandParameter(cmd, "Salesperson", _Salesperson, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IncludeDirectReports", _IncludeDirectReports, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DateType", _DateType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
