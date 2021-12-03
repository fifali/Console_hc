//using System;
//using System.Data;
//using System.Collections.Generic;
//using Newtonsoft.Json.Linq;
//using System.Configuration;
//using System.Net;
//using System.Text;
//using swiftpass.utils;
//using System.Web.Script.Serialization;
//namespace ConsoleHydee2
//{
//    class Program2
//    {
//        static HttpListener httpobj;

//        static void Main(string[] args)
//        {
//            Console.WriteLine("");
//            PublicBll bll = new PublicBll();
//            //提供一个简单的、可通过编程方式控制的 HTTP 协议侦听器。此类不能被继承。
//            httpobj = new HttpListener();
//            //定义url及端口号，通常设置为配置文件
//            //string url = ConfigurationManager.AppSettings["Url"];
//            string url = "";
//            bll.geturlParms(Environment.CurrentDirectory + "\\DBConn\\001.xml", out url);
//            Console.WriteLine($"URL：{url}\r\n");
//            httpobj.Prefixes.Add(url);
//            //启动监听器
//            httpobj.Start();
//            //异步监听客户端请求，当客户端的网络请求到来时会自动执行Result委托
//            //该委托没有返回值，有一个IAsyncResult接口的参数，可通过该参数获取context对象
//            httpobj.BeginGetContext(Result, null);
//            Console.WriteLine($"服务端初始化完毕，正在等待客户端请求,时间：{DateTime.Now.ToString()}\r\n");
//            Console.ReadKey();
//        }

//        private static void Result(IAsyncResult ar)
//        {
//            //当接收到请求后程序流会走到这里

//            //继续异步监听
//            httpobj.BeginGetContext(Result, null);
//            var guid = Guid.NewGuid().ToString();
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.WriteLine($"接到新的请求:{guid},时间：{DateTime.Now.ToString()}\r\n");
//            //获得context对象
//            var context = httpobj.EndGetContext(ar);
//            var request = context.Request;
//            var response = context.Response;
//            context.Response.ContentType = "text/plain;charset=UTF-8";//告诉客户端返回的ContentType类型为纯文本格式，编码为UTF-8
//            context.Response.AddHeader("Content-type", "text/plain");//添加响应头信息
//            context.Response.ContentEncoding = Encoding.UTF8;
//            string returnObj = null;//定义返回客户端的信息
//            if (request.HttpMethod == "POST" && request.InputStream != null)
//            {
//                //处理客户端发送的请求并返回处理信息
//                returnObj = HandleRequest(request, response);
//            }
//            else
//            {
//                returnObj = $"不是post请求或者传过来的数据为空\r\n";
//            }
//            var returnByteArr = Encoding.UTF8.GetBytes(returnObj);//设置客户端返回信息的编码
//            try
//            {
//                using (var stream = response.OutputStream)
//                {
//                    //把处理信息返回到客户端
//                    stream.Write(returnByteArr, 0, returnByteArr.Length);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"网络蹦了：{ex.ToString()}\r\n");
//            }
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine($"请求处理完成：{guid},时间：{ DateTime.Now.ToString()}\r\n");
//        }

//        private static string HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
//        {
//            string data = null;
//            string dodata = null;
//            try
//            {
//                var byteList = new List<byte>();
//                var byteArr = new byte[2048];
//                int readLen = 0;
//                int len = 0;
//                //接收客户端传过来的数据并转成字符串类型
//                do
//                {
//                    readLen = request.InputStream.Read(byteArr, 0, byteArr.Length);
//                    len += readLen;
//                    byteList.AddRange(byteArr);
//                } while (readLen != 0);
//                data = Encoding.UTF8.GetString(byteList.ToArray(), 0, len);
//                dodata = HydeeInterfaces(data, request.RawUrl);
//                //获取得到数据data可以进行其他操作
//            }
//            catch (Exception ex)
//            {
//                response.StatusDescription = "404";
//                response.StatusCode = 404;
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"在接收数据时发生错误:{ex.ToString()}\r\n");
//                return $"在接收数据时发生错误:{ex.ToString()}\r\n";//把服务端错误信息直接返回可能会导致信息不安全，此处仅供参考
//            }
//            response.StatusDescription = "200";//获取或设置返回给客户端的 HTTP 状态代码的文本说明。
//            response.StatusCode = 200;// 获取或设置返回给客户端的 HTTP 状态代码。
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine($"接收数据完成:{data.Trim()},时间：{DateTime.Now.ToString()}\r\n");
//            Console.WriteLine($"数据处理结果：{dodata}\r\n");
//            //return $"接收数据完成";
//            return dodata;
//        }

