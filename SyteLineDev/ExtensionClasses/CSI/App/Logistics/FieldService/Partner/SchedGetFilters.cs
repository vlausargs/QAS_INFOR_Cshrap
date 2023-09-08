//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SchedGetFilters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public interface ISchedGetFilters
    {
        int SchedGetFiltersSp(StringType Username,
                              StringType ScheduleID,
                              IntType FilterGroup,
                              ref ListYesNoType InclInc,
                              ref ListYesNoType InclSro,
                              ref ListYesNoType InclSroLine,
                              ref ListYesNoType InclSroOper,
                              ref ListYesNoType InclPlanLabor,
                              ref FSPartnerType Owner,
                              ref FSSROTypeType SroType,
                              ref ListYesNoType InclMiscTime,
                              ref CityType City,
                              ref StateType State,
                              ref PostalCodeType Zip,
                              ref CountyType County,
                              ref CountryType Country,
                              ref FSRegionType TerritoryRegion,
                              ref ListYesNoType UseRegion,
                              ref DeptType Dept);
    }

    public class SchedGetFilters : ISchedGetFilters
    {
        readonly IApplicationDB appDB;

        public SchedGetFilters(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SchedGetFiltersSp(StringType Username,
                                     StringType ScheduleID,
                                     IntType FilterGroup,
                                     ref ListYesNoType InclInc,
                                     ref ListYesNoType InclSro,
                                     ref ListYesNoType InclSroLine,
                                     ref ListYesNoType InclSroOper,
                                     ref ListYesNoType InclPlanLabor,
                                     ref FSPartnerType Owner,
                                     ref FSSROTypeType SroType,
                                     ref ListYesNoType InclMiscTime,
                                     ref CityType City,
                                     ref StateType State,
                                     ref PostalCodeType Zip,
                                     ref CountyType County,
                                     ref CountryType Country,
                                     ref FSRegionType TerritoryRegion,
                                     ref ListYesNoType UseRegion,
                                     ref DeptType Dept)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SchedGetFiltersSp";

                appDB.AddCommandParameter(cmd, "Username", Username, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ScheduleID", ScheduleID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterGroup", FilterGroup, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InclInc", InclInc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InclSro", InclSro, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InclSroLine", InclSroLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InclSroOper", InclSroOper, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InclPlanLabor", InclPlanLabor, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Owner", Owner, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SroType", SroType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InclMiscTime", InclMiscTime, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "City", City, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "State", State, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Zip", Zip, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "County", County, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Country", Country, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TerritoryRegion", TerritoryRegion, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseRegion", UseRegion, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Dept", Dept, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}