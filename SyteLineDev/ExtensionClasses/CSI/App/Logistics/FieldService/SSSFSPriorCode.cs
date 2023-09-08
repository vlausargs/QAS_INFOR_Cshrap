//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPriorCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPriorCode : ISSSFSPriorCode
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPriorCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSPriorCodeFn(
			string CustNum,
			int? CustSeq,
			string SerNum,
			string Item,
			string IncPriorCode = null,
			DateTime? IncDateTime = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			FSIncPriorCodeType _IncPriorCode = IncPriorCode;
			DateTimeType _IncDateTime = IncDateTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSPriorCode](@CustNum, @CustSeq, @SerNum, @Item, @IncPriorCode, @IncDateTime)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncPriorCode", _IncPriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncDateTime", _IncDateTime, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
