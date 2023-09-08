//PROJECT NAME: Production
//CLASS NAME: Rpt_WorkCenterTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Rpt_WorkCenterTransaction : IRpt_WorkCenterTransaction
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_WorkCenterTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_WorkCenterTransactionSp(string TransGroup = null,
		string WorkCentereStart = null,
		string WorkCenterEnd = null,
		string EmployeeStart = null,
		string EmployeeEnd = null,
		DateTime? TransDateStart = null,
		DateTime? TransDateEnd = null,
		string ShiftStart = null,
		string ShiftEnd = null,
		string TransType = null,
		string DocNumStart = null,
		string DocNumEnd = null,
		string BackflushTrans = null,
		int? PStartRecDateOffset = null,
		int? PEndRecDateOffset = null,
		string PrintCost = null,
		string pSite = null,
		string BGUser = null)
		{
			JobtranClassType _TransGroup = TransGroup;
			WcType _WorkCentereStart = WorkCentereStart;
			WcType _WorkCenterEnd = WorkCenterEnd;
			EmpNumType _EmployeeStart = EmployeeStart;
			EmpNumType _EmployeeEnd = EmployeeEnd;
			DateTimeType _TransDateStart = TransDateStart;
			DateTimeType _TransDateEnd = TransDateEnd;
			ShiftType _ShiftStart = ShiftStart;
			ShiftType _ShiftEnd = ShiftEnd;
			TransRestrictionCodeType _TransType = TransType;
			DocumentNumType _DocNumStart = DocNumStart;
			DocumentNumType _DocNumEnd = DocNumEnd;
			BflushTypeType _BackflushTrans = BackflushTrans;
			DateOffsetType _PStartRecDateOffset = PStartRecDateOffset;
			DateOffsetType _PEndRecDateOffset = PEndRecDateOffset;
			PrintModeType _PrintCost = PrintCost;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_WorkCenterTransactionSp";
				
				appDB.AddCommandParameter(cmd, "TransGroup", _TransGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkCentereStart", _WorkCentereStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkCenterEnd", _WorkCenterEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeStart", _EmployeeStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeEnd", _EmployeeEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStart", _TransDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnd", _TransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiftStart", _ShiftStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiftEnd", _ShiftEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocNumStart", _DocNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocNumEnd", _DocNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackflushTrans", _BackflushTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartRecDateOffset", _PStartRecDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndRecDateOffset", _PEndRecDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
