//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_ValidateOrderAndContract.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Automotive
{
	public interface IAU_ValidateOrderAndContract
	{
		(int? ReturnCode, string Infobar) AU_ValidateOrderAndContractSp(string ContractID,
		string Infobar,
		string CoNum = null,
		string PoNum = null);
	}
	
	public class AU_ValidateOrderAndContract : IAU_ValidateOrderAndContract
	{
		readonly IApplicationDB appDB;
		
		public AU_ValidateOrderAndContract(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AU_ValidateOrderAndContractSp(string ContractID,
		string Infobar,
		string CoNum = null,
		string PoNum = null)
		{
			AU_ContractIDType _ContractID = ContractID;
			InfobarType _Infobar = Infobar;
			CoNumType _CoNum = CoNum;
			PoNumType _PoNum = PoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_ValidateOrderAndContractSp";
				
				appDB.AddCommandParameter(cmd, "ContractID", _ContractID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
