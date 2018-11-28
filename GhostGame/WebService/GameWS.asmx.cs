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
       
        public GameWS()
        {          
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
        }
        

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void StartGame()
        {
            /* Como no dispongo de persistencia a datos, he tomado la decision de usar una clase estatica :(
             * Soy consciente de los problemas a la hora de realizar tests unitarios supone,
             * otras posibles soluciones serian mantener el objeto en memoria de con una variable de sesion o quizas
             * implementar una cookie con los datos o idas y venidas del cliente y servidor con los datos del estado
             * esta ultima junto con la de la cookie no me gustan nada */
            Game.NewGame();
            GameStatus gs = new GameStatus();
            gs.isGameOver = false;
            gs.currentWord = Game.GetCurrentWord();
            Context.Response.Write(js.Serialize(gs));
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void PlayerInput(string input)
        {
            if(input != string.Empty && input.Length == 1)
            {
                GameStatus gs = new GameStatus();
                gs.isGameOver = Game.PlayerInput(input);
                gs.humanScore = Game.human.GetCurrentScore();
                gs.cpuScore = Game.cpu.GetCurrentScore();
                gs.currentWord = Game.GetCurrentWord();
                Context.Response.Write(js.Serialize(gs));
            }
            
        }
       
      
        
    }
}
