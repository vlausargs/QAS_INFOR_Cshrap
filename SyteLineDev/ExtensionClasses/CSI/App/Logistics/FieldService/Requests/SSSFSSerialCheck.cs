//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSerialCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSerialCheck
	{
		(int? ReturnCode, string Prompt,
		string Infobar) SSSFSSerialCheckSp(string SerNum,
		string Prompt,
		string Infobar,
		string Item);
	}
	
	public class SSSFSSerialCheck : ISSSFSSerialCheck
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSerialCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Prompt,
		string Infobar) SSSFSSerialCheckSp(string SerNum,
		string Prompt,
		string Infobar,
		string Item)
		{
			SerNumType _SerNum = SerNum;
			Infobar _Prompt = Prompt;
			Infobar _Infobar = Infobar;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSerialCheckSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Prompt = _Prompt;
				Infobar = _Infobar;
				
				return (Severity, Prompt, Infobar);
			}
		}
	}
}
