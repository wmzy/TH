namespace TH.Model
{
    /// <summary>
    /// 工程企业或个人承揽工程信息
    /// </summary>
    public class ContractProject : InfoBase
    {
        public string Company { set; get; }     // 企业或经营个体
        public string Content { set; get; }     //承揽工程内容
        public string Introduction { set; get; }//企业或个人简介	
        public int ConstructionExperience { set; get; } //施工经验	
        public string Performance { set; get; }     //以往业绩
    }
}
