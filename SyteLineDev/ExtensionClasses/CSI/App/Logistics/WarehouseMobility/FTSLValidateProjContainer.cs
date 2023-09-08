//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateProjContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateProjContainer
	{
		int FTSLValidateProjContainerSp(string ProjNum,
		                                int? TaskNum,
		                                string ContainerNum,
		                                byte? AllowNewItemContainer,
		                                ref string Loc,
		                                ref string Description,
		                                ref string Infobar);
	}
	
	public class FTSLValidateProjContainer : IFTSLValidateProjContainer
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateProjContainer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateProjContainerSp(string ProjNum,
		                                       int? TaskNum,
		                                       string ContainerNum,
		                                       byte? AllowNewItemContainer,
		                                       ref string Loc,
		                                       ref string Description,
		                                       ref string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ContainerType _ContainerNum = ContainerNum;
			ListYesNoType _AllowNewItemContainer = AllowNewItemContainer;
			LocType _Loc = Loc;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateProjContainerSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowNewItemContainer", _AllowNewItemContainer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Loc = _Loc;
				Description = _Description;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
