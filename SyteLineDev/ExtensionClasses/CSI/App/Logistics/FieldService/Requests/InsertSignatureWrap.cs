//PROJECT NAME: Logistics
//CLASS NAME: InsertSignatureWrap.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class InsertSignatureWrap : IInsertSignatureWrap
	{
		readonly IApplicationDB appDB;
		
		
		public InsertSignatureWrap(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InsertSignatureWrapSp(byte[] Signature,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		DateTime? SignatureDate,
		string Infobar,
		decimal? Latitude = 0,
		decimal? Longitude = 0)
		{
			BinaryType _Signature = Signature;
			FSRefTypeJKNSType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSRefLineType _RefLineSuf = RefLineSuf;
			FSRefReleaseType _RefRelease = RefRelease;
			DateType _SignatureDate = SignatureDate;
			Infobar _Infobar = Infobar;
			FSGPSLocType _Latitude = Latitude;
			FSGPSLocType _Longitude = Longitude;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertSignatureWrapSp";
				
				appDB.AddCommandParameter(cmd, "Signature", _Signature, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SignatureDate", _SignatureDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Latitude", _Latitude, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Longitude", _Longitude, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
