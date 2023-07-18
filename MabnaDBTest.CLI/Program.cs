// See https://aka.ms/new-console-template for more information


using MabnaDBTest.CLI;

Console.Write("Please write number of row that you want to insert : ");
var numberOfInsertCount = Console.ReadKey();

int insertCount = Convert.ToInt32(numberOfInsertCount.KeyChar.ToString());
 
TradeData tradeData = new TradeData();
tradeData.InsertRandom(insertCount);