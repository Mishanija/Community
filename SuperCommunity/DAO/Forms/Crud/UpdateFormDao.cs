using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Forms.Crud
{
    public class UpdateFormDao : UpdateDao<Form>
    {
        public UpdateFormDao()
        {
            Table = Db.Forms;
        }
    }
}