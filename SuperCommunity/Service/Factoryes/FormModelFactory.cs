using SuperCommunity.DAO.Other;
using SuperCommunity.Models.Membership;
using SuperCommunity.Models.PageModels;

namespace SuperCommunity.Service.Factoryes
{
    public class FormModelFactory : ModelFactory<FormModel>
    {
        private readonly Form _form;

        public FormModelFactory(Form form)
        {
            _form = form;
        }

        public override FormModel BuildModel()
        {
            return new FormModel
            {
                Form = _form,
                PictureLinks = new UserPictureDao().GetAllPicturesUrls(_form.UserId)
            };
        }
    }
}