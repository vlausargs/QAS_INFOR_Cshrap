//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipHdr_Load.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROPackSlipHdr_Load
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSSROPackSlipHdr_LoadSp(int? PackNum,
		DateTime? PackDate,
		string InWhse,
		string SRONum,
		int? SROLine,
		int? SROOper,
		byte? TransPosted,
		byte? AllShipTos,
		string ShipToType,
		string ShipToNum,
		int? ShipToSeq,
		int? MinPackNum = null,
		int? MaxPackNum = null);
	}
	
	public class SSSFSSROPackSlipHdr_Load : ISSSFSSROPackSlipHdr_Load
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSSROPackSlipHdr_Load(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSSROPackSlipHdr_LoadSp(int? PackNum,
		DateTime? PackDate,
		string InWhse,
		string SRONum,
		int? SROLine,
		int? SROOper,
		byte? TransPosted,
		byte? AllShipTos,
		string ShipToType,
		string ShipToNum,
		int? ShipToSeq,
		int? MinPackNum = null,
		int? MaxPackNum = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				PackNumType _PackNum = PackNum;
				DateType _PackDate = PackDate;
				WhseType _InWhse = InWhse;
				FSSRONumType _SRONum = SRONum;
				FSSROLineType _SROLine = SROLine;
				FSSROOperType _SROOper = SROOper;
				ListYesNoType _TransPosted = TransPosted;
				ListYesNoType _AllShipTos = AllShipTos;
				FSDropShipTypeType _ShipToType = ShipToType;
				FSPartnerType _ShipToNum = ShipToNum;
				DropSeqType _ShipToSeq = ShipToSeq;
				PackNumType _MinPackNum = MinPackNum;
				PackNumType _MaxPackNum = MaxPackNum;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSSROPackSlipHdr_LoadSp";
					
					appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PackDate", _PackDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "InWhse", _InWhse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransPosted", _TransPosted, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AllShipTos", _AllShipTos, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ShipToType", _ShipToType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ShipToNum", _ShipToNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ShipToSeq", _ShipToSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "MinPackNum", _MinPackNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "MaxPackNum", _MaxPackNum, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
