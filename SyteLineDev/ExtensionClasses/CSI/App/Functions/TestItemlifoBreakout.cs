//PROJECT NAME: Data
//CLASS NAME: TestItemlifoBreakout.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TestItemlifoBreakout : ITestItemlifoBreakout
	{
		readonly IApplicationDB appDB;
		
		public TestItemlifoBreakout(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ItemlifoStackRemaining,
			decimal? WhseQtyRemaining) TestItemlifoBreakoutSp(
			Guid? ItemlifoRowPointer,
			string Whse,
			decimal? PercentageOfInventory,
			int? AllowRemainder,
			int? SecondPass,
			decimal? ItemlifoStackRemaining,
			decimal? WhseQtyRemaining)
		{
			RowPointerType _ItemlifoRowPointer = ItemlifoRowPointer;
			WhseType _Whse = Whse;
			DecimalType _PercentageOfInventory = PercentageOfInventory;
			ListYesNoType _AllowRemainder = AllowRemainder;
			ListYesNoType _SecondPass = SecondPass;
			QtyUnitType _ItemlifoStackRemaining = ItemlifoStackRemaining;
			QtyTotlType _WhseQtyRemaining = WhseQtyRemaining;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TestItemlifoBreakoutSp";
				
				appDB.AddCommandParameter(cmd, "ItemlifoRowPointer", _ItemlifoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PercentageOfInventory", _PercentageOfInventory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowRemainder", _AllowRemainder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SecondPass", _SecondPass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoStackRemaining", _ItemlifoStackRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WhseQtyRemaining", _WhseQtyRemaining, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemlifoStackRemaining = _ItemlifoStackRemaining;
				WhseQtyRemaining = _WhseQtyRemaining;
				
				return (Severity, ItemlifoStackRemaining, WhseQtyRemaining);
			}
		}
	}
}
