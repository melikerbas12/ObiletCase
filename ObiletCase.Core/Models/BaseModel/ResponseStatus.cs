using System.ComponentModel;

namespace ObiletCase.Core.Models
{
    public enum  ResponseStatus
    {
        [Description("Success")]
        Success,
       
        [Description("InvalidDepartureDate")]
        InvalidDepartureDate, 
       
        [Description("InvalidRoute")]
        InvalidRoute, 
      
        [Description("InvalidLocation")]
        InvalidLocation, 
       
        [Description("Timeout")]
        Timeout,
    }
}
