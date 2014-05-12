using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    /// <summary>
    /// 证件注册、挂靠（兼职）
    /// </summary>
    public class RequireCredential : InfoBase
    {
        public string Type { get; set; }   //所持证件类型
        public string Major { get; set; }    // 专业
        public string Class { get; set; }    // 证件类别
        public string Price { get; set; }       //价格
    }
}
