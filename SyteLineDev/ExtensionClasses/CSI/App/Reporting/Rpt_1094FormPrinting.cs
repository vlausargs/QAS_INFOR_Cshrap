//PROJECT NAME: Reporting
//CLASS NAME: Rpt_1094FormPrinting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_1094FormPrinting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_1094FormPrintingSp(Guid? SessionId = null,
		byte? Corrected = null,
		byte? Transmittal = null,
		byte? Member = null,
		byte? QOM = null,
		byte? QOMTR = null,
		byte? Section480 = null,
		byte? _98Pct = null,
		byte? MEC12Months = null,
		byte? MECJan = null,
		byte? MECFeb = null,
		byte? MECMar = null,
		byte? MECApr = null,
		byte? MECMay = null,
		byte? MECJun = null,
		byte? MECJul = null,
		byte? MECAug = null,
		byte? MECSep = null,
		byte? MECOct = null,
		byte? MECNov = null,
		byte? MECDec = null,
		byte? AGI12Months = null,
		byte? AGIJan = null,
		byte? AGIFeb = null,
		byte? AGIMar = null,
		byte? AGIApr = null,
		byte? AGIMay = null,
		byte? AGIJun = null,
		byte? AGIJul = null,
		byte? AGIAug = null,
		byte? AGISep = null,
		byte? AGIOct = null,
		byte? AGINov = null,
		byte? AGIDec = null,
		decimal? FTE12Months = null,
		decimal? FTEJan = null,
		decimal? FTEFeb = null,
		decimal? FTEMar = null,
		decimal? FTEApr = null,
		decimal? FTEMay = null,
		decimal? FTEJun = null,
		decimal? FTEJul = null,
		decimal? FTEAug = null,
		decimal? FTESep = null,
		decimal? FTEOct = null,
		decimal? FTENov = null,
		decimal? FTEDec = null,
		decimal? TEC12Months = null,
		decimal? TECJan = null,
		decimal? TECFeb = null,
		decimal? TECMar = null,
		decimal? TECApr = null,
		decimal? TECMay = null,
		decimal? TECJun = null,
		decimal? TECJul = null,
		decimal? TECAug = null,
		decimal? TECSep = null,
		decimal? TECOct = null,
		decimal? TECNov = null,
		decimal? TECDec = null,
		string TRI12Months = null,
		string TRIJan = null,
		string TRIFeb = null,
		string TRIMar = null,
		string TRIApr = null,
		string TRIMay = null,
		string TRIJun = null,
		string TRIJul = null,
		string TRIAug = null,
		string TRISep = null,
		string TRIOct = null,
		string TRINov = null,
		string TRIDec = null,
		decimal? TotalNo1095CFiledByALEMember = null,
		string pSite = null);
	}
	
	public class Rpt_1094FormPrinting : IRpt_1094FormPrinting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_1094FormPrinting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_1094FormPrintingSp(Guid? SessionId = null,
		byte? Corrected = null,
		byte? Transmittal = null,
		byte? Member = null,
		byte? QOM = null,
		byte? QOMTR = null,
		byte? Section480 = null,
		byte? _98Pct = null,
		byte? MEC12Months = null,
		byte? MECJan = null,
		byte? MECFeb = null,
		byte? MECMar = null,
		byte? MECApr = null,
		byte? MECMay = null,
		byte? MECJun = null,
		byte? MECJul = null,
		byte? MECAug = null,
		byte? MECSep = null,
		byte? MECOct = null,
		byte? MECNov = null,
		byte? MECDec = null,
		byte? AGI12Months = null,
		byte? AGIJan = null,
		byte? AGIFeb = null,
		byte? AGIMar = null,
		byte? AGIApr = null,
		byte? AGIMay = null,
		byte? AGIJun = null,
		byte? AGIJul = null,
		byte? AGIAug = null,
		byte? AGISep = null,
		byte? AGIOct = null,
		byte? AGINov = null,
		byte? AGIDec = null,
		decimal? FTE12Months = null,
		decimal? FTEJan = null,
		decimal? FTEFeb = null,
		decimal? FTEMar = null,
		decimal? FTEApr = null,
		decimal? FTEMay = null,
		decimal? FTEJun = null,
		decimal? FTEJul = null,
		decimal? FTEAug = null,
		decimal? FTESep = null,
		decimal? FTEOct = null,
		decimal? FTENov = null,
		decimal? FTEDec = null,
		decimal? TEC12Months = null,
		decimal? TECJan = null,
		decimal? TECFeb = null,
		decimal? TECMar = null,
		decimal? TECApr = null,
		decimal? TECMay = null,
		decimal? TECJun = null,
		decimal? TECJul = null,
		decimal? TECAug = null,
		decimal? TECSep = null,
		decimal? TECOct = null,
		decimal? TECNov = null,
		decimal? TECDec = null,
		string TRI12Months = null,
		string TRIJan = null,
		string TRIFeb = null,
		string TRIMar = null,
		string TRIApr = null,
		string TRIMay = null,
		string TRIJun = null,
		string TRIJul = null,
		string TRIAug = null,
		string TRISep = null,
		string TRIOct = null,
		string TRINov = null,
		string TRIDec = null,
		decimal? TotalNo1095CFiledByALEMember = null,
		string pSite = null)
		{
			RowPointerType _SessionId = SessionId;
			ListYesNoType _Corrected = Corrected;
			ListYesNoType _Transmittal = Transmittal;
			ListYesNoType _Member = Member;
			ListYesNoType _QOM = QOM;
			ListYesNoType _QOMTR = QOMTR;
			ListYesNoType _Section480 = Section480;
			ListYesNoType __98Pct = _98Pct;
			ListYesNoType _MEC12Months = MEC12Months;
			ListYesNoType _MECJan = MECJan;
			ListYesNoType _MECFeb = MECFeb;
			ListYesNoType _MECMar = MECMar;
			ListYesNoType _MECApr = MECApr;
			ListYesNoType _MECMay = MECMay;
			ListYesNoType _MECJun = MECJun;
			ListYesNoType _MECJul = MECJul;
			ListYesNoType _MECAug = MECAug;
			ListYesNoType _MECSep = MECSep;
			ListYesNoType _MECOct = MECOct;
			ListYesNoType _MECNov = MECNov;
			ListYesNoType _MECDec = MECDec;
			ListYesNoType _AGI12Months = AGI12Months;
			ListYesNoType _AGIJan = AGIJan;
			ListYesNoType _AGIFeb = AGIFeb;
			ListYesNoType _AGIMar = AGIMar;
			ListYesNoType _AGIApr = AGIApr;
			ListYesNoType _AGIMay = AGIMay;
			ListYesNoType _AGIJun = AGIJun;
			ListYesNoType _AGIJul = AGIJul;
			ListYesNoType _AGIAug = AGIAug;
			ListYesNoType _AGISep = AGISep;
			ListYesNoType _AGIOct = AGIOct;
			ListYesNoType _AGINov = AGINov;
			ListYesNoType _AGIDec = AGIDec;
			RsvdNumType _FTE12Months = FTE12Months;
			RsvdNumType _FTEJan = FTEJan;
			RsvdNumType _FTEFeb = FTEFeb;
			RsvdNumType _FTEMar = FTEMar;
			RsvdNumType _FTEApr = FTEApr;
			RsvdNumType _FTEMay = FTEMay;
			RsvdNumType _FTEJun = FTEJun;
			RsvdNumType _FTEJul = FTEJul;
			RsvdNumType _FTEAug = FTEAug;
			RsvdNumType _FTESep = FTESep;
			RsvdNumType _FTEOct = FTEOct;
			RsvdNumType _FTENov = FTENov;
			RsvdNumType _FTEDec = FTEDec;
			RsvdNumType _TEC12Months = TEC12Months;
			RsvdNumType _TECJan = TECJan;
			RsvdNumType _TECFeb = TECFeb;
			RsvdNumType _TECMar = TECMar;
			RsvdNumType _TECApr = TECApr;
			RsvdNumType _TECMay = TECMay;
			RsvdNumType _TECJun = TECJun;
			RsvdNumType _TECJul = TECJul;
			RsvdNumType _TECAug = TECAug;
			RsvdNumType _TECSep = TECSep;
			RsvdNumType _TECOct = TECOct;
			RsvdNumType _TECNov = TECNov;
			RsvdNumType _TECDec = TECDec;
			AbcCodeType _TRI12Months = TRI12Months;
			AbcCodeType _TRIJan = TRIJan;
			AbcCodeType _TRIFeb = TRIFeb;
			AbcCodeType _TRIMar = TRIMar;
			AbcCodeType _TRIApr = TRIApr;
			AbcCodeType _TRIMay = TRIMay;
			AbcCodeType _TRIJun = TRIJun;
			AbcCodeType _TRIJul = TRIJul;
			AbcCodeType _TRIAug = TRIAug;
			AbcCodeType _TRISep = TRISep;
			AbcCodeType _TRIOct = TRIOct;
			AbcCodeType _TRINov = TRINov;
			AbcCodeType _TRIDec = TRIDec;
			RsvdNumType _TotalNo1095CFiledByALEMember = TotalNo1095CFiledByALEMember;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_1094FormPrintingSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Corrected", _Corrected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Transmittal", _Transmittal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Member", _Member, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QOM", _QOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QOMTR", _QOMTR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Section480", _Section480, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "98Pct", __98Pct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MEC12Months", _MEC12Months, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECJan", _MECJan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECFeb", _MECFeb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECMar", _MECMar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECApr", _MECApr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECMay", _MECMay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECJun", _MECJun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECJul", _MECJul, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECAug", _MECAug, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECSep", _MECSep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECOct", _MECOct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECNov", _MECNov, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MECDec", _MECDec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGI12Months", _AGI12Months, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIJan", _AGIJan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIFeb", _AGIFeb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIMar", _AGIMar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIApr", _AGIApr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIMay", _AGIMay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIJun", _AGIJun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIJul", _AGIJul, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIAug", _AGIAug, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGISep", _AGISep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIOct", _AGIOct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGINov", _AGINov, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AGIDec", _AGIDec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTE12Months", _FTE12Months, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEJan", _FTEJan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEFeb", _FTEFeb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEMar", _FTEMar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEApr", _FTEApr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEMay", _FTEMay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEJun", _FTEJun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEJul", _FTEJul, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEAug", _FTEAug, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTESep", _FTESep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEOct", _FTEOct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTENov", _FTENov, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTEDec", _FTEDec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEC12Months", _TEC12Months, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECJan", _TECJan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECFeb", _TECFeb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECMar", _TECMar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECApr", _TECApr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECMay", _TECMay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECJun", _TECJun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECJul", _TECJul, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECAug", _TECAug, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECSep", _TECSep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECOct", _TECOct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECNov", _TECNov, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TECDec", _TECDec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRI12Months", _TRI12Months, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIJan", _TRIJan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIFeb", _TRIFeb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIMar", _TRIMar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIApr", _TRIApr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIMay", _TRIMay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIJun", _TRIJun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIJul", _TRIJul, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIAug", _TRIAug, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRISep", _TRISep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIOct", _TRIOct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRINov", _TRINov, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRIDec", _TRIDec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalNo1095CFiledByALEMember", _TotalNo1095CFiledByALEMember, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
