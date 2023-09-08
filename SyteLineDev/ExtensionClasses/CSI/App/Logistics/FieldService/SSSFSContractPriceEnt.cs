//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractPriceEnt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractPriceEnt : ISSSFSContractPriceEnt
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContractPriceEnt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? OutPercent) SSSFSContractPriceEntSp(
			string InType,
			string Contract,
			int? ContLine,
			string SroType,
			string InFamilyWork,
			decimal? OutPercent)
		{
			FSSRONumType _InType = InType;
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			FSSROTypeType _SroType = SroType;
			ItemType _InFamilyWork = InFamilyWork;
			CostPrcType _OutPercent = OutPercent;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContractPriceEntSp";
				
				appDB.AddCommandParameter(cmd, "InType", _InType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroType", _SroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InFamilyWork", _InFamilyWork, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutPercent", _OutPercent, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutPercent = _OutPercent;
				
				return (Severity, OutPercent);
			}
		}
	}
}
