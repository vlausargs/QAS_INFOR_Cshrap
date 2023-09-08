//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipLoadSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROPackSlipLoadSub : ISSSFSSROPackSlipLoadSub
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSSROPackSlipLoadSub(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) SSSFSSROPackSlipLoadSubSp(
			int? PackNum,
			string InWhse,
			string SRONum,
			int? SROLine,
			int? SROOper,
			int? TransPosted,
			int? AllShipTos,
			string ShipToType,
			string ShipToNum,
			int? ShipToSeq,
			int? AddMode = 0,
			string Infobar = null)
		{
			PackNumType _PackNum = PackNum;
			WhseType _InWhse = InWhse;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			ListYesNoType _TransPosted = TransPosted;
			ListYesNoType _AllShipTos = AllShipTos;
			FSDropShipTypeType _ShipToType = ShipToType;
			FSPartnerType _ShipToNum = ShipToNum;
			DropSeqType _ShipToSeq = ShipToSeq;
			ListYesNoType _AddMode = AddMode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROPackSlipLoadSubSp";
				
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InWhse", _InWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransPosted", _TransPosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllShipTos", _AllShipTos, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToType", _ShipToType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToNum", _ShipToNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToSeq", _ShipToSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddMode", _AddMode, ParameterDirection.Input);
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
