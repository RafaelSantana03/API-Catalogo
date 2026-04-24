namespace APICatalogo.Pagination;

public class ProdutosParameters
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; } = 1;
    private int pageSize;

    public int PageSize
    {
        get { return pageSize; }
        set { pageSize = (value > maxPageSize) ? maxPageSize : value; } // se o valor for maior que o maximo, atribui o maximo, caso contrario atribui o valor passado
    }
}

