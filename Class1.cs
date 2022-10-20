namespace LR_1
{
using System;
using System.Collections.Generic;
class Class1 {
  public static void Main (string[] args) {
    GameAccount user1=new GameAccount("Rita");
    GameAccount user2=new GameAccount("Duck");
    user1win(user1, user2, 2);
    user2win(user1, user2, 4);
    user1win(user1, user2, 6);
    user2win(user1, user2, 1);
    user1win(user1, user2, 2);
    user2win(user1, user2, 8);
    user1.GetStats();
    user2.GetStats();
  }
  public static void user1win(GameAccount user1, GameAccount user2, int rating)
  {
    user1.WinGame(rating,user2.UserName);
    user2.LoseGame(rating,user1.UserName);
  }
  public static void user2win(GameAccount user1, GameAccount user2, int rating)
  {
    user2.WinGame(rating,user1.UserName);
    user1.LoseGame(rating,user2.UserName);
  }
}

class GameAccount
{
  public string UserName{get; set;}
  public int Rating{get; set;}
  public int GamesCount{get; set; }
  private List<Game> AllGames= new List<Game>();
  public GameAccount(string name)
  {
    UserName=name;
    Rating=15;
    GamesCount=0;
  }
  public void Info()
  {
    Console.WriteLine (UserName+"`s info: ");
    Console.WriteLine ("Name "+ UserName+"\n Rating "+Rating+"\n Games count "+GamesCount);
  }
  public void WinGame(int rat, string name)
  {
    if(rat>=0)
    {
      int rating2=Rating+rat;
      Game game=new Game(name,GamesCount+1,"Win", Rating, rating2,rat);
      Rating+=rat;
      GamesCount++;
      AllGames.Add(game);
    }
    else Console.WriteLine ("Error. Rating can`t be less than 0.");
    
  }
  public void LoseGame(int rat, string name)
  {
    int rating2;
    if(rat>=0)
    {
      if(Rating-rat>=1) rating2=Rating-rat;
      else rating2=1;
      Game game=new Game(name,GamesCount+1,"Lose", Rating, rating2,rat);
      if(Rating-rat>=1) Rating-=rat;
      else Rating=1;
      GamesCount++;
      AllGames.Add(game);
    }
    else Console.WriteLine ("Error. Rating can`t be less than 0.");
  }
  public void GetStats()
  {
    Console.WriteLine (UserName+"`s game statistics: ");
    Console.WriteLine ("Id|Against whom|Rating1|Rating 2|Rating playing for|Result");
    for(int i=0;i<AllGames.Count;i++)
    {
      Console.WriteLine (AllGames[i].id+" | "+AllGames[i].player2+      "       | " +AllGames[i].rating1+"    | "+AllGames[i].rating2+"     | "+AllGames[i].ratingpf+"                | "+AllGames[i].res);
    }
      
  }
}
class Game
{
  public string player2{get;}
  public int rating1{get;}
  public int rating2{get;}
  public int ratingpf{get; }
  public int id{get;}
  public string res{get;}
  public Game(string name, int Id, string Res,int rat1,int rat2,int rat)
  {
    player2=name;
    rating1=rat1;
    rating2=rat2;
    id=Id;
    res=Res;
    ratingpf=rat;
  }
}

}