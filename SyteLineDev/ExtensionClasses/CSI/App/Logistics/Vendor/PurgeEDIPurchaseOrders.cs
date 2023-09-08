//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIPurchaseOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PurgeEDIPurchaseOrders : IPurgeEDIPurchaseOrders
	{
		readonly IApplicationDB appDB;
		
		
		public PurgeEDIPurchaseOrders(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Message) PurgeEDIPurchaseOrdersSp(string ExOptBegVend_Num = null,
		string ExOptEndVend_Num = null,
		string ExOptBegPo = null,
		string ExOptEndPo = null,
		DateTime? ExOptBegPost_Date = null,
		DateTime? ExOptEndPost_Date = null,
		DateTime? ExOptBegorder_Date = null,
		DateTime? ExOptEndorder_Date = null,
		string ExOptprPostedEmp = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		string Message = null)
		{
			VendNumType _ExOptBegVend_Num = ExOptBegVend_Num;
			VendNumType _ExOptEndVend_Num = ExOptEndVend_Num;
			PoNumType _ExOptBegPo = ExOptBegPo;
			PoNumType _ExOptEndPo = ExOptEndPo;
			DateType _ExOptBegPost_Date = ExOptBegPost_Date;
			DateType _ExOptEndPost_Date = ExOptEndPost_Date;
			DateType _ExOptBegorder_Date = ExOptBegorder_Date;
			DateType _ExOptEndorder_Date = ExOptEndorder_Date;
			StringType _ExOptprPostedEmp = ExOptprPostedEmp;
			DateOffsetType _CDateStartingOffset = CDateStartingOffset;
			DateOffsetType _CDateEndingOffset = CDateEndingOffset;
			DateOffsetType _OrderDateStartingOffset = OrderDateStartingOffset;
			DateOffsetType _OrderDateEndingOffset = OrderDateEndingOffset;
			InfobarType _Message = Message;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeEDIPurchaseOrdersSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegVend_Num", _ExOptBegVend_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndVend_Num", _ExOptEndVend_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegPo", _ExOptBegPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndPo", _ExOptEndPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegPost_Date", _ExOptBegPost_Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndPost_Date", _ExOptEndPost_Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegorder_Date", _ExOptBegorder_Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndorder_Date", _ExOptEndorder_Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostedEmp", _ExOptprPostedEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateStartingOffset", _CDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CDateEndingOffset", _CDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStartingOffset", _OrderDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEndingOffset", _OrderDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Message", _Message, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Message = _Message;
				
				return (Severity, Message);
			}
		}
	}
}
