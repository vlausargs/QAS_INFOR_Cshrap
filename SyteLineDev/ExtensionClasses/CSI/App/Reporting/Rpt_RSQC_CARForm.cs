//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CARForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CARForm : IRpt_RSQC_CARForm
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_CARForm(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CARFormSp(
			string begcar = null,
			string endcar = null,
			string begitem = null,
			string enditem = null,
			string begentity = null,
			string endentity = null,
			string beginsp = null,
			string endinsp = null,
			DateTime? begcdate = null,
			DateTime? endcdate = null,
			DateTime? begddate = null,
			DateTime? endddate = null,
			string status = null,
			string reftype = null,
			int? printcost = null,
			int? PrintInternal = null,
			int? PrintExternal = null)
		{
			QCDocNumType _begcar = begcar;
			QCDocNumType _endcar = endcar;
			ItemType _begitem = begitem;
			ItemType _enditem = enditem;
			QCDocNumType _begentity = begentity;
			QCDocNumType _endentity = endentity;
			EmpNumType _beginsp = beginsp;
			EmpNumType _endinsp = endinsp;
			DateType _begcdate = begcdate;
			DateType _endcdate = endcdate;
			DateType _begddate = begddate;
			DateType _endddate = endddate;
			StringType _status = status;
			StringType _reftype = reftype;
			ListYesNoType _printcost = printcost;
			FlagNyType _PrintInternal = PrintInternal;
			FlagNyType _PrintExternal = PrintExternal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_CARFormSp";
				
				appDB.AddCommandParameter(cmd, "begcar", _begcar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endcar", _endcar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begitem", _begitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enditem", _enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begentity", _begentity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endentity", _endentity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beginsp", _beginsp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endinsp", _endinsp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begcdate", _begcdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endcdate", _endcdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begddate", _begddate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endddate", _endddate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "status", _status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "reftype", _reftype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "printcost", _printcost, ParameterDirection.Input);
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
