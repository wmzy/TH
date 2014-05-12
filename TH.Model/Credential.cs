using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    /// <summary>
    /// 聘用证件持有人（兼职）
    /// </summary>
    public class Credential : InfoBase
    {
        public string CompanyName { get; set; }    //企业名称
        public string Type { get; set; }   //所需证件类型
        public string Major { get; set; }    // 专业
        public string Class { get; set; }    // 证件类别
        public string Price { get; set; }       //价格
    }
}
