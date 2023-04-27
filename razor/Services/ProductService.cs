using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

/// <summary>
/// 
/// </summary>
public class Product
{
    public Product()
    {

    }
    /// <summary>
    /// Gets or Sets ProductId
    /// </summary>
    // [DataMember(Name = "productId", EmitDefaultValue = false)]
    [JsonPropertyName("productId")]
    public int? ProductId { get; set; }

    /// <summary>
    /// Gets or Sets ProductName
    /// </summary>
    // [DataMember(Name = "productName", EmitDefaultValue = false)]
    [JsonPropertyName("productName")]
    public string ProductName { get; set; }

    /// <summary>
    /// Gets or Sets SupplierId
    /// </summary>
    // [DataMember(Name = "supplierId", EmitDefaultValue = false)]
    [JsonPropertyName("supplierId")]
    public int? SupplierId { get; set; }

    /// <summary>
    /// Gets or Sets CategoryId
    /// </summary>
    // [DataMember(Name = "categoryId", EmitDefaultValue = false)]
    [JsonPropertyName("categoryId")]
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or Sets QuantityPerUnit
    /// </summary>
    // [DataMember(Name = "quantityPerUnit", EmitDefaultValue = false)]
    [JsonPropertyName("quantityPerUnit")]
    public string QuantityPerUnit { get; set; }

    /// <summary>
    /// Gets or Sets UnitPrice
    /// </summary>
    // [DataMember(Name = "unitPrice", EmitDefaultValue = false)]
    [JsonPropertyName("unitPrice")]
    public double? UnitPrice { get; set; }

    /// <summary>
    /// Gets or Sets UnitsInStock
    /// </summary>
    // [DataMember(Name = "unitsInStock", EmitDefaultValue = false)]
    [JsonPropertyName("unitsInStock")]
    public int? UnitsInStock { get; set; }

    /// <summary>
    /// Gets or Sets UnitsOnOrder
    /// </summary>
    // [DataMember(Name = "unitsOnOrder", EmitDefaultValue = false)]
    [JsonPropertyName("unitsOnOrder")]
    public int? UnitsOnOrder { get; set; }

    /// <summary>
    /// Gets or Sets ReorderLevel
    /// </summary>
    // [DataMember(Name = "reorderLevel", EmitDefaultValue = false)]
    [JsonPropertyName("reorderLevel")]
    public int? ReorderLevel { get; set; }

    /// <summary>
    /// Gets or Sets Discontinued
    /// </summary>
    // [DataMember(Name = "discontinued", EmitDefaultValue = false)]
    [JsonPropertyName("discontinued")]
    public bool? Discontinued { get; set; }
}



public class ProductService
{
    public HttpClient Client { get; }

    public ProductService(HttpClient client)
    {
        client.BaseAddress = new Uri("http://localhost:5056");
        // GitHub API versioning
        client.DefaultRequestHeaders.Add("Accept",
            "application/vnd.github.v3+json");
        // GitHub requires a user-agent
        client.DefaultRequestHeaders.Add("User-Agent",
            "HttpClientFactory-Sample");
        Client = client;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var response = await Client.GetAsync("/Products");
        using var responseStream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(responseStream);
    }
}