﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode2
{
    public class EmailManager
    {
        private readonly IDatabaseManager _databaseManager;
        private readonly IEmailMessageCreator _emailMessageCreator;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public EmailManager(IDatabaseManager databaseManager, IEmailMessageCreator emailMessageCreator, IEmailSender emailSender, ILogger logger)
        {
            _databaseManager = databaseManager;
            _emailMessageCreator = emailMessageCreator;
            _emailSender = emailSender;
            _logger = logger;
        }
        public bool SendEmail(int emailId)
        {
            if (emailId <= 0)
            {
                _logger.Error("Incorrect emailId: " + emailId);
                return false;
            }
            EmailData emailData = _databaseManager.GetEmailData(emailId);
            if (emailData == null)
            {
                _logger.Error("Email data is null (emailId: " + emailId + ")");
                return false;
            }
            EmailMessage emailMessage = _emailMessageCreator.CreateEmailMessage(emailData);
            if (!ValidateEmailMessage(emailMessage))
            {
                _logger.Error("Email message is not valid (emailId: " + emailId + ")");
                return false;
            }
            try
            {
                _emailSender.SendEmail(emailMessage);
                _logger.Info("Email was sent!"); }
            catch (Exception ex)
            {
                _logger.Exception(ex.ToString());
                return false;
            }
            return true;
        }
        private bool ValidateEmailMessage(EmailMessage emailMessage)
        {
            if (emailMessage == null)
                return false;
            if (string.IsNullOrEmpty(emailMessage.From) || string.IsNullOrEmpty(emailMessage.To) || string.IsNullOrEmpty(emailMessage.Subject) || string.IsNullOrEmpty(emailMessage.Body))
                return false;
            if (emailMessage.Subject.Length > 255)
                return false;
            return true;
        }
    }
}
