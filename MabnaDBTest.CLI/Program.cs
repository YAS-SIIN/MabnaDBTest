// See https://aka.ms/new-console-template for more information


using MabnaDBTest.CLI;

Console.WriteLine("Please write number of row");
//int a = Convert.ToInt32(Console.ReadLine());
 
TradeData tradeData = new TradeData();
tradeData.InsertRandom();