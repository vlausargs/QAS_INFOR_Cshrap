//PROJECT NAME: CSICustomer
//CLASS NAME: BlanketLineItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IBlanketLineItemValid
    {
        int BlanketLineItemValidSp(CoNumType CoNum,
                                   ItemType Item,
                                   CustNumType CustNum,
                                   ref SiteType ShipSite,
                                   CurrCodeType CurrCode,
                                   ref UMType ItemUM,
                                   ref DescriptionType ItemDesc,
                                   ref CustItemType CustItem,
                                   ref FeatStrType FeatStr,
                                   ref Flag ItemPlanFlag,
                                   ref FeatTemplateType ItemFeatTempl,
                                   ref ItemType ItemItem,
                                   ref ListYesNoType Kit,
                                   ref ListYesNoType PrintKitComponents,
                                   ref ListYesNoType ItemSerialTracked,
                                   ref ListYesNoType AllowOnPickList,
                                   ref Infobar Infobar);
    }

    public class BlanketLineItemValid : IBlanketLineItemValid
    {
        readonly IApplicationDB appDB;

        public BlanketLineItemValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int BlanketLineItemValidSp(CoNumType CoNum,
                                          ItemType Item,
                                          CustNumType CustNum,
                                          ref SiteType ShipSite,
                                          CurrCodeType CurrCode,
                                          ref UMType ItemUM,
                                          ref DescriptionType ItemDesc,
                                          ref CustItemType CustItem,
                                          ref FeatStrType FeatStr,
                                          ref Flag ItemPlanFlag,
                                          ref FeatTemplateType ItemFeatTempl,
                                          ref ItemType ItemItem,
                                          ref ListYesNoType Kit,
                                          ref ListYesNoType PrintKitComponents,
                                          ref ListYesNoType ItemSerialTracked,
                                          ref ListYesNoType AllowOnPickList,
                                          ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BlanketLineItemValidSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipSite", ShipSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemUM", ItemUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemDesc", ItemDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustItem", CustItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FeatStr", FeatStr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemPlanFlag", ItemPlanFlag, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemFeatTempl", ItemFeatTempl, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemItem", ItemItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Kit", Kit, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PrintKitComponents", PrintKitComponents, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemSerialTracked", ItemSerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AllowOnPickList", AllowOnPickList, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
