using System.Collections.Generic;
namespace ConsoleHydee
{
    public class ObjectList
    {
        #region 请求体
        public class ReqData_B2BList
        {
            public string APPLYNO { get; set; }//申请单号
            public string SRCBUSNO { get; set; }//源业务机构编号
            public string OBJBUSNO { get; set; }//目标业务机构编号
            public string VENDORNO { get; set; }//供应商编号
            public string BUYER { get; set; }//采购员
            public string DELIVERY_UNIT { get; set; }//发货单位
            public string DELIVERY_ADDR { get; set; }//发运地点
            public string DELIVERY_DATE  { get; set; }//启运时间
            public string CONVEYANCE { get; set; }//运输方式
            public string CASHTYPE { get; set; }//付款方式
            public string INVOICE { get; set; }//开票形式
            public string NOTES { get; set; }//备注
            public List<ProductList> PRODUCTLIST { get; set; }
        }
        #endregion

        #region 返回体
        public class RetData_B2BList
        {
            public string RETURNCODE { get; set; }//0失败  1成功
            public string RETURNMSG { get; set; }//失败的情况下，返回失败信息
            public List<Data> DATA { get; set; }
        }
        #endregion

        #region 返回体Data
        public class Data
        {
            public string APPLYNO { get; set; }//申请单号
            public string APPDISTNO { get; set; }//配送单号
            public List<RProductList> PRODUCTLIST { get; set; }
        }
        #endregion
    }
}