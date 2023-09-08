//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintProjectPackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ReprintProjectPackingSlip : IRpt_ReprintProjectPackingSlip
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ReprintProjectPackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintProjectPackingSlipSp(int? start_slip_num = null,
		int? end_slip_num = null,
		int? pr_serial = null,
		int? ShowProject = null,
		int? ShowResource = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			PackNumType _start_slip_num = start_slip_num;
			PackNumType _end_slip_num = end_slip_num;
			ListYesNoType _pr_serial = pr_serial;
			FlagNyType _ShowProject = ShowProject;
			FlagNyType _ShowResource = ShowResource;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ReprintProjectPackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "start_slip_num", _start_slip_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_slip_num", _end_slip_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pr_serial", _pr_serial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowProject", _ShowProject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowResource", _ShowResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
