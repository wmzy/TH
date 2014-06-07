namespace TH.Model
{
    public class JobHunting : InfoBase
    {
        public string Name { get; set; }//姓名	
        public string Nation { get; set; }//民族	
        public int? Age { get; set; }    //年龄	
        public string WorkYears { get; set; }    //工作年限	
        public string Education { get; set; }    //学历	
        public string WorkExperience { get; set; }    //工作经验	
        public string Job { get; set; }    //求职岗位	
        public string Wage { get; set; }    //薪资要求	
        public string Introduction { get; set; }    //个人简介
    }
}
