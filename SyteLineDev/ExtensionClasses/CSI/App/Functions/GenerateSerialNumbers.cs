//PROJECT NAME: Data
//CLASS NAME: GenerateSerialNumbers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GenerateSerialNumbers : IGenerateSerialNumbers
	{
		readonly IApplicationDB appDB;
		
		public GenerateSerialNumbers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GenerateSerialNumbersSp(
			string Prefix,
			int? Qty,
			int? SerNumWidth,
			string MaxSerNum,
			Guid? TmpSerId,
			string RefStr,
			string Infobar,
			string Item)
		{
			SerialPrefixType _Prefix = Prefix;
			IntType _Qty = Qty;
			IntType _SerNumWidth = SerNumWidth;
			SerNumType _MaxSerNum = MaxSerNum;
			RowPointerType _TmpSerId = TmpSerId;
			RefStrType _RefStr = RefStr;
			InfobarType _Infobar = Infobar;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateSerialNumbersSp";
				
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNumWidth", _SerNumWidth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxSerNum", _MaxSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpSerId", _TmpSerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStr", _RefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
