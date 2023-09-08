//PROJECT NAME: Data
//CLASS NAME: SSSHasAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SSSHasAll : ISSSHasAll
	{
		readonly IApplicationDB appDB;
		
		public SSSHasAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? FSP_Available,
			int? POS_Available,
			int? ATT_Available,
			int? KBS_Available,
			int? DS_Available,
			int? SHP_Available,
			int? RMX_Available,
			int? VTX_Available,
			int? ACM_Available,
			int? RFQ_Available,
			int? OPM_Available,
			int? ROE_Availalbe,
			int? EIM_Available) SSSHasAllSp(
			int? FSP_Available = 0,
			int? POS_Available = 0,
			int? ATT_Available = 0,
			int? KBS_Available = 0,
			int? DS_Available = 0,
			int? SHP_Available = 0,
			int? RMX_Available = 0,
			int? VTX_Available = 0,
			int? ACM_Available = 0,
			int? RFQ_Available = 0,
			int? OPM_Available = 0,
			int? ROE_Availalbe = 0,
			int? EIM_Available = 0)
		{
			ListYesNoType _FSP_Available = FSP_Available;
			ListYesNoType _POS_Available = POS_Available;
			ListYesNoType _ATT_Available = ATT_Available;
			ListYesNoType _KBS_Available = KBS_Available;
			ListYesNoType _DS_Available = DS_Available;
			ListYesNoType _SHP_Available = SHP_Available;
			ListYesNoType _RMX_Available = RMX_Available;
			ListYesNoType _VTX_Available = VTX_Available;
			ListYesNoType _ACM_Available = ACM_Available;
			ListYesNoType _RFQ_Available = RFQ_Available;
			ListYesNoType _OPM_Available = OPM_Available;
			ListYesNoType _ROE_Availalbe = ROE_Availalbe;
			ListYesNoType _EIM_Available = EIM_Available;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSHasAllSp";
				
				appDB.AddCommandParameter(cmd, "FSP_Available", _FSP_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POS_Available", _POS_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ATT_Available", _ATT_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "KBS_Available", _KBS_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DS_Available", _DS_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SHP_Available", _SHP_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RMX_Available", _RMX_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VTX_Available", _VTX_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ACM_Available", _ACM_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RFQ_Available", _RFQ_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OPM_Available", _OPM_Available, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ROE_Availalbe", _ROE_Availalbe, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EIM_Available", _EIM_Available, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FSP_Available = _FSP_Available;
				POS_Available = _POS_Available;
				ATT_Available = _ATT_Available;
				KBS_Available = _KBS_Available;
				DS_Available = _DS_Available;
				SHP_Available = _SHP_Available;
				RMX_Available = _RMX_Available;
				VTX_Available = _VTX_Available;
				ACM_Available = _ACM_Available;
				RFQ_Available = _RFQ_Available;
				OPM_Available = _OPM_Available;
				ROE_Availalbe = _ROE_Availalbe;
				EIM_Available = _EIM_Available;
				
				return (Severity, FSP_Available, POS_Available, ATT_Available, KBS_Available, DS_Available, SHP_Available, RMX_Available, VTX_Available, ACM_Available, RFQ_Available, OPM_Available, ROE_Availalbe, EIM_Available);
			}
		}
	}
}