//        public static string HydeeInterfaces(string ReqHeadJson, string ReqType)
//        {
//            #region 变量定义
//            ObjectList.ReqData_B2BList _reqData_B2BList;
//            ObjectList.RetData_B2BList _retData_B2BList;
//            PublicBll bll = new PublicBll();
//            JObject jObject = null;
//            JavaScriptSerializer js = new JavaScriptSerializer();
//            List<ProductList> _productList = null;
//            //List<RProductList> _rproductList = null;
//            //RProductList _rproduct = null;
//            List<ObjectList.Data> _datalist = null;
//            ObjectList.Data _data = null;
//            string ls_retmsg = "TRUE";
//            string _product = null;
//            string ls_compid = null;
//            string ls_billno = null;
//            _reqData_B2BList = new ObjectList.ReqData_B2BList();
//            DataTable dt = null;
//            string ls_bandcode = null;
//            #endregion
//            try
//            {
//                #region 预留
//                if (ReqType == "/Other")
//                {
//                    #region 反序列化请求（注释）
//                    #endregion
//                    #region 反序列化请求
//                    #endregion
//                }
//                #endregion
//                #region 海川委托配送
//                else
//                {

//                }
//                #endregion
//                #region 获取数据库连接
//                if (!bll.getcnParms(Environment.CurrentDirectory + "\\DBConn\\" + "002.xml", out ls_retmsg))
//                {
//                    bll.dao.RollbackTrans();
//                    _retData_B2BList = new ObjectList.RetData_B2BList();
//                    _retData_B2BList.RETURNCODE = "0";
//                    _retData_B2BList.RETURNMSG = ls_retmsg;
//                    return js.Serialize(_retData_B2BList);
//                }
//                #endregion
//                #region 验证身份
//                ls_retmsg = bll.checkUserValid(bll.FunctionId, bll.InterfaceUserID, bll.InterfacePassWord, bll.OperUserID, bll.OperPassWord, ls_retmsg);
//                if (ls_retmsg != "TRUE")
//                {
//                    #region 错误返回
//                    bll.dao.RollbackTrans();
//                    _retData_B2BList = new ObjectList.RetData_B2BList();
//                    _retData_B2BList.RETURNCODE = "0";
//                    _retData_B2BList.RETURNMSG = ls_retmsg;
//                    return js.Serialize(_retData_B2BList);
//                    #endregion
//                }
//                #endregion
//                #region  业务处理
//                switch (ReqType)
//                {
//                    case "/CreateOrder"://创建订单
//                        #region 反序列化请求productList
//                        jObject = JObject.Parse(ReqHeadJson);
//                        _product = jObject["PRODUCTLIST"].ToString();
//                        _productList = new List<ProductList>();
//                        _productList = PublicClass.JsonStringToList<ProductList>(_product);
//                        #endregion
//                        #region 变量初始化
//                        _reqData_B2BList.PRODUCTLIST = _productList;
//                        _reqData_B2BList.APPLYNO = jObject["APPLYNO"].ToString();
//                        _reqData_B2BList.BUYER = jObject["BUYER"].ToString();
//                        _reqData_B2BList.CASHTYPE = jObject["CASHTYPE"].ToString();
//                        _reqData_B2BList.CONVEYANCE = jObject["CONVEYANCE"].ToString();
//                        _reqData_B2BList.DELIVERY_ADDR = jObject["DELIVERY_ADDR"].ToString();
//                        _reqData_B2BList.DELIVERY_DATE = jObject["DELIVERY_DATE"].ToString();
//                        _reqData_B2BList.DELIVERY_UNIT = jObject["DELIVERY_UNIT"].ToString();
//                        _reqData_B2BList.INVOICE = jObject["INVOICE"].ToString();
//                        _reqData_B2BList.NOTES = jObject["NOTES"].ToString();
//                        _reqData_B2BList.OBJBUSNO = jObject["OBJBUSNO"].ToString();
//                        _reqData_B2BList.SRCBUSNO = jObject["SRCBUSNO"].ToString();
//                        _reqData_B2BList.VENDORNO = jObject["VENDORNO"].ToString();
//                        #endregion
//                        #region 数据验证
//                        if (string.IsNullOrEmpty(_reqData_B2BList.APPLYNO))
//                        {
//                            ls_retmsg = "【申请单号】不能为空";
//                            #region 错误返回
//                            bll.dao.RollbackTrans();
//                            _retData_B2BList = new ObjectList.RetData_B2BList();
//                            _retData_B2BList.RETURNCODE = "0";
//                            _retData_B2BList.RETURNMSG = ls_retmsg;
//                            return js.Serialize(_retData_B2BList);
//                            #endregion
//                        }
//                        dt = new DataTable();
//                        dt = bll.dao.GetDataTable("select ''||f_get_serial('APP','" + _reqData_B2BList.SRCBUSNO + "') as billno from dual");
//                        if (dt.Rows.Count <= 0)
//                        {
//                            ls_retmsg = "生成委托配送申请单号失败";
//                            #region 错误返回
//                            bll.dao.RollbackTrans();
//                            _retData_B2BList = new ObjectList.RetData_B2BList();
//                            _retData_B2BList.RETURNCODE = "-1";
//                            _retData_B2BList.RETURNMSG = ls_retmsg;
//                            return js.Serialize(_retData_B2BList);
//                            #endregion
//                        }
//                        ls_billno = dt.Rows[0][0].ToString();
//                        dt = bll.dao.GetDataTable("select compid from s_busi where busno = '" + _reqData_B2BList.OBJBUSNO + "'");
//                        if (dt.Rows.Count <= 0)
//                        {
//                            ls_retmsg = "生成委托配送申请单号失败";
//                            #region 错误返回
//                            bll.dao.RollbackTrans();
//                            _retData_B2BList = new ObjectList.RetData_B2BList();
//                            _retData_B2BList.RETURNCODE = "-1";
//                            _retData_B2BList.RETURNMSG = ls_retmsg;
//                            return js.Serialize(_retData_B2BList);
//                            #endregion
//                        }
//                        if (dt.Rows.Count <= 0)
//                        {
//                            ls_retmsg = "源目标业务机构不正确";
//                            #region 错误返回
//                            bll.dao.RollbackTrans();
//                            _retData_B2BList = new ObjectList.RetData_B2BList();
//                            _retData_B2BList.RETURNCODE = "-1";
//                            _retData_B2BList.RETURNMSG = ls_retmsg;
//                            return js.Serialize(_retData_B2BList);
//                            #endregion
//                        }
//                        ls_compid = dt.Rows[0][0].ToString();
//                        //if (string.IsNullOrEmpty(_reqData_B2BList.agentId))
//                        //{
//                        //    _reqData_B2BList.agentId = "999";
//                        //}
//                        //if (string.IsNullOrEmpty(_reqData_B2BList.salerId))
//                        //{
//                        //    _reqData_B2BList.salerId = "999";
//                        //}
//                        //dt = bll.dao.GetDataTable("select ''||f_get_serial('" + ls_billtype + "','" + ls_compid + "') billno from dual");
//                        //ls_billno = dt.Rows[0]["billno"].ToString();
//                        //dt = bll.dao.GetDataTable("select 1 from t_b2b_order_status where order_id = '" + _reqData_B2BList.orderId + "'");
//                        //if (dt.Rows.Count > 0)
//                        //{
//                        //    ls_retmsg = "已经存在的【订单编号" + _reqData_B2BList.APPLYNO.ToString() + "】";
//                        //    #region 错误返回
//                        //    bll.dao.RollbackTrans();
//                        //    _retData_B2BList = new ObjectList.RetData_B2BList();
//                        //    _retData_B2BList.RETURNCODE = "0";
//                        //    _retData_B2BList.RETURNMSG = ls_retmsg;
//                        //    return js.Serialize(_retData_B2BList);
//                        //    #endregion
//                        //}
//                        #endregion
//                        #region 插入委托配送申请单头
//                        ls_retmsg = bll.dao.SqlDataTable(@"INSERT INTO t_distapply_h
//                                                              (billcode,
//                                                               applyno,
//                                                               srcbusno,
//                                                               objbusno,
//                                                               status,
//                                                               checkbit1,
//                                                               checkbit2,
//                                                               checkbit3,
//                                                               checkbit4,
//                                                               checkbit5,
//                                                               createuser,
//                                                               createtime,
//                                                               lastmodify,
//                                                               lasttime,
//                                                               compid,
//                                                               account_date,
//                                                               dist_flag,
//                                                               VENDORNO,
//                                                                BUYER,
//                                                                DELIVERY_UNIT,
//                                                                DELIVERY_ADDR,
//                                                                DELIVERY_DATE,
//                                                                CONVEYANCE,
//                                                                CASHTYPE,
//                                                                NOTES
//                                                                )
//                                                            VALUES
//                                                              ('APE',
//                                                               '" + ls_billno + @"',
//                                                               " + _reqData_B2BList.SRCBUSNO + @",
//                                                               " + _reqData_B2BList.OBJBUSNO + @",
//                                                               0,
//                                                               0,
//                                                               0,
//                                                               0,
//                                                               0,
//                                                               0,
//                                                               168,
//                                                               sysdate,
//                                                               168,
//                                                               sysdate,
//                                                               " + ls_compid + @",
//                                                               sysdate,
//                                                               0,
//                                                               " + _reqData_B2BList.VENDORNO + @",
//                                                               " + _reqData_B2BList.BUYER + @",
//                                                               '" + _reqData_B2BList.DELIVERY_UNIT + @"',
//                                                               '" + _reqData_B2BList.DELIVERY_ADDR + @"',
//                                                               to_date('" + _reqData_B2BList.DELIVERY_DATE + @"','yyyy-MM-dd'),
//                                                               '" + _reqData_B2BList.CONVEYANCE + @"',
//                                                               null,
//                                                               '来自海川委托配送：" + _reqData_B2BList.NOTES + @"'
//                                                               )
//                                                            ");
//                        if (ls_retmsg != "TRUE")
//                        {
//                            #region 错误返回
//                            bll.dao.RollbackTrans();
//                            _retData_B2BList = new ObjectList.RetData_B2BList();
//                            _retData_B2BList.RETURNCODE = "0";
//                            _retData_B2BList.RETURNMSG = ls_retmsg;
//                            return js.Serialize(_retData_B2BList);
//                            #endregion
//                        }
//                        #endregion
//                        #region 插入委托配送申请明细
//                        for (int i = 0; i < _reqData_B2BList.PRODUCTLIST.Count; i++)
//                        {
//                            dt = bll.dao.GetDataTable("select 1 from t_ware where compid = " + ls_compid + @" and warecode = " + _reqData_B2BList.PRODUCTLIST[i].WAREID);
//                            if (dt.Rows.Count <= 0)
//                            {
//                                ls_retmsg = "无法识别的【货品id】";
//                                #region 错误返回
//                                bll.dao.RollbackTrans();
//                                _retData_B2BList = new ObjectList.RetData_B2BList();
//                                _retData_B2BList.RETURNCODE = "0";
//                                _retData_B2BList.RETURNMSG = ls_retmsg;
//                                return js.Serialize(_retData_B2BList);
//                                #endregion
//                            }

