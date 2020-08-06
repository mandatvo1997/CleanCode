using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w4
{
    class UserService
    {
        private readonly IMessagingService _messagingService;
        private readonly ILogger _logger;
        private readonly IRepository _repository;
        public UserService(ILogger logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public IUserViewModel GetUserInfo(string userName)
        {
            try
            {
                var user = _repository.GetUser(userName);
                if (user != null && user.IsActive)
                {
                    return new UserViewModel()
                    {
                        FirstName = user.FirstName,
                        Surname = user.Surname,
                        GroupName = user.Group.Name
                    };
                }
                return new NullUserViewModel();
            }catch (Exception ex)
            {
                throw new Exception(string.Format("An error occurred while trying to get user data from the database. UserName = {0}", userName), ex);
            }
        }
    }
}
