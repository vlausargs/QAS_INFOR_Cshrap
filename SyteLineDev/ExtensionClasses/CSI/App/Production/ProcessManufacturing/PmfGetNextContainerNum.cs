//PROJECT NAME: Production
//CLASS NAME: PmfGetNextContainerNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetNextContainerNum
	{
		(int? ReturnCode, string ContainerNum, string InfoBar) PmfGetNextContainerNumSp(string Whse,
		                                                                                string Loc,
		                                                                                string Job,
		                                                                                short? Suffix,
		                                                                                byte? CreateContainer,
		                                                                                string ContainerNum,
		                                                                                string InfoBar);
	}
	
	public class PmfGetNextContainerNum : IPmfGetNextContainerNum
	{
		readonly IApplicationDB appDB;
		
		public PmfGetNextContainerNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ContainerNum, string InfoBar) PmfGetNextContainerNumSp(string Whse,
		                                                                                       string Loc,
		                                                                                       string Job,
		                                                                                       short? Suffix,
		                                                                                       byte? CreateContainer,
		                                                                                       string ContainerNum,
		                                                                                       string InfoBar)
		{
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ByteType _CreateContainer = CreateContainer;
			ContainerNumType _ContainerNum = ContainerNum;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetNextContainerNumSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateContainer", _CreateContainer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ContainerNum = _ContainerNum;
				InfoBar = _InfoBar;
				
				return (Severity, ContainerNum, InfoBar);
			}
		}
	}
}
