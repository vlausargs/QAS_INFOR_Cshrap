//PROJECT NAME: CSIVendor
//CLASS NAME: ProfileChangeOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IProfileChangeOrder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileChangeOrderSp(string pPoType = null,
		string pPoStat = null,
		string pPoitemStat = null,
		string pChgStat = null,
		string pStartPoNum = null,
		string pEndPoNum = null,
		short? pStartPoLine = null,
		short? pEndPoLine = null,
		short? pStartPoRelease = null,
		short? pEndPoRelease = null,
		string pStartvendor = null,
		string pEndVendor = null);
	}
	
	public class ProfileChangeOrder : IProfileChangeOrder
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileChangeOrder(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileChangeOrderSp(string pPoType = null,
		string pPoStat = null,
		string pPoitemStat = null,
		string pChgStat = null,
		string pStartPoNum = null,
		string pEndPoNum = null,
		short? pStartPoLine = null,
		short? pEndPoLine = null,
		short? pStartPoRelease = null,
		short? pEndPoRelease = null,
		string pStartvendor = null,
		string pEndVendor = null)
		{
			StringType _pPoType = pPoType;
			StringType _pPoStat = pPoStat;
			StringType _pPoitemStat = pPoitemStat;
			Infobar _pChgStat = pChgStat;
			PoNumType _pStartPoNum = pStartPoNum;
			PoNumType _pEndPoNum = pEndPoNum;
			PoLineType _pStartPoLine = pStartPoLine;
			PoLineType _pEndPoLine = pEndPoLine;
			PoReleaseType _pStartPoRelease = pStartPoRelease;
			PoReleaseType _pEndPoRelease = pEndPoRelease;
			VendNumType _pStartvendor = pStartvendor;
			VendNumType _pEndVendor = pEndVendor;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileChangeOrderSp";
				
				appDB.AddCommandParameter(cmd, "pPoType", _pPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoStat", _pPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoitemStat", _pPoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChgStat", _pChgStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoNum", _pStartPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoNum", _pEndPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoLine", _pStartPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoLine", _pEndPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoRelease", _pStartPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoRelease", _pEndPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartvendor", _pStartvendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
