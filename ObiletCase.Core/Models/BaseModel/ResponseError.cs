namespace ObiletCase.Core.Models
{
    public class  ResponseError
    {
      public int StatusCode { get; set; }
      public string RequestUrl { get; set; }
      public string ErrorMessage { get; set; }
    }
}
