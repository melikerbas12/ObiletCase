using ObiletCase.Core.Models;

namespace ObiletCase.Business.Utilities
{
    public interface IGenerateRequestBaseModel<T>
    {
         public RequestBaseModel<T> GetRequestBaseModel(T? data);
    }
}