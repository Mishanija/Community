using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Pictures.Crud
{
    public class PictureUpdateDao : UpdateDao<Picture>
    {
        public PictureUpdateDao()
        {
            Table = Db.Pictures;
        }
    }
}