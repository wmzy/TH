using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    /// <summary>
    /// 融资、贷款
    /// </summary>
    public class Financing : InfoBase
    {
        public string CompanyName { get; set; }    //企业名称
        public string Range { get; set; }       //	融资范围
        public string Condition { get; set; }   // 贷款条件
        public string Quota { get; set; }       //贷款额度
        public string Interest { get; set; }    // 利息
    }
}
