namespace ShopStoreApi.Errors;

public class Exceptionhandler:ApiResponse
{
    public Exceptionhandler(int statuseCode, string message = null ,string dtails=null) : base(statuseCode, message)
    {
        Dtails = dtails;
    }

    public string Dtails { get; set; }
}