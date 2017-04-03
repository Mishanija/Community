using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Forms.Crud
{
    public class FindFormDao : FindDao<Form>
    {
        public FindFormDao()
        {
            Table = Db.Forms;
        }

        public override Form GetObjectById(int id)
        {
            return (from form in Table where form.FormId == id select form).First();
        }

        public Form GetFormByUserId(int id)
        {
            return (from form in Table where form.UserId == id select form).FirstOrDefault();
        }
    }
}