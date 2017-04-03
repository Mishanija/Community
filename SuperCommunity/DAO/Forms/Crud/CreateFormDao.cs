using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Forms.Crud
{
    public class CreateFormDao : CreateDao<Form>
    {
        public CreateFormDao()
        {
            Table = Db.Forms;
        }
    }
}