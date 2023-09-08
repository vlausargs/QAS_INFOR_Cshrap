//PROJECT NAME: CSICustomer
//CLASS NAME: ChComm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IChComm
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChCommSp(string StartSlsman,
		string EndSlsman,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		string StartInvoice,
		string EndInvoice,
		string OldStatus,
		string NewStatus,
		DateTime? PaymentDate,
		byte? ProcessUnpdComm,
		byte? DeleteComp,
		byte? PProcess,
		string Infobar,
		short? StartDueDateOffset = null,
		short? EndDueDateOffset = null,
		short? PaymentDateOffset = null);
	}
	
	public class ChComm : IChComm
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ChComm(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChCommSp(string StartSlsman,
		string EndSlsman,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		string StartInvoice,
		string EndInvoice,
		string OldStatus,
		string NewStatus,
		DateTime? PaymentDate,
		byte? ProcessUnpdComm,
		byte? DeleteComp,
		byte? PProcess,
		string Infobar,
		short? StartDueDateOffset = null,
		short? EndDueDateOffset = null,
		short? PaymentDateOffset = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				SlsmanType _StartSlsman = StartSlsman;
				SlsmanType _EndSlsman = EndSlsman;
				DateType _StartDueDate = StartDueDate;
				DateType _EndDueDate = EndDueDate;
				InvNumType _StartInvoice = StartInvoice;
				InvNumType _EndInvoice = EndInvoice;
				CommdueStatusType _OldStatus = OldStatus;
				CommdueStatusType _NewStatus = NewStatus;
				DateType _PaymentDate = PaymentDate;
				FlagNyType _ProcessUnpdComm = ProcessUnpdComm;
				FlagNyType _DeleteComp = DeleteComp;
				FlagNyType _PProcess = PProcess;
				InfobarType _Infobar = Infobar;
				DateOffsetType _StartDueDateOffset = StartDueDateOffset;
				DateOffsetType _EndDueDateOffset = EndDueDateOffset;
				DateOffsetType _PaymentDateOffset = PaymentDateOffset;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ChCommSp";
					
					appDB.AddCommandParameter(cmd, "StartSlsman", _StartSlsman, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndSlsman", _EndSlsman, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartInvoice", _StartInvoice, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndInvoice", _EndInvoice, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "OldStatus", _OldStatus, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "NewStatus", _NewStatus, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PaymentDate", _PaymentDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ProcessUnpdComm", _ProcessUnpdComm, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DeleteComp", _DeleteComp, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "StartDueDateOffset", _StartDueDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDueDateOffset", _EndDueDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PaymentDateOffset", _PaymentDateOffset, ParameterDirection.Input);
					
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
