using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    /// <summary>
    /// 相关供求信息
    /// </summary>
    public class OtherInfo : InfoEntityBase
    {
        public string CompanyName { get; set; }    //企业或个人名称
        public string Content { set; get; }     //	供求内容
        public string Price { get; set; }       //价格
    }
}
