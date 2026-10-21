using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public partial class FormMain : Form
{
    private readonly SqliteRepository _repository;

    public FormMain()
    {
        InitializeComponent();

        _repository = new SqliteRepository("store.db");
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        dgvResults.AutoGenerateColumns = true;
        dgvResults.ReadOnly = true;
        dgvResults.AllowUserToAddRows = false;
    }

    private void btnCalcAggregates_Click(object sender, EventArgs e)
    {
        var onlineOrders = _repository.LoadOnlineOrders();

        int totalOrders = onlineOrders.Count();
        int expensiveOrders = onlineOrders.Count(x => x.Price * x.Quantity > 1000m);
        decimal totalRevenue = onlineOrders.Sum(x => x.Price * x.Quantity);
        decimal averagePositionPrice = onlineOrders.Average(x => x.Price);
        decimal minPrice = onlineOrders.Min(x => x.Price);
        decimal maxPrice = onlineOrders.Max(x => x.Price);

        lblCount.Text = $"Всего: {totalOrders} | > 1000: {expensiveOrders}";
        lblSum.Text = $"Выручка: {totalRevenue:C}";
        lblAvg.Text = $"Средняя цена: {averagePositionPrice:C}";
        lblMinMax.Text = $"Мин: {minPrice:C} | Макс: {maxPrice:C}";

        string categories = onlineOrders
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x)
            .Aggregate(
                "Категории: ",
                (current, next) => current + (current == "Категории: " ? "" : ", ") + next);

        lblAggregate.Text = categories;
    }

    private void btnExceptOnlineOnly_Click(object sender, EventArgs e)
    {
        var onlineOrders = _repository.LoadOnlineOrders();
        var storeOrders = _repository.LoadStoreOrders();

        var result = onlineOrders
            .Select(x => x.ProductName)
            .Except(storeOrders.Select(x => x.ProductName))
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        BindResult(result);
    }

    private void btnIntersectBoth_Click(object sender, EventArgs e)
    {
        var onlineOrders = _repository.LoadOnlineOrders();
        var storeOrders = _repository.LoadStoreOrders();

        var result = onlineOrders
            .Select(x => x.ProductName)
            .Intersect(storeOrders.Select(x => x.ProductName))
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        BindResult(result);
    }

    private void btnUnionAllUnique_Click(object sender, EventArgs e)
    {
        var onlineOrders = _repository.LoadOnlineOrders();
        var storeOrders = _repository.LoadStoreOrders();

        var result = onlineOrders
            .Select(x => x.ProductName)
            .Union(storeOrders.Select(x => x.ProductName))
            .OrderBy(x => x)
            .ToList();

        BindResult(result);
    }

    private void BindResult(List<string> products)
    {
        dgvResults.DataSource = products
            .Select(p => new { ProductName = p })
            .ToList();
    }
}