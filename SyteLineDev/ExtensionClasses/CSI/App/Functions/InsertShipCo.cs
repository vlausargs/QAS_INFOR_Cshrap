//PROJECT NAME: Data
//CLASS NAME: InsertShipCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InsertShipCo : IInsertShipCo
	{
		readonly IApplicationDB appDB;
		
		public InsertShipCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InsertShipCoSp(
			string pCoType = null,
			int? pBatchID = null,
			string pCoStat = null,
			string pCoitemStat = null,
			string pStartCoNum = null,
			string pEndCoNum = null,
			string pStartCustNum = null,
			string pEndCustNum = null,
			string pStartItem = null,
			string pEndItem = null,
			int? IncludeShipEarly = null,
			DateTime? CutoffDate = null)
		{
			InfobarType _pCoType = pCoType;
			BatchIdType _pBatchID = pBatchID;
			InfobarType _pCoStat = pCoStat;
			InfobarType _pCoitemStat = pCoitemStat;
			CoNumType _pStartCoNum = pStartCoNum;
			CoNumType _pEndCoNum = pEndCoNum;
			CustNumType _pStartCustNum = pStartCustNum;
			CustNumType _pEndCustNum = pEndCustNum;
			ItemType _pStartItem = pStartItem;
			ItemType _pEndItem = pEndItem;
			ListYesNoType _IncludeShipEarly = IncludeShipEarly;
			DateType _CutoffDate = CutoffDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertShipCoSp";
				
				appDB.AddCommandParameter(cmd, "pCoType", _pCoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBatchID", _pBatchID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoStat", _pCoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoitemStat", _pCoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCoNum", _pStartCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCoNum", _pEndCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCustNum", _pStartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum", _pEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeShipEarly", _IncludeShipEarly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
