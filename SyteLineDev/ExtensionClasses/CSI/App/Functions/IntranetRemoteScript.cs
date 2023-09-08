//PROJECT NAME: Data
//CLASS NAME: IntranetRemoteScript.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IntranetRemoteScript : IIntranetRemoteScript
	{
		readonly IApplicationDB appDB;
		
		public IntranetRemoteScript(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IntranetRemoteScriptSp(
			string Parm1Value = "",
			string Parm2Value = "",
			string Parm3Value = "",
			string Parm4Value = "",
			string Parm5Value = "",
			string Parm6Value = "",
			string Parm7Value = "",
			string Parm8Value = "",
			string Parm9Value = "",
			string Parm10Value = "",
			string Parm11Value = "",
			string Parm12Value = "",
			string Parm13Value = "",
			string Parm14Value = "",
			string Parm15Value = "",
			string Parm16Value = "",
			string Parm17Value = "",
			string Parm18Value = "",
			string Parm19Value = "",
			string Parm20Value = "",
			string Parm21Value = "",
			string Parm22Value = "",
			string Parm23Value = "",
			string Parm24Value = "",
			string Parm25Value = "",
			string Parm26Value = "",
			string Parm27Value = "",
			string Parm28Value = "",
			string Parm29Value = "",
			string Parm30Value = "",
			string Parm31Value = "",
			string Parm32Value = "",
			string Parm33Value = "",
			string Parm34Value = "",
			string Parm35Value = "",
			string Parm36Value = "",
			string Parm37Value = "",
			string Parm38Value = "",
			string Parm39Value = "",
			string Parm40Value = "",
			string Parm41Value = "",
			string Parm42Value = "",
			string Parm43Value = "",
			string Parm44Value = "",
			string Parm45Value = "",
			string Parm46Value = "",
			string Parm47Value = "",
			string Parm48Value = "",
			string Parm49Value = "",
			string Parm50Value = "",
			string Parm51Value = "",
			string Parm52Value = "",
			string Parm53Value = "",
			string Parm54Value = "",
			string Parm55Value = "",
			string Parm56Value = "",
			string Parm57Value = "",
			string Parm58Value = "",
			string Parm59Value = "",
			string Parm60Value = "",
			string Parm61Value = "",
			string Parm62Value = "",
			string Parm63Value = "",
			string Parm64Value = "",
			string Parm65Value = "",
			string Parm66Value = "",
			string Parm67Value = "",
			string Parm68Value = "",
			string Parm69Value = "",
			string Parm70Value = "",
			string Parm71Value = "",
			string Parm72Value = "",
			string Parm73Value = "",
			string Parm74Value = "",
			string Parm75Value = "",
			string Parm76Value = "",
			string Parm77Value = "",
			string Parm78Value = "",
			string Parm79Value = "",
			string Parm80Value = "",
			string Parm81Value = "",
			string Parm82Value = "",
			string Parm83Value = "",
			string Parm84Value = "",
			string Parm85Value = "",
			string Parm86Value = "",
			string Parm87Value = "",
			string Parm88Value = "",
			string Parm89Value = "",
			string Parm90Value = "",
			string Parm91Value = "",
			string Parm92Value = "",
			string Parm93Value = "",
			string Parm94Value = "",
			string Parm95Value = "",
			string Parm96Value = "",
			string Parm97Value = "",
			string Parm98Value = "",
			string Parm99Value = "",
			string Parm100Value = "")
		{
			StringType _Parm1Value = Parm1Value;
			StringType _Parm2Value = Parm2Value;
			StringType _Parm3Value = Parm3Value;
			StringType _Parm4Value = Parm4Value;
			StringType _Parm5Value = Parm5Value;
			StringType _Parm6Value = Parm6Value;
			StringType _Parm7Value = Parm7Value;
			StringType _Parm8Value = Parm8Value;
			StringType _Parm9Value = Parm9Value;
			StringType _Parm10Value = Parm10Value;
			StringType _Parm11Value = Parm11Value;
			StringType _Parm12Value = Parm12Value;
			StringType _Parm13Value = Parm13Value;
			StringType _Parm14Value = Parm14Value;
			StringType _Parm15Value = Parm15Value;
			StringType _Parm16Value = Parm16Value;
			StringType _Parm17Value = Parm17Value;
			StringType _Parm18Value = Parm18Value;
			StringType _Parm19Value = Parm19Value;
			StringType _Parm20Value = Parm20Value;
			StringType _Parm21Value = Parm21Value;
			StringType _Parm22Value = Parm22Value;
			StringType _Parm23Value = Parm23Value;
			StringType _Parm24Value = Parm24Value;
			StringType _Parm25Value = Parm25Value;
			StringType _Parm26Value = Parm26Value;
			StringType _Parm27Value = Parm27Value;
			StringType _Parm28Value = Parm28Value;
			StringType _Parm29Value = Parm29Value;
			StringType _Parm30Value = Parm30Value;
			StringType _Parm31Value = Parm31Value;
			StringType _Parm32Value = Parm32Value;
			StringType _Parm33Value = Parm33Value;
			StringType _Parm34Value = Parm34Value;
			StringType _Parm35Value = Parm35Value;
			StringType _Parm36Value = Parm36Value;
			StringType _Parm37Value = Parm37Value;
			StringType _Parm38Value = Parm38Value;
			StringType _Parm39Value = Parm39Value;
			StringType _Parm40Value = Parm40Value;
			StringType _Parm41Value = Parm41Value;
			StringType _Parm42Value = Parm42Value;
			StringType _Parm43Value = Parm43Value;
			StringType _Parm44Value = Parm44Value;
			StringType _Parm45Value = Parm45Value;
			StringType _Parm46Value = Parm46Value;
			StringType _Parm47Value = Parm47Value;
			StringType _Parm48Value = Parm48Value;
			StringType _Parm49Value = Parm49Value;
			StringType _Parm50Value = Parm50Value;
			StringType _Parm51Value = Parm51Value;
			StringType _Parm52Value = Parm52Value;
			StringType _Parm53Value = Parm53Value;
			StringType _Parm54Value = Parm54Value;
			StringType _Parm55Value = Parm55Value;
			StringType _Parm56Value = Parm56Value;
			StringType _Parm57Value = Parm57Value;
			StringType _Parm58Value = Parm58Value;
			StringType _Parm59Value = Parm59Value;
			StringType _Parm60Value = Parm60Value;
			StringType _Parm61Value = Parm61Value;
			StringType _Parm62Value = Parm62Value;
			StringType _Parm63Value = Parm63Value;
			StringType _Parm64Value = Parm64Value;
			StringType _Parm65Value = Parm65Value;
			StringType _Parm66Value = Parm66Value;
			StringType _Parm67Value = Parm67Value;
			StringType _Parm68Value = Parm68Value;
			StringType _Parm69Value = Parm69Value;
			StringType _Parm70Value = Parm70Value;
			StringType _Parm71Value = Parm71Value;
			StringType _Parm72Value = Parm72Value;
			StringType _Parm73Value = Parm73Value;
			StringType _Parm74Value = Parm74Value;
			StringType _Parm75Value = Parm75Value;
			StringType _Parm76Value = Parm76Value;
			StringType _Parm77Value = Parm77Value;
			StringType _Parm78Value = Parm78Value;
			StringType _Parm79Value = Parm79Value;
			StringType _Parm80Value = Parm80Value;
			StringType _Parm81Value = Parm81Value;
			StringType _Parm82Value = Parm82Value;
			StringType _Parm83Value = Parm83Value;
			StringType _Parm84Value = Parm84Value;
			StringType _Parm85Value = Parm85Value;
			StringType _Parm86Value = Parm86Value;
			StringType _Parm87Value = Parm87Value;
			StringType _Parm88Value = Parm88Value;
			StringType _Parm89Value = Parm89Value;
			StringType _Parm90Value = Parm90Value;
			StringType _Parm91Value = Parm91Value;
			StringType _Parm92Value = Parm92Value;
			StringType _Parm93Value = Parm93Value;
			StringType _Parm94Value = Parm94Value;
			StringType _Parm95Value = Parm95Value;
			StringType _Parm96Value = Parm96Value;
			StringType _Parm97Value = Parm97Value;
			StringType _Parm98Value = Parm98Value;
			StringType _Parm99Value = Parm99Value;
			StringType _Parm100Value = Parm100Value;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IntranetRemoteScriptSp";
				
				appDB.AddCommandParameter(cmd, "Parm1Value", _Parm1Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm2Value", _Parm2Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm3Value", _Parm3Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm4Value", _Parm4Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm5Value", _Parm5Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm6Value", _Parm6Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm7Value", _Parm7Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm8Value", _Parm8Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm9Value", _Parm9Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm10Value", _Parm10Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm11Value", _Parm11Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm12Value", _Parm12Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm13Value", _Parm13Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm14Value", _Parm14Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm15Value", _Parm15Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm16Value", _Parm16Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm17Value", _Parm17Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm18Value", _Parm18Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm19Value", _Parm19Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm20Value", _Parm20Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm21Value", _Parm21Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm22Value", _Parm22Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm23Value", _Parm23Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm24Value", _Parm24Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm25Value", _Parm25Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm26Value", _Parm26Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm27Value", _Parm27Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm28Value", _Parm28Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm29Value", _Parm29Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm30Value", _Parm30Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm31Value", _Parm31Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm32Value", _Parm32Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm33Value", _Parm33Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm34Value", _Parm34Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm35Value", _Parm35Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm36Value", _Parm36Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm37Value", _Parm37Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm38Value", _Parm38Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm39Value", _Parm39Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm40Value", _Parm40Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm41Value", _Parm41Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm42Value", _Parm42Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm43Value", _Parm43Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm44Value", _Parm44Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm45Value", _Parm45Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm46Value", _Parm46Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm47Value", _Parm47Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm48Value", _Parm48Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm49Value", _Parm49Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm50Value", _Parm50Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm51Value", _Parm51Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm52Value", _Parm52Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm53Value", _Parm53Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm54Value", _Parm54Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm55Value", _Parm55Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm56Value", _Parm56Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm57Value", _Parm57Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm58Value", _Parm58Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm59Value", _Parm59Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm60Value", _Parm60Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm61Value", _Parm61Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm62Value", _Parm62Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm63Value", _Parm63Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm64Value", _Parm64Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm65Value", _Parm65Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm66Value", _Parm66Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm67Value", _Parm67Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm68Value", _Parm68Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm69Value", _Parm69Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm70Value", _Parm70Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm71Value", _Parm71Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm72Value", _Parm72Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm73Value", _Parm73Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm74Value", _Parm74Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm75Value", _Parm75Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm76Value", _Parm76Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm77Value", _Parm77Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm78Value", _Parm78Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm79Value", _Parm79Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm80Value", _Parm80Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm81Value", _Parm81Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm82Value", _Parm82Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm83Value", _Parm83Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm84Value", _Parm84Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm85Value", _Parm85Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm86Value", _Parm86Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm87Value", _Parm87Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm88Value", _Parm88Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm89Value", _Parm89Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm90Value", _Parm90Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm91Value", _Parm91Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm92Value", _Parm92Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm93Value", _Parm93Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm94Value", _Parm94Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm95Value", _Parm95Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm96Value", _Parm96Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm97Value", _Parm97Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm98Value", _Parm98Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm99Value", _Parm99Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm100Value", _Parm100Value, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
