//PROJECT NAME: Data
//CLASS NAME: ISSSHasAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISSSHasAll
	{
		(int? ReturnCode,
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
			int? EIM_Available = 0);
	}
}

