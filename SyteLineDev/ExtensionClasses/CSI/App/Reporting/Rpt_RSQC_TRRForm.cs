//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_TRRForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_TRRForm : IRpt_RSQC_TRRForm
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_TRRForm(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_TRRFormSp(
			string begtrr = null,
			string endtrr = null,
			string beginsp = null,
			string endinsp = null,
			DateTime? begcreatedate = null,
			DateTime? endcreatedate = null,
			DateTime? begclosedate = null,
			DateTime? endclosedate = null,
			int? printnotes = null,
			int? PrintInternal = null,
			int? PrintExternal = null)
		{
			QCDocNumType _begtrr = begtrr;
			QCDocNumType _endtrr = endtrr;
			EmpNumType _beginsp = beginsp;
			EmpNumType _endinsp = endinsp;
			DateType _begcreatedate = begcreatedate;
			DateType _endcreatedate = endcreatedate;
			DateType _begclosedate = begclosedate;
			DateType _endclosedate = endclosedate;
			ListYesNoType _printnotes = printnotes;
			FlagNyType _PrintInternal = PrintInternal;
			FlagNyType _PrintExternal = PrintExternal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_TRRFormSp";
				
				appDB.AddCommandParameter(cmd, "begtrr", _begtrr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endtrr", _endtrr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beginsp", _beginsp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endinsp", _endinsp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begcreatedate", _begcreatedate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endcreatedate", _endcreatedate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begclosedate", _begclosedate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endclosedate", _endclosedate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "printnotes", _printnotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternal", _PrintInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternal", _PrintExternal, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
