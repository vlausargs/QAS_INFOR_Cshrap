//PROJECT NAME: FSPlusPartnerExt
//CLASS NAME: FSPartners.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Partner;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusPartner
{
    [IDOExtensionClass("FSPartners")]
    public class FSPartners : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSPartnerCreateUtilSp(string StartCustNum,
                                            string EndCustNum,
                                            byte? InclCust,
                                            string StartVendNum,
                                            string EndVendNum,
                                            byte? InclVend,
                                            string StartEmpNum,
                                            string EndEmpNum,
                                            byte? InclEmp,
                                            decimal? SunHrs,
                                            decimal? MonHrs,
                                            decimal? TueHrs,
                                            decimal? WedHrs,
                                            decimal? ThuHrs,
                                            decimal? FriHrs,
                                            decimal? SatHrs,
                                            string Dept,
                                            byte? OverrideDept,
                                            string Whse,
                                            decimal? Cost,
                                            decimal? Rate,
                                            string ReimbMethod,
                                            byte? ReimbMatl,
                                            byte? ReimbLabor,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSPartnerCreateUtilExt = new SSSFSPartnerCreateUtilFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSSSFSPartnerCreateUtilExt.SSSFSPartnerCreateUtilSp(StartCustNum,
                                                                                   EndCustNum,
                                                                                   InclCust,
                                                                                   StartVendNum,
                                                                                   EndVendNum,
                                                                                   InclVend,
                                                                                   StartEmpNum,
                                                                                   EndEmpNum,
                                                                                   InclEmp,
                                                                                   SunHrs,
                                                                                   MonHrs,
                                                                                   TueHrs,
                                                                                   WedHrs,
                                                                                   ThuHrs,
                                                                                   FriHrs,
                                                                                   SatHrs,
                                                                                   Dept,
                                                                                   OverrideDept,
                                                                                   Whse,
                                                                                   Cost,
                                                                                   Rate,
                                                                                   ReimbMethod,
                                                                                   ReimbMatl,
                                                                                   ReimbLabor,
                                                                                   ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
        
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPartnerDefaultsSp(string PartnerId,
			ref int? GPSPollingInterval)
		{
			var iGetPartnerDefaultsExt = new GetPartnerDefaultsFactory().Create(this, true);
			
			var result = iGetPartnerDefaultsExt.GetPartnerDefaultsSp(PartnerId,
				GPSPollingInterval);
			
			GPSPollingInterval = result.GPSPollingInterval;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetCurPartnerSp(ref string Partner,
		                                ref string Name,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetCurPartnerExt = new SSSFSGetCurPartnerFactory().Create(appDb);
				
				int Severity = iSSSFSGetCurPartnerExt.SSSFSGetCurPartnerSp(ref Partner,
				                                                           ref Name,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetPartnerGPSLocSp(string PartnerId,
		decimal? Latitude,
		decimal? Longitude,
		DateTime? LocDate,
		int? GPSOnline)
		{
			var iSetPartnerGPSLocExt = new SetPartnerGPSLocFactory().Create(this, true);
			
			var result = iSetPartnerGPSLocExt.SetPartnerGPSLocSp(PartnerId,
			Latitude,
			Longitude,
			LocDate,
			GPSOnline);
			
			int Severity = result.Value;
			return Severity;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSPartTmpLoadSp(string SkillFilter,
		string LicertFilter,
		string DeptFilter,
		string AreaDescFilter,
		string CountryFilter,
		string StateFilter,
		string CountyFilter,
		string CityFilter,
		string ZipFilter)
		{
			var iSSSFSPartTmpLoadExt = new SSSFSPartTmpLoadFactory().Create(this, true);
			
			var result = iSSSFSPartTmpLoadExt.SSSFSPartTmpLoadSp(SkillFilter,
			LicertFilter,
			DeptFilter,
			AreaDescFilter,
			CountryFilter,
			StateFilter,
			CountyFilter,
			CityFilter,
			ZipFilter);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSRecalcReimbSp(string PartnerID,
		string CurrCode)
		{
			var iSSSFSRecalcReimbExt = new SSSFSRecalcReimbFactory().Create(this, true);
			
			var result = iSSSFSRecalcReimbExt.SSSFSRecalcReimbSp(PartnerID,
			CurrCode);
			
			int Severity = result.Value;
			return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MobileSROCreateSp(Guid? RowPointer,
		[Optional] string Description,
		[Optional] string CustNum,
		[Optional] int? CustSeq,
		[Optional] string PartnerId,
		[Optional] string Contact,
		[Optional] string Email,
		[Optional] string Phone,
		[Optional] string SroStat,
		[Optional] string StatCode,
		[Optional] string PriorCode,
		[Optional] string BillCode,
		[Optional] string BillType,
		[Optional] DateTime? OpenDate,
		[Optional] DateTime? CloseDate,
		ref string Infobar)
		{
			var iMobileSROCreateExt = new MobileSROCreateFactory().Create(this, true);
			
			var result = iMobileSROCreateExt.MobileSROCreateSp(RowPointer,
			Description,
			CustNum,
			CustSeq,
			PartnerId,
			Contact,
			Email,
			Phone,
			SroStat,
			StatCode,
			PriorCode,
			BillCode,
			BillType,
			OpenDate,
			CloseDate,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}

    }
}
