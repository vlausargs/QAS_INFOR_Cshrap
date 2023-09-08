//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetIncWaiverCharge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetIncWaiverCharge : ISSSFSGetIncWaiverCharge
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetIncWaiverCharge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSGetIncWaiverChargeFn(
			string Contract,
			string Item,
			string UnitOfRate = null)
		{
			FSContractType _Contract = Contract;
			ItemType _Item = Item;
			FSContUnitOfRateType _UnitOfRate = UnitOfRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetIncWaiverCharge](@Contract, @Item, @UnitOfRate)";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitOfRate", _UnitOfRate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
