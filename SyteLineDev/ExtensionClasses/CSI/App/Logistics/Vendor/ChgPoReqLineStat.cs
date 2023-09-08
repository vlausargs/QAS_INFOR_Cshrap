//PROJECT NAME: CSIVendor
//CLASS NAME: ChgPoReqLineStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IChgPoReqLineStat
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChgPoReqLineStatSp(string ProcSel,
		string PreqitemFStat,
		string PreqitemTStat,
		string PreqFrom,
		string PreqTo,
		short? PreqFromLine,
		short? PreqToLine,
		string PreqSApprover,
		string PreqEApprover,
		string PreqitemSVendor,
		string PreqitemEVendor,
		DateTime? PreqSRequest,
		DateTime? PreqERequest,
		DateTime? PreqitemSDue,
		DateTime? PreqitemEDue,
		string Infobar,
		short? StartRequestDateOffset = null,
		short? EndRequestDateOffset = null,
		short? StartDueDateOffset = null,
		short? EndDueDateOffset = null,
		string BGUser = null);
	}
	
	public class ChgPoReqLineStat : IChgPoReqLineStat
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ChgPoReqLineStat(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChgPoReqLineStatSp(string ProcSel,
		string PreqitemFStat,
		string PreqitemTStat,
		string PreqFrom,
		string PreqTo,
		short? PreqFromLine,
		short? PreqToLine,
		string PreqSApprover,
		string PreqEApprover,
		string PreqitemSVendor,
		string PreqitemEVendor,
		DateTime? PreqSRequest,
		DateTime? PreqERequest,
		DateTime? PreqitemSDue,
		DateTime? PreqitemEDue,
		string Infobar,
		short? StartRequestDateOffset = null,
		short? EndRequestDateOffset = null,
		short? StartDueDateOffset = null,
		short? EndDueDateOffset = null,
		string BGUser = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				LongListType _ProcSel = ProcSel;
				PreqitemStatusType _PreqitemFStat = PreqitemFStat;
				PreqitemStatusType _PreqitemTStat = PreqitemTStat;
				ReqNumType _PreqFrom = PreqFrom;
				ReqNumType _PreqTo = PreqTo;
				ReqLineType _PreqFromLine = PreqFromLine;
				ReqLineType _PreqToLine = PreqToLine;
				NameType _PreqSApprover = PreqSApprover;
				NameType _PreqEApprover = PreqEApprover;
				VendNumType _PreqitemSVendor = PreqitemSVendor;
				VendNumType _PreqitemEVendor = PreqitemEVendor;
				DateType _PreqSRequest = PreqSRequest;
				DateType _PreqERequest = PreqERequest;
				DateType _PreqitemSDue = PreqitemSDue;
				DateType _PreqitemEDue = PreqitemEDue;
				InfobarType _Infobar = Infobar;
				DateOffsetType _StartRequestDateOffset = StartRequestDateOffset;
				DateOffsetType _EndRequestDateOffset = EndRequestDateOffset;
				DateOffsetType _StartDueDateOffset = StartDueDateOffset;
				DateOffsetType _EndDueDateOffset = EndDueDateOffset;
				UsernameType _BGUser = BGUser;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ChgPoReqLineStatSp";
					
					appDB.AddCommandParameter(cmd, "ProcSel", _ProcSel, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqitemFStat", _PreqitemFStat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqitemTStat", _PreqitemTStat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqFrom", _PreqFrom, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqTo", _PreqTo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqFromLine", _PreqFromLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqToLine", _PreqToLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqSApprover", _PreqSApprover, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqEApprover", _PreqEApprover, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqitemSVendor", _PreqitemSVendor, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqitemEVendor", _PreqitemEVendor, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqSRequest", _PreqSRequest, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqERequest", _PreqERequest, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqitemSDue", _PreqitemSDue, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PreqitemEDue", _PreqitemEDue, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "StartRequestDateOffset", _StartRequestDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndRequestDateOffset", _EndRequestDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDueDateOffset", _StartDueDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDueDateOffset", _EndDueDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
					
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
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
