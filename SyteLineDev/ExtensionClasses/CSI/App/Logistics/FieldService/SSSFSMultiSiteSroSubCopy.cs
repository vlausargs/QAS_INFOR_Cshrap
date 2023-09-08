//PROJECT NAME: Logistics
//CLASS NAME: SSSFSMultiSiteSroSubCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSMultiSiteSroSubCopy : ISSSFSMultiSiteSroSubCopy
	{
		readonly IApplicationDB appDB;
		
		public SSSFSMultiSiteSroSubCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSMultiSiteSroSubCopySp(
			string iFromSite,
			string iToSite,
			string iFromSroNum,
			string iToSroNum,
			int? iCloseSourceSro,
			int? iDeleteSourceSro,
			int? iCopyNotes,
			string iValSroType,
			string iValSlsman,
			string iValPartner,
			string iValOperCode,
			string Infobar)
		{
			SiteType _iFromSite = iFromSite;
			SiteType _iToSite = iToSite;
			FSSRONumType _iFromSroNum = iFromSroNum;
			FSSRONumType _iToSroNum = iToSroNum;
			ListYesNoType _iCloseSourceSro = iCloseSourceSro;
			ListYesNoType _iDeleteSourceSro = iDeleteSourceSro;
			ListYesNoType _iCopyNotes = iCopyNotes;
			StringType _iValSroType = iValSroType;
			StringType _iValSlsman = iValSlsman;
			StringType _iValPartner = iValPartner;
			StringType _iValOperCode = iValOperCode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSMultiSiteSroSubCopySp";
				
				appDB.AddCommandParameter(cmd, "iFromSite", _iFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSite", _iToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromSroNum", _iFromSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToSroNum", _iToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCloseSourceSro", _iCloseSourceSro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDeleteSourceSro", _iDeleteSourceSro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCopyNotes", _iCopyNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iValSroType", _iValSroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iValSlsman", _iValSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iValPartner", _iValPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iValOperCode", _iValOperCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
