using System;
using System.Collections.Generic;

public class Product
{
    
    private string _name;
    private int _productId;
    private decimal _price;
    private int _quantity;

    
    public Product(string name, int productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    
    public string GetName() => _name;
    public int GetProductId() => _productId;
    public decimal GetPrice() => _price;
    public int GetQuantity() => _quantity;

    
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}

public class Address
{
    
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    
    public bool IsInUSA()
    {
        return _country.ToUpper() == "USA";
    }

    
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}

public class Customer
{
    
    private string _name;
    private Address _address;

    
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    
    public string GetName() => _name;
    public Address GetAddress() => _address;

    
    public bool IsFromUSA()
    {
        return _address.IsInUSA();
    }
}

public class Order
{
    
    private List<Product> _products;
    private Customer _customer;
    private const decimal DomesticShippingCost = 5.00m;
    private const decimal InternationalShippingCost = 35.00m;

    
    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
    public decimal CalculateTotalPrice()
    {
        decimal totalProductCost = 0;

        foreach (var product in _products)
        {
            totalProductCost += product.GetTotalCost();
        }

        decimal shippingCost = _customer.IsFromUSA() ? DomesticShippingCost : InternationalShippingCost;

        return totalProductCost + shippingCost;
    }

    
    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in _products)
        {
            packingLabel += $"{product.GetName()}, Product ID: {product.GetProductId()}\n";
        }
        return packingLabel;
    }

    
    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"{_customer.GetName()}\n";
        shippingLabel += _customer.GetAddress().GetFullAddress();
        return shippingLabel;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        var address1 = new Address("123 Main St", "New York", "NY", "USA");
        var address2 = new Address("456 Elm St", "Vancouver", "BC", "Canada");

        
        var customer1 = new Customer("John Doe", address1);
        var customer2 = new Customer("Jane Smith", address2);

        
        var product1 = new Product("Laptop", 101, 899.99m, 1);
        var product2 = new Product("Mouse", 102, 19.99m, 2);
        var product3 = new Product("Keyboard", 103, 49.99m, 1);
        var product4 = new Product("Monitor", 104, 199.99m, 1);

        
        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalPrice():F2}\n");
    }
}
