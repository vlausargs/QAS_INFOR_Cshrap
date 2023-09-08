//PROJECT NAME: Production
//CLASS NAME: PmfGetSystemDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetSystemDefaults
	{
		(int? ReturnCode, string InfoBar,
		string BaseWtUm,
		string BaseVolUm,
		string DensityDesc,
		string DefStagingLoc,
		string DefWipItem,
		Guid? SessionId) PmfGetSystemDefaultsSp(string InfoBar = null,
		string Whse = null,
		string BaseWtUm = null,
		string BaseVolUm = null,
		string DensityDesc = null,
		string DefStagingLoc = null,
		string DefWipItem = null,
		Guid? SessionId = null);
	}
	
	public class PmfGetSystemDefaults : IPmfGetSystemDefaults
	{
		readonly IApplicationDB appDB;
		
		public PmfGetSystemDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar,
		string BaseWtUm,
		string BaseVolUm,
		string DensityDesc,
		string DefStagingLoc,
		string DefWipItem,
		Guid? SessionId) PmfGetSystemDefaultsSp(string InfoBar = null,
		string Whse = null,
		string BaseWtUm = null,
		string BaseVolUm = null,
		string DensityDesc = null,
		string DefStagingLoc = null,
		string DefWipItem = null,
		Guid? SessionId = null)
		{
			InfobarType _InfoBar = InfoBar;
			WhseType _Whse = Whse;
			UMType _BaseWtUm = BaseWtUm;
			UMType _BaseVolUm = BaseVolUm;
			DescriptionType _DensityDesc = DensityDesc;
			LocType _DefStagingLoc = DefStagingLoc;
			ItemType _DefWipItem = DefWipItem;
			RowPointerType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetSystemDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseWtUm", _BaseWtUm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BaseVolUm", _BaseVolUm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DensityDesc", _DensityDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefStagingLoc", _DefStagingLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefWipItem", _DefWipItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				BaseWtUm = _BaseWtUm;
				BaseVolUm = _BaseVolUm;
				DensityDesc = _DensityDesc;
				DefStagingLoc = _DefStagingLoc;
				DefWipItem = _DefWipItem;
				SessionId = _SessionId;
				
				return (Severity, InfoBar, BaseWtUm, BaseVolUm, DensityDesc, DefStagingLoc, DefWipItem, SessionId);
			}
		}
	}
}