//                            dt = bll.dao.GetDataTable("select classcode from t_ware_class_base where classgroupno='03' and wareid=" + _reqData_B2BList.PRODUCTLIST[i].WAREID + " AND compid = (CASE WHEN EXISTS (SELECT 1 FROM t_ware_class_base twcb WHERE twcb.compid = " + ls_compid + " AND twcb.wareid = t_ware_class_base.wareid) THEN 103 ELSE 0 END)");
//                            if (dt.Rows.Count <= 0)
//                            {
//                                ls_retmsg = "未维护的剂型分类";
//                                #region 错误返回
//                                bll.dao.RollbackTrans();
//                                _retData_B2BList = new ObjectList.RetData_B2BList();
//                                _retData_B2BList.RETURNCODE = "-1";
//                                _retData_B2BList.RETURNMSG = ls_retmsg;
//                                return js.Serialize(_retData_B2BList);
//                                #endregion
//                            }
//                            ls_bandcode = dt.Rows[0][0].ToString();
//                            ls_retmsg = bll.dao.SqlDataTable(@"INSERT INTO t_distapply_d
//                                                          (applyno,
//                                                           wareid,
//                                                           safeqty,
//                                                           overqty,
//                                                           wareqty,
//                                                           storeqty,
//                                                           checkqty,
//                                                           salemonqty,
//                                                           purprice,
//                                                           saleprice,
//                                                           applyqty,
//                                                           distqty,
//                                                           parityflag,
//                                                           actualqty,
//                                                           saletax,
//                                                           bandcode,
//                                                           rowno,
//                                                           batid,
//                                                           stallno,
//                                                           bak1,
//                                                           batapplyqty,
//                                                           matureflag,
//                                                           notes)
//                                                        VALUES
//                                                          ('" + ls_billno + @"',
//                                                           " + _reqData_B2BList.PRODUCTLIST[i].WAREID + @",
//                                                           0,
//                                                           0,
//                                                           0,
//                                                           0,
//                                                           " + _reqData_B2BList.PRODUCTLIST[i].APPLYQTY + @",
//                                                           0,
//                                                           " + _reqData_B2BList.PRODUCTLIST[i].PURPRICE + @",
//                                                           0,
//                                                           " + _reqData_B2BList.PRODUCTLIST[i].APPLYQTY + @",
//                                                           0,
//                                                           0,
//                                                           0,
//                                                           13.00,
//                                                           '" + ls_bandcode + @"',
//                                                           " + _reqData_B2BList.PRODUCTLIST[i].ROWNO + @",
//                                                           0,
//                                                           'NONE',
//                                                           " + _reqData_B2BList.PRODUCTLIST[i].APPLYQTY + @",
//                                                           " + _reqData_B2BList.PRODUCTLIST[i].APPLYQTY + @",
//                                                           1,
//                                                           '" + _reqData_B2BList.PRODUCTLIST[i].NOTES + @"')
//                                                        ");
//                            if (ls_retmsg != "TRUE")
//                            {
//                                #region 错误返回
//                                bll.dao.RollbackTrans();
//                                _retData_B2BList = new ObjectList.RetData_B2BList();
//                                _retData_B2BList.RETURNCODE = "0";
//                                _retData_B2BList.RETURNMSG = ls_retmsg;
//                                return js.Serialize(_retData_B2BList);
//                                #endregion
//                            }
//                        }
//                        #endregion
//                        #region 返回
//                        if (ls_retmsg != "TRUE")
//                        {
//                            #region 错误返回
//                            bll.dao.RollbackTrans();
//                            _retData_B2BList = new ObjectList.RetData_B2BList();
//                            _retData_B2BList.RETURNCODE = "0";
//                            _retData_B2BList.RETURNMSG = ls_retmsg;
//                            return js.Serialize(_retData_B2BList);
//                            #endregion
//                        }
//                        else
//                        {
//                            #region 成功返回
//                            bll.dao.CommitTrans();
//                            _retData_B2BList = new ObjectList.RetData_B2BList();
//                            //_rproductList = new List<RProductList>();
//                            //_datalist = new List<ObjectList.Data>();
//                            //dt = bll.dao.GetDataTable(@"SELECT rowno erpOrderItemId,
//                            //                       f_get_warecode(wareid, " + ls_compid + @") productCode,
//                            //                       wareqty AS amount,
//                            //                       whlprice AS price,
//                            //                       wareqty * whlprice AS money,
//                            //                       0 AS promoMoney,
//                            //                       makeno AS batchnumber,
//                            //                       invalidate AS validDate,
//                            //                       NULL AS checkFile
//                            //                  FROM t_batsale_d where rownum < 3");
//                            //for (int i = 0; i < dt.Rows.Count; i++)
//                            //{
//                            //    _rproduct = new RProductList();
//                            //    _rproduct.BATID = dt.Rows[i]["erpOrderItemId"].ToString();
//                            //    _rproduct.DISTQTY = dt.Rows[i]["productCode"].ToString();
//                            //    _rproduct.INVALIDATE = dt.Rows[i]["amount"].ToString();
//                            //    _rproduct.MAKENO = dt.Rows[i]["price"].ToString();
//                            //    _rproduct.MONEY = dt.Rows[i]["money"].ToString();
//                            //    _rproduct.NOTES = dt.Rows[i]["promoMoney"].ToString();
//                            //    _rproduct.PRICE = dt.Rows[i]["batchNumber"].ToString();
//                            //    _rproduct.ROWNO = dt.Rows[i]["validDate"].ToString();
//                            //    _rproduct.WAREID = dt.Rows[i]["checkFile"].ToString();
//                            //    _rproductList.Add(_rproduct);
//                            //}
//                            _data = new ObjectList.Data();
//                            _datalist = new List<ObjectList.Data>();
//                            _data.APPLYNO = ls_billno;
//                            _data.APPDISTNO = null;
//                            //_data.PRODUCTLIST = null;
//                            _datalist.Add(_data);
//                            _retData_B2BList.RETURNCODE = "1";
//                            _retData_B2BList.RETURNMSG = "OK";
//                            _retData_B2BList.DATA = _datalist;
//                            return js.Serialize(_retData_B2BList);
//                            #endregion
//                        }
//                    #endregion
//                    case "/CancelOrder"://取消订单
//                        #region 数据验证
//                        jObject = JObject.Parse(ReqHeadJson);
//                        ls_billno = jObject["APPLYNO"].ToString();
//                        if (string.IsNullOrEmpty(ls_billno))
//                        {
//                            ls_retmsg = "【申请单号】不能为空";
//                            #region 错误返回
//                            bll.dao.RollbackTrans();
//                            _retData_B2BList = new ObjectList.RetData_B2BList();
//                            _retData_B2BList.RETURNCODE = "0";
//                            _retData_B2BList.RETURNMSG = ls_retmsg;
//                            return js.Serialize(_retData_B2BList);
//                            #endregion
//                        }
//                        #endregion
//                        #region 返回
//                        bll.dao.RollbackTrans();
//                        _retData_B2BList = new ObjectList.RetData_B2BList();
//                        _retData_B2BList.RETURNCODE = "0";
//                        _retData_B2BList.RETURNMSG = "此接口开发中......";
//                        return js.Serialize(_retData_B2BList);
//                    #endregion
//                    default:
//                        #region 异常返回
//                        bll.dao.RollbackTrans();
//                        _retData_B2BList = new ObjectList.RetData_B2BList();
//                        _retData_B2BList.RETURNCODE = "0";
//                        _retData_B2BList.RETURNMSG = "无法识别的功能地址";
//                        return js.Serialize(_retData_B2BList);
//                        #endregion
//                }
//            }
//            #endregion
//            catch (Exception ex)
//            {
//                #region 异常返回
//                bll.dao.RollbackTrans();
//                _retData_B2BList = new ObjectList.RetData_B2BList();
//                _retData_B2BList.RETURNCODE = "0";
//                _retData_B2BList.RETURNMSG = ex.Message.ToString();
//                return js.Serialize(_retData_B2BList);
//                #endregion
//            }
//        }
//    }
//}
