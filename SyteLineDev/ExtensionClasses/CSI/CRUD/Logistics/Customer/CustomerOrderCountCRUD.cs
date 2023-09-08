using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CSI.Logistics.Customer
{
    public interface ICustomerOrderCountCRUD
    {
        (int? Severity, int? OrderCount, string Infobar) GetCustomerOrderCount(string orderType,
            string filterType,
            string customer,
            int? shipTo,
            int? days);

    }
    public class CustomerOrderCountCRUD : ICustomerOrderCountCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IApplicationDB appDB;
        const int DEFAULT_LATE_ORDER_DAYS = 0;
		const int DEFAULT_NEW_ORDER_DAYS = 7;
		const int DEFAULT_STOPPED_ORDER_DAYS = 30;
		const int DEFAULT_COMPLETED_ORDER_DAYS = 30;

		public CustomerOrderCountCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory,
                       IApplicationDB appDB)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;

        }


        public (int? Severity, int? OrderCount, string Infobar) GetCustomerOrderCount(string orderType,
            string filterType,
            string customer,
            int? shipTo,
            int? days)
        {
            OrderType _OrderType = ParseEnum<OrderType>(orderType);
            FilterType _FilterType = ParseEnum<FilterType>(filterType);
			customer = customer?.Trim();

			#region CRUD LoadArbitrary
			try
            {
                var tLoadRequest = collectionLoadRequestFactory.SQLLoad(
                        columnExpressionByColumnName: new Dictionary<string, string>()
                            {
                                {"reccount","COUNT(*)"}
                            },
                       tableName: "co",
                       loadForChange: false,
                       lockingType: LockingType.None,
                       fromClause: BuildFromClause(_FilterType, customer, shipTo, days),
                       whereClause: BuildWhereClause(_FilterType, customer, shipTo, days),
                       orderByClause: collectionLoadRequestFactory.Clause(""), 0, null);


                var tLoadResponse = this.appDB.Load(tLoadRequest);
                var OrderCount = (int)tLoadResponse?.Items[0]?.GetValue<int>("reccount");
                return (0, OrderCount, "");
            }
            catch (Exception ex)
            {

                return (-1, 0, ex.Message); ;
            }

            #endregion  LoadArbitrary
        }



		private IParameterizedCommand BuildFromClause(FilterType _FilterType, string cust_num, int? shipTo, int? days)
		{
			days = days ?? DEFAULT_LATE_ORDER_DAYS;

			if (_FilterType == FilterType.Late)

				return collectionLoadRequestFactory.Clause("AS co JOIN (SELECT  co_num from coitem ci WHERE " +
								$"ci.stat = N'O' AND ci.due_date < cast(GETDATE()-{days} as date) GROUP BY ci.co_num) i on i.co_num = co.co_num");
			else
				return collectionLoadRequestFactory.Clause("AS co");

		}

		private IParameterizedCommand BuildWhereClause(FilterType _FilterType, string cust_num, int? shipTo, int? days)
		{
			switch (_FilterType)
			{
				case FilterType.Late:
					return BuildWhereClauseLateOrders(cust_num, shipTo);
				case FilterType.Open:
					return BuildWhereClauseOpenOrders(cust_num, shipTo);
				case FilterType.New:
					return BuildWhereClauseNewOrders(cust_num, shipTo, days);
				case FilterType.Stopped:
					return BuildWhereClauseStoppedOrders(cust_num, shipTo, days);
				case FilterType.Complete:
					return BuildWhereClauseCompleteOrders(cust_num, shipTo, days);

				default:
					return default;
			}


		}

		private IParameterizedCommand BuildWhereClauseLateOrders(string cust_num, int? shipTo)
		{


			if (string.IsNullOrEmpty(cust_num))
				return collectionLoadRequestFactory.Clause("co.type = N'R'");

			else
				return collectionLoadRequestFactory.Clause("LTRIM(co.cust_num) = {0}" +
															ShiptToWhereCondition(shipTo) +
														" AND co.type = N'R'", cust_num, shipTo);

		}

		private IParameterizedCommand BuildWhereClauseOpenOrders(string cust_num, int? shipTo)
		{
			if (string.IsNullOrEmpty(cust_num))
				return collectionLoadRequestFactory.Clause("co.type = N'E' AND (co.stat = N'W' OR co.stat = N'P')");

			else
				return collectionLoadRequestFactory.Clause("LTRIM(co.cust_num) = {0}" +
																	  ShiptToWhereCondition(shipTo) +
																	" AND co.type = N'E'" +
																	" AND (co.stat = N'W' OR co.stat = N'P')", cust_num, shipTo);

		}

		private IParameterizedCommand BuildWhereClauseNewOrders(string cust_num, int? shipTo, int? days)
		{

			days = days ?? DEFAULT_NEW_ORDER_DAYS;

			if (string.IsNullOrEmpty(cust_num))
				return collectionLoadRequestFactory.Clause("co.type = N'R'" +
															$" AND co.order_date >= cast(GETDATE()-{days} as date)");

			else
				return collectionLoadRequestFactory.Clause("LTRIM(co.cust_num) = {0}" +
																	 ShiptToWhereCondition(shipTo) +
																	" AND co.type = N'R'" +
																   $" AND co.order_date >= cast(GETDATE()-{days} as date)", cust_num, shipTo);

		}

		private IParameterizedCommand BuildWhereClauseStoppedOrders(string cust_num, int? shipTo, int? days)
		{

			days = days ?? DEFAULT_STOPPED_ORDER_DAYS;

			if (string.IsNullOrEmpty(cust_num))
				return collectionLoadRequestFactory.Clause("co.type = N'R' AND co.stat = N'S'" +
															$" AND co.order_date >= cast(GETDATE()-{days} as date)");

			else
				return collectionLoadRequestFactory.Clause("LTRIM(co.cust_num) = {0}" +
																	   ShiptToWhereCondition(shipTo) +
																	" AND co.type = N'R'" +
																	" AND co.stat = N'S'" +
																	$" AND co.order_date >= cast(GETDATE()-{days} as date)", cust_num, shipTo);

		}

		private IParameterizedCommand BuildWhereClauseCompleteOrders(string cust_num, int? shipTo, int? days)
		{


			days = days ?? DEFAULT_COMPLETED_ORDER_DAYS;

			if (string.IsNullOrEmpty(cust_num))
				return collectionLoadRequestFactory.Clause("co.type = N'R' AND (co.stat = N'C' OR co.stat = N'H')" +
															$" AND co.order_date >= cast(GETDATE()-{days} as date)");

			else
				return collectionLoadRequestFactory.Clause("LTRIM(co.cust_num) = {0}" +
																	   ShiptToWhereCondition(shipTo) +
																	" AND co.type = N'R'" +
																	" AND (co.stat = N'C' OR co.stat = N'H')" +
																	$" AND co.order_date >= cast(GETDATE()-{days} as date)", cust_num, shipTo);

		}

		private string ShiptToWhereCondition(int? shipTo)
        {
			return shipTo == null ? "" : " AND co.cust_seq = {1}";

		}

		private T ParseEnum<T>(string value)
		{

			try
			{
				return (T)Enum.Parse(typeof(T), value, true);
			}
			catch (Exception)
			{

				return default;
			}

		}

		enum OrderType
		{
			[Description("Regular Orders")]
			Order = 0,
			[Description("Estimates")]
			Estimate = 1
		}

		enum FilterType
		{
			[Description("All Orders (ex. Open Quotes would be done using Order Type = Estimate and Filter Type = Open)")]
			Open,
			[Description("Orders that contain at least one line where the Due Date is greater then Today – Late Order Days (Default to 0)")]
			Late,
			[Description("Order where the Status is Planned or Ordered and the Order Date > Today – New Order Days (Default to 7)")]
			New,
			[Description("Order where the Status is Stopped and the Order Date > Today – Stopped Order Days (Default to 30)")]
			Stopped,
			[Description("Order where the Status is Complete or History")]
			Complete
		}
	}
}
