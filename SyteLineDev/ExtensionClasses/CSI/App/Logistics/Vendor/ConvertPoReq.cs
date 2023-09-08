//PROJECT NAME: Logistics
//CLASS NAME: ConvertPoReq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ConvertPoReq : IConvertPoReq
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ConvertPoReq(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ConvertPoReqSp(string ProcSel,
		string PreqNum,
		int? PreqFromLine,
		int? PreqToLine,
		int? CopyText,
		string PoType,
		string PoNum,
		int? PoChangeFlag,
		string Infobar,
		string CostCode = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				LongListType _ProcSel = ProcSel;
				ReqNumType _PreqNum = PreqNum;
				ReqLineType _PreqFromLine = PreqFromLine;
				ReqLineType _PreqToLine = PreqToLine;
				FlagNyType _CopyText = CopyText;
				PoTypeType _PoType = PoType;
				PoNumType _PoNum = PoNum;
				FlagNyType _PoChangeFlag = PoChangeFlag;
				InfobarType _Infobar = Infobar;
				CostCodeType _CostCode = CostCode;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ConvertPoReqSp";
					
					appDB.AddCommandParameter(cmd, "ProcSel", _ProcSel, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqNum", _PreqNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqFromLine", _PreqFromLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqToLine", _PreqToLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CopyText", _CopyText, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PoType", _PoType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PoChangeFlag", _PoChangeFlag, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
