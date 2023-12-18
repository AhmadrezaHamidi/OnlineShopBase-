using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Exceptions
{
    public enum ExceptionCode
    {
        [Display(Name = "SystemException", Description = "System exception.")]
        SystemException = 98,
        [Display(Name = "UserNotFound", Description = "User unauthorized or not found.")]
        UserNotFound,
        [Display(Name = "UsernameOrPasswordIncorrect", Description = "Username or password is incorrect.")]
        UsernameOrPasswordIncorrect,
        [Display(Name = "ValidationException", Description = "Validation exception.")]
        ValidationException,
        [Display(Name = "EntityNotFoundException", Description = "Entity not found.")]
        EntityNotFound,
        [Display(Name = "EntityExistsException", Description = "Entity exists with this parameters.")]
        EntityExists,
        [Display(Name = "InvalidDateException", Description = "Date is not valid.")]
        InvalidDate,
        [Display(Name = "ArgumentNullException", Description = "Argument is null.")]
        ArgumentNull,
        [Display(Name = "HttpMethodCallError", Description = "Http method call has error.")]
        HttpMethodCallError,
        [Display(Name = "CustomerRegisterResponseNotFound", Description = "Customer register response not found or has error.")]
        CustomerRegisterResponseNotFound
    }
}
