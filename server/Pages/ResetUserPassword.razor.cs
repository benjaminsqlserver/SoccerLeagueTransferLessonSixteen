using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.Extensions.Configuration;

namespace SoccerLeagueTransferApp.Pages
{
    public partial class ResetUserPasswordComponent
    {
        //custom method to reset user password

        private async Task ResetUserPassword()
        {
            try
            {
                SoccerLeagueTransferApp.Models.ConData.User appUser = await ConData.MuyikGetUserByEmail(user.EmailAddress);

                if (appUser.UserID > 0)//this implies that user was found in the data store
                {
                    var toAddress = appUser.EmailAddress;
                    var emailTitle = "Password Reset Notification";
                    var newPassword = new Random(7).Next().ToString() + appUser.Username;//generating new password

                    await ConData.MuyikResetPassword(appUser.UserID, newPassword);//updating password in datastore


                    //generate email body

                    var emailBody = "Dear " + appUser.Username + ",\nThis is to inform you that we have received a request to reset your password. Your new password is " + newPassword + ".\nPlease go to the login page to login with this new password.Don't forget to change your password after logging in.";
                    var fromAddress = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("EmailSettings")["fromAddress"];
                    var smtpServerAddress = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("EmailSettings")["smtpServerAddress"];
                    var portNumber = Convert.ToInt32(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("EmailSettings")["smtpPortNumber"]);
                    var smtpUserName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("EmailSettings")["smtpUserName"];
                    var smtpPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("EmailSettings")["smtpPassword"];

                    //send password reset email

                    MuyikUtility.Email.SendEmail(toAddress, fromAddress, emailTitle, emailBody, smtpServerAddress, portNumber, smtpUserName, smtpPassword);


                    //notify user

                    NotificationService.Notify(NotificationSeverity.Success, "Password Reset Success!", "You Have successfully Reset Your Password.Please Check Your Inbox to get the new password", 5000);


                    //reset page

                    user = new Models.ConData.User();




                }
                else//user not found
                {
                    //notify user

                    NotificationService.Notify(NotificationSeverity.Error, "Email Address Error!", "No Soccer Transfer App User Was Found With That Email Address", 9000);

                    return;
                }
            }
            catch(Exception ex)
            {
                //notify user

                NotificationService.Notify(NotificationSeverity.Error, "Password Reset Error!", "Password Reset Error", 9000);
            }
            

        }
    }
}
