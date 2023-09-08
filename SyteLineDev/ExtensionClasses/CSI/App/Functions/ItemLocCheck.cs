//PROJECT NAME: Data
//CLASS NAME: ItemLocCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemLocCheck : IItemLocCheck
	{
		readonly IApplicationDB appDB;
		
		public ItemLocCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			Guid? ItemlocRowPointer) ItemLocCheckSp(
			string PItem,
			string PWhse,
			string PSite = null,
			string PLoc = null,
			int? PForTransitLoc = null,
			int? PIlocCanAdd = null,
			string PIlocTrnFunct = null,
			int? POutgoing = null,
			string Infobar = null,
			int? CreateIfMissing = 0,
			Guid? ItemlocRowPointer = null)
		{
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			SiteType _PSite = PSite;
			LocType _PLoc = PLoc;
			FlagNyType _PForTransitLoc = PForTransitLoc;
			ListYesNoType _PIlocCanAdd = PIlocCanAdd;
			SecurityFunctionType _PIlocTrnFunct = PIlocTrnFunct;
			FlagNyType _POutgoing = POutgoing;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CreateIfMissing = CreateIfMissing;
			RowPointerType _ItemlocRowPointer = ItemlocRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLocCheckSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForTransitLoc", _PForTransitLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIlocCanAdd", _PIlocCanAdd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIlocTrnFunct", _PIlocTrnFunct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POutgoing", _POutgoing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateIfMissing", _CreateIfMissing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocRowPointer", _ItemlocRowPointer, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				ItemlocRowPointer = _ItemlocRowPointer;
				
				return (Severity, Infobar, ItemlocRowPointer);
			}
		}
	}
}
