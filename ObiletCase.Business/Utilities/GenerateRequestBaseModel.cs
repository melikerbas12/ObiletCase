using ObiletCase.Core.Models;

namespace ObiletCase.Business.Utilities
{
    public class GenerateRequestBaseModel<T> : IGenerateRequestBaseModel<T?>
    {
        public RequestBaseModel<T> GetRequestBaseModel(T? data)
        {
            return new RequestBaseModel<T>()
            {
                Data = data!,
                Date = DateTime.Now,
                Language = "tr-TR"
            };
        }
    }
}