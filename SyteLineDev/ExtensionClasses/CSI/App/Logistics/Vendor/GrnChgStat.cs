//PROJECT NAME: Logistics
//CLASS NAME: GrnChgStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGrnChgStat
	{
		(ICollectionLoadResponse Data, int? ReturnCode, int? GrnsChanged, string Infobar) GrnChgStatSp(string OldGrnStat,
		string NewGrnStat,
		string StartVendNum,
		string EndVendNum,
		string StartGrnNum,
		string EndGrnNum,
		byte? PProcess,
		int? GrnsChanged,
		string Infobar);
	}
	
	public class GrnChgStat : IGrnChgStat
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public GrnChgStat(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, int? GrnsChanged, string Infobar) GrnChgStatSp(string OldGrnStat,
		string NewGrnStat,
		string StartVendNum,
		string EndVendNum,
		string StartGrnNum,
		string EndGrnNum,
		byte? PProcess,
		int? GrnsChanged,
		string Infobar)
		{
			GrnStatusType _OldGrnStat = OldGrnStat;
			GrnStatusType _NewGrnStat = NewGrnStat;
			VendNumType _StartVendNum = StartVendNum;
			VendNumType _EndVendNum = EndVendNum;
			GrnNumType _StartGrnNum = StartGrnNum;
			GrnNumType _EndGrnNum = EndGrnNum;
			FlagNyType _PProcess = PProcess;
			IntType _GrnsChanged = GrnsChanged;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GrnChgStatSp";
				
				appDB.AddCommandParameter(cmd, "OldGrnStat", _OldGrnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewGrnStat", _NewGrnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartVendNum", _StartVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendNum", _EndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartGrnNum", _StartGrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGrnNum", _EndGrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnsChanged", _GrnsChanged, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                GrnsChanged = _GrnsChanged;
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, GrnsChanged, Infobar);
			}
		}
	}
}
