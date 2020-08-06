namespace CleanCode2
{
    public interface IEmailMessageCreator
    {
        EmailMessage CreateEmailMessage(EmailManager emailData);
        EmailMessage CreateEmailMessage(EmailData emailData);
    }
}