//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSSetAvail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSSetAvail
	{
		int SSSSetAvailSp(ref byte? Avail_SSS_FSP,
		                  ref byte? Avail_SSS_RMX,
		                  ref byte? Avail_SSS_SHP,
		                  ref byte? Avail_SSS_RFQ,
		                  ref byte? Avail_SSS_VTX,
		                  ref byte? Avail_SSS_ROE,
		                  ref byte? Avail_SSS_POS,
		                  ref byte? Avail_SSS_CCI,
		                  ref byte? Avail_SSS_SL);
	}
	
	public class SSSSetAvail : ISSSSetAvail
	{
		readonly IApplicationDB appDB;
		
		public SSSSetAvail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSSetAvailSp(ref byte? Avail_SSS_FSP,
		                         ref byte? Avail_SSS_RMX,
		                         ref byte? Avail_SSS_SHP,
		                         ref byte? Avail_SSS_RFQ,
		                         ref byte? Avail_SSS_VTX,
		                         ref byte? Avail_SSS_ROE,
		                         ref byte? Avail_SSS_POS,
		                         ref byte? Avail_SSS_CCI,
		                         ref byte? Avail_SSS_SL)
		{
			ListYesNoType _Avail_SSS_FSP = Avail_SSS_FSP;
			ListYesNoType _Avail_SSS_RMX = Avail_SSS_RMX;
			ListYesNoType _Avail_SSS_SHP = Avail_SSS_SHP;
			ListYesNoType _Avail_SSS_RFQ = Avail_SSS_RFQ;
			ListYesNoType _Avail_SSS_VTX = Avail_SSS_VTX;
			ListYesNoType _Avail_SSS_ROE = Avail_SSS_ROE;
			ListYesNoType _Avail_SSS_POS = Avail_SSS_POS;
			ListYesNoType _Avail_SSS_CCI = Avail_SSS_CCI;
			ListYesNoType _Avail_SSS_SL = Avail_SSS_SL;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSSetAvailSp";
				
				appDB.AddCommandParameter(cmd, "Avail_SSS_FSP", _Avail_SSS_FSP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Avail_SSS_RMX", _Avail_SSS_RMX, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Avail_SSS_SHP", _Avail_SSS_SHP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Avail_SSS_RFQ", _Avail_SSS_RFQ, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Avail_SSS_VTX", _Avail_SSS_VTX, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Avail_SSS_ROE", _Avail_SSS_ROE, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Avail_SSS_POS", _Avail_SSS_POS, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Avail_SSS_CCI", _Avail_SSS_CCI, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Avail_SSS_SL", _Avail_SSS_SL, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Avail_SSS_FSP = _Avail_SSS_FSP;
				Avail_SSS_RMX = _Avail_SSS_RMX;
				Avail_SSS_SHP = _Avail_SSS_SHP;
				Avail_SSS_RFQ = _Avail_SSS_RFQ;
				Avail_SSS_VTX = _Avail_SSS_VTX;
				Avail_SSS_ROE = _Avail_SSS_ROE;
				Avail_SSS_POS = _Avail_SSS_POS;
				Avail_SSS_CCI = _Avail_SSS_CCI;
				Avail_SSS_SL = _Avail_SSS_SL;
				
				return Severity;
			}
		}
	}
}
