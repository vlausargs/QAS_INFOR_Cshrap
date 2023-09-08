//PROJECT NAME: Logistics
//CLASS NAME: Reserve.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IReserve
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ReserveSp(string RsvdType,
		string InFile,
		string StartCoNum,
		string EndCoNum,
		short? StartCoLine,
		short? EndCoLine,
		short? StartCoRelease,
		short? EndCoRelease,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		string StartCustNum,
		string EndCustNum,
		string StartItem,
		string EndItem,
		string Infobar,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null,
		short? StartDueDateOffset = null,
		short? EndDueDateOffset = null);
	}
	
	public class Reserve : IReserve
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Reserve(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ReserveSp(string RsvdType,
		string InFile,
		string StartCoNum,
		string EndCoNum,
		short? StartCoLine,
		short? EndCoLine,
		short? StartCoRelease,
		short? EndCoRelease,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		string StartCustNum,
		string EndCustNum,
		string StartItem,
		string EndItem,
		string Infobar,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null,
		short? StartDueDateOffset = null,
		short? EndDueDateOffset = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _RsvdType = RsvdType;
				StringType _InFile = InFile;
				CoNumType _StartCoNum = StartCoNum;
				CoNumType _EndCoNum = EndCoNum;
				CoLineType _StartCoLine = StartCoLine;
				CoLineType _EndCoLine = EndCoLine;
				CoLineType _StartCoRelease = StartCoRelease;
				CoLineType _EndCoRelease = EndCoRelease;
				GenericDate _StartOrderDate = StartOrderDate;
				GenericDate _EndOrderDate = EndOrderDate;
				GenericDate _StartDueDate = StartDueDate;
				GenericDate _EndDueDate = EndDueDate;
				CustNumType _StartCustNum = StartCustNum;
				CustNumType _EndCustNum = EndCustNum;
				ItemType _StartItem = StartItem;
				ItemType _EndItem = EndItem;
				Infobar _Infobar = Infobar;
				DateOffsetType _StartOrderDateOffset = StartOrderDateOffset;
				DateOffsetType _EndOrderDateOffset = EndOrderDateOffset;
				DateOffsetType _StartDueDateOffset = StartDueDateOffset;
				DateOffsetType _EndDueDateOffset = EndDueDateOffset;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ReserveSp";
					
					appDB.AddCommandParameter(cmd, "RsvdType", _RsvdType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "InFile", _InFile, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartCoNum", _StartCoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndCoNum", _EndCoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartCoLine", _StartCoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndCoLine", _EndCoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartCoRelease", _StartCoRelease, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndCoRelease", _EndCoRelease, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartOrderDate", _StartOrderDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndOrderDate", _EndOrderDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "StartOrderDateOffset", _StartOrderDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndOrderDateOffset", _EndOrderDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDueDateOffset", _StartDueDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDueDateOffset", _EndDueDateOffset, ParameterDirection.Input);
					
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
