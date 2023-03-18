# EmailService-MSGraphApi
To send an email using Microsoft Graph API with a Service Principal in .NET, follow these steps:

First, you need to register your application in Azure Active Directory to get a client ID, client secret, and tenant ID. This can be done by following this tutorial: https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app
Next, you need to give your application permission to send email on behalf of users in your tenant. You can do this by granting the application the Mail.Send permission. You can do this by following this tutorial: https://docs.microsoft.com/en-us/graph/auth-v2-service#2-get-a-token
Once you have registered your application and granted it the necessary permissions, you can use the Microsoft Graph API to send emails. 
