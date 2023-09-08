//PROJECT NAME: CSICustomer
//CLASS NAME: ChangeCOStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IChangeCOStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChangeCOStatusSp(string PText,
		string OrderType,
		string OldCoStat,
		string NewCoStat,
		string StartingOrder,
		string EndingOrder,
		DateTime? StartingDate,
		DateTime? EndingDate,
		string Infobar,
		short? StartingOrderDateOffset = null,
		short? EndingOrderDateOffset = null);
	}
	
	public class ChangeCOStatus : IChangeCOStatus
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ChangeCOStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChangeCOStatusSp(string PText,
		string OrderType,
		string OldCoStat,
		string NewCoStat,
		string StartingOrder,
		string EndingOrder,
		DateTime? StartingDate,
		DateTime? EndingDate,
		string Infobar,
		short? StartingOrderDateOffset = null,
		short? EndingOrderDateOffset = null)
		{
			LongListType _PText = PText;
			CoTypeType _OrderType = OrderType;
			CoStatusType _OldCoStat = OldCoStat;
			CoStatusType _NewCoStat = NewCoStat;
			CoNumType _StartingOrder = StartingOrder;
			CoNumType _EndingOrder = EndingOrder;
			DateType _StartingDate = StartingDate;
			DateType _EndingDate = EndingDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingOrderDateOffset = StartingOrderDateOffset;
			DateOffsetType _EndingOrderDateOffset = EndingOrderDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeCOStatusSp";
				
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCoStat", _OldCoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCoStat", _NewCoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrder", _StartingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrder", _EndingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDate", _StartingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDate", _EndingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingOrderDateOffset", _StartingOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrderDateOffset", _EndingOrderDateOffset, ParameterDirection.Input);
				
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
