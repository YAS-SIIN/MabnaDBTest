// See https://aka.ms/new-console-template for more information


using MabnaDBTest.CLI;

Console.WriteLine("Please write number of row that you want to insert : ");
int insertCount = Convert.ToInt32(Console.Read());
 
TradeData tradeData = new TradeData();
tradeData.InsertRandom(insertCount);