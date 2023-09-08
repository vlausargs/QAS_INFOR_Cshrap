//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSGetWarrCodeIn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetWarrCodeIn
	{
		int SSSFSGetWarrCodeInfo(string iWarrCode,
		                         ref string oDescription,
		                         ref int? oDuration,
		                         ref string oDurationType,
		                         ref int? oDuration2,
		                         ref string Infobar);
	}
	
	public class SSSFSGetWarrCodeIn : ISSSFSGetWarrCodeIn
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetWarrCodeIn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSGetWarrCodeInfo(string iWarrCode,
		                                ref string oDescription,
		                                ref int? oDuration,
		                                ref string oDurationType,
		                                ref int? oDuration2,
		                                ref string Infobar)
		{
			FSWarrCodeType _iWarrCode = iWarrCode;
			DescriptionType _oDescription = oDescription;
			FSDurationType _oDuration = oDuration;
			FSDurationTypeType _oDurationType = oDurationType;
			FSDurationType _oDuration2 = oDuration2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetWarrCodeInfo";
				
				appDB.AddCommandParameter(cmd, "iWarrCode", _iWarrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oDescription", _oDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oDuration", _oDuration, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oDurationType", _oDurationType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oDuration2", _oDuration2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oDescription = _oDescription;
				oDuration = _oDuration;
				oDurationType = _oDurationType;
				oDuration2 = _oDuration2;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
