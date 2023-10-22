namespace ShopStoreApi.Errors;

public class ApiResponse
{
    public ApiResponse(int statuseCode, string message)
    {
        StatuseCode = statuseCode;
        Message = message ?? GetStatusecodeMeaasge(statuseCode);
    }

    private string? GetStatusecodeMeaasge(int statuseCode)
    {
        return statuseCode switch
        {
            400 => "a bad request, you have made",
            401=>"Authorized,you are no!",
            404=>" refrence found it was not!",
            500=>"your sever  is dead",
            _=>null
        };
    }

    public int StatuseCode { get; set; }
    public String Message { get; set; }
}