using Microsoft.AspNetCore.Identity.UI.Services;

namespace Travel_Agency_Project.Utility {
    public class EmailService : IEmailSender {
        public Task SendEmailAsync ( string email, string subject, string htmlMessage ) {
            
            // Logic of Email Not Completed
            
            return Task.CompletedTask;  
        }
    }
}
