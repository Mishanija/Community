using SuperCommunity.DAO.User.Crud;

namespace SuperCommunity.Service.Entities.Account
{
    public class AccountConfirmationService : IService
    {
        private readonly UpdateUserDao _updateDao = new UpdateUserDao();

        public void DeleteConfirmationToken(string confirmationToken)
        {
            var user = _updateDao.FindUserByConfirmationToken(confirmationToken);

            user.ConfirmationToken = null;

            _updateDao.UpdateObject(user);
        }
    }
}