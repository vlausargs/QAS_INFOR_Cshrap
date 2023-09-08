//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BarcodedEmployeeBadges.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_BarcodedEmployeeBadges
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_BarcodedEmployeeBadgesSp(int? LabelSets = 2,
		byte? DisplayText = (byte)0,
		string EmployeeStarting = null,
		string EmployeeEnding = null,
		string pSite = null);
	}
	
	public class Rpt_BarcodedEmployeeBadges : IRpt_BarcodedEmployeeBadges
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_BarcodedEmployeeBadges(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_BarcodedEmployeeBadgesSp(int? LabelSets = 2,
		byte? DisplayText = (byte)0,
		string EmployeeStarting = null,
		string EmployeeEnding = null,
		string pSite = null)
		{
			IntType _LabelSets = LabelSets;
			ListYesNoType _DisplayText = DisplayText;
			EmpNumType _EmployeeStarting = EmployeeStarting;
			EmpNumType _EmployeeEnding = EmployeeEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_BarcodedEmployeeBadgesSp";
				
				appDB.AddCommandParameter(cmd, "LabelSets", _LabelSets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayText", _DisplayText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeStarting", _EmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeEnding", _EmployeeEnding, ParameterDirection.Input);
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
