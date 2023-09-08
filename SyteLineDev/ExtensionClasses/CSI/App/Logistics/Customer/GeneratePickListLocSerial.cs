//PROJECT NAME: CSICustomer
//CLASS NAME: GeneratePickListLocSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGeneratePickListLocSerial
	{
		(int? ReturnCode, string Infobar) GeneratePickListLocSerialSp(Guid? ProcessId,
		byte? AssignLoc,
		byte? AssignSerial,
		byte? SkipOrderLineCycCnt,
		byte? SkipOrderLineQtyNotAvail,
		byte? IncludeZeroQuantityAvailableKitItems,
		string Infobar,
		byte? AvailableParmChanged = (byte)0);
	}
	
	public class GeneratePickListLocSerial : IGeneratePickListLocSerial
	{
		readonly IApplicationDB appDB;
		
		public GeneratePickListLocSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GeneratePickListLocSerialSp(Guid? ProcessId,
		byte? AssignLoc,
		byte? AssignSerial,
		byte? SkipOrderLineCycCnt,
		byte? SkipOrderLineQtyNotAvail,
		byte? IncludeZeroQuantityAvailableKitItems,
		string Infobar,
		byte? AvailableParmChanged = (byte)0)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _AssignLoc = AssignLoc;
			ListYesNoType _AssignSerial = AssignSerial;
			ListYesNoType _SkipOrderLineCycCnt = SkipOrderLineCycCnt;
			ListYesNoType _SkipOrderLineQtyNotAvail = SkipOrderLineQtyNotAvail;
			ListYesNoType _IncludeZeroQuantityAvailableKitItems = IncludeZeroQuantityAvailableKitItems;
			InfobarType _Infobar = Infobar;
			FlagNyType _AvailableParmChanged = AvailableParmChanged;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GeneratePickListLocSerialSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssignLoc", _AssignLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssignSerial", _AssignSerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipOrderLineCycCnt", _SkipOrderLineCycCnt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipOrderLineQtyNotAvail", _SkipOrderLineQtyNotAvail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeZeroQuantityAvailableKitItems", _IncludeZeroQuantityAvailableKitItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AvailableParmChanged", _AvailableParmChanged, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
