using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Request;

namespace SuperCommunity.Service.Entities.Forms.Request
{
    public class FormRequestService : RequestService<Form>
    {
        public override bool IsBadRequest(Form form, string userName)
        {
            return form == null || !new Security().CheckUser(form.UserId, userName);
        }
    }
}