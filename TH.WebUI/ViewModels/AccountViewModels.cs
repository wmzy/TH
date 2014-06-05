using System;
using System.ComponentModel.DataAnnotations;

namespace TH.WebUI.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "E-mail 地址")]
        [EmailAddress]
        public string Email { get; set; }
    }
    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "E-mail 地址")]
        [EmailAddress]
        public string Email { get; set; }

    }

    public class PasswordResetViewModel
    {
        [Required]
        [Display(Name = "Token")]
        public string Token { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }


        public string UserId { get; set; }
    }

    public class UserInfoViewModel
    {
        [Display(Name = "姓名")]
        public string RealName { get; set; }
        [Display(Name = "QQ号码")]
        public string QQ { get; set; }
        [Display(Name = "电话号")]
        public string Phone { get; set; }
        [Display(Name = "手机号")]
        public string MobilePhone { get; set; }
        [Required]
        [Display(Name = "E-mail 地址")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "住址")]
        public string Address { get; set; }
        [Display(Name = "城市")]
        public string City { get; set; }
        [Display(Name = "生日")]
        public DateTime? Birthday { get; set; }
        [Display(Name = "性别")]
        public string Sex { get; set; }
        [Display(Name = "个人简介")]
        public string AboutMe { get; set; }
    }
    public class RechargeViewModel
    {
        [Required]
        [Display(Name = "购买财富值量")]
        public int WealthValue { get; set; }
    }
}
