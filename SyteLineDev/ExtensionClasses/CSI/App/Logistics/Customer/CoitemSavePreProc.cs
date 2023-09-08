//PROJECT NAME: Logistics
//CLASS NAME: CoitemSavePreProc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemSavePreProc : ICoitemSavePreProc
	{
		readonly IApplicationDB appDB;
		
		
		public CoitemSavePreProc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CoitemSavePreProcSp(int? ItemCustAdd = 0,
		int? ItemCustUpdate = 0,
		int? AllowOverCreditLimit = 0,
		string CoNum = null)
		{
			ListYesNoType _ItemCustAdd = ItemCustAdd;
			ListYesNoType _ItemCustUpdate = ItemCustUpdate;
			ListYesNoType _AllowOverCreditLimit = AllowOverCreditLimit;
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemSavePreProcSp";
				
				appDB.AddCommandParameter(cmd, "ItemCustAdd", _ItemCustAdd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCustUpdate", _ItemCustUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowOverCreditLimit", _AllowOverCreditLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
