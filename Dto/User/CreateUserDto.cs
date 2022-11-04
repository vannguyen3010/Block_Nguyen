using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyBlog.Dto.User;

public class CreateUserDto
{
    [Required(ErrorMessage="DisplayName khong the bo trong")]
    
    public String DisplayName{get;set;}

    [Required(ErrorMessage="Email khong the bo trong")]
    [EmailAddress(ErrorMessage="Email khong hop le")]
    public String Email{get;set;}

    [Required(ErrorMessage="Phone khong the bo trong")]
    public String Phone{get;set;}
    public DateTime DateOfBirth{get;set;}


    public String Address{get;set;}

}