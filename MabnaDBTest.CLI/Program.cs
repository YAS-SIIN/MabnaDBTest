// See https://aka.ms/new-console-template for more information


using MabnaDBTest.CLI;

Console.Write("Please write number of row that you want to insert : ");
var aa = Console.Read();
int insertCount = Convert.ToInt32(aa);
 
TradeData tradeData = new TradeData();
tradeData.InsertRandom(insertCount);