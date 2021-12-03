using System.Runtime.Serialization;
using System.Collections.Generic;
namespace ConsoleHydee
{
    [DataContract]
    #region 请求消息明细
    public class ProductList
    {
        [DataMember(Order = 0)]
        public string WAREID { get; set; }//商品编号

        [DataMember(Order = 1)]
        public string ROWNO { get; set; }//行号

        [DataMember(Order = 2)]
        public string APPLYQTY { get; set; }//申请数量

        [DataMember(Order = 3)]
        public string PURPRICE { get; set; }//单价

        [DataMember(Order = 4)]
        public string BATID { get; set; }//批次号

        [DataMember(Order = 5)]
        public string MAKENO { get; set; }//生产批号

        [DataMember(Order = 6)]
        public string INVALIDATE { get; set; }//有效期至

        [DataMember(Order = 7)]
        public string NOTES { get; set; }//备注

        [DataMember(Order = 8)]
        public string AMOUNT { get; set; }//金额
    }
    #endregion
    #region 返回消息明细
    public class RProductList
    {
        [DataMember(Order = 0)]
        public string WAREID { get; set; }//产品编码

        [DataMember(Order = 1)]
        public string ROWNO { get; set; }//行号

        [DataMember(Order = 2)]
        public string DISTQTY { get; set; }//数量  

        [DataMember(Order = 3)]
        public string PRICE { get; set; }//单价

        [DataMember(Order = 4)]
        public string MONEY { get; set; }//金额

        [DataMember(Order = 5)]
        public string BATID { get; set; }//批次号

        [DataMember(Order = 6)]
        public string MAKENO { get; set; }//生产批号

        [DataMember(Order = 7)]
        public string INVALIDATE { get; set; }//有效期至

        [DataMember(Order = 8)]
        public string NOTES { get; set; }//备注
    }
    #endregion
}