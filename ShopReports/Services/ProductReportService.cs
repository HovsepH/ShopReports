using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services;

public class ProductReportService
{
    private readonly ShopContext shopContext;

    public ProductReportService(ShopContext shopContext)
    {
        this.shopContext = shopContext;
    }

    public ProductCategoryReport GetProductCategoryReport()
    {
        var categories = this.shopContext.Categories
            .Select(c => new ProductCategoryReportLine()
            {
                CategoryName = c.Name,
                CategoryId = c.Id,
            })
            .OrderByDescending(c => c.CategoryName)
            .ToList();

        return new ProductCategoryReport(categories, DateTime.Now);
    }

    public ProductReport GetProductReport()
    {
        var products = this.shopContext.Products
            .Select(p => new ProductReportLine()
            {
                Price = p.UnitPrice,
                Manufacturer = p.Manufacturer.Name,
                ProductTitle = p.Title.Title,
                ProductId = p.TitleId,
            })
            .OrderByDescending(p => p.ProductTitle).ToList();

        return new ProductReport(products, DateTime.Now);
    }

    public FullProductReport GetFullProductReport()
    {
        var products = this.shopContext.Products
            .Select(p => new FullProductReportLine()
            {
                Price = p.UnitPrice,
                Manufacturer = p.Manufacturer.Name,
                Category = p.Title.Category.Name,
                CategoryId = p.Title.CategoryId,
                Name = p.Title.Title,
                ProductId = p.TitleId,
            })
            .OrderBy(p => p.Name).ToList();

        return new FullProductReport(products, DateTime.Now);
    }

#pragma warning disable
    public ProductTitleSalesRevenueReport GetProductTitleSalesRevenueReport()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    protected virtual void Dispose(bool disposing)
    {
        throw new NotImplementedException();
    }
}



