//PROJECT NAME: CSIMaterial
//CLASS NAME: MultiSiteBOMCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IMultiSiteBOMCopy
	{
		(int? ReturnCode, string InfoBar) MultiSiteBOMCopySp(string SourceSite = null,
		string TargetSite = null,
		string Item = null,
		byte? CreateNonInventoryItems = (byte)0,
		byte? IncludeDrawingNbr = (byte)0,
		int? StartOperNum = null,
		int? EndOperNum = null,
		string CopyOption = "D",
		int? NewOperNum = null,
		string NewRevision = null,
		string InfoBar = null);
	}
	
	public class MultiSiteBOMCopy : IMultiSiteBOMCopy
	{
		readonly IApplicationDB appDB;
		
		public MultiSiteBOMCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) MultiSiteBOMCopySp(string SourceSite = null,
		string TargetSite = null,
		string Item = null,
		byte? CreateNonInventoryItems = (byte)0,
		byte? IncludeDrawingNbr = (byte)0,
		int? StartOperNum = null,
		int? EndOperNum = null,
		string CopyOption = "D",
		int? NewOperNum = null,
		string NewRevision = null,
		string InfoBar = null)
		{
			SiteType _SourceSite = SourceSite;
			SiteType _TargetSite = TargetSite;
			ItemType _Item = Item;
			ListYesNoType _CreateNonInventoryItems = CreateNonInventoryItems;
			ListYesNoType _IncludeDrawingNbr = IncludeDrawingNbr;
			OperNumType _StartOperNum = StartOperNum;
			OperNumType _EndOperNum = EndOperNum;
			StringType _CopyOption = CopyOption;
			OperNumType _NewOperNum = NewOperNum;
			RevisionType _NewRevision = NewRevision;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiSiteBOMCopySp";
				
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TargetSite", _TargetSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateNonInventoryItems", _CreateNonInventoryItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeDrawingNbr", _IncludeDrawingNbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOperNum", _StartOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOperNum", _EndOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyOption", _CopyOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewOperNum", _NewOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRevision", _NewRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
