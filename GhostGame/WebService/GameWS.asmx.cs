using GhostGame.Src;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace GhostGame.WebService
{
    /// <summary>
    /// Descripción breve de GameWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class GameWS : System.Web.Services.WebService
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        GameStatus gs = new GameStatus();
        public GameWS()
        {          
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
        }
        

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void StartGame()
        {
            Game.NewGame();
            gs.isGameOver = false;
            gs.currentWord = Game.GetCurrentWord();
            Context.Response.Write(js.Serialize(gs));
        }
        
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void PlayerInput(string input)
        {

            gs.isGameOver = Game.PlayerInput(input);
            gs.humanScore = Game.human.GetCurrentScore();
            gs.cpuScore = Game.cpu.GetCurrentScore();
            gs.currentWord = Game.GetCurrentWord();
            Context.Response.Write(js.Serialize(gs));
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetGameSatus()
        {

            gs.humanScore = Game.human.GetCurrentScore();
            gs.cpuScore = Game.cpu.GetCurrentScore();
            gs.currentWord = Game.GetCurrentWord();
            Context.Response.Write(js.Serialize(gs));
        }
      
        
    }
}
