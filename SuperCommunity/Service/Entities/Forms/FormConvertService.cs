

using System.Collections.Generic;
using SuperCommunity.DAO.Forms.Crud;
using SuperCommunity.Models.PageModels;
using SuperCommunity.Service.Entities.Pictures.IO;

namespace SuperCommunity.Service.Entities.Forms
{
    public class FormConvertService : IService
    {
        public bool Convert(FormModel model, bool isValidModel, bool isNewObject)
        {
            model.Form.MyPhoto = new PicturePathService().CheckAndCutUrl(model.Form.MyPhoto);

            if (isValidModel)
            {
                if (isNewObject)
                {
                    new CreateFormDao().SaveObject(model.Form);
                }
                else
                {
                    new UpdateFormDao().UpdateAndAttachObject(model.Form);
                }
                return true;
            }

            // Устраняет странное исключение.
            // Оно возникает, когда на форму передается пустая
            // коллекция. Возвращается в контроллер невалидная
            // коллекция (при использовании хелпера Html.HiddenFor)
            if (model.PictureLinks == null)
            {
                model.PictureLinks = new List<string>();
            }

            return false;
        }
    }
}