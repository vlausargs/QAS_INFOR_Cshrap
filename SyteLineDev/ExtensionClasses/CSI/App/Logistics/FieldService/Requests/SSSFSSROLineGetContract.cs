//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLineGetContract.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROLineGetContract
	{
		(int? ReturnCode, string Contract,
		int? ContLine) SSSFSSROLineGetContractSp(string SRONum,
		string SerNum,
		string Item,
		string Contract,
		int? ContLine);
	}
	
	public class SSSFSSROLineGetContract : ISSSFSSROLineGetContract
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROLineGetContract(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Contract,
		int? ContLine) SSSFSSROLineGetContractSp(string SRONum,
		string SerNum,
		string Item,
		string Contract,
		int? ContLine)
		{
			FSSRONumType _SRONum = SRONum;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROLineGetContractSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Contract = _Contract;
				ContLine = _ContLine;
				
				return (Severity, Contract, ContLine);
			}
		}
	}
}
