//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetContPriceBasis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetContPriceBasis : ISSSFSGetContPriceBasis
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetContPriceBasis(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSGetContPriceBasisFn(
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
				cmd.CommandText = "SELECT  dbo.[SSSFSGetContPriceBasis](@Contract, @Item, @UnitOfRate)";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitOfRate", _UnitOfRate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
