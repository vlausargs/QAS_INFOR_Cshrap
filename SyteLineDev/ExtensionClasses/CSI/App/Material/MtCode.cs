//PROJECT NAME: Material
//CLASS NAME: MtCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MtCode : IMtCode
	{
		readonly IApplicationDB appDB;

		public MtCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Ref,
			string RefDesc,
			string Job,
			string Loc,
			string LocCode,
			string Reason,
			string ReasonDesc,
			string Type,
			string From,
			string To,
			decimal? TotPost,
			string Infobar) MtCodeSp(
			string Site = null,
			decimal? TransNum = null,
			string Ref = null,
			string RefDesc = null,
			string Job = null,
			string Loc = null,
			string LocCode = null,
			string Reason = null,
			string ReasonDesc = null,
			string Type = null,
			string From = null,
			string To = null,
			decimal? TotPost = null,
			string Infobar = null,
			int? PostJour = null)
		{
			SiteType _Site = Site;
			MatlTransNumType _TransNum = TransNum;
			StringType _Ref = Ref;
			StringType _RefDesc = RefDesc;
			StringType _Job = Job;
			StringType _Loc = Loc;
			StringType _LocCode = LocCode;
			ReasonCodeType _Reason = Reason;
			DescriptionType _ReasonDesc = ReasonDesc;
			StringType _Type = Type;
			StringType _From = From;
			StringType _To = To;
			AmtTotType _TotPost = TotPost;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PostJour = PostJour;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MtCodeSp";

				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref", _Ref, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefDesc", _RefDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocCode", _LocCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Reason", _Reason, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReasonDesc", _ReasonDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "From", _From, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "To", _To, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotPost", _TotPost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostJour", _PostJour, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Ref = _Ref;
				RefDesc = _RefDesc;
				Job = _Job;
				Loc = _Loc;
				LocCode = _LocCode;
				Reason = _Reason;
				ReasonDesc = _ReasonDesc;
				Type = _Type;
				From = _From;
				To = _To;
				TotPost = _TotPost;
				Infobar = _Infobar;

				return (Severity, Ref, RefDesc, Job, Loc, LocCode, Reason, ReasonDesc, Type, From, To, TotPost, Infobar);
			}
		}
	}
}
