using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Forms.Crud
{
    public class FormDeleteDao : DeleteDao<Form>
    {
        public FormDeleteDao()
        {
            Table = Db.Forms;
        }
    }
}