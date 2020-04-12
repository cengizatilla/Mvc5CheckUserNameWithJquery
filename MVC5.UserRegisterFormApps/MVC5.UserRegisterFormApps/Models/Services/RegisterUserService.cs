using MVC5.UserRegisterFormApps.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.UserRegisterFormApps.Models.Services
{
    public class RegisterUserService : IDisposable
    {
        Context.Mvc5UserRegisterEntities context;
        public RegisterUserService()
        {
            context = new Context.Mvc5UserRegisterEntities();
        }

        public outputResult<RegisterUser> addNewUser(RegisterUser userData)
        {
            try
            {
                if (userData == null)
                    return new outputResult<RegisterUser>() { isSuccess = false, message = "Nesne null olarak geldi" };
                if (string.IsNullOrEmpty(userData.name) || string.IsNullOrEmpty(userData.lastName) || string.IsNullOrEmpty(userData.emailAddress))
                    return new outputResult<RegisterUser>() { isSuccess = false, message = "Form alanlarını eksiksiz olarak doldurunuz" };

                context.registeredUsers.Add(new Context.registeredUser()
                {
                    ID = userData.ID,
                    name = userData.name,
                    lastName = userData.lastName,
                    password = userData.password,
                    emailAddress = userData.emailAddress,
                    isActive = userData.isActive,
                    activationCode = userData.activationCode,
                    createdDate = userData.createdDate
                });

                return context.SaveChanges() > 0 ? new outputResult<RegisterUser>() { isSuccess = true, message = "Kayıt başarılı", dataItem = userData } : new outputResult<RegisterUser>() { isSuccess = false, message = "Kayıt işleminde hata" };
            }
            catch (Exception ex)
            {
                return new outputResult<RegisterUser>() { isSuccess = false, message = ex.Message };
            }
        }

        public outputResult<RegisterUser> checkEmailAddres(string emailAddress)
        {
            var userData = context.registeredUsers.SingleOrDefault(i => i.emailAddress == emailAddress);
            return userData == null ? new outputResult<RegisterUser>() { isSuccess = true, dataItem = null } : new outputResult<RegisterUser>() { isSuccess = false, message = "Email adresi sistem içerisinde kayıtlı ", dataItem = new RegisterUser() { ID = userData.ID, name = userData.name, emailAddress = userData.emailAddress } };
        }

        public outputResultList<RegisterUser> getDataList()
        {
            return new outputResultList<RegisterUser>()
            {
                isSuccess = true,
                dataList = (from I in context.registeredUsers
                            select new RegisterUser()
                            {
                                ID = I.ID,
                                name = I.name,
                                lastName = I.lastName,
                                emailAddress = I.emailAddress,
                                password = I.password,
                                activationCode = I.activationCode,
                                createdDate = I.createdDate.Value,
                                isActive = I.isActive.Value
                            }).ToList()
            };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}