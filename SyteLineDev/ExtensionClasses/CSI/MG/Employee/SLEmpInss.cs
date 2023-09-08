//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpInss.cs

using System;
using CSI.Data.SQL.UDDT;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;

using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLEmpInss")]
    public class SLEmpInss : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ACAResetCorrectedEmployeesSp(ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iACAResetCorrectedEmployeesExt = new ACAResetCorrectedEmployeesFactory().Create(appDb);

                int Severity = iACAResetCorrectedEmployeesExt.ACAResetCorrectedEmployeesSp(ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ACAUpdateEmpinsForXMLGenSp([Optional] string EmployeeNumStarting,
		                                      [Optional] string EmployeeNumEnding,
		                                      [Optional] DateTime? OfferDateStarting,
		                                      [Optional] DateTime? OfferDateEnding,
		                                      [Optional] byte? Corrected,
		                                      [Optional] string ReceiptID,
		                                      [Optional] short? SubmissionID,
		                                      ref int? TotalNumberOf1095,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iACAUpdateEmpinsForXMLGenExt = new ACAUpdateEmpinsForXMLGenFactory().Create(appDb);
				
				var result = iACAUpdateEmpinsForXMLGenExt.ACAUpdateEmpinsForXMLGenSp(EmployeeNumStarting,
				                                                                     EmployeeNumEnding,
				                                                                     OfferDateStarting,
				                                                                     OfferDateEnding,
				                                                                     Corrected,
				                                                                     ReceiptID,
				                                                                     SubmissionID,
				                                                                     TotalNumberOf1095,
				                                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				TotalNumberOf1095 = result.TotalNumberOf1095;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int Tmp10941095cSp([Optional] Guid? SessionID,
		                          [Optional] string Action,
		                          ref decimal? Total_1095,
		                          [Optional] string EmployerName,
		                          [Optional] string EmployerEIN,
		                          [Optional] string EmployerAddr__1,
		                          [Optional] string EmployerCity,
		                          [Optional] string EmployerState,
		                          [Optional] string EmployerCountry,
		                          [Optional] string EmployerZip,
		                          [Optional] string ContactFirstName,
		                          [Optional] string ContactLastName,
		                          [Optional] string ContactPhone,
		                          [Optional] string DGEEmployerName,
		                          [Optional] string DGEEmployerEIN,
		                          [Optional] string DGEEmployerAddr__1,
		                          [Optional] string DGEEmployerCity,
		                          [Optional] string DGEEmployerState,
		                          [Optional] string DGEEmployerCountry,
		                          [Optional] string DGEEmployerZip,
		                          [Optional] string DGEContactFirstName,
		                          [Optional] string DGEContactLastName,
		                          [Optional] string DGEContactPhone,
		                          [Optional] string OtherAleName01,
		                          [Optional] string OtherAleEin01,
		                          [Optional] string OtherAleName02,
		                          [Optional] string OtherAleEin02,
		                          [Optional] string OtherAleName03,
		                          [Optional] string OtherAleEin03,
		                          [Optional] string OtherAleName04,
		                          [Optional] string OtherAleEin04,
		                          [Optional] string OtherAleName05,
		                          [Optional] string OtherAleEin05,
		                          [Optional] string OtherAleName06,
		                          [Optional] string OtherAleEin06,
		                          [Optional] string OtherAleName07,
		                          [Optional] string OtherAleEin07,
		                          [Optional] string OtherAleName08,
		                          [Optional] string OtherAleEin08,
		                          [Optional] string OtherAleName09,
		                          [Optional] string OtherAleEin09,
		                          [Optional] string OtherAleName10,
		                          [Optional] string OtherAleEin10,
		                          [Optional] string OtherAleName11,
		                          [Optional] string OtherAleEin11,
		                          [Optional] string OtherAleName12,
		                          [Optional] string OtherAleEin12,
		                          [Optional] string OtherAleName13,
		                          [Optional] string OtherAleEin13,
		                          [Optional] string OtherAleName14,
		                          [Optional] string OtherAleEin14,
		                          [Optional] string OtherAleName15,
		                          [Optional] string OtherAleEin15,
		                          [Optional] string OtherAleName16,
		                          [Optional] string OtherAleEin16,
		                          [Optional] string OtherAleName17,
		                          [Optional] string OtherAleEin17,
		                          [Optional] string OtherAleName18,
		                          [Optional] string OtherAleEin18,
		                          [Optional] string OtherAleName19,
		                          [Optional] string OtherAleEin19,
		                          [Optional] string OtherAleName20,
		                          [Optional] string OtherAleEin20,
		                          [Optional] string OtherAleName21,
		                          [Optional] string OtherAleEin21,
		                          [Optional] string OtherAleName22,
		                          [Optional] string OtherAleEin22,
		                          [Optional] string OtherAleName23,
		                          [Optional] string OtherAleEin23,
		                          [Optional] string OtherAleName24,
		                          [Optional] string OtherAleEin24,
		                          [Optional] string OtherAleName25,
		                          [Optional] string OtherAleEin25,
		                          [Optional] string OtherAleName26,
		                          [Optional] string OtherAleEin26,
		                          [Optional] string OtherAleName27,
		                          [Optional] string OtherAleEin27,
		                          [Optional] string OtherAleName28,
		                          [Optional] string OtherAleEin28,
		                          [Optional] string OtherAleName29,
		                          [Optional] string OtherAleEin29,
		                          [Optional] string OtherAleName30,
		                          [Optional] string OtherAleEin30,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTmp10941095cExt = new Tmp10941095cFactory().Create(appDb);
				
				var result = iTmp10941095cExt.Tmp10941095cSp(SessionID,
				                                             Action,
				                                             Total_1095,
				                                             EmployerName,
				                                             EmployerEIN,
				                                             EmployerAddr__1,
				                                             EmployerCity,
				                                             EmployerState,
				                                             EmployerCountry,
				                                             EmployerZip,
				                                             ContactFirstName,
				                                             ContactLastName,
				                                             ContactPhone,
				                                             DGEEmployerName,
				                                             DGEEmployerEIN,
				                                             DGEEmployerAddr__1,
				                                             DGEEmployerCity,
				                                             DGEEmployerState,
				                                             DGEEmployerCountry,
				                                             DGEEmployerZip,
				                                             DGEContactFirstName,
				                                             DGEContactLastName,
				                                             DGEContactPhone,
				                                             OtherAleName01,
				                                             OtherAleEin01,
				                                             OtherAleName02,
				                                             OtherAleEin02,
				                                             OtherAleName03,
				                                             OtherAleEin03,
				                                             OtherAleName04,
				                                             OtherAleEin04,
				                                             OtherAleName05,
				                                             OtherAleEin05,
				                                             OtherAleName06,
				                                             OtherAleEin06,
				                                             OtherAleName07,
				                                             OtherAleEin07,
				                                             OtherAleName08,
				                                             OtherAleEin08,
				                                             OtherAleName09,
				                                             OtherAleEin09,
				                                             OtherAleName10,
				                                             OtherAleEin10,
				                                             OtherAleName11,
				                                             OtherAleEin11,
				                                             OtherAleName12,
				                                             OtherAleEin12,
				                                             OtherAleName13,
				                                             OtherAleEin13,
				                                             OtherAleName14,
				                                             OtherAleEin14,
				                                             OtherAleName15,
				                                             OtherAleEin15,
				                                             OtherAleName16,
				                                             OtherAleEin16,
				                                             OtherAleName17,
				                                             OtherAleEin17,
				                                             OtherAleName18,
				                                             OtherAleEin18,
				                                             OtherAleName19,
				                                             OtherAleEin19,
				                                             OtherAleName20,
				                                             OtherAleEin20,
				                                             OtherAleName21,
				                                             OtherAleEin21,
				                                             OtherAleName22,
				                                             OtherAleEin22,
				                                             OtherAleName23,
				                                             OtherAleEin23,
				                                             OtherAleName24,
				                                             OtherAleEin24,
				                                             OtherAleName25,
				                                             OtherAleEin25,
				                                             OtherAleName26,
				                                             OtherAleEin26,
				                                             OtherAleName27,
				                                             OtherAleEin27,
				                                             OtherAleName28,
				                                             OtherAleEin28,
				                                             OtherAleName29,
				                                             OtherAleEin29,
				                                             OtherAleName30,
				                                             OtherAleEin30,
				                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				Total_1095 = result.Total_1095;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
