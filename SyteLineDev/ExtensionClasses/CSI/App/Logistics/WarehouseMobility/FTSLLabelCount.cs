//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLLabelCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLLabelCount
	{
		int FTSLLabelCountSp(string LabelType,
		                     string Whse,
		                     string FromLoc,
		                     string ToLoc,
		                     string FromItem,
		                     string ToItem,
		                     string FromContainer,
		                     string ToContainer,
		                     string Type,
		                     string TaskType,
		                     string FromEmp,
		                     string ToEmp,
		                     ref int? Count,
		                     ref string Infobar);
	}
	
	public class FTSLLabelCount : IFTSLLabelCount
	{
		readonly IApplicationDB appDB;
		
		public FTSLLabelCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLLabelCountSp(string LabelType,
		                            string Whse,
		                            string FromLoc,
		                            string ToLoc,
		                            string FromItem,
		                            string ToItem,
		                            string FromContainer,
		                            string ToContainer,
		                            string Type,
		                            string TaskType,
		                            string FromEmp,
		                            string ToEmp,
		                            ref int? Count,
		                            ref string Infobar)
		{
			LabelType _LabelType = LabelType;
			WhseType _Whse = Whse;
			LocType _FromLoc = FromLoc;
			LocType _ToLoc = ToLoc;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			ContainerNumType _FromContainer = FromContainer;
			ContainerNumType _ToContainer = ToContainer;
			JobType _Type = Type;
			DescriptionType _TaskType = TaskType;
			EmpNumType _FromEmp = FromEmp;
			EmpNumType _ToEmp = ToEmp;
			CustSeqType _Count = Count;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLLabelCountSp";
				
				appDB.AddCommandParameter(cmd, "LabelType", _LabelType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromContainer", _FromContainer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToContainer", _ToContainer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskType", _TaskType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEmp", _FromEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmp", _ToEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Count", _Count, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Count = _Count;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
