using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Pictures.Crud
{
    public class PictureCreateDao : CreateDao<Picture>
    {
        public PictureCreateDao()
        {
            Table = Db.Pictures;
        }
    }
}