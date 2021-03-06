using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresOrders.Models;
using System.Collections.Generic;
using System;

namespace PierresOrders.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreateInstanceOfOrder_Order()
    {
      Order newOrder = new Order("Title", "Description", 4, 211217);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    
    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newOrder = new List<Order> { };

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newOrder, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrderDetails_OrderList()
    {
      string title1 = "Order1";
      string title2 = "Order2";
      Order newOrder1 = new Order(title1, "Description", 4, 211217);
      Order newOrder2 = new Order(title2, "Description", 4, 211217);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_OrdersAreAssignedAnId_Int()
    {
      string title = "Order#1";
      Order newOrder = new Order(title, "Description", 4, 211217);
      
      int result = newOrder.Id;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      Order newOrder1 = new Order("Title", "Description", 4, 211217);
      Order newOrder2 = new Order("Title", "Description", 4, 211217);

      Order result = Order.Find(2);

      Assert.AreEqual(newOrder2, result);
    }
  }
}