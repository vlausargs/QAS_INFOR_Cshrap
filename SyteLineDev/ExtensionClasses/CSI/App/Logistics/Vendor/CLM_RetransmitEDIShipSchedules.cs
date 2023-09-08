//PROJECT NAME: Logistics
//CLASS NAME: RetransmitEDIShipSchedules.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_RetransmitEDIShipSchedules
    {
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RetransmitEDIShipSchedulesSp(string VendorStarting = null,
		                                                                                             string VendorEnding = null,
		                                                                                             string PoStarting = null,
		                                                                                             string PoEnding = null,
		                                                                                             DateTime? CDateStarting = null,
		                                                                                             DateTime? CDateEnding = null,
		                                                                                             short? CDateStartingOffset = null,
		                                                                                             short? CDateEndingOffset = null,
		                                                                                             byte? ProcessFlag = (byte)1,
		                                                                                             string Infobar = null);
	}
	
	public class CLM_RetransmitEDIShipSchedules : ICLM_RetransmitEDIShipSchedules
    {
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_RetransmitEDIShipSchedules(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RetransmitEDIShipSchedulesSp(string VendorStarting = null,
		                                                                                                    string VendorEnding = null,
		                                                                                                    string PoStarting = null,
		                                                                                                    string PoEnding = null,
		                                                                                                    DateTime? CDateStarting = null,
		                                                                                                    DateTime? CDateEnding = null,
		                                                                                                    short? CDateStartingOffset = null,
		                                                                                                    short? CDateEndingOffset = null,
		                                                                                                    byte? ProcessFlag = (byte)1,
		                                                                                                    string Infobar = null)
		{
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			PoNumType _PoStarting = PoStarting;
			PoNumType _PoEnding = PoEnding;
			DateType _CDateStarting = CDateStarting;
			DateType _CDateEnding = CDateEnding;
			DateOffsetType _CDateStartingOffset = CDateStartingOffset;
			DateOffsetType _CDateEndingOffset = CDateEndingOffset;
			ListYesNoType _ProcessFlag = ProcessFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RetransmitEDIShipSchedulesSp";
				
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoStarting", _PoStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoEnding", _PoEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStarting", _CDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEnding", _CDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStartingOffset", _CDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEndingOffset", _CDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessFlag", _ProcessFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
