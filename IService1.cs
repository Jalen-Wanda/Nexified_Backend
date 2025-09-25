using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CampusService
{
    [ServiceContract]
    public interface IService1
    {
        // Existing methods (keep all your current ones)
        [OperationContract]
        Product GetProduct(int id);

        [OperationContract]
        User getUser(string password, string email);

        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        int Login(string email, string password);

        [OperationContract]
        int Register(User argUser);

        [OperationContract]
        int AddProduct(Product product);

        [OperationContract]
        Product GetProductByUserEmail(string email);

        [OperationContract]
        List<Product> SearchProducts(string searchTerm);

        [OperationContract]
        int UpdateProduct(Product product);

        [OperationContract]
        int PlaceBid(int productId, int userId, decimal bidAmount);

        // Reporting methods
        [OperationContract]
        int GetProductsSoldCount(DateTime startDate, DateTime endDate);

        [OperationContract]
        int GetTotalStockCount();

     
        [OperationContract]
        decimal GetTotalRevenue(DateTime startDate, DateTime endDate);

        [OperationContract]
        DataTable GetSalesByCategory(DateTime startDate, DateTime endDate);

        [OperationContract]
        DataTable GetLowStockProducts(int threshold);

        [OperationContract]
        DataTable GetStockByCategory();

        [OperationContract]
        int GetActiveUsersCount(DateTime startDate, DateTime endDate);

        [OperationContract]
        decimal GetTopSpenderAmount(DateTime startDate, DateTime endDate);

        [OperationContract]
        decimal GetAverageUserSpend(DateTime startDate, DateTime endDate);

        [OperationContract]
        int GetActiveAuctionsCount();

        [OperationContract]
        int GetCompletedAuctionsCount(DateTime startDate, DateTime endDate);

        [OperationContract]
        decimal GetAverageWinningBid(DateTime startDate, DateTime endDate);

        [OperationContract]
        double GetAuctionSuccessRate(DateTime startDate, DateTime endDate);

        [OperationContract]
        DataTable GetDailyRegistrationsReport(DateTime startDate, DateTime endDate);

        // Cart methods (these should work with your Cart table)
        [OperationContract]
        int AddToCart(int userId, int productId, int quantity);

        [OperationContract]
        List<Cart> GetUserCart(int userId);

        [OperationContract]
        int RemoveFromCart(int cartId);

        // Invoice methods (these work with your existing Invoice table)
        [OperationContract]
        int CreateInvoice(int userId, decimal totalAmount);

        [OperationContract]
        int AddInvoiceLine(int invoiceId, int productId, int quantity, decimal price);

        [OperationContract]
        List<Invoice> GetUserInvoices(int userId);

        // Admin methods
        [OperationContract]
        List<Product> GetProductsByUserId(int userId);

        [OperationContract]
        List<Product> GetProductsForApproval();

        [OperationContract]
        int ApproveProduct(int productId);

        [OperationContract]
        int RejectProduct(int productId);
        
        [OperationContract]
        List<Bid> GetBidHistory(int productId);

        [OperationContract]
        List<Bid> GetUserBids(int userId);

        [OperationContract]
        Bid GetWinningBid(int productId);

        [OperationContract]
        int CompleteAuction(int productId);
    }
}