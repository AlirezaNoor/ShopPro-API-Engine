using Core.Entity;

public class product : BaseEntity
{
    public string name { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }
    public int producttypeid { get; set; }
    public int productbrandid { get; set; }
    public string pictureurl { get; set; }
    public ProductBrand productbrand { get; set; }
    public ProductType producttype { get; set; }
}